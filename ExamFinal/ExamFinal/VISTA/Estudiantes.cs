using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ExamFinal
{
    public partial class Estudiantes : Form
    {
        EntidadEstudiante entidadEstudiante = new EntidadEstudiante();
        ControladorEstudiante controladorEstudiante = new ControladorEstudiante();
        Modelo mod = new Modelo();
        public Estudiantes()
        {
            InitializeComponent();
        }

        private void Estudiantes_Load(object sender, EventArgs e)
        {
            cargarGrid();
            cargarCombo();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtIdEstudiante.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtDireccion.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtEdad.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                cbIdMateria.SelectedValue = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = controladorEstudiante.Search(Convert.ToInt16(txtIdEstudiante.Text));
            txtNombre.Text = dt.Rows[0][1].ToString();
            txtApellido.Text = dt.Rows[0][2].ToString();
            txtDireccion.Text = dt.Rows[0][3].ToString();
            txtEdad.Text = dt.Rows[0][4].ToString();
            int index = Convert.ToInt16(dt.Rows[0][5].ToString());
            cbIdMateria.SelectedIndex = index;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            controladorEstudiante.Insert(entidadEstudiante);
            cargarGrid();
            limpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            controladorEstudiante.Modify(entidadEstudiante);
            cargarGrid();
            limpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            controladorEstudiante.Delete(Convert.ToInt16(txtIdEstudiante.Text));
            cargarGrid();
            limpiarCampos();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void cargarEntidad()
        {
            entidadEstudiante.Id_estudiante = Convert.ToInt16(txtIdEstudiante.Text);
            entidadEstudiante.Nombre = txtNombre.Text;
            entidadEstudiante.Apellido = txtApellido.Text;
            entidadEstudiante.Direccion = txtDireccion.Text;
            entidadEstudiante.Edad = Convert.ToInt16(txtEdad.Text);
            entidadEstudiante.Id_materia = Convert.ToInt16(cbIdMateria.SelectedValue);
        }

        private void limpiarCampos()
        {
            txtIdEstudiante.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtEdad.Text = "";
            cbIdMateria.SelectedIndex = 0;
        }

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorEstudiante.Read();
        }

        private void cargarCombo()
        {


            string conexion = "Data Source=localhost; Initial Catalog=bd_colegio; Integrated Security=True;";
            SqlConnection sqlConn = new SqlConnection(conexion);
            sqlConn.Open();
            SqlCommand sqlCmd = new SqlCommand();
            SqlDataAdapter sqlDA;
            DataTable dt = new DataTable();
            string sql;

            sql = "select " + "id_materia," + "nombre" + " from " +
            "materia";
            sqlDA = new SqlDataAdapter(sql, sqlConn);
            sqlDA.Fill(dt);
            sqlConn.Close();
            cbIdMateria.DataSource = dt;
            cbIdMateria.DisplayMember = "nombre";
            cbIdMateria.ValueMember = "id_materia";
            cbIdMateria.SelectedIndex = 0;
        }

    }
}

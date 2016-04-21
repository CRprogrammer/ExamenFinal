using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ExamFinal
{
    public partial class Materias : Form
    {
        EntidadMateria entidadMateria = new EntidadMateria();
        ControladorMateria controladorMateria = new ControladorMateria();
        Modelo mod = new Modelo();
        public Materias()
        {
            InitializeComponent();
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            cargarGrid();
            cargarCombo();

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtIdMateria.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                cbIdProfesor.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = controladorMateria.Search(Convert.ToInt16(txtIdMateria.Text));
            txtNombre.Text = dt.Rows[0][1].ToString();
            int index = Convert.ToInt16(dt.Rows[0][2].ToString());
            cbIdProfesor.SelectedIndex = index;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            controladorMateria.Insert(entidadMateria);
            cargarGrid();
            limpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            controladorMateria.Modify(entidadMateria);
            cargarGrid();
            limpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            controladorMateria.Delete(Convert.ToInt16(txtIdMateria.Text));
            cargarGrid();
            limpiarCampos();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void cargarEntidad()
        {
            entidadMateria.Id_materia = Convert.ToInt16(txtIdMateria.Text);
            entidadMateria.Nombre = txtNombre.Text;
            entidadMateria.Id_profesor = Convert.ToInt16(cbIdProfesor.SelectedValue);

        }

        private void limpiarCampos()
        {
            txtIdMateria.Text = "";
            txtNombre.Text = "";
            cbIdProfesor.SelectedIndex = 0;
        }

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorMateria.Read();
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

            sql = "select " + "id_profesor," + "concat (" + "nombre," + "' '," + "apellido) as NombreCompleto" + " from " +
            "profesor";
            sqlDA = new SqlDataAdapter(sql, sqlConn);
            sqlDA.Fill(dt);
            sqlConn.Close();
            cbIdProfesor.DataSource = dt;
            cbIdProfesor.DisplayMember = "NombreCompleto";
            cbIdProfesor.ValueMember = "id_profesor";
            cbIdProfesor.SelectedIndex = 0;
        }

    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace ExamFinal
{
    public partial class Profesores : Form
    {
        EntidadProfesor entidadProfesor = new EntidadProfesor();
        ControladorProfesor controladorProfesor = new ControladorProfesor();
        Modelo mod = new Modelo();
        public Profesores()
        {
            InitializeComponent();
        }

        private void Profesores_Load(object sender, EventArgs e)
        {
            cargarGrid();            

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtIdProfesor.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtNombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = controladorProfesor.Search(Convert.ToInt16(txtIdProfesor.Text));
            txtNombre.Text = dt.Rows[0][1].ToString();
            txtApellido.Text = dt.Rows[0][2].ToString();


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            controladorProfesor.Insert(entidadProfesor);
            cargarGrid();
            limpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cargarEntidad();
            controladorProfesor.Modify(entidadProfesor);
            cargarGrid();
            limpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {

            controladorProfesor.Delete(Convert.ToInt16(txtIdProfesor.Text));
            cargarGrid();
            limpiarCampos();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }

        private void cargarEntidad()
        {
            entidadProfesor.Id_profesor = Convert.ToInt16(txtIdProfesor.Text);
            entidadProfesor.Nombre = txtNombre.Text;
            entidadProfesor.Apellido = txtApellido.Text;

        }

        private void limpiarCampos()
        {
            txtIdProfesor.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";

        }

        private void cargarGrid()
        {
            dataGridView1.DataSource = controladorProfesor.Read();
        }

    }
}


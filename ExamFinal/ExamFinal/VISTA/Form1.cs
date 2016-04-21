using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamFinal
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void estudiantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estudiantes estudiantes = new Estudiantes();
            estudiantes.WindowState = FormWindowState.Maximized;
            estudiantes.MdiParent = this;
            estudiantes.Show();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias();
            materias.WindowState = FormWindowState.Maximized;
            materias.MdiParent = this;
            materias.Show();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Profesores profesores = new Profesores();
            profesores.WindowState = FormWindowState.Maximized;
            profesores.MdiParent = this;
            profesores.Show();
        }

        private void estadisticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Program.ShowConsoleWindow();

        }
    }
}

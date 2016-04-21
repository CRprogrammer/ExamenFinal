using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExamFinal
{
    public class Modelo
    {
        string conexion = "Data Source='localhost';Initial Catalog=bd_colegio;Integrated Security=Yes;";
        SqlConnection sqlconn;

        public void DBConnect()
        {
            sqlconn = new SqlConnection(conexion);
            
            try
            {
                sqlconn.Open();
                
            }
            catch (Exception e)
            {
                var Errormessage = MessageBox.Show("Ha ocurrido el siguiente error: " + e.Message.ToString());
            }

        }

        public void DBDisconnect()
        {
            sqlconn.Close();
            
        }

        public void ExecuteSQL(string sql)
        {
            SqlCommand sqlcomm = new SqlCommand();
            DBConnect();
            sqlcomm.Connection = sqlconn;
            sqlcomm.CommandText = sql;
            sqlcomm.CommandType = CommandType.Text;
            sqlcomm.ExecuteNonQuery();
            DBDisconnect();
        }

        public DataTable FillDT(string sql)
        {
            DBConnect();
            SqlDataAdapter sqlda = new SqlDataAdapter(sql, sqlconn);           
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            DBDisconnect();
            return dt;
        }
    }
}

using System.Data;

namespace ExamFinal
{
    class ControladorProfesor
    {
        Modelo mod = new Modelo();
        EntidadProfesor entidad = new EntidadProfesor();
        string sql;

        public DataTable Read()
        {
            sql = "Select "
                + "id_profesor,"
                + "nombre,"
                + "apellido"
                + " from "
                + "profesor";
            return mod.FillDT(sql);
        }

        public DataTable Search(int id)
        {
            sql = "Select "
                + "id_profesor,"
                + "nombre,"
                + "apellido"
                + " from "
                + "profesor"
                + " where "
                + "id_profesor = " + id;
            return mod.FillDT(sql);
        }

        public void Insert(EntidadProfesor entidad)
        {
            sql = "Insert into profesor ("
                + "id_profesor,"
                + "nombre,"
                + "apellido"
                + ") values ("
                + entidad.Id_profesor + ","
                + "'" + entidad.Nombre + "',"
                + "'" + entidad.Apellido + "'"
                + ")";
            mod.ExecuteSQL(sql);
        }

        public void Modify(EntidadProfesor entidad)
        {
            sql = "Update profesor Set "
                + "nombre ='" + entidad.Nombre + "',"
                + "apellido = '" + entidad.Apellido + "'"
                + " where "
                + "id_profesor = " + entidad.Id_profesor;
            mod.ExecuteSQL(sql);
        }

        public void Delete(int id)
        {
            sql = "Delete profesor "
                + "where "
                + "id_profesor = " + id;
            mod.ExecuteSQL(sql);
        }
    }
}

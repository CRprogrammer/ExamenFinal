using System.Data;


namespace ExamFinal
{
    class ControladorMateria
    {
        Modelo mod = new Modelo();
        EntidadMateria entidad = new EntidadMateria();

        string sql;

        public DataTable Read()
        {
            sql = "Select "
                + "id_materia,"
                + "nombre,"
                + "id_profesor"
                + " from "
                + "materia";
            return mod.FillDT(sql);
        }

        public DataTable Search(int id)
        {
            sql = "Select "
                + "id_materia,"
                + "nombre,"
                + "id_profesor"
                + " from "
                + "materia"
                + " where "
                + "id_materia = " + id;
            return mod.FillDT(sql);
        }

        public void Insert(EntidadMateria entidad)
        {
            sql = "Insert into materia ("
                + "id_materia,"
                + "nombre,"
                + "id_profesor"
                + ") values ("
                + entidad.Id_materia + ","
                + "'" + entidad.Nombre + "',"
                + entidad.Id_profesor
                + ")";
            mod.ExecuteSQL(sql);
        }

        public void Modify(EntidadMateria entidad)
        {
            sql = "Update materia Set "
                + "nombre ='" + entidad.Nombre + "',"
                + "id_profesor =" + entidad.Id_profesor
                + " where "
                + "id_materia = " + entidad.Id_materia;
            mod.ExecuteSQL(sql);
        }

        public void Delete(int id)
        {
            sql = "Delete materia "
                + "where "
                + "id_materia = " + id;
            mod.ExecuteSQL(sql);
        }
    }
}


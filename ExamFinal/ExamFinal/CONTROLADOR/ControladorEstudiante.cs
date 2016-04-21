using System.Data;


namespace ExamFinal
{
    class ControladorEstudiante
    {
        Modelo mod = new Modelo();
        EntidadEstudiante entidad = new EntidadEstudiante();
        string sql;

        public DataTable Read()
        {
            sql = "Select "
                + "id_estudiante,"
                + "nombre,"
                + "apellido,"
                + "direccion,"
                + "edad,"
                + "id_materia"
                + " from "
                + "estudiante";
            return mod.FillDT(sql);
        }

        public DataTable Search(int id)
        {
            sql = "Select "
                + "id_estudiante,"
                + "nombre,"
                + "apellido,"
                + "direccion,"
                + "edad,"
                + "id_materia"
                + " from "
                + "estudiante"
                + " where "
                + "id_estudiante = " + id;
            return mod.FillDT(sql);
        }

        public void Insert(EntidadEstudiante entidad)
        {
            sql = "Insert into estudiante ("
                + "id_estudiante,"
                + "nombre,"
                + "apellido,"
                + "direccion,"
                + "edad,"
                + "id_materia"
                + ") VALUES ("
                + entidad.Id_estudiante + ","
                + "'" + entidad.Nombre + "',"
                + "'" + entidad.Apellido + "',"
                + "'" + entidad.Direccion + "',"
                + entidad.Edad + ","
                + entidad.Id_materia + ""
                //+ 1 //entidad.Id_Salario
                + ")";
            mod.ExecuteSQL(sql);
        }

        public void Modify(EntidadEstudiante entidad)
        {
            sql = "Update estudiante Set "
                + "id_estudiante =" + entidad.Id_estudiante + ","
                + "nombre = '" + entidad.Nombre + "',"
                + "apellido = '" + entidad.Apellido + "',"
                + "direccion = '" + entidad.Direccion + "',"
                + "edad =" + entidad.Edad + ","
                + "id_materia =" + entidad.Id_materia
                //+ "ID_SALARIO = " + 1 //entidad.Id_Salario
                + " where "
                + "id_estudiante = " + entidad.Id_estudiante;
            mod.ExecuteSQL(sql);
        }

        public void Delete(int id)
        {
            sql = "Delete estudiante "
                + "where "
                + "id_estudiante = " + id;
            mod.ExecuteSQL(sql);
        }

        public void CargaCombo()
        {
            sql = "select " + "id_materia," + "nombre" + " from " +
                "materia";
            mod.ExecuteSQL(sql);
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace IngresaUsuarios
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Insert" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Insert.svc or Insert.svc.cs at the Solution Explorer and start debugging.
    public class Insert : IInsert
    {
       
        public String PruebaTexto(String valor)
        {
            string mensaje = string.Empty;
            try
            {
                mensaje = "Saludos " + valor + " " + "Mensaje de prueba desde el Servicio-WCF";
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            return mensaje;
        }

        public DataSet PoblarDGV()
        {
            string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = conexion;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                using (sql)
                {
                    sql.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select * from Usuario", sql);
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public string PruebaConexion()
        {
            string mensaje = string.Empty;
            string conexion = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString.ToString();
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = conexion;

            try
            {
                sql.Open();
                if (sql == null)
                {
                    mensaje = "la conexion no tiene ningun valor";
                }
                else if (sql.State == ConnectionState.Closed)
                {
                    mensaje = "la conexion no esta Open";
                }
                else
                {
                    mensaje = sql.State.ToString(); ;
                }
                sql.Close();
                return mensaje;
            }

            catch (Exception ex) { return ex.Message; }
        }
    }
}

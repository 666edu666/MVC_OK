using ProyectoMVCReal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoMVCReal.Helper
{
    public class HelperDoctor
    {

        SqlConnection con;
        SqlCommand com;
        SqlDataReader read;


        public HelperDoctor()
        {
            String cadena = ConfigurationManager.ConnectionStrings["cadenaHospital"].ConnectionString;
            this.con = new SqlConnection(cadena);
            this.com = new SqlCommand();
            this.com.Connection = this.con;
        }

        // Busco un DOCTOR desde el código del doctor
        public Doctor BuscarDoctor(int cod)
        {
            Doctor doct = null;

            String sql = "select * from doctor where doctor_no = @codDoc";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;

            SqlParameter pamDoc = new SqlParameter("@codDoc", cod);
            this.com.Parameters.Add(pamDoc);

            this.con.Open();

            this.read = this.com.ExecuteReader();
            if (this.read.HasRows)
            {
                this.read.Read();
                doct = new Doctor(
                    int.Parse(this.read["hospital_cod"].ToString()),
                    int.Parse(this.read["doctor_no"].ToString()),
                    this.read["apellido"].ToString(),
                    this.read["especialidad"].ToString(),
                    int.Parse(this.read["salario"].ToString())
                    );
            }                        
            CierraConexion();
            return doct;
        }

        //Devuelvo la lsita de todos los DOCTORES
        public List<Doctor> GetDoctores()
        {
            List<Doctor> lista = null;
            Doctor doc;

            String sql = "select * from doctor";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.con.Open();
            this.read = this.com.ExecuteReader();           

            if (this.read.HasRows)
            {
                lista = new List<Doctor>();
                while (this.read.Read())
                {
                    doc = new Doctor(
                        int.Parse(this.read["hospital_cod"].ToString()),
                        int.Parse(this.read["doctor_no"].ToString()),
                        this.read["apellido"].ToString(),
                        this.read["especialidad"].ToString(),
                        int.Parse(this.read["salario"].ToString())
                    );
                    lista.Add(doc);
                }
            }
            CierraConexion();
            return lista;
        }

        public void BorraDoctor(int cod)
        {
            String sql = "delete from doctor where doctor_no = @docno";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;

            SqlParameter pamCod = new SqlParameter("@docno", cod);
            this.com.Parameters.Add(pamCod);

            this.con.Open();
            this.com.ExecuteNonQuery();


            this.con.Close();
            this.com.Parameters.Clear();

        }

        //Cierro todo SQL
        private void CierraConexion()
        {
            this.com.Parameters.Clear();
            this.read.Close();
            this.con.Close();
        }

    }
}
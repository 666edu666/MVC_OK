using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


//Espaco de nombres de la configuración =>Web.config
using System.Configuration;
using System.Data.SqlClient;
using ProyectoMVCReal.Models;

namespace ProyectoMVCReal.Helper
{
    public class HelperDepartamento
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader read;

        public HelperDepartamento()
        {
            String cadena = ConfigurationManager.ConnectionStrings["cadenaHospital"].ConnectionString;
            this.con = new SqlConnection(cadena);
            this.com = new SqlCommand();
            this.com.Connection = this.con;
        }
        public Departamento BuscarDepartamento (int depno)
        {
            String sql = "select * from dept where dept_no = @deptno";
            SqlParameter pamdept = new SqlParameter("@deptno", depno);
            this.com.Parameters.Add(pamdept); 

            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;

            this.con.Open();
            Departamento dept = new Departamento();
            this.read = this.com.ExecuteReader();
            if (this.read.HasRows)
            {
                this.read.Read();
                
                dept.Localidad = this.read["LOC"].ToString();
                dept.Nombre = this.read["DNOMBRE"].ToString();
                dept.Numero = int.Parse(this.read["DEPT_NO"].ToString());
                
            }
            this.read.Close();
            this.com.Parameters.Clear();
            this.con.Close();
            return dept;            
        }

        public List <Departamento> GetDepartamentos()
        {
            List<Departamento> lista  = new List<Departamento>(); ;

            String sql = "select * from dept";
            this.com.CommandType = System.Data.CommandType.Text;

            this.com.CommandText = sql;
            this.con.Open();
            this.read = this.com.ExecuteReader();

            while (this.read.Read())
            {
                
                Departamento d = new Departamento();
                d.Localidad = this.read["LOC"].ToString();
                d.Numero= int.Parse(this.read["dept_no"].ToString());
                d.Nombre = this.read["dnombre"].ToString();
                lista.Add(d);
            }

            this.read.Close();
            this.com.Parameters.Clear();
            this.con.Close();

            return lista;
        }
    }
}
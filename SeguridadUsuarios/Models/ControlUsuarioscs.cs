using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguridadUsuarios.Models
{
    public class ControlUsuarioscs
    {
        public String Role { get; set; }

        public Boolean ExisteUsuario(String usuario, String password)
        {
            //Imitando una BBDD => Solo tengo dos (admin-admin user-user)
            if (usuario.ToUpper()=="USER" && password.ToUpper() == "USER")
            {
                this.Role = "USUARIO";
                return true;
            }
            if (usuario.ToUpper() == "ADMIN" && password.ToUpper() == "ADMIN")
            {
                this.Role = "ADMINISTRADOR";
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
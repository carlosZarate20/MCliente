using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MantenimientoCliente.Models;

namespace MantenimientoCliente.ViewModel
{
    public class LoginViewModel
    {
        public String Codigo { get; set; }
        public String Contraseña { get; set; }
        public LoginViewModel()
        {

        }
    }
}
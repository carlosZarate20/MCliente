using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MantenimientoCliente.Models;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;

namespace MantenimientoCliente.ViewModel
{
    public class RegistrarClienteViewModel
    {
        public Int32? ClienteId { get; set;}
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String DNI { get; set; }
        public Int32 Edad { get; set; }
        public String Sexo { get; set; }
        public String Nivel { get; set; }

        public List<SelectListItem> Niveles { get; set; }
        public String Telefono { get; set; }

        public RegistrarClienteViewModel()
        {
        }

        public RegistrarClienteViewModel(Int32? ClienteId)
        {
            this.ClienteId = ClienteId;

        }

       
    
    }
}
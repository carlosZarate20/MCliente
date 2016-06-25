using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MantenimientoCliente.Models;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;

namespace MantenimientoCliente.ViewModel
{
    public class EditarViewModel
    {
        public Int32? ClienteId { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String DNI { get; set; }
        public Int32 Edad { get; set; }
        public String Sexo { get; set; }
        public String Nivel { get; set; }

        public String Telefono { get; set; }

        public EditarViewModel()
        {

        }
        public EditarViewModel(Int32? ClienteId)
        {
            this.ClienteId = ClienteId;

            if(ClienteId.HasValue)
            {
                MantenimientoClienteEntities context = new MantenimientoClienteEntities();
                Cliente objCliente = context.Cliente.FirstOrDefault(X => X.ClienteId == ClienteId.Value);

                Nombre = objCliente.Nombre;
                Apellidos = objCliente.Apellido;
                DNI = objCliente.DNI;
                Edad = objCliente.Edad;
                Sexo = objCliente.Sexo;
                Nivel = objCliente.Nivel_Estudio;
                Telefono = objCliente.Telefono;
            }
        }
    }
}
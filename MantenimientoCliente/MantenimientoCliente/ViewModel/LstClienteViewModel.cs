using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MantenimientoCliente.Models;

namespace MantenimientoCliente.ViewModel
{
    public class LstClienteViewModel
    {
        public List<Cliente> LstCliente { get; set; }
        public String BuscarCliente { get; set; }

        public String EliminarCliente { get; set; }

        public LstClienteViewModel()
        {
            MantenimientoClienteEntities context = new MantenimientoClienteEntities();
            LstCliente = context.Cliente.ToList();
        }

        public void LstBuscarCliente()
        {
            MantenimientoClienteEntities context = new MantenimientoClienteEntities();
            if(BuscarCliente == null)
                LstCliente = context.Cliente.ToList();
            else
            {
                LstCliente = context.Cliente.Where(x => x.Nombre.Contains(BuscarCliente)).ToList();
           
            }
        }

    

    }
}
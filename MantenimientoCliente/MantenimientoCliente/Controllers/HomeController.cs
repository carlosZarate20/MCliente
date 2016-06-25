using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MantenimientoCliente.ViewModel;
using MantenimientoCliente.Models;

namespace MantenimientoCliente.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            LoginViewModel objViewModel = new LoginViewModel();
            return View(objViewModel);

        }
        [HttpPost]
        public ActionResult Login(LoginViewModel objViewModel)
        {
            try
            {
                MantenimientoClienteEntities context = new MantenimientoClienteEntities();

                if (String.IsNullOrWhiteSpace(objViewModel.Codigo) && String.IsNullOrWhiteSpace(objViewModel.Contraseña))
                {
                    TempData["Mensaje"] = "Ingrese datos de campos faltantes";
                    return View(objViewModel);
                }

                if (String.IsNullOrWhiteSpace(objViewModel.Codigo))
                {
                    TempData["Mensaje"] = "Ingrese Nombre de Usuario";
                    return View(objViewModel);
                }

                if (String.IsNullOrWhiteSpace(objViewModel.Contraseña))
                {
                    TempData["Mensaje"] = "Ingrese Contraseña";
                    return View(objViewModel);
                }

                if (!(objViewModel.Codigo == "root" && objViewModel.Contraseña == "root"))
                {
                    TempData["Mensaje"] = "Nombre de usuario y/o contraseña incorrecta";
                    return View(objViewModel);
                }
            }
            catch (Exception ex)
            {
                return View(objViewModel);
            }

            return RedirectToAction("LstCliente");
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Index(LoginModel login)
        {
            Session["LOGIN"] = login;
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session["LOGIN"] = null;
            return View("Login");
        }



        public ActionResult LstCliente()
        {
            LstClienteViewModel objViewModel = new LstClienteViewModel();
            return View(objViewModel);
        }
        [HttpPost]
        public ActionResult LstCliente(LstClienteViewModel Model)
        {
            Model.LstBuscarCliente();
            return View(Model);
        }

        public ActionResult EliminarCliente(Int32 ClienteId)
        {
            try
            {
                MantenimientoClienteEntities obj = new MantenimientoClienteEntities();
                var objCliente = obj.Cliente.FirstOrDefault(x => x.ClienteId == ClienteId);
                obj.Cliente.Remove(objCliente);
                obj.SaveChanges();
                TempData["MensajeRespuesta"] = "Se elimino satisfactoriamente el cliente";
            }
            catch (Exception Ex)
            {
            }
            return RedirectToAction("LstCliente");
        }

        public ActionResult RegistrarCliente(Int32? ClienteId)
        {
            RegistrarClienteViewModel objViewModel = new RegistrarClienteViewModel(ClienteId);

            return View(objViewModel);
        }

        [HttpPost]
        public ActionResult RegistrarCliente(RegistrarClienteViewModel objViewModel)
        {
            try
            {
                if (objViewModel.DNI == null || objViewModel.Nombre == null || objViewModel.Apellidos == null
                    || objViewModel.Telefono == null)
                {
                    TempData["Mensaje"] = "Ingresar Campos Faltantes";
                    return View(objViewModel);
                }
                
                if (objViewModel.Nombre.Length < 3 || objViewModel.Nombre.Length > 25 ||
                    objViewModel.Apellidos.Length < 3 || objViewModel.Apellidos.Length > 25 || objViewModel.Edad <18 || objViewModel.Edad>110
                    ||  objViewModel.Telefono.Length != 9 || objViewModel.DNI.Length != 8)
                {
                    TempData["Mensaje"] = "Datos Incorrectos";
                    return View(objViewModel);
                }

           

                MantenimientoClienteEntities context = new MantenimientoClienteEntities();
                Cliente objCliente = null;

                if (objViewModel.ClienteId.HasValue)
                    objCliente = context.Cliente.FirstOrDefault(X => X.ClienteId == objViewModel.ClienteId.Value);
                else
                {
                    objCliente = new Cliente();
                    context.Cliente.Add(objCliente);
                }
                objCliente.Nombre = objViewModel.Nombre;
                objCliente.Apellido = objViewModel.Apellidos;
                objCliente.DNI = objViewModel.DNI;
                objCliente.Edad = objViewModel.Edad;
                objCliente.Sexo = objViewModel.Sexo;
                objCliente.Nivel_Estudio = objViewModel.Nivel;
                objCliente.Telefono = objViewModel.Telefono;
                context.SaveChanges();
                TempData["MensajeRespuesta"] = "Se Registro satisfactoriamente el cliente";
                return RedirectToAction("LstCliente");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "No se pudo registrar");
            }
            return View(objViewModel);
        }

        public ActionResult EditarCliente(Int32? ClienteId)
        {
            EditarViewModel objViewModel = new EditarViewModel(ClienteId);

            return View(objViewModel);
        }

        [HttpPost]
        public ActionResult EditarCliente(EditarViewModel objViewModel)
        {
            try
            {
                MantenimientoClienteEntities context = new MantenimientoClienteEntities();
                Cliente objCliente = new Cliente(); ;

                if (objViewModel.ClienteId.HasValue)
                    objCliente = context.Cliente.FirstOrDefault(X => X.ClienteId == objViewModel.ClienteId.Value);

                objCliente.Nombre = objViewModel.Nombre;
                objCliente.Apellido = objViewModel.Apellidos;
                objCliente.DNI = objViewModel.DNI;
                objCliente.Edad = objViewModel.Edad;
                objCliente.Sexo = objViewModel.Sexo;
                objCliente.Nivel_Estudio = objViewModel.Nivel;
                objCliente.Telefono = objViewModel.Telefono;
                context.SaveChanges();
                TempData["MensajeRespuesta"] = "Se Edito satisfactoriamente el cliente";
                return RedirectToAction("LstCliente");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "No se pudo editar");
            }
            return View(objViewModel);
        }
    }
}
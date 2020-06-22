using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Netcore.Application.Contracts;

namespace Netcore.Web
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly IEmpleadoAppService _empleadoAppService;
        public HomeController(ILogger<HomeController> logger,
            IEmpleadoAppService empleadoAppService)
        {
            _logger = logger;
            _empleadoAppService = empleadoAppService;
        }

        [AutoValidateAntiforgeryToken]
        public async virtual Task<ActionResult> Index()
        {

            var empleadosLista = await _empleadoAppService.ObtenerTodos();

            //var result = await _empleadoAppService.ObtenerPorId(1);

            ViewData["EmpleadosLista"] = empleadosLista;
            //  return result;

            return View();
        }

        [AutoValidateAntiforgeryToken]
        public async virtual Task<ActionResult> Edit()
        {

            return View();
        }


        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public async Task<ActionResult> Registrar(IFormCollection formCollection)
        {

            var empleadoItem = await _empleadoAppService.Agregar(


                new Application.Dtos.EmpleadoDto()
                {
                    Nombres = formCollection["Nombres"],
                    ApellidoPaterno = formCollection["ApellidoPaterno"]

                }
                );

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Error/{code:int}")]
        public IActionResult Error(int code)
        {
            // ViewData["ListaErrores"]  = status;
            return View(code);
        }
    }
}

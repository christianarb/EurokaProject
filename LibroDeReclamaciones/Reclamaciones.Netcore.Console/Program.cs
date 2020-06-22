using Netcore.Domain.Agregates.ReclamoAgg;
using System;

namespace Netcore.Console
{
    class Program
    {
        static void Main(string[] args)
        {

            // Console.WriteLine("Hello World!");

            Reclamo reclamo = new Reclamo();
            reclamo.AceptaCondiciones = true;
            //reclamo.Activo = true;
            reclamo.ConformidadCondiciones = true;
            reclamo.Consumidor = new Domain.Agregates.PersonaAgg.Persona();
            reclamo.Consumidor.ApellidoMaterno = "Bautista";
            reclamo.Consumidor.ApellidoPaterno = "Ruiz";
            reclamo.Consumidor.Correo = "christian_arb@hotmail.com";
            reclamo.Consumidor.Nombres = "Christian Ruiz";
            reclamo.Consumidor.NroDocumento = "44193294";
            reclamo.Consumidor.Telefono = "957866694";
            reclamo.Consumidor.TipoDocumento = new Domain.Agregates.ParametroAgg.ParametroDetalle();
            reclamo.Consumidor.TipoDocumento.Id = 1;

        }
    }
}

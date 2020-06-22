using System;
using System.Collections.Generic;
using System.Text;

namespace Netcore.Infrastructure.Crosscutting
{
    public class Variables
    {
        public const int CantidadCookies = 4;
        public const string UrlBook = "https://docs.yanbal.com/test-cdt/cdigital/us/2020/c6/oficial"; // "https://docs.yanbal.com/catalogo/peru/per-2020-c05/";
        public const string ParametroEstado = "ESTADO";
        public const string ParametroEstadoNuevo = "Nuevo";
        public const string UsuarioCreacion = "System";

        public const string HOSTNAME_HYBRIS_CAR = "hybris.car.hostname";
        public const string CONTEXT_HYBRIS_CAR = "hybris.car.{0}.context";
        public const string Corporate = "corporate";
        public class CookiesName
        {
            public const string Cns  = "cns";
            public const string Pais = "pais";
            public const string Anio = "anio";
            public const string Campania = "campania";
        }

        public class Columnas
        {
            public const string FlipBookCompleteUrl = "flipbookcompleteurl";
         
            public const string Name = "name";
            public const string Description = "description";
            public const string Cultura = "en-US";
            public const string Price = "price";
            public const string ProductId = "productid";
            public const string Amount = "amount";
            public const string PathPedidos = "//item";

        }
       public enum CampaniaCatalogo : ushort
        {
            CodigoPais = 0,
            Anio = 1,
            Campania = 2
        }
    }
}

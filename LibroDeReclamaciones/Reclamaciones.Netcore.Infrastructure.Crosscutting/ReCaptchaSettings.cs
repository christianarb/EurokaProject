using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netcore.Infrastructure.Crosscutting
{
    public class ReCaptchaSettings
    {
        public string reCaptchaSiteKey { get; set; }
        public string reCaptchaSecretKey { get; set; }

        public string UrlConfirmacion { get; set; }
        
    }

}

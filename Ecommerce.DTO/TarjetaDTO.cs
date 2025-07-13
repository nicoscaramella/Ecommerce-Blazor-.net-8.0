using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class TarjetaDTO
    {
        [Required(ErrorMessage = "Ingrese el titular de la tarjeta.")]
        public string? Titular { get; set; }
        [Required(ErrorMessage = "Ingrese el número de tarjeta.")]
        public string? NumeroTarjeta { get; set; }
        [Required(ErrorMessage = "Ingrese la fecha de vigencia.")]
        public string? Vigencia { get; set; }
        [Required(ErrorMessage = "Ingrese el CVV.")]
        public string? CVV { get; set; }

    }
}


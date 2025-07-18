﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ProductoDTO
    {
     public int IdProducto { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre completo.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese descripcion.")]
        public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "Ingrese el precio.")]
        public decimal? Precio { get; set; }
        [Required(ErrorMessage = "Ingrese el precio de oferta.")]
        public decimal? PrecioOferta { get; set; }
        [Required(ErrorMessage = "Ingrese la cantidad.")]
        public int? Cantidad { get; set; }
        [Required(ErrorMessage = "Ingrese la imagen.")]
        public string? Imagen { get; set; }

        public DateTime? FechaCreacion { get; set; }


        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }
    }
}

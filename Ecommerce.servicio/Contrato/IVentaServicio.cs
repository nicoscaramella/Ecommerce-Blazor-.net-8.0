﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;
namespace Ecommerce.servicio.Contrato
{
    public  interface IVentaServicio
    {
        Task<VentaDTO> Registrar(VentaDTO modelo);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ecommerce.modelo;
using Ecommerce.DTO;
using Ecommerce.repositorio.Contrato;
using Ecommerce.servicio.Contrato;
using AutoMapper;

namespace Ecommerce.servicio.Implementacion
{
    public class VentaServicio : IVentaServicio
    {
        private readonly IVentaRepositorio _modeloRepositorio;
        private readonly IMapper _mapper;
        public VentaServicio(IVentaRepositorio modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<VentaDTO> Registrar(VentaDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Venta>(modelo);
                var ventaGenerada = await _modeloRepositorio.Registrar(dbModelo);

                if (ventaGenerada.IdVenta == 0)
                   throw new TaskCanceledException("no se pudo registrar la venta");
                else

                return _mapper.Map<VentaDTO>(ventaGenerada);


            }
            catch (Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("Error during authorization", ex);
            }
        }
    }
}

using AutoMapper;
using Ecommerce.DTO;
using Ecommerce.modelo;
using Ecommerce.repositorio.Contrato;
using Ecommerce.servicio.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.servicio.Implementacion
{
    public class DashboardServicio : IDashboardService
    {
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;
        private readonly IGenericoRepositorio<Producto> _productoRepositorio;
        private readonly IVentaRepositorio _ventaRepositorio;
        
        public DashboardServicio(IVentaRepositorio ventaRepositorio,
                                 IGenericoRepositorio<Usuario> usuarioRepositorio, 
                                IGenericoRepositorio<Producto> productoRepositorio
                                )
        {
            _ventaRepositorio = ventaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _productoRepositorio = productoRepositorio;
        } 

        private string Ingresos()
        {
            var consulta = _ventaRepositorio.Consultar();
            decimal? ingresos = consulta.Sum(p => p.Total);
            return Convert.ToString(ingresos);


        }

        private int Ventas()
        {
            var consulta = _ventaRepositorio.Consultar();
            int total  = consulta.Count();
            return total;

        }
        private int Clientes()
        {
            var consulta = _usuarioRepositorio.Consultar(u => u.Rol.ToLower() == "cliente");
            int total = consulta.Count();
            return total;

        }

        private int Productos()
        {
            var consulta = _productoRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }


        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO
                {
                    TotalIngresos = Ingresos(),
                    TotalVentas = Ventas(),
                    TotalCliente = Clientes(),
                    TotalProductos = Productos()
                };
                return dto;
            }
            catch(Exception ex)
            {
                // Log the exception (not implemented here)
                throw new Exception("Error during authorization", ex);
            }
            
        }
    }
}

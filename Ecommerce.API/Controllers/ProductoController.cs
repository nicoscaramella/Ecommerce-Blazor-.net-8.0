﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.DTO;
using Ecommerce.servicio.Contrato;
using Ecommerce.servicio.Implementacion;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;
        public ProductoController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet("Lista/{buscar:alpha?}")]

        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.esCorrecto = true;
                response.Resultado = await _productoServicio.Lista(buscar);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);


        }

        [HttpGet("Catalogo/{categoria:alpha}/{buscar:alpha?}")]

        public async Task<IActionResult> Catalogo(string categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (categoria.ToLower() == "todos") buscar = "";
                if (buscar == "NA") buscar = "";

                response.esCorrecto = true;
                response.Resultado = await _productoServicio.Catalogo(categoria,buscar);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet("Obtener/{id:int}")]

        public async Task<IActionResult> Obtener(int id)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            { 
                response.esCorrecto = true;
                response.Resultado = await _productoServicio.ObtenerPorId(id);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);


        }

        [HttpPost("Crear")]

        public async Task<IActionResult> Crear([FromBody]ProductoDTO modelo)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.esCorrecto = true;
                response.Resultado = await _productoServicio.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

        [HttpPut("Editar")]

        public async Task<IActionResult> Editar([FromBody] ProductoDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.esCorrecto = true;
                response.Resultado = await _productoServicio.Editar(modelo);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }
        [HttpDelete("Eliminar/{id:int}")]

        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.esCorrecto = true;
                response.Resultado = await _productoServicio.Eliminar(id);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);
        }

    }
}

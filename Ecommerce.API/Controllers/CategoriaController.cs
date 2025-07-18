﻿using Ecommerce.DTO;
using Ecommerce.servicio.Contrato;
using Ecommerce.servicio.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServicio _categoriaServicio;
        public CategoriaController(ICategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }


        [HttpGet("Lista/{buscar:alpha?}")]

        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.esCorrecto = true;
                response.Resultado = await _categoriaServicio.Lista(buscar);

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
            var response = new ResponseDTO<CategoriaDTO>();

            try
            {
                response.esCorrecto = true;
                response.Resultado = await _categoriaServicio.ObtenerPorId(id);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]

        public async Task<IActionResult> Crear([FromBody] CategoriaDTO modelo)
        {
            var response = new ResponseDTO<CategoriaDTO>();
            try
            {
                response.esCorrecto = true;
                response.Resultado = await _categoriaServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]

        public async Task<IActionResult> Editar([FromBody] CategoriaDTO modelo)
        {
            var response = new ResponseDTO<bool>();
            try
            {
                response.esCorrecto = true;
                response.Resultado = await _categoriaServicio.Editar(modelo);
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
                response.Resultado = await _categoriaServicio.Eliminar(id);
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

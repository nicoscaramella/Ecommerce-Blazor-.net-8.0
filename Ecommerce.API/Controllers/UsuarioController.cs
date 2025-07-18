﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.servicio.Contrato;
using Ecommerce.DTO;


namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public UsuarioController(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        [HttpGet("Lista/{rol:alpha}/{buscar:alpha?}")]

        public async Task<IActionResult> Lista(string rol, string buscar = "NA")
        {
            var response = new ResponseDTO<List<UsuarioDTO>>();

            try
            {
                if (buscar == "NA") buscar = "";

                response.esCorrecto = true;
                response.Resultado = await _usuarioServicio.Lista(rol, buscar);

            }
            catch(Exception ex)
            {
               response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);


        }

        [HttpGet("Obtener/{id:int}")]

        public async Task<IActionResult> Obtener(int id)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
               
                response.esCorrecto = true;
                response.Resultado = await _usuarioServicio.ObtenerPorId(id);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);


        }


        [HttpPost("Crear")]

        public async Task<IActionResult> Crear([FromBody]UsuarioDTO modelo)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {

                response.esCorrecto = true;
                response.Resultado = await _usuarioServicio.Crear(modelo);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);


        }

        [HttpPost("Autorizacion")]

        public async Task<IActionResult> Autorizacion([FromBody] LoginDTO modelo)
        {
            var response = new ResponseDTO<SesionDTO>();

            try
            {

                response.esCorrecto = true;
                response.Resultado = await _usuarioServicio.Autorizacion(modelo);

            }
            catch (Exception ex)
            {
                response.esCorrecto = false;
                response.Mensaje = ex.Message;
            }

            return Ok(response);


        }

        [HttpPut("Editar")]

        public async Task<IActionResult> Editar([FromBody] UsuarioDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.esCorrecto = true;
                response.Resultado = await _usuarioServicio.Editar(modelo);

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
                response.Resultado = await _usuarioServicio.Eliminar(id);

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

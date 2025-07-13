using Ecommerce.DTO;
using Ecommerce.servicio.Contrato;
using Ecommerce.servicio.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {

        private readonly IDashboardService _dashboardServicio;
        public DashboardController(IDashboardService dashboardServicio)
        {
            _dashboardServicio = dashboardServicio;
        }

        [HttpGet("Resumen")]

        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {

                response.esCorrecto = true;
                response.Resultado =  _dashboardServicio.Resumen();

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

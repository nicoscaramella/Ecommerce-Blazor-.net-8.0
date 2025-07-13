using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.DTO;

namespace Ecommerce.servicio.Contrato
{
    public interface IUsuarioServicio
    {

        Task<List<UsuarioDTO>> Lista(string rol, string buscar);
        Task<UsuarioDTO> ObtenerPorId(int id);
        Task<SesionDTO> Autorizacion(LoginDTO modelo);
        Task<UsuarioDTO> Crear(UsuarioDTO modelo);
        Task<bool> Editar(UsuarioDTO modelo);

        Task<bool> Eliminar(int id);

    }
}

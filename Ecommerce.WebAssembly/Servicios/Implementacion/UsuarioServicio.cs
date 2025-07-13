using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;


namespace Ecommerce.WebAssembly.Servicios.Implementacion
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly HttpClient _httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<ResponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("usuario/autorizacion", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("usuario/crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(UsuarioDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("usuario/editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"usuario/eliminar/{id}");
        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"usuario/lista/{rol}/{buscar}");

        }

        public async Task<ResponseDTO<UsuarioDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"usuario/obtener/{id}");
        }
    }
}

using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;

namespace Ecommerce.WebAssembly.Servicios.Implementacion
{
    public class CategoriaServicio : ICategoriaServicio
    {

        private readonly HttpClient _httpClient;
        public CategoriaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("categoria/crear", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("categoria/editar", modelo);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
           return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"categoria/eliminar/{id}");
        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> Lista(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"categoria/lista/{buscar}");
        }

        public async Task<ResponseDTO<CategoriaDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"categoria/lista/{id}");
        }
    }
    
}

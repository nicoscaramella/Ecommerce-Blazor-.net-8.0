﻿using Blazored.LocalStorage;
using Ecommerce.DTO;
using Blazored.Toast.Services;
using Ecommerce.WebAssembly.Servicios.Contrato;

namespace Ecommerce.WebAssembly.Servicios.Implementacion
{
    public class CarritoServicio : ICarritoServicio
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;    
        public CarritoServicio(ILocalStorageService localStorageService,
        ISyncLocalStorageService syncLocalStorageService,
        IToastService toastService)
        {
            _localStorageService = localStorageService;
            _syncLocalStorageService = syncLocalStorageService;
            _toastService = toastService;
        }
       

        public event Action MostrarItems;

        public async Task AgregarCarrito(CarritoDTO modelo)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if (carrito == null)
                    carrito = new List<CarritoDTO>();
                
                var encontrado = carrito.FirstOrDefault(p => p.Producto.IdProducto == modelo.Producto.IdProducto);
                if (encontrado != null)
                    carrito.Remove(encontrado);
                
                carrito.Add(modelo);
                await _localStorageService.SetItemAsync("carrito", carrito);

                if(encontrado != null)
                    _toastService.ShowSuccess("Producto actualizado en el carrito");
                else
                    _toastService.ShowSuccess("Producto agregado al carrito");
                MostrarItems.Invoke();

            }
            catch
            {
                _toastService.ShowError("Error al agregar el producto al carrito");
            }
        }

        public int CantidadProductos()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");
            return carrito == null ? 0 : carrito.Count;
        }

        public async Task<List<CarritoDTO>> DevolverCarrito()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
            if (carrito == null)
                carrito = new List<CarritoDTO>();
            return carrito;
        }

        public async Task EliminarProducto(int id)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if ( carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(p => p.Producto.IdProducto == id);
                    if (elemento != null)
                    { carrito.Remove(elemento);
                        await _localStorageService.SetItemAsync("carrito", carrito);
                        MostrarItems.Invoke();
                    }
                }

            }
            catch
            {
                _toastService.ShowError("Error al eliminar el producto del carrito");
            }
        }

        public async Task LimpiarCarrito()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            MostrarItems.Invoke();
        }
    }
}

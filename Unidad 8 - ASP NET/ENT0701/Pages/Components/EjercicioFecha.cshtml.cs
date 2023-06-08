using ENT0701.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ENT0701.Pages.Components
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EjercicioFechaModel : PageModel
    {
        private readonly ILogger<EjercicioFechaModel> _logger;

        public readonly BikeStoresDB Data;

        public List<string[]> GetStoreActiveOrders(string storeName, DateTime formDate)
        {
            var query = (from Stores in Data.Stores
                         join Orders in Data.Orders
                           on Stores.StoreId equals Orders.StoreId
                         where Stores.StoreName == storeName && (Orders.OrderStatus == 1 || Orders.OrderStatus == 2)
                         select new string[] { Orders.OrderId.ToString(), 
                                               Orders.OrderStatus.ToString(), 
                                               Orders.OrderDate.ToString(), 
                                               Orders.OrderDate.Subtract(formDate).Days.ToString() }
                         ).ToList();
            return query;
        }

        public EjercicioFechaModel(BikeStoresDB data)
        {
            Data = data;
        }
        public void OnGet()
        {
        }
    }
}

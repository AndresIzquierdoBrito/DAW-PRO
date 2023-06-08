using ENT0701.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ENT0701.Pages.Components
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EjercicioFiltroModel : PageModel
    {
        private readonly ILogger<EjercicioFiltroModel> _logger;
        public readonly BikeStoresDB Data;

        public List<string[]> FilterByBikeModel(string? brand, string? bikeModel)
        {
            var query = new List<string[]>();
            if (bikeModel != null)
            {
                query = (from OrderItems in Data.OrderItems
                         join Products in Data.Products
                             on OrderItems.ProductId equals Products.ProductId
                         where Products.ProductName == bikeModel
                         orderby OrderItems.OrderId descending
                         select new string[] {
                              OrderItems.OrderId.ToString(),
                              Products.ProductName,
                              OrderItems.Quantity.ToString(),
                              (OrderItems.Discount * 100).ToString("0") + " %",
                              OrderItems.ListPrice.ToString() + " €",
                              (OrderItems.ListPrice - (OrderItems.ListPrice*OrderItems.Discount)).ToString("0.00") +  " €"}
                        ).ToList();
            }
            else if (brand != null)
            {
                query = (from OrderItems in Data.OrderItems
                         join Products in Data.Products
                             on OrderItems.ProductId equals Products.ProductId
                         join Brands in Data.Brands
                             on Products.BrandId equals Brands.BrandId
                         where Brands.BrandName == brand
                         orderby OrderItems.OrderId descending
                         select new string[] {
                              OrderItems.OrderId.ToString(),
                              Products.ProductName,
                              OrderItems.Quantity.ToString(),
                              (OrderItems.Discount * 100).ToString("0") + " %",
                              OrderItems.ListPrice.ToString() + " €",
                              (OrderItems.ListPrice - (OrderItems.ListPrice*OrderItems.Discount)).ToString("0.00") +  " €"}
                        ).ToList();
            }
            else
            {
                query = (from OrderItems in Data.OrderItems
                         join Products in Data.Products
                             on OrderItems.ProductId equals Products.ProductId
                         orderby OrderItems.OrderId descending
                         select new string[] {
                              OrderItems.OrderId.ToString(),
                              Products.ProductName,
                              OrderItems.Quantity.ToString(),
                              (OrderItems.Discount * 100).ToString("0") + " %",
                              OrderItems.ListPrice.ToString() + " €",
                              (OrderItems.ListPrice - (OrderItems.ListPrice*OrderItems.Discount)).ToString("0.00") +  " €"}
                        ).ToList();
            }
            return query;

        }

        public EjercicioFiltroModel(BikeStoresDB data)
        {
            Data = data;
        }

        public void OnGet()
        {
            // Add your logic here
        }
    }
}
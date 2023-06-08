using ENT0701.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ENT0701.Pages.Components
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EjercicioSeleccionModel : PageModel
    {
        private readonly ILogger<EjercicioSeleccionModel> _logger;

        public readonly BikeStoresDB Data;

        public EjercicioSeleccionModel(BikeStoresDB data)
        {
            Data = data;
        }

        public List<string[]> GetBrandProductList(string brandName, string filterOption)
        {
            var query = new List<string[]>();
            if (filterOption == "less1000")
            {
                query = (from Brands in Data.Brands
                        join Products in Data.Products
                            on Brands.BrandId equals Products.BrandId
                        join Stocks in Data.Stocks
                            on Products.ProductId equals Stocks.ProductId
                        where Brands.BrandName == brandName && Products.ListPrice < 1000
                        select new string[] { Brands.BrandName, Products.ProductName, Products.ModelYear.ToString(), Stocks.Quantity.ToString() , Products.ListPrice.ToString() + '€' }
                        ).ToList();
            }
            else if (filterOption == "more1000")
                {
                    query = (from Brands in Data.Brands
                            join Products in Data.Products
                                on Brands.BrandId equals Products.BrandId
                            join Stocks in Data.Stocks
                                on Products.ProductId equals Stocks.ProductId
                            where Brands.BrandName == brandName && Products.ListPrice >= 1000
                            select new string[] { Brands.BrandName, Products.ProductName, Products.ListPrice.ToString() + '€' }
                            ).ToList();
                }

            return query;
        }

        public void OnGet()
        {
        }

    }
}

using ENT0701.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

namespace ENT0701.Pages.Components
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class EjercicioAnadirStaffModel : PageModel
    {
        private readonly ILogger<EjercicioAnadirStaffModel> _logger;

        public readonly BikeStoresDB Data;

        public EjercicioAnadirStaffModel(BikeStoresDB data)
        {
            Data = data;
        }

        public List<string[]> GetStaffData()
        {
            var query = ( from Staffs in Data.Staffs
                          join Stores in Data.Stores
                            on Staffs.StoreId equals Stores.StoreId
                          select new string[] {Staffs.StaffId.ToString(), Staffs.FirstName, Staffs.LastName, Staffs.Email, Staffs.Phone, Stores.StoreName }
                        ).ToList();

            return query;
        }

        public void CreateStaffMember(string firstName, string lastName, string staffEmail, string staffPhone, string storeName)
        {
            int storeId = (from Stores in Data.Stores
                           where Stores.StoreName == storeName
                           select Stores.StoreId).FirstOrDefault();

            Staffs newStaff = new Staffs
            {
                FirstName = firstName,
                LastName = lastName,
                Email = staffEmail,
                Phone = staffPhone,
                StoreId = storeId,
                Active = 1 //Staff esta activo de base
            };

            Data.Staffs.Add(newStaff);
            Data.SaveChanges();
        }

        public bool ValidateEmptyNullEmpty(string inputString)
        {
            return !string.IsNullOrEmpty(inputString);
        }

        public bool ValidateStaffSurname(string staffSurname)
        {
            return !string.IsNullOrEmpty(staffSurname);
        }

        public bool ValidateStaffEmail(string staffEmail)
        {
            return !string.IsNullOrEmpty(staffEmail) && IsValidEmail(staffEmail);
        }

        public bool ValidateStaffPhone(string staffPhone)
        {
            return !string.IsNullOrEmpty(staffPhone) && IsValidPhoneNumber(staffPhone);
        }

        public bool ValidateStoreName(string storeName)
        {
            return !string.IsNullOrEmpty(storeName);
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; //Sacado de templates de filtro de email
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^\(\d{3}\) \d{3}-\d{4}$"; //Sacado de templates de filtro de este tipo de numero de telefonos estadounideses
            return Regex.IsMatch(phoneNumber, phonePattern);
        }
        public void OnGet()
        {
        }
    }
}

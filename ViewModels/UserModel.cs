using Microsoft.AspNetCore.Mvc.Rendering;
namespace MP1.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public int City { get; set; }

        public IEnumerable<SelectListItem> CityList { get; set; }
    }
}

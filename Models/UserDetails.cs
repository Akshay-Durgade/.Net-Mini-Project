using Microsoft.Data.SqlClient;
using System.Data;
namespace MP1.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string EmailId { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public static void Insert(UserDetails u)
        {
            SqlConnection cn=new SqlConnection();
        }
    }
}

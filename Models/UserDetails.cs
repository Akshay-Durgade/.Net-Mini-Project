using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
namespace MP1.Models
{
    public class UserDetails
    {
        [Key]
        [Display(Name = "Student Id")]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Student User Name")]
        [Required(ErrorMessage = "Please enter Login name")]
        public string UserName { get; set; }


        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(30, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please enter emailId")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?([6-9]{1})\)?([0-9]{9})$",
                  ErrorMessage = "Entered valid phone number.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select Degree")]
        public int City { get; set; }

        public static void Insert(UserDetails u)
        {
            Console.WriteLine("3");
            SqlConnection cn=new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Project;Integrated Security=True;";
            try
            {
                Console.WriteLine("4");
                cn.Open();
                SqlCommand insert = new SqlCommand();
                insert.Connection = cn;
                insert.CommandType = CommandType.StoredProcedure;
                insert.CommandText="InsertUser";
                insert.Parameters.AddWithValue("@UserName", u.UserName);
                insert.Parameters.AddWithValue("@FullName", u.FullName);
                insert.Parameters.AddWithValue("@Password", u.Password);
                insert.Parameters.AddWithValue("@Gender", u.Gender);
                insert.Parameters.AddWithValue("@EmailId", u.EmailId);
                insert.Parameters.AddWithValue("@City", u.City);
                insert.Parameters.AddWithValue("@PhoneNumber", u.PhoneNumber);
                insert.ExecuteNonQuery();
                Console.WriteLine("5");
                Console.WriteLine("Query Worked Entry Inserted");
                Console.WriteLine("6" +
                    "");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { cn.Close(); }    
        }

        public static List<UserDetails> DisplayAll()
        {
            List<UserDetails> list = new List<UserDetails>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Project;Integrated Security=True;";
            try
            {
                
                Console.WriteLine("4");
                cn.Open();
                SqlCommand insert = new SqlCommand();
                insert.Connection = cn;
                insert.CommandType = CommandType.StoredProcedure;
                insert.CommandText = "DisplayAll";
                SqlDataReader dr = insert.ExecuteReader();
                while (dr.Read())
                    list.Add(new UserDetails { Id = dr.GetInt32("Id"), UserName = dr.GetString("UserName"), FullName = dr.GetString("FullName"), Gender= dr.GetString("Gender"), EmailId = dr.GetString("EmailId"), City= dr.GetInt32("City"), PhoneNumber = dr.GetString("PhoneNumber")});
                /*return list;*/
                dr.Close();
                return list;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally
            {

                cn.Close(); 

            }
            return list;

        }

        public static UserDetails DisplaySingleDetails(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Project;Integrated Security=True;";
            UserDetails u=new UserDetails();
            try
            {

                Console.WriteLine("4");
                cn.Open();
                SqlCommand insert = new SqlCommand();
                insert.Connection = cn;
                insert.CommandType = CommandType.StoredProcedure;
                insert.CommandText = "DisplaySingleData";
                insert.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = insert.ExecuteReader();
                if (dr.Read())
                {
                    u.Id = dr.GetInt32("Id");
                    u.FullName=dr.GetString("FullName");
                    u.UserName = dr.GetString("UserName");
                    u.Gender = dr.GetString("Gender");
                    u.EmailId = dr.GetString("EmailId");
                    u.City = dr.GetInt32("City");
                    u.PhoneNumber = dr.GetString("PhoneNumber");
                }
                    /*return list;*/
                dr.Close();
                return u;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally
            {
                cn.Close();

            }
            return u;
        }

        public static void DeleteUser(int id) 
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Project;Integrated Security=True;";
            UserDetails u = new UserDetails();
            try
            {

                Console.WriteLine("4");
                cn.Open();
                SqlCommand insert = new SqlCommand();
                insert.Connection = cn;
                insert.CommandType = CommandType.StoredProcedure;
                insert.CommandText = "DeleteUser";
                insert.Parameters.AddWithValue("@Id", id);
                SqlDataReader dr = insert.ExecuteReader();
                if (dr.Read())
                {
                    u.Id = dr.GetInt32("Id");
                    u.FullName = dr.GetString("FullName");
                    u.UserName = dr.GetString("UserName");
                    u.Gender = dr.GetString("Gender");
                    u.EmailId = dr.GetString("EmailId");
                    u.City = dr.GetInt32("City");
                    u.PhoneNumber = dr.GetString("PhoneNumber");
                }
                /*return list;*/
                dr.Close();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally
            {
                cn.Close();

            }
        }

        public static UserDetails DisplayLogin(String username, String password)
        {
            Console.WriteLine(username+"Inside UserDetails");
            Console.WriteLine(password + "Inside UserDetails");
            UserDetails u = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Project;Integrated Security=True;";
            
            try
            {

                Console.WriteLine("4");
                cn.Open();
                SqlCommand insert = new SqlCommand();
                insert.Connection = cn;
                insert.CommandType = CommandType.StoredProcedure;
                insert.CommandText = "LoginData";
                insert.Parameters.AddWithValue("@UserName", username);
                insert.Parameters.AddWithValue("@Password", password);
                SqlDataReader dr = insert.ExecuteReader();
                if (dr.Read())
                {
                    u=new UserDetails();
                    u.Id = dr.GetInt32("Id");
                    u.FullName = dr.GetString("FullName");
                    u.UserName = dr.GetString("UserName");
                    u.Gender = dr.GetString("Gender");
                    u.EmailId = dr.GetString("EmailId");
                    u.City = dr.GetInt32("City");
                    u.PhoneNumber = dr.GetString("PhoneNumber");
                }
                /*return list;*/
                dr.Close();
                return u;
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally
            {
                cn.Close();

            }
            return u;
            
        }

        public static void UpdateUser(UserDetails u)
        {

            Console.WriteLine("Update SQL Block Entered");
            SqlConnection cn = new SqlConnection();
            Console.WriteLine(u.UserName+"Username");
            cn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Project;Integrated Security=True;";
            try
            {
                Console.WriteLine("4");
                cn.Open();
                SqlCommand insert = new SqlCommand();
                insert.Connection = cn;
                insert.CommandType = CommandType.StoredProcedure;
                insert.CommandText = "UpdateUser";
                insert.Parameters.AddWithValue("@Id", u.Id);
                insert.Parameters.AddWithValue("@UserName", u.UserName);
                insert.Parameters.AddWithValue("@FullName", u.FullName);
                insert.Parameters.AddWithValue("@Gender", u.Gender);
                insert.Parameters.AddWithValue("@EmailId", u.EmailId);
                insert.Parameters.AddWithValue("@City", u.City);
                insert.Parameters.AddWithValue("@PhoneNumber", u.PhoneNumber);
                insert.ExecuteNonQuery();
                Console.WriteLine("5");
                Console.WriteLine("Query Worked Entry Inserted");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { cn.Close(); }
        }
    }
}

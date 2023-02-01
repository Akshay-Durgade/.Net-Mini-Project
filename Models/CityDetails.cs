using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MP1.Models
{
    public class CityDetails
    {
        public int CityId { get; set; }
        public string CityName { get; set; }

        public static List<SelectListItem> GetAllList()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Project;Integrated Security=True;";
            try
            {
                Console.WriteLine("4");
                cn.Open();
                SqlCommand insert = new SqlCommand();
                insert.Connection = cn;
                insert.CommandType = CommandType.StoredProcedure;
                insert.CommandText = "DisplayAllCity";
                SqlDataReader dr = insert.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new SelectListItem(dr.GetString("CityName"),dr.GetInt32("CityId").ToString()));
                }

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
    }
}

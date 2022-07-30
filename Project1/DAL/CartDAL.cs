using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Project1.Models;

namespace Project1.DAL
{
    public class CartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public CartDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);

        }
        private bool CheckCartData(Cart c)
        {

            return true;
        }
        public int AddToCart(Cart cart)
        {
            bool result = CheckCartData(cart);
            if (result == true)
            {
                string qry = "insert into Cart values(@Uid,@Id)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@Uid", cart.Uid);
                cmd.Parameters.AddWithValue("@Id", cart.Id);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            else
            {
                return 2;
            }
        }
        public List<Product> ViewFromCart(string Uid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.Id,p.Name,p.Price, p.Company, c.Cid,c.Uid from Product p " +
                        " inner join Cart c on c.Id = p.Id " +
                        " where c.Uid = @Uid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Uid", Convert.ToInt32(Uid));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Company = dr["Company"].ToString();
                    p.Price = Convert.ToInt32(dr["Price"]);
                   
                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
           
            else
            {
                return plist;

            }
        }
      
        public int RemoveFromCart(int Cid)
        {

            string qry = "delete from Cart where Cid=@Cid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Cid", Cid);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;


        }
    }
}

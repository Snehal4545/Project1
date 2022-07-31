using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.DAL
{
    public class OrderDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public OrderDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        private bool CheckOrderData(Order or)
        {

            return true;
        }
        public int PlaceOrder(Order or)
        {
            bool result = CheckOrderData(or);
            if (result == true)
            {
                string qry = "insert into Orders(Id,Uid) values(@Id,@Uid)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("Id", or.Id);
                cmd.Parameters.AddWithValue("@Uid", or.Uid);

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

        public List<Product> ViewProductForOrder(string Uid)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.Id,p.Name,p.Price, o.Oid,O.Uid from Product p " +
                        " inner join Orders o on o.Id = p.Id " +
                        " where o.Uid = @Oid";
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
                    p.Price = Convert.ToInt32(dr["Price"]);
                    p.Id = Convert.ToInt32(dr["Oid"]);
                    p.Uid = Convert.ToInt32(dr["Uid"]);
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
        public int RemoveFromOrders(int Oid)
        {

            string qry = "delete from Orders where Oid=@Oid";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Oid", Oid);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security;
using System.Data.SqlClient;
using Project1.Models;

namespace Project1.DAL
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ProductDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> plist = new List<Product>();
            string qry = "select * from Product";
            cmd = new SqlCommand(qry, con);
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
            }
            con.Close();
            return plist;
        }
        public Product GetProductById(int Id)
        {
            Product p = new Product();
            string qry = "select * from Product where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.Id = Convert.ToInt32(dr["Id"]);
                    p.Name = dr["Name"].ToString();
                    p.Company = dr["Company"].ToString();
                    p.Price = Convert.ToInt32(dr["Price"]);
                }
            }
            con.Close();
            return p;
        }

        public int AddProduct(Product prod)
        {
            string qry = "insert into Product values(@Name,@Company,@Price)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@Name", prod.Name);
            cmd.Parameters.AddWithValue("@Company", prod.Company);
            cmd.Parameters.AddWithValue("@Price", prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int UpdateProduct(Product prod)
        {
            string qry = "update Product set Name=@Name,Company=@Company ,Price=@price where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", prod.Id);
            cmd.Parameters.AddWithValue("@Name", prod.Name);
            cmd.Parameters.AddWithValue("@Company", prod.Company);
            cmd.Parameters.AddWithValue("@Price", prod.Price);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public int DeleteProduct(int Id)
        {
            string qry = "delete from Product where Id=@Id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@Id", Id);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }



    }
}

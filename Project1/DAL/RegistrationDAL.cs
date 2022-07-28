using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.DAL
{
    public class RegistrationDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
       
        public RegistrationDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }

        public int Registration(Registration reg)
        {
            string qry = "insert into Users(Name,EmailId,Password) values(@Name,@EmailId,@Password)";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@Name", reg.Name);
            cmd.Parameters.AddWithValue("@EmailId", reg.EmailId);
            cmd.Parameters.AddWithValue("@Password", reg.Password);
            cmd.Parameters.AddWithValue("@RoleId", reg.RoleId);
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
        public Registration LogIn(Registration log)
        {
            Registration r = new Registration();
            string qry = " select * from Users where EmailId=@EmailId";
            cmd = new SqlCommand(qry, con);

            cmd.Parameters.AddWithValue("@EmailId", log.EmailId);

            con.Open();
            dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    r.Uid = Convert.ToInt32(dr["Uid"]);
                    r.Name = dr["Name"].ToString();
                    r.EmailId = dr["EmailId"].ToString();
                    r.Password = dr["Password"].ToString();
                    r.RoleId = Convert.ToInt32(dr["RoleId"]);
                }
                con.Close();
                return r;

            }
            else
            {
                return r;
            }
            
            
        }




    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.IdentityModel.Protocols;

namespace VGTSERVER1
{
    public class UserInterface
    {
        string connectionString = "Data Source=DESKTOP-AVCRPLB\\SQLEXPRESS;Initial Catalog=VGTBD;Integrated Security=True";
        public UserInterface(string Login,string Password)
        {
            
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"INSERT INTO Users VALUES('{Login}', '{Password}')");
            }
            
        }

        public User Get(string login)
        {
            User user = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                user = db.Query<User>("SELECT * FROM Users WHERE Login = @login", new { login }).FirstOrDefault();
            }
            return user;
        }

        public User Create(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
            }
            return user;
        }

  
    }
}

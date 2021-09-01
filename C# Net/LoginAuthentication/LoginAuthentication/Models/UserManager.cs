using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Security;
using Logging;

namespace LoginAuthentication.Models
{
    public class UserManager
    {
        //const string ConnString = @"server=MYPC/SQL;database=RetailSecurity;trusted_connection=true";
        const string ConnString = @"Data Source = localhost\SQL; Initial Catalog = RetailSecurity; Integrated Security = True";
        public static void Register(User user)
        {
            try
            {
                //hash the password
                var hashedPW = Hashing.HashPassword(user.Password);

                using (var conn = new SqlConnection(ConnString))
                {
                    var comm = new SqlCommand("INSERT INTO Users(Username,Password) VALUES(@user,@pass)", conn);
                    comm.Parameters.Add("@user", System.Data.SqlDbType.VarChar).Value = user.Username;
                    comm.Parameters.Add("@pass", System.Data.SqlDbType.VarChar).Value = hashedPW;
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
                Logger.Instance.Information($"{user.Username} has registered");
               
            }
            catch (Exception ex)
            {
                //log error
                Logger.Instance.Critical($"Error occured in UserManager.Register: {ex.Message}");
            }
        }

        public static User Authenticate(User user)
        {
            string dbPassword = null;
            try
            {
                //get the user from the db using the username
                using (var conn = new SqlConnection(ConnString))
                {
                    var comm = conn.CreateCommand();
                    comm.CommandText = "SELECT * FROM Users WHERE Username = @user";
                    comm.Parameters.Add("@user", System.Data.SqlDbType.VarChar).Value = user.Username;
                    conn.Open();
                    using (var reader = comm.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user.ID = reader.GetInt32(0);
                            user.Username = reader.GetString(1);
                            dbPassword = reader.GetString(2);
                        }
                    }
                }
                //verify the hashed password
                if (Hashing.ValidatePassword(user.Password, dbPassword))
                {
                    //log
                    Logger.Instance.Information($"{user.Username} passed authentication");
                    return user;
                }
                else
                {
                    //log
                    Logger.Instance.Error($"{user.Username} failed authentication");

                    //parse the log file - 


                    return null;
                }
            }
            catch (Exception ex)
            {
                //log
                Logger.Instance.Critical($"Error occured in UserManager.Authenticate: {ex.Message}");
                return null;
            }
        }
    }
}

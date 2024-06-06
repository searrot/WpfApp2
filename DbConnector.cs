using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using MySqlConnector;

namespace WpfApp2
{
    internal static class DbConnector
    {
        private static readonly string ConnStr = "Server=localhost;DataBase=ekzDb;port=3306;User Id=ivan;password=Testpass123";
        private static readonly MySqlConnection Conn = new MySqlConnection(ConnStr);

        static DbConnector()
        {
            Conn.Open();
        }

        public static long AddUser(User user)
        {
            try
            {
                try
                {
                    Conn.Open();
                }
                catch { }
                var cmd = Conn.CreateCommand();
                cmd.CommandText = "INSERT INTO `users` (login, password) VALUES (@l, @p)";
                cmd.Parameters.Add(new MySqlParameter("@l", user.Login));
                cmd.Parameters.Add(new MySqlParameter("@p", user.Password));
                cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally { Conn.Close(); }
        }

        public static long AddStats(Stats stats)
        {
            try
            {
                try
                {
                    Conn.Open();
                }
                catch { }
                var cmd = Conn.CreateCommand();
                cmd.CommandText = "INSERT INTO `online_stats` (login_time, logout_time) VALUES (@l, @p)";
                cmd.Parameters.Add(new MySqlParameter("@l", stats.LoginTime));
                cmd.Parameters.Add(new MySqlParameter("@p", stats.LogoutTime));
                cmd.ExecuteNonQuery();
                return cmd.LastInsertedId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            finally { Conn.Close(); }
        }

        public static bool Check(User user)
        {
            try
            {
                Conn.Open();
            }
            catch { }
            
            var cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT password FROM `users` WHERE login = @l";
            cmd.Parameters.Add(new MySqlParameter("@l", user.Login));
            var res = cmd.ExecuteReader();
            try
            {
                while (res.Read())
                {
                    var value = res.GetString(0);
                    if (value is string pass)
                    {
                        if (user.Password == pass)
                        {

                            return true;
                        }
                    }
                }

                return false;

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
            finally
            {
                 Conn.Close();
            }
        }
    }
}

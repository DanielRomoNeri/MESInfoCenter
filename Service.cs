using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MESInfoCenter.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace MESInfoCenter
{
    
    internal class Service
    {

    

        public static bool addApp(string appName, string appPath, string guidePath, string imagePath, string image2Path, string repoPath, string appDescription, int createdBy)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query =
                    "INSERT INTO apps (appName, appPath, guidePath, imagePath, image2Path, repoPath, appDescription, createdBy, updatedBy) VALUES (@appName, @appPath, @guidePath, @imagePath, @image2Path, @repoPath, @appDescription, @createdBy, @updatedBy)";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@appName", appName);
                    cmd.Parameters.AddWithValue("@appPath", appPath);
                    cmd.Parameters.AddWithValue("@guidePath", guidePath);
                    cmd.Parameters.AddWithValue("@imagePath", imagePath);
                    cmd.Parameters.AddWithValue("@image2Path", image2Path);
                    cmd.Parameters.AddWithValue("@repoPath", repoPath);
                    cmd.Parameters.AddWithValue("@appDescription", appDescription);
                    cmd.Parameters.AddWithValue("@createdBy", createdBy);
                    cmd.Parameters.AddWithValue("@updatedBy", createdBy);



                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static void updateApp(int ID)
        {

        }

        public static void deleteApp(int ID) 
        {

        }

        public static List<Apps> getAppList()
        {
            List<Apps> apps = new List<Apps>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT appID, appName, appPath, guidePath, imagePath, image2Path, repoPath, appDescription FROM apps";
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        apps.Add(new Apps
                        {
                            appID = reader.GetInt32("appID"),
                            appName = reader.GetString("appName"),
                            appPath = reader.GetString("appPath"),
                            guidePath = reader.GetString("guidePath"),
                            imagePath = reader.GetString("imagePath"),
                            image2Path = reader.GetString("image2Path"),
                            repoPath = reader.GetString("repoPath"),
                            appDescription = reader.GetString("appDescription"),

                        });
                    }
                }
            }
            return apps;
        }

        public static void getAppByID(int ID)
        {

        }
        public static void addTroubleShooting()
        {

        }

        public static List<TroubleShooting> getTroubleShootingList(int appID)
        {
            List<TroubleShooting> troubleShootings = new List<TroubleShooting>();
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT tsTitle, tsErrorTag, tsDescription, tsSolution FROM troubleshooting WHERE appID = @appID";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@appID", appID);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        troubleShootings.Add(new TroubleShooting
                        {
                            tsTitle = reader.GetString("tsTitle"),
                            tsErrorTag = reader.GetString("tsErrorTag"),
                            tsDescription = reader.GetString("tsDescription"),
                            tsSolution = reader.GetString("tsSolution"),
            

                        });
                    }
                }
            }
            return troubleShootings;
        }

        public static void getTroubleShootingDataByID(int ID)
        {

        }

        //public static User validateUser(string userName, string password)
        //{
        //    using (var conn = DBConnection.GetConnection())
        //    {

        //        conn.Open();
        //        string query = "SELECT userID, password, role FROM mesinfocenter.users WHERE userName = @username";
        //        using (var cmd = new MySqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@username", userName);
        //            var result = cmd.ExecuteReader();
        //            if (result.Read())
        //            {
                       
        //            }
        //            else
        //            {

        //            }

        //            return result != null && password == result.ToString();
        //        }
        //    }

        //}
    }


}

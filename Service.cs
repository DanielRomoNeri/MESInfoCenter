using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MESInfoCenter.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.IO;

namespace MESInfoCenter
{
    
    internal class Service
    {

    

        public static bool addApp(string appName, string appPath, string guidePath, string imagePath, string image2Path, string repoPath, string appDescription, int createdBy, string lastVersion)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query =
                        "INSERT INTO apps (appName, appPath, guidePath, imagePath, image2Path, repoPath, appDescription, createdBy, updatedBy, lastVersion) " +
                        "VALUES (@appName, @appPath, @guidePath, @imagePath, @image2Path, @repoPath, @appDescription, @createdBy, @updatedBy, @lastVersion)";
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
                        cmd.Parameters.AddWithValue("@lastVersion", lastVersion);




                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
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
            try
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
            catch (Exception e)
            {

                MessageBox.Show($"Ocurrió un error al intentar acceder a la base de datos:\n {e}");            
                return null;
            }
        }

        public static bool addTroubleShooting(int appID, string tsTitle, string tsErrorTag, string tsDescription, string tsSolution)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query =
                        "INSERT INTO troubleshooting (appID, tsTitle, tsErrorTag, tsDescription, tsSolution) " +
                        "VALUES (@appID, @tsTitle, @tsErrorTag, @tsDescription, @tsSolution)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appID", appID);
                        cmd.Parameters.AddWithValue("@tsTitle", tsTitle);
                        cmd.Parameters.AddWithValue("@tsErrorTag", tsErrorTag);
                        cmd.Parameters.AddWithValue("@tsDescription", tsDescription);
                        cmd.Parameters.AddWithValue("@tsSolution", tsSolution);





                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public static List<TroubleShooting> getTroubleShootingList(int appID)
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show($"Ocurrió un error al intentar acceder a la base de datos:\n {e}");
                return null;
            }
        }


        public static bool validateUser(string userName, string password)
        {
            using (var conn = DBConnection.GetConnection())
            {
                
                conn.Open();
                string passwordDB;
                string query = "SELECT userID, userName, password, role FROM mesinfocenter.users WHERE userName = @username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        User.userID = reader.GetInt32("userID");
                        User.userName = reader.GetString("userName");
                        User.role = reader.GetString("role");
                        passwordDB = reader.GetString("password");
                    }
                    else
                    {
                        return false;
                    }

                    return passwordDB == password;
                }
            }

        }

        public static string saveGuide(string originPath, string appName)
        {
            appName = appName.Replace(" ", "_").Replace("-", "_").Replace(".", "_");
            string folder = $@"\\gumfp01\group\programs\LABVIEW\MES (RUNCARD)\A. Production Apps\MESInfoCenter\AppsResources\app_{appName}\guia"; // Ruta donde se guardará la guia
            string fileExtension = Path.GetExtension(originPath);
            string fileName = $@"\{appName}_guia{fileExtension}";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string newPath = Path.Combine(folder, fileName);
            File.Copy(originPath, newPath, true);
            MessageBox.Show("Guia guardada");
            return newPath;
        }

        public static string saveImage(string originPath, string appName)
        {
            appName = appName.Replace(" ", "_").Replace("-", "_").Replace(".", "_");
            string folder = $@"\\gumfp01\group\programs\LABVIEW\MES (RUNCARD)\A. Production Apps\MESInfoCenter\AppsResources\app_{appName}\imagenes"; // Ruta donde se guardará la imagen
            string fileExtension = Path.GetExtension(originPath);
            string fileName = $@"\image1{fileExtension}";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string newPath = Path.Combine(folder, fileName);
            File.Copy(originPath, newPath, true);
            MessageBox.Show("Imagen guardada");
            return newPath;
        }

        public static string saveImage2(string originPath, string appName)
        {
            appName = appName.Replace(" ", "_").Replace("-", "_").Replace(".", "_");
            string folder = $@"\\gumfp01\group\programs\LABVIEW\MES (RUNCARD)\A. Production Apps\MESInfoCenter\AppsResources\app_{appName}\imagenes"; // Ruta donde se guardará la imagen
            string fileExtension = Path.GetExtension(originPath);
            string fileName = $@"\image2{fileExtension}";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string newPath = Path.Combine(folder, fileName);
            File.Copy(originPath, newPath, true);
            MessageBox.Show("Imagen guardada");
            return newPath;
        }

    }


}

using System;
using System.Collections.Generic;
using MySqlConnector;
using MESInfoCenter.Models;
using System.Windows.Forms;
using System.IO;

namespace MESInfoCenter
{

    internal class Service
    {

    

        public static bool addApp(
            string appName, string appAuthorName, string appPath, string guidePath,
            string imagePath, string image2Path, string repoPath, string appDescription,
            int createdBy, string lastVersion)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query =
                        "INSERT INTO apps (appName, appAuthorName, appPath, guidePath, imagePath, image2Path, repoPath, appDescription, createdBy, updatedBy, lastVersion) " +
                        "VALUES (@appName, @appAuthorName, @appPath, @guidePath, @imagePath, @image2Path, @repoPath, @appDescription, @createdBy, @updatedBy, @lastVersion)";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appName", appName);
                        cmd.Parameters.AddWithValue("@appAuthorName", appAuthorName);
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

        public static bool isNameRepeated(string appName)
        {
            using (var conn = DBConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT appName FROM mesinfocenter.apps WHERE appName = @appName";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@appName", appName);
                    var result = cmd.ExecuteScalar();
                    return result != null;
                }
           
                
                
            }
        }

        public static bool updateApp(int appID, string appName, string appAuthorName, string appPath, string guidePath,
            string imagePath, string image2Path, string repoPath, string appDescription,
            int updatedBy, string lastVersion)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query =
                        "UPDATE mesinfocenter.apps SET appName = @appName, appAuthorName = @appAuthorName, appPath = @appPath, " +
                        "guidePath = @guidePath, imagePath = @imagePath, image2Path = @image2Path, repoPath = @repoPath, " +
                        "appDescription = @appDescription, updatedBy = @updatedBy, lastVersion = @lastVersion " +
                        "WHERE appID = @appID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appName", appName);
                        cmd.Parameters.AddWithValue("@appAuthorName", appAuthorName);
                        cmd.Parameters.AddWithValue("@appPath", appPath);
                        cmd.Parameters.AddWithValue("@guidePath", guidePath);
                        cmd.Parameters.AddWithValue("@imagePath", imagePath);
                        cmd.Parameters.AddWithValue("@image2Path", image2Path);
                        cmd.Parameters.AddWithValue("@repoPath", repoPath);
                        cmd.Parameters.AddWithValue("@appDescription", appDescription);
                        cmd.Parameters.AddWithValue("@updatedBy", updatedBy);
                        cmd.Parameters.AddWithValue("@lastVersion", lastVersion);
                        cmd.Parameters.AddWithValue("@appID", appID); 

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public static bool deleteTS(int tsID)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM mesinfocenter.troubleshooting WHERE tsID = @tsID";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tsID", tsID);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public static bool deleteApp(int appID) 
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM mesinfocenter.apps WHERE appID = @appID"; 

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appID", appID); 

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public static List<Apps> getAppList()
        {
            try
            {
                List<Apps> apps = new List<Apps>();
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT appID, appName, appAuthorName, appPath, guidePath, imagePath, image2Path, repoPath, appDescription, lastVersion FROM mesinfocenter.apps";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            apps.Add(new Apps
                            {
                                appID = reader.GetInt32("appID"),
                                appName = reader.GetString("appName"),
                                appAuthorName = reader.GetString("appAuthorName"),
                                appPath = reader.GetString("appPath"),
                                guidePath = reader.GetString("guidePath"),
                                imagePath = reader.GetString("imagePath"),
                                image2Path = reader.GetString("image2Path"),
                                repoPath = reader.GetString("repoPath"),
                                appDescription = reader.GetString("appDescription"),
                                lastVersion = reader.GetString("lastVersion")

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
                    string query = "SELECT tsID, appID, tsTitle, tsErrorTag, tsDescription, tsSolution FROM troubleshooting WHERE appID = @appID";
                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@appID", appID);
                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            troubleShootings.Add(new TroubleShooting
                            {
                                tsID = reader.GetInt32("tsID"),
                                appID = reader.GetInt32("appID"),
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
                string query = "SELECT userID, fullName, userName, password, role FROM mesinfocenter.users WHERE userName = @username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", userName);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        User.userID = reader.GetInt32("userID");
                        User.fullName = reader.GetString("fullName");
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

        public static string saveGuide(string originPath, string folderName)
        {
            string folder = $@"\\gumfp01\group\programs\LABVIEW\MES (RUNCARD)\A. Production Apps\MESInfoCenter\AppsResources\app_{folderName}\guia"; // Ruta donde se guardará la imagen
            string fileExtension = Path.GetExtension(originPath);
            string fileName = $"guia{fileExtension}";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string newPath = Path.Combine(folder, fileName);
            File.Copy(originPath, newPath, true);
            //MessageBox.Show("Guía guardada");
            return newPath;
        }

        public static string saveImage(string originPath, string folderName)
        {
            string folder = $@"\\gumfp01\group\programs\LABVIEW\MES (RUNCARD)\A. Production Apps\MESInfoCenter\AppsResources\app_{folderName}\imagenes"; // Ruta donde se guardará la imagen
            string fileExtension = Path.GetExtension(originPath);
            string fileName = $"image1{fileExtension}";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string newPath = Path.Combine(folder, fileName);
            File.Copy(originPath, newPath, true);
            //MessageBox.Show("Imagen guardada");
            return newPath;
        }

        public static string saveImage2(string originPath, string folderName)
        {
            string folder = $@"\\gumfp01\group\programs\LABVIEW\MES (RUNCARD)\A. Production Apps\MESInfoCenter\AppsResources\app_{folderName}\imagenes"; // Ruta donde se guardará la imagen
            string fileExtension = Path.GetExtension(originPath);
            string fileName = $"image2{fileExtension}";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string newPath = Path.Combine(folder, fileName);
            File.Copy(originPath, newPath, true);
            //MessageBox.Show("Imagen2 guardada");
            return newPath;
        }

    }


}

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace OrganiserApp.Services
{
    public static class SettingsService
    {

        

        #region public methods

        /// <summary>
        /// Serialize username to xml file
        /// </summary>
        /// <param name="login"> Typed user login</param>
        public static void Serialize(string login)
        {
            XmlSerializer writer = new XmlSerializer(typeof(string));
            var path = Directory.GetCurrentDirectory() + Resources.LoginFileName;
            FileStream file = File.Create(path);
            writer.Serialize(file, login);
            file.Close();
        }

        /// <summary>
        /// Deserialize xml file to username
        /// </summary>
        /// <returns>Saved username if not exist returns empty string</returns>
        public static string Deserialize()
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(string));
                var path = Directory.GetCurrentDirectory() + Resources.LoginFileName;
                FileStream file = File.OpenRead(path);
                string login = writer.Deserialize(file).ToString();
                file.Close();
                return login;
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Delete saved login data
        /// </summary>
        public static void DeleteSerialized()
        {
            XmlSerializer writer = new XmlSerializer(typeof(string));
            var path = Directory.GetCurrentDirectory() + Resources.LoginFileName;
            File.Delete(path);
        }

        #endregion
    }
}

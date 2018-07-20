using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace RetroPieGamelistCleaner
{
    class Settings
    {
        private string appDir = Path.GetDirectoryName(Application.ExecutablePath);
        private string customPath;
        private string defaultFilename = "settings.cfg";

        private ExeConfigurationFileMap configFileMap;
        private Configuration configFile;
        private KeyValueConfigurationCollection settings;

        public enum Type
        {
            Integer,
            Decimal,
            TimeSpan,
            Float,
            Double,
            Boolean,
            String
        }

        public Settings()
        {
            customPath = Path.Combine(appDir, defaultFilename);
        }

        public string ConfigFile
        {
            set 
            {
                if (value != null)
                {
                    try
                    {
                        string dir = Path.GetDirectoryName(value);
                        string file = Path.GetFileName(value);

                        if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                        customPath = Path.Combine(dir, file);
                    }

                    catch { }
                }
            }

            get
            {
                return customPath;
            }

        }

        public void OpenSettings()
        {
            try
            {
                configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                settings = configFile.AppSettings.Settings;
            }

            catch { }
        }

        public void WriteSettings()
        {
            try
            {
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }

            catch { }
        }

        public string GetSetting(string key)
        {
            return GetSetting(key, Type.String, "");
        }

        public dynamic GetSetting(string key, Type type, string def)
        {
            string result;

            try
            {
                result = settings[key].Value ?? null;
            }

            catch (Exception ex)
            {
                result = null;
            }

            if (type == Type.Integer)
            {
                if (result == null) return Convert.ToInt32(def);
                else return Convert.ToInt32(result);
            }

            if (type == Type.Decimal)
            {
                if (result == null) return Convert.ToDecimal(def);
                else return Convert.ToDecimal(result);
            }

            if (type == Type.TimeSpan)
            {
                if (result == null) return TimeSpan.Parse(def);
                else return TimeSpan.Parse(result);
            }

            if (type == Type.Float)
            {
                if (result == null) return float.Parse(def);
                else return float.Parse(result);
            }

            if (type == Type.Double)
            {
                if (result == null) return double.Parse(def, CultureInfo.InvariantCulture);
                else return double.Parse(result, CultureInfo.InvariantCulture);
            }

            if (type == Type.Boolean)
            {
                if (result == null) return Convert.ToBoolean(def);
                else return Convert.ToBoolean(result);
            }

            if (type == Type.String)
            {
                if (result == null) return def;
                else return result;
            }

            else return result;
        }

        public void SetSetting(string key, string value)
        {
            try
            {
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
            }

            catch { }
        }

        public void EraseSetting(string key)
        {
            try
            {
                if (settings[key] != null) settings.Remove(key);
            }

            catch { }
        }

        public string LoadSetting(string key)
        {
            return LoadSetting(key, Type.String, "");
        }

        public dynamic LoadSetting(string key, Type type, string def)
        {
            string result;

            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                Configuration configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                KeyValueConfigurationCollection settings = configFile.AppSettings.Settings;

                try
                {
                    result = settings[key].Value ?? null;
                }

                catch
                {
                    result = null;
                }
            }

            catch
            {
                result = null;
            }

            if (type == Type.Integer)
            {
                if (result == null) return Convert.ToInt32(def);
                else return Convert.ToInt32(result);
            }

            if (type == Type.Decimal)
            {
                if (result == null) return Convert.ToDecimal(def);
                else return Convert.ToDecimal(result);
            }

            if (type == Type.TimeSpan)
            {
                if (result == null) return TimeSpan.Parse(def);
                else return TimeSpan.Parse(result);
            }

            if (type == Type.Float)
            {
                if (result == null) return float.Parse(def);
                else return float.Parse(result);
            }

            if (type == Type.Double)
            {
                if (result == null) return double.Parse(def, CultureInfo.InvariantCulture);
                else return double.Parse(result, CultureInfo.InvariantCulture);
            }

            if (type == Type.Boolean)
            {
                if (result == null) return Convert.ToBoolean(def);
                else return Convert.ToBoolean(result);
            }

            if (type == Type.String)
            {
                if (result == null) return def;
                else return result;
            }

            else return result;
        }

        public void SaveSetting(string key, string value)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }

            catch { }
        }

        public void EraseSetting2(string key)
        {
            try
            {
                ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
                configFileMap.ExeConfigFilename = customPath;

                var configFile = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;

                if (settings[key] != null)
                {
                    settings.Remove(key);
                }

                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }

            catch { }
        }
    }
}

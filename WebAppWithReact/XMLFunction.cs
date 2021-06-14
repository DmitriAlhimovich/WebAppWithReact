using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;


namespace WebAppWithReact
{
    /// <summary>
    /// Набор функций
    /// </summary>
    public class XMLFunction
    {
        #region Сохранить/Получить данные из XML-файла
        /// <summary>
        /// Сериализация данных в хмл
        /// </summary>        
        public static string SaveInformation(Object obj, string filePath)
        {
            string dir = filePath.Substring(0, filePath.LastIndexOf("\\"));

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string strEx = string.Empty;

            XmlSerializer formatter = new XmlSerializer(typeof(List<Employees>));

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                try
                {
                    if ((obj as List<Employees>) != null)
                    {
                        formatter.Serialize(fs, obj);
                    }
                }
                catch (Exception e)
                {
                    strEx = e.Message.ToString();
                }
            }
            return strEx;
        }

        /// <summary>
        /// Получение данных из xml-файла
        /// </summary>
        public static Object ReadInformation(string filePath, Object obj, out string strEx)
        {
            strEx = string.Empty;
            FileInfo fInfo = new FileInfo(filePath);
            Object returnObj = null;

            if (fInfo.Exists)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Employees>));

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    try
                    {
                        returnObj = (List<Employees>)formatter.Deserialize(fs);
                    }
                    catch (Exception e)
                    {
                        strEx = e.Message.ToString();
                    }
                }
            }
            else
            {
                strEx = String.Format("Не удалось найти файл: {0}! ", fInfo.Name);
            }

            return returnObj;
        }
        #endregion
    }
}
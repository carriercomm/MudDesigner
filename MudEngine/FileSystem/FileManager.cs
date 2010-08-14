﻿//Microsoft .NET Framework
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace MudEngine.FileSystem
{
    /// <summary>
    /// Handles saving and loading of engine objects
    /// </summary>
    public static class FileManager
    {
        public enum OutputFormats
        {
            XML = 0,
        }

        /// <summary>
        /// The filetype that the MUDs files will be saved as
        /// </summary>
        public static OutputFormats FileType
        {
            get;
            set;
        }

        /// <summary>
        /// Writes content out to a file.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void WriteLine(String filename, String value, String name)
        {
            if (!File.Exists(filename))
            {
                FileStream s = File.Create(filename);
                s.Close();
            }

            using (StreamWriter sw = File.AppendText(filename))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(name);
                sb.Append("=");
                sb.Append(value);
                sw.WriteLine(sb.ToString());
                sw.Close();
            }
        }

        public static String GetData(String filename, String name)
        {
            foreach (String line in File.ReadAllLines(filename))
            {
                //Ignore comments
                if (line.StartsWith(";"))
                    continue;

                if (line.StartsWith(name))
                    return line.Substring(name.Length + 1); //Accounts for name=value;
            }

            return "No data Found.";
        }

        /// <summary>
        /// Returns the complete path to the specified data's save folder.
        /// </summary>
        /// <param name="DataType"></param>
        /// <returns></returns>
        public static String GetDataPath(SaveDataTypes DataType)
        {
            String assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName;
            String assemblyName = System.IO.Path.GetFileName(assemblyPath);
            String installBase = assemblyPath.Substring(0, assemblyPath.Length - assemblyName.Length);

            if (DataType == SaveDataTypes.Root)
                return installBase;
            else
                return System.IO.Path.Combine(installBase, DataType.ToString());
        }

        public static String GetDataPath(String Realm, String Zone)
        {
            String assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName;
            String assemblyName = System.IO.Path.GetFileName(assemblyPath);
            String installBase = assemblyPath.Substring(0, assemblyPath.Length - assemblyName.Length);
            String realmsPath = System.IO.Path.Combine(installBase, "Realms");
            String requestRealm = Path.Combine(installBase, Realm);
            String requestedRealmZones = Path.Combine(installBase, "Zones");
            String requestedZone = Path.Combine(installBase, Zone);

            return requestedZone;
        }

        public static String GetDataPath(String Realm, String Zone, String Room)
        {
            return System.IO.Path.Combine(GetDataPath(Realm, Zone), Room);
        }

        //TODO Write CopyDirectory method.
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Data.EntityClient;
using System.Configuration;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UT.Helper
{
    public class cExcel
    {

        public static DataTable ReadExcelFile(string sheetName, string path)
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable dt = new DataTable();
                string Import_FileName = path;
                string fileExtension = Path.GetExtension(Import_FileName);
                if (fileExtension == ".xls")
                    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                if (fileExtension == ".xlsx")
                    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                string query = "Select * from [" + sheetName + "$]";
                using (OleDbDataAdapter da = new OleDbDataAdapter(query, conn))
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public static List<string> GetAllExcelFiles()
        {
            //TODO: look into globbing helperFilesDir for all xlsx files
            List<string> ExcelFiles = new List<string>();
            string exeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string helperFilesDir = Path.GetFullPath(Path.Combine(exeDir, "..\\..\\HelperFiles\\"));
            //Go through each file in the directory and check to see if it is a xlsx file
            foreach (var excelFilename in Directory.EnumerateDirectories(helperFilesDir))
            {
                if ("xlsx".Equals(Path.GetExtension(excelFilename)))
                    ExcelFiles.Add(Path.Combine(helperFilesDir, excelFilename));
            }
            return ExcelFiles;
        }
        public static void InsertProjectData(TestContext testContext)
        {
            RemoveAllData();
            List<string> ExcelFiles = cExcel.GetAllExcelFiles();
            foreach (string excelFile in ExcelFiles)
            {
                Console.WriteLine(String.Format("{0} exists: {1}", excelFile, File.Exists(excelFile)));
                DataTable dt = new DataTable();
                string strSheetName = "Sheet1";
                dt = cExcel.ReadExcelFile(strSheetName, excelFile);
                string connectionString = getConnectionString();
                Console.WriteLine(String.Format("Connection String: {0}", connectionString));
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        setIdentityInsert(command, dt.Rows[0]["Table"].ToString(), "ON");
                        foreach (DataRow row in dt.Rows) // Loop over the rows.
                        {
                            string query = row["Query"].ToString();
                            int numRowsAffected = 0;
                            if (query.Length > 1)
                            {
                                Console.WriteLine(query);
                                command.CommandText = query;
                                numRowsAffected = command.ExecuteNonQuery();
                                if (numRowsAffected != 1)
                                {
                                    Console.WriteLine(String.Format("Query affected {0} rows instead of the expected 1 row.", numRowsAffected));
                                }
                            }
                        }
                        setIdentityInsert(command, dt.Rows[0]["Table"].ToString(), "OFF");
                    }
                }
            }
        }
        public static void RemoveAllData()
        {
            string connectionString = getConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    foreach (string excelFile in cExcel.GetAllExcelFiles())
                    {
                        Console.WriteLine(String.Format("{0} exists: {1}", excelFile, File.Exists(excelFile)));
                        DataTable dt = new DataTable();
                        string strSheetName = "Sheet1";
                        dt = cExcel.ReadExcelFile(strSheetName, excelFile);
                        string table = dt.Rows[0]["Table"].ToString();
                        string query = string.Format("DELETE FROM {0}", table);
                        Console.WriteLine(query);
                        command.CommandText = query;
                        int numRowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine(String.Format("\t{0} rows affected", numRowsAffected));
                    }
                }
            }
        }
        public static string getConnectionString()
        {
            return new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["VolTeerConnectionString"].ConnectionString).ProviderConnectionString;
        }

        public static void setIdentityInsert(SqlCommand command, string table, string value)
        {
            try
            {
                command.CommandText = string.Format("SET IDENTITY_INSERT {0} {1}", table, value);
                command.ExecuteNonQuery();
            }
            catch
            {
            }
        }
    }
}
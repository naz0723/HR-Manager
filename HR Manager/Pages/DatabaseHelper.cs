using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace HRManager.App_code
{
    public class DatabaseHelper
    {
       
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["HRManager"].ConnectionString;
        }

      
        public void LogError(Exception ex)
        {
            string logFilePath = @"C:\PWEB\HR Manager\HR Manager\Errores\database_errors.txt";

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} - Error: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                writer.WriteLine();
            }
        }


        public DataTable ExecuteSelectQuery(string query, SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (sqlParameters != null)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddRange(sqlParameters);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw;
            }
        }

        public int ExecuteNonQuery(string query, SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                       
                        if (sqlParameters != null)
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddRange(sqlParameters);
                        }

                      
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine(ex);
                throw; 
            }
        }


    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DiaryERP.Utils
{
    public static class ConnectionTester
    {
        public static async Task<bool> TestConnectionAsync(string connectionString)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                Debug.Print("Forbindelse oprettet.");
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print("Forbindelse fejlede:");
                Debug.Print(ex.Message);
                return false;
            }
        }
    }
}

using Microsoft.Data.SqlClient;
using System;
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
                Console.WriteLine("Forbindelse oprettet.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Forbindelse fejlede:");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

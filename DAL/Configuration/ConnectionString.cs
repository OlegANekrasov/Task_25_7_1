using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_25_7_1.DAL.Configuration
{
    public static class ConnectionString
    {
        public static string MsSqlConnection => @"Server=.\MSSQLSERVER2019;Initial Catalog=ElectronicLibrary;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;";
    }
}

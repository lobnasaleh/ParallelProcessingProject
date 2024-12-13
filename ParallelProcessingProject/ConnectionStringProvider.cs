using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProcessingProject
{
    internal class ConnectionStringProvider
    {
        public static string ConnectionString { get; } 
            = @"Data Source=localhost;Initial Catalog=ATM;Integrated Security=True;TrustServerCertificate=True";
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrderingApp.Models
{
    internal class FilePath
    {
        public string Path { get; private set; }
        public string File { get; set; }

        public FilePath(string file)
        {
            Path = $@"C:\Users\Dell\source\repos\RestaurantApp\RestaurantOrderingApp\CSVfiles\{file}";
        }
    }
}

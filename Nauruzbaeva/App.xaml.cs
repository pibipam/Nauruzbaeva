using Nauruzbaeva.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Nauruzbaeva
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static user23Entities _context;
        public static user23Entities GetContext()
        {
            if (_context == null)
            {
                _context = new user23Entities();
            }
            return _context;
        }
    }
}

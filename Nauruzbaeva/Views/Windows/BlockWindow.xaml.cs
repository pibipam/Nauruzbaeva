using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Nauruzbaeva.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для BlockWindow.xaml
    /// </summary>
    public partial class BlockWindow : Window
    {
        public BlockWindow()
        {
            InitializeComponent();
            Timer timer;
            timer = new Timer(CloseWindow, null, 10000, Timeout.Infinite);

            void CloseWindow(object state)
            {
                Dispatcher.Invoke(() =>
                {
                    this.Close();

                });
            }
        }
    }
}

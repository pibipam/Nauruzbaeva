using Nauruzbaeva.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для EventInfoWIndow.xaml
    /// </summary>
    public partial class EventInfoWIndow : Window
    {
        public EventInfoWIndow(Event selectedEvent)
        {
            InitializeComponent();
            EventGrid.DataContext = selectedEvent;
        }
    }
}

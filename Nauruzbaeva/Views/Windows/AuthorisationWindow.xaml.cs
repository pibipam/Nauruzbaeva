using Nauruzbaeva.AppData;
using Nauruzbaeva.Model;
using Nauruzbaeva.Views.OrganizerWindows;
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
    /// Логика взаимодействия для AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        private static user23Entities _context = App.GetContext();
        public AuthorisationWindow()
        {
            List<string> roles = new List<string> { "Организатор", "Модератор", "Жюри", "Участник" };
            InitializeComponent();
            RoleCmb.ItemsSource = roles;
        }

        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AuthoriseHelper.Authorise(LoginTb.Text, PassTb.Password, RoleCmb.SelectedItem as string))
            {
                CAPTCHAWindow cAPTCHAWindow = new CAPTCHAWindow();
                if (cAPTCHAWindow.ShowDialog() == true)
                {
                    if (RoleCmb.SelectedIndex == 0)
                    {
                        OrganizerWindow organizerWindow = new OrganizerWindow(AuthoriseHelper.selectedOrg);
                        organizerWindow.Show();
                        Close();
                    }
                }

            }
        }

        private void SignUpHl_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            Close();
        }

        private void EnterHl_Click(object sender, RoutedEventArgs e)
        {
            EventsWindow eventsWindow = new EventsWindow();
            eventsWindow.Show();
            Close();
        }
    }
}

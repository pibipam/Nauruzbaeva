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
    /// Логика взаимодействия для EventsWindow.xaml
    /// </summary>
    public partial class EventsWindow : Window
    {
        private static user23Entities _context = App.GetContext();
        List<Direction> directions = _context.Direction.ToList();
        List<Event> events = _context.Event.ToList();
        private Organizer _selectedUser;
        public EventsWindow()
        {
            InitializeComponent();
            EventsLb.ItemsSource = _context.Event.ToList();
            directions.Insert(0, new Direction() { Name = "Все направления" });
            DirectionCmb.ItemsSource = directions;
            DirectionCmb.DisplayMemberPath = "Name";
            ProfileTbl.Visibility = Visibility.Collapsed;
            SignInTbl.Visibility = Visibility.Visible;
            NewEventBtn.Visibility = Visibility.Collapsed;
        }
        public EventsWindow(Organizer selectedUser)
        {
            InitializeComponent();
            _selectedUser = selectedUser;
            EventsLb.ItemsSource = _context.Event.ToList();
            directions.Insert(0, new Direction() { Name = "Все направления" });
            DirectionCmb.ItemsSource = directions;
            DirectionCmb.DisplayMemberPath = "Name";
            ProfileTbl.Visibility = Visibility.Visible;
            SignInTbl.Visibility = Visibility.Collapsed;
            ProfileTbl.Text = AuthoriseHelper.selectedOrg.Lastname;
            NewEventBtn.Visibility = Visibility.Visible;
        }

        private void DirectionCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            events = _context.Event.ToList();
            if (DirectionCmb.SelectedIndex == 0)
            {
                events = _context.Event.ToList();
                EventsLb.ItemsSource = events;
            }
            else
            {
                events = events.Where(ev => ev.Direction == DirectionCmb.SelectedItem as Direction).ToList();
                EventsLb.ItemsSource = events;
            }
        }

        private void SignInHL_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }

        private void EventsLb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EventInfoWIndow eventInfoWIndow = new EventInfoWIndow(EventsLb.SelectedItem as Event);
            eventInfoWIndow.Show();
            Close();
        }

        private void ProfileHl_Click(object sender, RoutedEventArgs e)
        {
            ProfileWIndow profileWIndow = new ProfileWIndow(_selectedUser);
            profileWIndow.Show();
            Close();
        }

        private void NewEventBtn_Click(object sender, RoutedEventArgs e)
        {
            NewEventWindow newEventWindow = new NewEventWindow(_selectedUser);
            newEventWindow.ShowDialog();
        }
    }
}

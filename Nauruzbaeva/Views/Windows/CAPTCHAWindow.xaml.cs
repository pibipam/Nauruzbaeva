using Nauruzbaeva.AppData;
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
    /// Логика взаимодействия для CAPTCHAWindow.xaml
    /// </summary>
    public partial class CAPTCHAWindow : Window
    {
        string captcha;
        int errorsCount = 0;
        public CAPTCHAWindow()
        {
            InitializeComponent();
            captcha = AuthoriseHelper.GenerateCaptcha();
            CaptchaTbl.Text = captcha;
        }
        private void EntrytBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CaptchaTb.Text == captcha)
            {
                DialogResult = true;
            }
            else
            {
                errorsCount++;
                MessageBoxHelper.Error("CAPTCHA введеа неправильно.");
                captcha = AuthoriseHelper.GenerateCaptcha();
                CaptchaTbl.Text = captcha;
                CaptchaTb.Text = string.Empty;
            }
            if (errorsCount == 3)
            {
                BlockWindow blockWindow = new BlockWindow();
                blockWindow.ShowDialog();
                errorsCount = 0;
            }
        }
    }
}

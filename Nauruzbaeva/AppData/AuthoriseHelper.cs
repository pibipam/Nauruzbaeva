using Nauruzbaeva.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Nauruzbaeva.AppData
{
    internal class AuthoriseHelper
    {
        public static Moderator selectedModer;
        public static Organizer selectedOrg;
        public static Jury selectedJury;
        public static Participant selectedPart;
        private static user23Entities _context = App.GetContext();
        /// <summary> 
        /// Авторизует пользователя.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool Authorise(string login, string password, string role)
        {
            if (login == string.Empty || password == string.Empty)
            {
                MessageBoxHelper.Error("Не все поля для ввода были заполнены.");
                return false;
            }
            else
            {
                if (role == "Организатор")
                {
                    List<Organizer> organizers = _context.Organizer.ToList();
                    foreach (Organizer org in organizers)
                    {
                        if (login == org.Id.ToString() && password == org.Password)
                        {
                            selectedOrg = org;
                            return true;
                        }
                    }
                    if (selectedOrg == null)
                    {
                        MessageBoxHelper.Error("Неправильно введен логин или пароль");
                        return false;
                    }
                }
                else if (role == "Модератор")
                {
                    List<Moderator> moderators = _context.Moderator.ToList();
                    foreach (Moderator moderator in moderators)
                    {
                        if (login == moderator.Id.ToString() && password == moderator.Password)
                        {
                            selectedModer = moderator;
                            return true;
                        }
                        else
                        {
                            MessageBoxHelper.Error("Неправильно введен логин или пароль");
                            return false;
                        }
                    }
                }
                else if (role == "Жюри")
                {
                    List<Jury> juries = _context.Jury.ToList();
                    foreach (Jury jury in juries)
                    {
                        if (login == jury.Id.ToString() && password == jury.Email)
                        {
                            selectedJury = jury;
                            return true;
                        }
                        else
                        {
                            MessageBoxHelper.Error("Неправильно введен логин или пароль");
                            return false;
                        }
                    }
                }
                else if (role == "Участник")
                {
                    List<Participant> participants = _context.Participant.ToList();
                    foreach (Participant participant in participants)
                    {
                        if (login == participant.Id.ToString() && password == participant.Password)
                        {
                            selectedPart = participant;
                            return true;
                        }
                        else
                        {
                            MessageBoxHelper.Error("Неправильно введен логин или пароль");
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
                if (selectedJury != null || selectedModer != null || selectedOrg != null || selectedPart != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// Генерирует текст капчи.
        /// </summary>
        /// <returns></returns>
        public static string GenerateCaptcha()
        {
            List<char> chars = new List<char> { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
                                                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
                                                '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            Random random = new Random();
            string output = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                output += chars[random.Next(0, chars.Count)];
            }
            return output;
        }
    }
}

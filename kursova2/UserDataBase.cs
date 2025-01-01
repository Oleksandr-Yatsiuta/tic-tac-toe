using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace kursova2
{
    public static class UserDataBase
    {
        // Читання всіх користувачів з XML
        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();

            try
            {
                // Завантаження XML файлу
                XElement xml = XElement.Load("players.xml");
                foreach (var playerElement in xml.Elements("Player"))
                {
                    var user = new User
                    {
                        Name = playerElement.Element("Name")?.Value,
                        Password = playerElement.Element("Password")?.Value,
                        Rating = int.Parse(playerElement.Element("Rating")?.Value ?? "0")
                    };
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                // Обробка помилок при завантаженні XML файлу
                Console.WriteLine("Помилка при завантаженні користувачів: " + ex.Message);
            }

            return users;
        }
    }
}

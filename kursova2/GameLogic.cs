using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static kursova2.LogInMenu;

namespace kursova2
{
    public class GameLogic

    {
        private Button[,] buttons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public GameLogic(Button[,] buttons, System.Windows.Forms.Label label1, System.Windows.Forms.Label label2)
        {
            this.buttons = buttons;
            this.label1 = label1;
            this.label2 = label2;
        }

        private void WinCombo()
        {
            string winner = "";

            // Перевірка горизонтальних ліній
            if (buttons[0, 0].Text == buttons[0, 1].Text && buttons[0, 1].Text == buttons[0, 2].Text && buttons[0, 0].Text != "")
            {
                winner = buttons[0, 0].Text;
                ProcessResult(winner);
                return;
            }   
            if (buttons[1, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[1, 2].Text && buttons[1, 0].Text != "")
            {
                winner = buttons[1, 0].Text;
                ProcessResult(winner);
                return;
            }
            if (buttons[2, 0].Text == buttons[2, 1].Text && buttons[2, 1].Text == buttons[2, 2].Text && buttons[2, 0].Text != "")
            {
                winner = buttons[2, 0].Text;
                ProcessResult(winner);
                return;
            }

            // Перевірка вертикальних ліній
            if (buttons[0, 0].Text == buttons[1, 0].Text && buttons[1, 0].Text == buttons[2, 0].Text && buttons[0, 0].Text != "")
            {
                winner = buttons[0, 0].Text;
                ProcessResult(winner);
                return;
            }
            if (buttons[0, 1].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 1].Text && buttons[0, 1].Text != "")
            {
                winner = buttons[0, 1].Text;
                ProcessResult(winner);
                return;
            }
            if (buttons[0, 2].Text == buttons[1, 2].Text && buttons[1, 2].Text == buttons[2, 2].Text && buttons[0, 2].Text != "")
            {
                winner = buttons[0, 2].Text;
                ProcessResult(winner);
                return;
            }

            // Перевірка діагоналей
            if (buttons[0, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[2, 2].Text && buttons[0, 0].Text != "")
            {
                winner = buttons[0, 0].Text;
                ProcessResult(winner);
                return;
            }
            if (buttons[2, 0].Text == buttons[1, 1].Text && buttons[1, 1].Text == buttons[0, 2].Text && buttons[2, 0].Text != "")
            {
                winner = buttons[2, 0].Text;
                ProcessResult(winner);
                return;
            }

            // Якщо не знайдено переможця і є порожні клітинки
            if (!HasEmptyCells())
            {
                MessageBox.Show("Нічия!");
                ResetFields(buttons, 1, label1);
            }
        }



        // Хід гравця
        public void PlayerMove(Button button)
        {
            if (button.Text == "")
            {
                button.Text = "X";
                button.Enabled = false;

                WinCombo();

                BotMove();
            }
        }

        private void BotMove()
        {
            // Знаходимо першу порожню клітинку для бота
            for (int i = 0; i < buttons.GetLength(0); i++)
            {
                for (int j = 0; j < buttons.GetLength(1); j++)
                {
                    if (buttons[i, j].Text == "")
                    {
                        buttons[i, j].Text = "O";
                        buttons[i, j].Enabled = false;
                        label1.Text = "Ходить X";
                        WinCombo();
                        return;
                    }
                }
            }
        }

        private bool HasEmptyCells()
        {
            foreach (var button in buttons)
            {
                if (button.Text == "")
                {
                    return true;
                }
            }
            return false;
        }

        private void ProcessResult(string winner)
        {

            if (LogInMenu.CurrentUser != null)
            {
                // Оновлення рейтингу для існуючих користувачів
                if (winner == "X")
                {
                    LogInMenu.CurrentUser.Rating += 10;
                    MessageBox.Show($"Перемога! Ваш рейтинг: {LogInMenu.CurrentUser.Rating}");
                }
                else if (winner == "O")
                {
                    LogInMenu.CurrentUser.Rating = Math.Max(0, LogInMenu.CurrentUser.Rating - 10);
                    MessageBox.Show($"Поразка! Ваш рейтинг: {LogInMenu.CurrentUser.Rating}");
                }

                // Оновлюємо рейтинг користувача в базі даних
                UpdateUserRating(LogInMenu.CurrentUser);

                label2.Text = $"Ваш рейтинг: {LogInMenu.CurrentUser.Rating}";
            }

            GameLogic.ResetFields(buttons, 1, label1);
        }
        public void UpdateUserRating(User user)
        {
            var users = UserDataBase.LoadUsers();
            var existingUser = users.FirstOrDefault(u => u.Name == user.Name);

            if (existingUser != null)
            {
                // Якщо користувач існує, оновлюємо його рейтинг
                existingUser.Rating = user.Rating;
            }
            else
            {
                // Якщо користувач не існує, додаємо його з початковим рейтингом 0
                users.Add(new User { Name = user.Name, Password = user.Password, Rating = 0 });
            }

            SaveUpdatedUsers(users);
        }


        private void SaveUpdatedUsers(List<User> users)
        {
            try
            {
                XElement xml = new XElement("Players",
                    users.Select(user => new XElement("Player",
                        new XElement("Name", user.Name),
                        new XElement("Password", user.Password),
                        new XElement("Rating", user.Rating)
                    ))
                );
                xml.Save("players.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при збереженні даних: {ex.Message}");
            }
        }

        private static void ResetFields(Button[,] buttons, int Player, System.Windows.Forms.Label label1)
        {
            foreach (var button in buttons)
            {
                button.Text = "";
                button.Enabled = true;
            }
            Player = 1;
            label1.Text = "Ходить X";
        }


        // Метод для відображення переможця
        private void ShowWinner(string winner, Button[,] buttons, int Player, System.Windows.Forms.Label label1)
        {
            if (CurrentUser != null)
            {
                int currentRating = CurrentUser.Rating;

                CurrentUser.Rating = currentRating + 10;
                label2.Text = $"Ваш рейтинг: {CurrentUser.Rating}";
                // Оновлюємо рейтинг у базі даних
                UpdateUserRating(CurrentUser);
                MessageBox.Show($"Перемога гравця {winner}! Рейтинг {CurrentUser.Name}: {CurrentUser.Rating}");
            }

            ResetFields(buttons, Player, label1);
        }


    }
}

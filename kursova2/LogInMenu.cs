using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace kursova2
{
    public partial class LogInMenu : Form
    {
        private TextBox LogInPasswordInput;
        private Label LogInPasswordLabel;
        private TextBox PlayerLogInInput;
        private Label PlayerLogInLabel;
        private Button LogInButton;
        private Button GoToMainButton;
        private Label LogoLabel;


        public static User CurrentUser { get; set; } 
        public LogInMenu()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            string playerName = PlayerLogInInput.Text;
            string password = LogInPasswordInput.Text;

            if (string.IsNullOrWhiteSpace(playerName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Будь ласка, введіть ім'я користувача та пароль.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // завантаження XML
            var users = UserDataBase.LoadUsers();

            // Перевірка на користувача
            var user = users.FirstOrDefault(u => u.Name == playerName);
            if (user == null)
            {
                MessageBox.Show("Користувач не знайдений!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Переревірка на валідність пароля
            if (user.Password != password)
            {
                MessageBox.Show("Невірний пароль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Ставимо поточного гравця
            CurrentUser = user;
            MessageBox.Show($"Логін успішний: {user.Name}");


            GameMenu gameMenu = new GameMenu();
            this.Hide();
            gameMenu.Show();
        }
        //Перехід на головну сторінку
        private void GoToMainButton_Click(object sender, EventArgs e)
        {
            StartMenu gamefield = new StartMenu();
            this.Hide();
            gamefield.Show();
        }

        private void InitializeComponent()
        {
            this.LogoLabel = new System.Windows.Forms.Label();
            this.LogInPasswordInput = new System.Windows.Forms.TextBox();
            this.LogInPasswordLabel = new System.Windows.Forms.Label();
            this.PlayerLogInInput = new System.Windows.Forms.TextBox();
            this.PlayerLogInLabel = new System.Windows.Forms.Label();
            this.LogInButton = new System.Windows.Forms.Button();
            this.GoToMainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogoLabel
            // 
            this.LogoLabel.AutoSize = true;
            this.LogoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogoLabel.Location = new System.Drawing.Point(39, 9);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Size = new System.Drawing.Size(650, 69);
            this.LogoLabel.TabIndex = 7;
            this.LogoLabel.Text = "Гра Хрестики Нолики";
            // 
            // LogInPasswordInput
            // 
            this.LogInPasswordInput.Location = new System.Drawing.Point(261, 233);
            this.LogInPasswordInput.Name = "LogInPasswordInput";
            this.LogInPasswordInput.Size = new System.Drawing.Size(170, 22);
            this.LogInPasswordInput.TabIndex = 13;
            // 
            // LogInPasswordLabel
            // 
            this.LogInPasswordLabel.AutoSize = true;
            this.LogInPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogInPasswordLabel.Location = new System.Drawing.Point(256, 190);
            this.LogInPasswordLabel.Name = "LogInPasswordLabel";
            this.LogInPasswordLabel.Size = new System.Drawing.Size(191, 29);
            this.LogInPasswordLabel.TabIndex = 12;
            this.LogInPasswordLabel.Text = "Введіть пароль ";
            // 
            // PlayerLogInInput
            // 
            this.PlayerLogInInput.Location = new System.Drawing.Point(261, 148);
            this.PlayerLogInInput.Name = "PlayerLogInInput";
            this.PlayerLogInInput.Size = new System.Drawing.Size(170, 22);
            this.PlayerLogInInput.TabIndex = 11;
            // 
            // PlayerLogInLabel
            // 
            this.PlayerLogInLabel.AutoSize = true;
            this.PlayerLogInLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerLogInLabel.Location = new System.Drawing.Point(256, 105);
            this.PlayerLogInLabel.Name = "PlayerLogInLabel";
            this.PlayerLogInLabel.Size = new System.Drawing.Size(189, 29);
            this.PlayerLogInLabel.TabIndex = 10;
            this.PlayerLogInLabel.Text = "Введіть гравця ";
            // 
            // LogInButton
            // 
            this.LogInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogInButton.Location = new System.Drawing.Point(273, 287);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(133, 52);
            this.LogInButton.TabIndex = 14;
            this.LogInButton.Text = "Увійти";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // GoToMainButton
            // 
            this.GoToMainButton.Location = new System.Drawing.Point(583, 361);
            this.GoToMainButton.Name = "GoToMainButton";
            this.GoToMainButton.Size = new System.Drawing.Size(106, 55);
            this.GoToMainButton.TabIndex = 15;
            this.GoToMainButton.Text = "Назад";
            this.GoToMainButton.UseVisualStyleBackColor = true;
            this.GoToMainButton.Click += new System.EventHandler(this.GoToMainButton_Click);
            // 
            // LogInMenu
            // 
            this.ClientSize = new System.Drawing.Size(725, 446);
            this.Controls.Add(this.GoToMainButton);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.LogInPasswordInput);
            this.Controls.Add(this.LogInPasswordLabel);
            this.Controls.Add(this.PlayerLogInInput);
            this.Controls.Add(this.PlayerLogInLabel);
            this.Controls.Add(this.LogoLabel);
            this.Name = "LogInMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


    }
}

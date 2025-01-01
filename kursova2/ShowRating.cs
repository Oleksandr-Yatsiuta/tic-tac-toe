using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static kursova2.UserDataBase;

namespace kursova2
{
    public partial class ShowRating : Form
    {
        private Label LogoLabel;
        private Label PlayerRatingLabel;
        private ListBox PlayerListBox;
        private Button GoToMainButton;

        public ShowRating()
        {
            InitializeComponent();
            LoadPlayers();
        }

        // Завантаження списку користувачів та їх рейтингів з UserDataBase
        private void LoadPlayers()
        {
            // Отримуємо список користувачів
            var users = UserDataBase.LoadUsers();

            // Додаємо кожного користувача в ListBox
            foreach (var user in users)
            {
                PlayerListBox.Items.Add($"Гравець: {user.Name}, Рейтинг: {user.Rating}");
            }
        }

        // Перехід до основного меню
        private void GoToMainButton_Click_1(object sender, EventArgs e)
        {
            StartMenu gamefield = new StartMenu();
            this.Hide();
            gamefield.Show();
        }

        private void InitializeComponent()
        {
            this.LogoLabel = new System.Windows.Forms.Label();
            this.PlayerRatingLabel = new System.Windows.Forms.Label();
            this.GoToMainButton = new System.Windows.Forms.Button();
            this.PlayerListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LogoLabel
            // 
            this.LogoLabel.AutoSize = true;
            this.LogoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogoLabel.Location = new System.Drawing.Point(121, 9);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Size = new System.Drawing.Size(650, 69);
            this.LogoLabel.TabIndex = 6;
            this.LogoLabel.Text = "Гра Хрестики Нолики";
            // 
            // PlayerRatingLabel
            // 
            this.PlayerRatingLabel.AutoSize = true;
            this.PlayerRatingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlayerRatingLabel.Location = new System.Drawing.Point(353, 109);
            this.PlayerRatingLabel.Name = "PlayerRatingLabel";
            this.PlayerRatingLabel.Size = new System.Drawing.Size(196, 29);
            this.PlayerRatingLabel.TabIndex = 7;
            this.PlayerRatingLabel.Text = "Рейтинг гравців";
            // 
            // GoToMainButton
            // 
            this.GoToMainButton.Location = new System.Drawing.Point(752, 446);
            this.GoToMainButton.Name = "GoToMainButton";
            this.GoToMainButton.Size = new System.Drawing.Size(106, 55);
            this.GoToMainButton.TabIndex = 8;
            this.GoToMainButton.Text = "Назад";
            this.GoToMainButton.UseVisualStyleBackColor = true;
            this.GoToMainButton.Click += new System.EventHandler(this.GoToMainButton_Click_1);
            // 
            // PlayerListBox
            // 
            this.PlayerListBox.FormattingEnabled = true;
            this.PlayerListBox.ItemHeight = 16;
            this.PlayerListBox.Location = new System.Drawing.Point(358, 162);
            this.PlayerListBox.Name = "PlayerListBox";
            this.PlayerListBox.Size = new System.Drawing.Size(187, 116);
            this.PlayerListBox.TabIndex = 9;
            // 
            // ShowRating
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.PlayerListBox);
            this.Controls.Add(this.GoToMainButton);
            this.Controls.Add(this.PlayerRatingLabel);
            this.Controls.Add(this.LogoLabel);
            this.Name = "ShowRating";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

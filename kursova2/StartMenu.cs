using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursova2
{
    public partial class StartMenu : Form
    {
        private System.Windows.Forms.Label LogoLabel;
        private Button ShowRaitingButton;
        private Button LogInButton;
        private Button RaitingGameButton;
        public StartMenu()
        {
            InitializeComponent();
        }

        //Перехід на сторінку реєстрації
        private void RaitingGameButton_Click(object sender, EventArgs e)
        {
            RegistrationMenu registration = new RegistrationMenu();
            this.Hide();
            registration.Show();

        }
        //Перехід на меню з показом рейтингу
        private void ShowRaitingButton_Click(object sender, EventArgs e)
        {
            ShowRating showrating = new ShowRating();
            this.Hide();
            showrating.Show();
        }

        //Перехід на меню логіну
        private void LogInButton_Click(object sender, EventArgs e)
        {
            LogInMenu loginmenu = new LogInMenu();
            this.Hide();
            loginmenu.Show();
        }


        private void InitializeComponent()
        {
            this.LogoLabel = new System.Windows.Forms.Label();
            this.ShowRaitingButton = new System.Windows.Forms.Button();
            this.RaitingGameButton = new System.Windows.Forms.Button();
            this.LogInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogoLabel
            // 
            this.LogoLabel.AutoSize = true;
            this.LogoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogoLabel.Location = new System.Drawing.Point(125, 29);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Size = new System.Drawing.Size(650, 69);
            this.LogoLabel.TabIndex = 1;
            this.LogoLabel.Text = "Гра Хрестики Нолики";
            // 
            // ShowRaitingButton
            // 
            this.ShowRaitingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowRaitingButton.Location = new System.Drawing.Point(272, 192);
            this.ShowRaitingButton.Name = "ShowRaitingButton";
            this.ShowRaitingButton.Size = new System.Drawing.Size(328, 46);
            this.ShowRaitingButton.TabIndex = 0;
            this.ShowRaitingButton.Text = "Рейтинг";
            this.ShowRaitingButton.Click += new System.EventHandler(this.ShowRaitingButton_Click);
            // 
            // RaitingGameButton
            // 
            this.RaitingGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RaitingGameButton.Location = new System.Drawing.Point(272, 142);
            this.RaitingGameButton.Name = "RaitingGameButton";
            this.RaitingGameButton.Size = new System.Drawing.Size(328, 44);
            this.RaitingGameButton.TabIndex = 3;
            this.RaitingGameButton.Text = "Зареєструвати гравця";
            this.RaitingGameButton.UseVisualStyleBackColor = true;
            this.RaitingGameButton.Click += new System.EventHandler(this.RaitingGameButton_Click);
            // 
            // LogInButton
            // 
            this.LogInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogInButton.Location = new System.Drawing.Point(272, 244);
            this.LogInButton.Name = "LogInButton";
            this.LogInButton.Size = new System.Drawing.Size(328, 50);
            this.LogInButton.TabIndex = 13;
            this.LogInButton.Text = "Увійти в аккаунт";
            this.LogInButton.UseVisualStyleBackColor = true;
            this.LogInButton.Click += new System.EventHandler(this.LogInButton_Click);
            // 
            // StartMenu
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.LogInButton);
            this.Controls.Add(this.RaitingGameButton);
            this.Controls.Add(this.ShowRaitingButton);
            this.Controls.Add(this.LogoLabel);
            this.Name = "StartMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}



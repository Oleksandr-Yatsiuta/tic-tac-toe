using System;
using System.Drawing;
using System.Windows.Forms;

namespace kursova2
{
    public partial class GameMenu : Form
    {

        private Button[,] buttons = new Button[3, 3];
        private System.Windows.Forms.Label label1;
        private Button ShowRaitingButton;
        private System.Windows.Forms.Label label2;
        public int Player;
         GameLogic gameLogic;


        public GameMenu()
        {
            InitializeComponent();
            gameLogic = new GameLogic(buttons, label1, label2);
            Player = 1;


            if (LogInMenu.CurrentUser != null)
            {
                MessageBox.Show($"Поточний користувач: {LogInMenu.CurrentUser.Name}");
            }
            else
            {
                Console.WriteLine("Поточний користувач не встановлений");
            }

            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(150, 150);
                }
            }
            Field();
        }


        private void Field()
        {
            for (int i = 0; i < buttons.Length / 3; i++)
            {
                for (int j = 0; j < buttons.Length / 3; j++)
                {
                    buttons[i, j].Location = new Point(12 + 156 * j, 12 + 156 * i);
                    buttons[i, j].Click += button_Click;
                    buttons[i, j].Font = new Font(new FontFamily("Microsoft Sans Serif"), 74);
                    buttons[i, j].Text = "";
                    this.Controls.Add(buttons[i, j]);
                }
            }
        }



        private void button_Click(object sender, EventArgs e)
        {
            // Визначення кнопки, на яку натиснув гравець
            Button clickedButton = sender as Button;

            if (clickedButton != null && gameLogic != null)
            {
                gameLogic.PlayerMove(clickedButton);
            }
        }

        //Перехід на меню показу рейтингу
        private void ShowRaitingButton_Click(object sender, EventArgs e)
        {
            ShowRating showrating = new ShowRating();
            this.Hide();
            showrating.Show();
        }


        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ShowRaitingButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.label1.Location = new System.Drawing.Point(714, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ходить X";
            // 
            // ShowRaitingButton
            // 
            this.ShowRaitingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowRaitingButton.Location = new System.Drawing.Point(644, 463);
            this.ShowRaitingButton.Name = "ShowRaitingButton";
            this.ShowRaitingButton.Size = new System.Drawing.Size(255, 39);
            this.ShowRaitingButton.TabIndex = 1;
            this.ShowRaitingButton.Text = "Рейтинг";
            this.ShowRaitingButton.Click += new System.EventHandler(this.ShowRaitingButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(677, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ваш рейтинг :";
            // 
            // GameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ShowRaitingButton);
            this.Controls.Add(this.label1);
            this.Name = "GameMenu";
            this.Text = "GameMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}

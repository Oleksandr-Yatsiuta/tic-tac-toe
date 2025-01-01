using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;

namespace kursova2
{
    public partial class RegistrationMenu : Form
    {
        private Label LogoLabel;
        private Label Player1Label;
        private TextBox Password1Input;
        private Label Password1Label;
        private Button AfterRegistrationButton;
        private Button GoToMainButton;
        private TextBox Player1Input;

        public RegistrationMenu()
        {
            InitializeComponent();
        }


        private void RegisterUser()
        {
            string playerName = Player1Input.Text;
            string password = Password1Input.Text;

            // Перевірка на коректність введених даних
            if (string.IsNullOrWhiteSpace(playerName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Будь ласка, введіть ім'я та пароль!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Перевірка на наявність користувача
            if (IsUserExist(playerName))
            {
                MessageBox.Show("Користувач з таким ім'ям вже існує!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Додавання гравця до бази даних
            AddPlayerToXml(playerName, password, 0); // Рейтинг за замовчуванням - 0

            MessageBox.Show("Користувач успішно зареєстрований!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);


            StartMenu gamefield = new StartMenu();
            this.Hide();
            gamefield.Show();

        }

        private bool IsUserExist(string playerName)
        {
            string filePath = "players.xml";

            if (File.Exists(filePath))
            {
                XDocument xdoc = XDocument.Load(filePath);
                // Перевірка, чи існує вже користувач з таким ім'ям
                return xdoc.Descendants("Player")
                           .Any(player => player.Element("Name")?.Value == playerName);
            }

            return false;
        }

        private void AddPlayerToXml(string playerName, string password, int rating)
        {
            string filePath = "players.xml";

            XDocument xdoc;

            // Якщо файл вже існує, завантажити його
            if (File.Exists(filePath))
            {
                xdoc = XDocument.Load(filePath);
            }
            else
            {
                // Якщо файлу немає, створити новий документ з кореневим елементом Players
                xdoc = new XDocument(new XElement("Players"));
            }

            // Додати нового гравця
            XElement newPlayer = new XElement("Player",
                new XElement("Name", playerName),
                new XElement("Password", password),
                new XElement("Rating", rating)
            );
            xdoc.Root.Add(newPlayer);

            // Зберегти зміни у файл
            xdoc.Save(filePath);
        }

        //Перехід на головне меню після реєстрації
        private void AfterRegistrationButton_Click_1(object sender, EventArgs e)
        {
            RegisterUser(); 
        }

        //Перехід на головне меню
        private void GoToMainButton_Click(object sender, EventArgs e)
        {
            StartMenu gamefield = new StartMenu();
            this.Hide();
            gamefield.Show();
        }

        private void InitializeComponent()
        {
            this.LogoLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player1Input = new System.Windows.Forms.TextBox();
            this.Password1Input = new System.Windows.Forms.TextBox();
            this.Password1Label = new System.Windows.Forms.Label();
            this.AfterRegistrationButton = new System.Windows.Forms.Button();
            this.GoToMainButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogoLabel
            // 
            this.LogoLabel.AutoSize = true;
            this.LogoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogoLabel.Location = new System.Drawing.Point(109, 23);
            this.LogoLabel.Name = "LogoLabel";
            this.LogoLabel.Size = new System.Drawing.Size(650, 69);
            this.LogoLabel.TabIndex = 5;
            this.LogoLabel.Text = "Гра Хрестики Нолики";
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Player1Label.Location = new System.Drawing.Point(337, 132);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(189, 29);
            this.Player1Label.TabIndex = 6;
            this.Player1Label.Text = "Введіть гравця ";
            // 
            // Player1Input
            // 
            this.Player1Input.Location = new System.Drawing.Point(342, 175);
            this.Player1Input.Name = "Player1Input";
            this.Player1Input.Size = new System.Drawing.Size(170, 22);
            this.Player1Input.TabIndex = 7;
            // 
            // Password1Input
            // 
            this.Password1Input.Location = new System.Drawing.Point(342, 260);
            this.Password1Input.Name = "Password1Input";
            this.Password1Input.Size = new System.Drawing.Size(170, 22);
            this.Password1Input.TabIndex = 9;
            // 
            // Password1Label
            // 
            this.Password1Label.AutoSize = true;
            this.Password1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Password1Label.Location = new System.Drawing.Point(337, 217);
            this.Password1Label.Name = "Password1Label";
            this.Password1Label.Size = new System.Drawing.Size(191, 29);
            this.Password1Label.TabIndex = 8;
            this.Password1Label.Text = "Введіть пароль ";
            // 
            // AfterRegistrationButton
            // 
            this.AfterRegistrationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AfterRegistrationButton.Location = new System.Drawing.Point(292, 327);
            this.AfterRegistrationButton.Name = "AfterRegistrationButton";
            this.AfterRegistrationButton.Size = new System.Drawing.Size(269, 48);
            this.AfterRegistrationButton.TabIndex = 10;
            this.AfterRegistrationButton.Text = "Зареєструватися";
            this.AfterRegistrationButton.UseVisualStyleBackColor = true;
            this.AfterRegistrationButton.Click += new System.EventHandler(this.AfterRegistrationButton_Click_1);
            // 
            // GoToMainButton
            // 
            this.GoToMainButton.Location = new System.Drawing.Point(771, 417);
            this.GoToMainButton.Name = "GoToMainButton";
            this.GoToMainButton.Size = new System.Drawing.Size(106, 55);
            this.GoToMainButton.TabIndex = 11;
            this.GoToMainButton.Text = "Назад";
            this.GoToMainButton.UseVisualStyleBackColor = true;
            this.GoToMainButton.Click += new System.EventHandler(this.GoToMainButton_Click);
            // 
            // RegistrationMenucs
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.GoToMainButton);
            this.Controls.Add(this.AfterRegistrationButton);
            this.Controls.Add(this.Password1Input);
            this.Controls.Add(this.Password1Label);
            this.Controls.Add(this.Player1Input);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.LogoLabel);
            this.Name = "RegistrationMenucs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



    }
}

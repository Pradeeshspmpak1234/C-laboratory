using System;
using System.Drawing;
using System.Windows.Forms;

namespace UserInputDemo
{
    public class InputForm : Form
    {
        private Label lblNameTitle;
        private TextBox txtNameInput;
        private Label lblAgeTitle;
        private TextBox txtAgeInput;
        private Button btnProcess;
        private Label lblResultDisplay;

        public InputForm()
        {
            this.Text = "User Data Processor";
            this.Size = new Size(420, 340);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            lblNameTitle = new Label
            {
                Text = "Enter Your Name:",
                Location = new Point(30, 20),
                Size = new Size(150, 20)
            };

            txtNameInput = new TextBox
            {
                Location = new Point(30, 45),
                Size = new Size(340, 25)
            };

            lblAgeTitle = new Label
            {
                Text = "Enter Your Current Age:",
                Location = new Point(30, 85),
                Size = new Size(180, 20)
            };

            txtAgeInput = new TextBox
            {
                Location = new Point(30, 110),
                Size = new Size(100, 25)
            };

            btnProcess = new Button
            {
                Text = "Process My Info",
                Location = new Point(30, 160),
                Size = new Size(140, 35)
            };

            btnProcess.Click += new EventHandler(BtnProcess_Click);

            lblResultDisplay = new Label
            {
                Text = "Waiting for valid user input...",
                Location = new Point(30, 220),
                Size = new Size(340, 60),
                ForeColor = Color.DarkBlue,
                Font = new Font("Arial", 10, FontStyle.Italic)
            };

            this.Controls.Add(lblNameTitle);
            this.Controls.Add(txtNameInput);
            this.Controls.Add(lblAgeTitle);
            this.Controls.Add(txtAgeInput);
            this.Controls.Add(btnProcess);
            this.Controls.Add(lblResultDisplay);
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            string userName = txtNameInput.Text.Trim();
            string ageRawInput = txtAgeInput.Text.Trim();

            if (string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(ageRawInput))
            {
                MessageBox.Show(
                    "Please fill out both data fields.",
                    "Missing Data",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!int.TryParse(ageRawInput, out int currentAge) ||
                currentAge < 0)
            {
                MessageBox.Show(
                    "Please enter a valid whole number for age.",
                    "Input Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            int yearsToCentennial = 100 - currentAge;

            if (yearsToCentennial > 0)
            {
                lblResultDisplay.Font =
                    new Font("Arial", 10, FontStyle.Bold);

                lblResultDisplay.Text =
                    $"Hello {userName}!\n" +
                    $"You have {yearsToCentennial} years left until you reach 100.";
            }
            else
            {
                lblResultDisplay.Font =
                    new Font("Arial", 10, FontStyle.Bold);

                lblResultDisplay.Text =
                    $"Hello {userName}!\n" +
                    "Amazing! You have already lived a full century or more.";
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InputForm());
        }
    }
}
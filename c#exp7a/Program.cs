using System;
using System.Windows.Forms;

namespace ValidationApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
        }
    }
}

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ValidationApp
{
    public partial class Form1 : Form
    {
        private TextBox? txtEmail;
        private TextBox? txtAge;
        private Button? btnSubmit;
        private ErrorProvider? errorProvider;

        public Form1()
        {
            InitializeComponentsManually();
        }

        private void InitializeComponentsManually()
        {
            this.Text = "WinForms Validation Demo";
            this.Size = new System.Drawing.Size(400, 250);
            this.StartPosition = FormStartPosition.CenterScreen;

            errorProvider = new ErrorProvider();

            TableLayoutPanel grid = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                ColumnCount = 2,
                RowCount = 3
            };

            grid.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 30F));

            grid.ColumnStyles.Add(
                new ColumnStyle(SizeType.Percent, 70F));

            Label lblEmail = new Label
            {
                Text = "Email:",
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                AutoSize = true
            };

            txtEmail = new TextBox
            {
                Dock = DockStyle.Fill
            };

            txtEmail.Validating += TxtEmail_Validating;

            Label lblAge = new Label
            {
                Text = "Age (18-100):",
                Anchor = AnchorStyles.Left | AnchorStyles.Right,
                AutoSize = true
            };

            txtAge = new TextBox
            {
                Dock = DockStyle.Fill
            };

            txtAge.Validating += TxtAge_Validating;

            btnSubmit = new Button
            {
                Text = "Submit",
                Width = 100,
                Height = 30
            };

            btnSubmit.Click += BtnSubmit_Click;

            grid.Controls.Add(lblEmail, 0, 0);
            grid.Controls.Add(txtEmail, 1, 0);

            grid.Controls.Add(lblAge, 0, 1);
            grid.Controls.Add(txtAge, 1, 1);

            grid.Controls.Add(btnSubmit, 1, 2);

            this.Controls.Add(grid);
        }

        private void TxtEmail_Validating(
            object? sender,
            CancelEventArgs e)
        {
            if (txtEmail == null || errorProvider == null)
                return;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                !Regex.IsMatch(txtEmail.Text, pattern))
            {
                e.Cancel = true;

                errorProvider.SetError(
                    txtEmail,
                    "Enter a valid email address.");
            }
            else
            {
                errorProvider.SetError(
                    txtEmail,
                    string.Empty);
            }
        }

        private void TxtAge_Validating(
            object? sender,
            CancelEventArgs e)
        {
            if (txtAge == null || errorProvider == null)
                return;

            if (!int.TryParse(txtAge.Text, out int age) ||
                age < 18 ||
                age > 100)
            {
                e.Cancel = true;

                errorProvider.SetError(
                    txtAge,
                    "Age must be a number between 18 and 100.");
            }
            else
            {
                errorProvider.SetError(
                    txtAge,
                    string.Empty);
            }
        }

        private void BtnSubmit_Click(
            object? sender,
            EventArgs e)
        {
            if (this.ValidateChildren(
                ValidationConstraints.Enabled))
            {
                MessageBox.Show(
                    "Form is valid! Data processed successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Please correct the errors in the form.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}
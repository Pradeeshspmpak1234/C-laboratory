using System;
using System.Windows.Forms;

namespace DialogBoxDemo
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new LauncherForm());
        }
    }

    public class LauncherForm : Form
    {
        public LauncherForm()
        {
            this.Text = "Main Window Launcher";
            this.Width = 320;
            this.Height = 200;
            this.StartPosition = FormStartPosition.CenterScreen;

            Button btnLaunch = new Button
            {
                Text = "Launch Dialog Box",
                Left = 50,
                Top = 50,
                Width = 200,
                Height = 45
            };

            btnLaunch.Click += ButtonLaunch_Click;

            this.Controls.Add(btnLaunch);
        }

        private void ButtonLaunch_Click(object? sender, EventArgs e)
        {
            string userResponse =
                CustomDialog.ShowInputDialog(
                    "Profile Setup",
                    "Please enter your name:");

            if (!string.IsNullOrEmpty(userResponse))
            {
                MessageBox.Show(
                    $"Welcome, {userResponse}!",
                    "Success");
            }
        }
    }

    public static class CustomDialog
    {
        public static string ShowInputDialog(
            string title,
            string promptText)
        {
            Form dialog = new Form
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label lblText = new Label
            {
                Left = 20,
                Top = 20,
                Width = 350,
                Text = promptText
            };

            TextBox txtInput = new TextBox
            {
                Left = 20,
                Top = 50,
                Width = 340
            };

            Button btnOk = new Button
            {
                Text = "OK",
                Left = 160,
                Top = 90,
                Width = 90,
                DialogResult = DialogResult.OK
            };

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Left = 270,
                Top = 90,
                Width = 90,
                DialogResult = DialogResult.Cancel
            };

            dialog.AcceptButton = btnOk;
            dialog.CancelButton = btnCancel;

            dialog.Controls.Add(lblText);
            dialog.Controls.Add(txtInput);
            dialog.Controls.Add(btnOk);
            dialog.Controls.Add(btnCancel);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return txtInput.Text;
            }

            return string.Empty;
        }
    }
}
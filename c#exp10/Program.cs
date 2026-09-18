using System;
using System.Windows.Forms;

namespace MDIApplication
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}

using System;
using System.Windows.Forms;

namespace MDIApplication
{
    public class MainForm : Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem newMenu;
        private ToolStripMenuItem exitMenu;
        private ToolStripMenuItem toolsMenu;
        private ToolStripMenuItem dialogMenu;

        public MainForm()
        {
            Text = "My MDI Application";
            Width = 900;
            Height = 600;
            IsMdiContainer = true;

            menuStrip = new MenuStrip();

            fileMenu = new ToolStripMenuItem("File");
            newMenu = new ToolStripMenuItem("New");
            exitMenu = new ToolStripMenuItem("Exit");

            fileMenu.DropDownItems.Add(newMenu);
            fileMenu.DropDownItems.Add(exitMenu);

            toolsMenu = new ToolStripMenuItem("Tools");
            dialogMenu = new ToolStripMenuItem("Custom Dialog");
            toolsMenu.DropDownItems.Add(dialogMenu);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(toolsMenu);

            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;

            newMenu.Click += NewMenu_Click;
            exitMenu.Click += ExitMenu_Click;
            dialogMenu.Click += DialogMenu_Click;
        }

        private void NewMenu_Click(object? sender, EventArgs e)
        {
            ChildForm child = new ChildForm();
            child.MdiParent = this;
            child.Show();
        }

        private void DialogMenu_Click(object? sender, EventArgs e)
        {
            CustomDialog dialog = new CustomDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(
                    "Name: " + dialog.StudentName +
                    "\nAge: " + dialog.StudentAge,
                    "Student Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ExitMenu_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDIApplication
{
    public class CustomDialog : Form
    {
        private TextBox nameTextBox;
        private TextBox ageTextBox;
        private Button okButton;
        private Button cancelButton;

        public string StudentName
        {
            get { return nameTextBox.Text; }
        }

        public string StudentAge
        {
            get { return ageTextBox.Text; }
        }

        public CustomDialog()
        {
            Text = "Student Details";
            Width = 400;
            Height = 250;
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Label nameLabel = new Label();
            nameLabel.Text = "Name:";
            nameLabel.Location = new Point(40, 40);
            nameLabel.AutoSize = true;

            nameTextBox = new TextBox();
            nameTextBox.Location = new Point(120, 35);
            nameTextBox.Width = 200;

            Label ageLabel = new Label();
            ageLabel.Text = "Age:";
            ageLabel.Location = new Point(40, 80);
            ageLabel.AutoSize = true;

            ageTextBox = new TextBox();
            ageTextBox.Location = new Point(120, 75);
            ageTextBox.Width = 200;

            okButton = new Button();
            okButton.Text = "OK";
            okButton.Location = new Point(120, 130);
            okButton.Width = 80;

            cancelButton = new Button();
            cancelButton.Text = "Cancel";
            cancelButton.Location = new Point(220, 130);
            cancelButton.Width = 80;

            okButton.Click += OkButton_Click;
            cancelButton.Click += CancelButton_Click;

            Controls.Add(nameLabel);
            Controls.Add(nameTextBox);
            Controls.Add(ageLabel);
            Controls.Add(ageTextBox);
            Controls.Add(okButton);
            Controls.Add(cancelButton);

            AcceptButton = okButton;
            CancelButton = cancelButton;
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            if (nameTextBox.Text == "" || ageTextBox.Text == "")
            {
                MessageBox.Show(
                    "Please enter Name and Age.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace MDIApplication
{
    public class ChildForm : Form
    {
        public ChildForm()
        {
            Text = "Child Form";
            Width = 500;
            Height = 300;

            Label label = new Label();
            label.Text = "This is an MDI Child Form";
            label.Font = new Font("Arial", 18);
            label.AutoSize = true;
            label.Location = new Point(100, 100);

            Controls.Add(label);
        }
    }
}


using System;
using System.Drawing;
using System.Windows.Forms;

namespace MDIApplication
{
    public class MainForm : Form
    {
        MenuStrip menuStrip;
        ToolStripMenuItem fileMenu, windowMenu;
        ToolStripMenuItem newMenu, exitMenu;
        ToolStripMenuItem cascadeMenu, tileMenu;

        public MainForm()
        {
            Text = "MDI Application";
            Width = 800;
            Height = 500;
            IsMdiContainer = true;

            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem("File");
            newMenu = new ToolStripMenuItem("New");
            exitMenu = new ToolStripMenuItem("Exit");
            windowMenu = new ToolStripMenuItem("Window");
            cascadeMenu = new ToolStripMenuItem("Cascade");
            tileMenu = new ToolStripMenuItem("Tile");

            fileMenu.DropDownItems.Add(newMenu);
            fileMenu.DropDownItems.Add(exitMenu);
            windowMenu.DropDownItems.Add(cascadeMenu);
            windowMenu.DropDownItems.Add(tileMenu);

            menuStrip.Items.Add(fileMenu);
            menuStrip.Items.Add(windowMenu);
            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);

            newMenu.Click += NewMenu_Click;
            exitMenu.Click += ExitMenu_Click;
            cascadeMenu.Click += CascadeMenu_Click;
            tileMenu.Click += TileMenu_Click;
        }

        private void NewMenu_Click(object sender, EventArgs e)
        {
            Form child = new Form();
            child.Text = "Child Window";
            child.Width = 400;
            child.Height = 300;
            child.MdiParent = this;
            child.Show();
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CascadeMenu_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileMenu_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
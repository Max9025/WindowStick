using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowTopMostController.UI
{
    internal class TrayController
    {
        private NotifyIcon _notifyIcon;
        private MainForm _mainForm;

        public TrayController(MainForm mainForm)
        {
            _mainForm = mainForm;

            _notifyIcon = new NotifyIcon();
            
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(
                "WindowTopMostController.UI.Icon.createimg-ai.ico"))
            {
                if (stream != null)
                    _notifyIcon.Icon = new Icon(stream);
                else
                    MessageBox.Show("Tray icon resource not found.");
            }

            _notifyIcon.Visible = true;
            _notifyIcon.Text = "WindowStick";

            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem openItem = new ToolStripMenuItem("Open");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Exit");

            openItem.Click += OpenItem_Click;
            exitItem.Click += ExitItem_Click;

            menu.Items.Add(openItem);
            menu.Items.Add(exitItem);
            
            _notifyIcon.ContextMenuStrip = menu;

            _notifyIcon.MouseClick += NotifyIcon_MouseClick;
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowForm();
            }
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();

            _mainForm.WindowService.ResetAllTopMost();
            Application.Exit();
        }

        private void ShowForm()
        {
            if (_mainForm.Visible)
            {
                _mainForm.Activate();
            }
            else
            {
                _mainForm.Show();
                _mainForm.Activate();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowTopMostController.Models;
using WindowTopMostController.Services;

namespace WindowTopMostController
{
    public partial class MainForm : Form
    {
        public WindowService WindowService => _windowService;

        private readonly WindowService _windowService = new WindowService();
        private WindowInfo _selectedWindow;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            listWindows.Items.Clear();

            var windows = _windowService.GetWindows();

            foreach (var window in windows)
            {
                listWindows.Items.Add(window);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            MainForm_Load(sender, e);
        }

        private void listWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedWindow = listWindows.SelectedItem as WindowInfo;

            if (_selectedWindow == null)
            {
                chkTopMous.Enabled = false;
                chkTopMous.Checked = false;
                return;
            }

            chkTopMous.Enabled = true;

            chkTopMous.Checked = _windowService.IsTopMost(_selectedWindow);
        }

        private void chkTopMous_CheckedChanged(object sender, EventArgs e)
        {
            if (_selectedWindow == null)
                return;

            _windowService.SetTopMost(_selectedWindow, chkTopMous.Checked);
        }
    }
}

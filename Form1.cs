namespace TBToggler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool autoHideEnabled = TaskbarSettings.ToggleTaskbarAutoHide();
            notifyIcon1.Icon = autoHideEnabled ? Properties.Resources.AutoHideOnIcon : Properties.Resources.AutoHideOffIcon;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            //TaskbarSettings.ToggleTaskbarAutoHideRegistry();
        }

        private void ExitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}

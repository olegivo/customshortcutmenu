using System;
using System.Windows.Forms;

namespace CustomShortcutMenu
{
    public partial class CustomizeShortcutForm : Form
    {
        public CustomizeShortcutForm()
        {
            InitializeComponent();
        }

        public ShortcutMenu ShortcutMenu { get; set; }

        private void tbShortcut_KeyDown(object sender, KeyEventArgs e)
        {
            ShortcutMenu.Shortcut = e.KeyData;
            ShortcutMenu.Modifiers = e.Modifiers;
            tbShortcut.Text = ShortcutMenu.GetHotkeyString();
        }

        private void tbDescription_TextChanged(object sender, EventArgs e)
        {
            ShortcutMenu.Description = tbDescription.Text;
        }

        private void CustomizeShortcutForm_Load(object sender, EventArgs e)
        {
            tbDescription.Text = ShortcutMenu.Description;
            tbShortcut.Text = ShortcutMenu.GetHotkeyString();
        }
    }
}

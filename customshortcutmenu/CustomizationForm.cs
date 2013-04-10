using System;
using System.Text;
using System.Windows.Forms;

namespace CustomShortcutMenu
{
    public partial class CustomizationForm : Form
    {
        public CustomizationForm()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            var sb = new StringBuilder();
            if (e.Control) sb.Append("<Control> + ");
            if (e.Alt) sb.Append("<Alt> + ");
            if (e.Shift) sb.Append("<Shift> + ");
            //sb.Append(e.KeyData.ToString());
            sb.Append(e.KeyCode.ToString());
            textBox1.Text = sb.ToString();
            item.Shortcut = e.KeyData;
            item.Modifiers = e.Modifiers;
            args = e;
        }
        ShortcutMenu item = new ShortcutMenu();
        private KeyEventArgs args;

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CustomShortcutMenu
{
    public partial class ShowMenuForm : Form
    {
        private List<ShortcutMenu> menus;
        private Dictionary<short, ContextMenu> hotkeyDic;

        public ShowMenuForm()
        {
            InitializeComponent();
            LoadMenu();
        }

        private const int WM_HOTKEY = 0x0312;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                var wParam = (short)m.WParam;
                if (hotkeyDic.ContainsKey(wParam))
                {
                    ShowMenu(hotkeyDic[wParam]);
                }
            }
            base.WndProc(ref m);
        }

        private void ShowMenu(ContextMenu contextMenu)
        {
            var position = Cursor.Position;
            contextMenu.Show(this, PointToClient(position));
        }

        private  void LoadMenu()
        {
            object o;
            using (var reader = new StreamReader("settings.xml"))
            {
                var serializer = new XmlSerializer(typeof (List<ShortcutMenu>));
                o = serializer.Deserialize(reader);
                reader.Close();
            }
            menus = (List<ShortcutMenu>)o;
            RebuildMenuItems();
        }

        private void RebuildMenuItems()
        {
            UnregisterHotKey();
            hotkeyDic = new Dictionary<short, ContextMenu>();
            var customizeMenu = new MenuItem("Настроить меню");
            foreach (var menu in menus)
            {
                var contextMenu = new ContextMenu();
                contextMenu.Collapse += (sender, args) =>
                    {
                        WindowState = FormWindowState.Minimized;
                    };
                contextMenu.MenuItems.AddRange(menu.GetMenuItems());
                contextMenu.MenuItems.Add(customizeMenu);

                menu.RegisterHotkey(Handle);
                hotkeyDic.Add(menu.HotkeyId, contextMenu);
                //var success = RegisterHotKey(Handle, GetType().GetHashCode(), menu.Win32Modifiers, menu.CharCode);
                //if (success)
                //{
                //    //TxtKeyEnumValue.Text = ((int)frm.ShortcutInput1.Keys).ToString();
                //    //StreamWriter writer = File.CreateText(Application.StartupPath + "\\HotkeyValue.txt");
                //    //writer.Write(TxtKeyEnumValue.Text);
                //    //writer.Close();
                //}
                //else
                //    MessageBox.Show("Could not register Hotkey - there is probably a conflict.  ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ShowMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnregisterHotKey();
        }

        private void UnregisterHotKey()
        {
            foreach (var menu in menus)
                menu.UnregisterHotkey();
            //UnregisterHotKey(Handle, GetType().GetHashCode());
        }
    }
}

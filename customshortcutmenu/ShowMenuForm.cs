using System;
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
            menus = LoadMenu();
            RebuildMenuItems();
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

        public List<ShortcutMenu> LoadMenu()
        {
            object o;
            using (var reader = new StreamReader("settings.xml"))
            {
                var serializer = new XmlSerializer(typeof (List<ShortcutMenu>));
                o = serializer.Deserialize(reader);
                reader.Close();
            }
            return (List<ShortcutMenu>)o;
        }

        private void RebuildMenuItems()
        {
            UnregisterHotKey();
            hotkeyDic = new Dictionary<short, ContextMenu>();
            foreach (var menu in menus)
            {
                var contextMenu = new ContextMenu();
                contextMenu.Collapse += (sender, args) =>
                    {
                        WindowState = FormWindowState.Minimized;
                    };
                contextMenu.MenuItems.Add("Отмена");
                contextMenu.MenuItems.Add("-");
                contextMenu.MenuItems.AddRange(menu.GetMenuItems());
                contextMenu.MenuItems.Add("-");
                contextMenu.MenuItems.Add(new MenuItem("Настроить меню", (sender, args) => CustomizeMenus()));
                contextMenu.MenuItems.Add(new MenuItem("Закрыть программу", (sender, args) => Close()));

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

        private void CustomizeMenus()
        {
            //TODO: вносить изменения в клон переданного объекта, чтобы изменения применялись только по требованию пользователя (кнопка "сохранить")
            var customizeShortcutForm = new CustomizationForm {ShortcutMenus = menus};
            customizeShortcutForm.ShowDialog();
        }

        private void ShowMenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveMenu(menus, "settings.xml");
            UnregisterHotKey();
        }

        private void UnregisterHotKey()
        {
            foreach (var menu in menus)
                menu.UnregisterHotkey();
            //UnregisterHotKey(Handle, GetType().GetHashCode());
        }

        public void SaveMenu(List<ShortcutMenu> shortcutMenus, string settingsFilename)
        {
            try
            {
                using (var writer = new StreamWriter(settingsFilename))
                {
                    var serializer = new XmlSerializer(typeof(List<ShortcutMenu>));
                    serializer.Serialize(writer, shortcutMenus);
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CustomShortcutMenu
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable, XmlInclude(typeof(ShortcutMenuItem))]
    public class ShortcutMenu : IDisposable
    {
        private readonly GlobalHotkeys hotkey = new GlobalHotkeys();
        public List<ShortcutMenu> SubItems { get; set; }
        public Keys Shortcut { get; set; }
        public Keys Modifiers { get; set; }
        public byte CharCode { get { return (byte)Shortcut; } }

        public short HotkeyId
        {
            get { return hotkey.HotkeyID; }
        }

        public void RegisterHotkey(IntPtr handle)
        {
            //hotkey = new GlobalHotkeys();
            hotkey.RegisterGlobalHotKey(CharCode, Win32Modifiers, handle);
        }

        public void UnregisterHotkey()
        {
            hotkey.UnregisterGlobalHotKey();
        }

        private const byte ModAlt = 1, ModControl = 2, ModShift = 4, ModWin = 8;
        public byte Win32Modifiers
        {
            get
            {
                byte toReturn = 0;
                if (IsShift)
                    toReturn += ModShift;
                if (IsControl)
                    toReturn += ModControl;
                if (IsAlt)
                    toReturn += ModAlt;
                return toReturn;
            }
        }

        private bool IsShift
        {
            get { return (Modifiers & Keys.Shift) != Keys.None; }
        }

        private bool IsControl
        {
            get { return (Modifiers & Keys.Control) != Keys.None; }
        }

        private bool IsAlt
        {
            get { return (Modifiers & Keys.Alt) != Keys.None; }
        }

        public string Description { get; set; }

        public virtual MenuItem GetMenuItem()
        {
            var menuItem = new MenuItem(Description){Shortcut = (Shortcut) Shortcut};
            if (SubItems != null)
                menuItem.MenuItems.AddRange(GetMenuItems());
            return menuItem;
        }

        public MenuItem[] GetMenuItems()
        {
            return SubItems.Select(item => item.GetMenuItem()).ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (IsControl) sb.Append("<Control> + ");
            if (IsAlt) sb.Append("<Alt> + ");
            if (IsShift) sb.Append("<Shift> + ");
            if (Shortcut!=Keys.None) sb.Append(Shortcut);

            return base.ToString() + " " + sb;
        }

        public void Dispose()
        {
            hotkey.Dispose();
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CustomShortcutMenu
{
    [Serializable]
    public class ShortcutMenuItem : ShortcutMenu
    {
        public string Filename { get; set; }

        public override MenuItem GetMenuItem()
        {
            var menuItem = base.GetMenuItem();
            if (SubItems == null || SubItems.Count == 0) menuItem.Click += (sender, e) =>
                {
                    if (File.Exists(Filename))
                    {
                        var processStartInfo = new ProcessStartInfo(Filename)
                            {
                                WorkingDirectory = Path.GetDirectoryName(Filename)
                            };
                        Process.Start(processStartInfo);
                        //new Process()
                    }
                    else
                        MessageBox.Show
                            (
                                string.Format("Файл {0} не найден", Filename),
                                "Не найден файл для запуска",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                };
            return menuItem;
        }
    }
}
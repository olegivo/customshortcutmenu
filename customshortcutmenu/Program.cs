using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CustomShortcutMenu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Shortcuts();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ShowMenuForm());
        }

        private static void Shortcuts()
        {
            var shortcutMenus = new List<ShortcutMenu>();
            shortcutMenus.Add
                (
                    new ShortcutMenu
                        {
                            Description = "F11",
                            Shortcut = Keys.F11,
                            Modifiers = Keys.Control | Keys.Alt | Keys.Shift,
                            SubItems = new List<ShortcutMenu>(new[]
                                {
                                    new ShortcutMenu
                                        {
                                            Description = "1",
                                            SubItems = new List<ShortcutMenu>
                                                {
                                                    new ShortcutMenuItem
                                                        {
                                                            Description = "11",
                                                            Filename = @"c:\11.bat"
                                                        },
                                                    new ShortcutMenuItem
                                                        {
                                                            Description = "12",
                                                            Filename = @"c:\12.bat"
                                                        }

                                                }
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "2",
                                            Filename = @"c:\1.bat"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "3",
                                            Filename = @"c:\2.bat"
                                        }
                                })
                        });
            shortcutMenus.Add
                (
                    new ShortcutMenu
                        {
                            Description = "F12",
                            Shortcut = Keys.F12,
                            Modifiers = Keys.Control | Keys.Alt | Keys.Shift,
                            SubItems = new List<ShortcutMenu>(new[]
                                {
                                    new ShortcutMenu
                                        {
                                            Description = "4",
                                            SubItems = new List<ShortcutMenu>
                                                {
                                                    new ShortcutMenuItem
                                                        {
                                                            Description = "41",
                                                            Filename = @"c:\41.bat"
                                                        },
                                                    new ShortcutMenuItem
                                                        {
                                                            Description = "42",
                                                            Filename = @"c:\42.bat"
                                                        }

                                                }
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "5",
                                            Filename = @"c:\5.bat"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "6",
                                            Filename = @"c:\6.bat"
                                        }
                                })
                        });

            try
            {
                using (var writer = new StreamWriter("settings.xml"))
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

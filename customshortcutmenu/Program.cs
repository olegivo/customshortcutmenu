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
                            Description = "Обновить",
                            Shortcut = Keys.F11,
                            Modifiers = Keys.Control | Keys.Alt | Keys.Shift,
                            SubItems = new List<ShortcutMenu>(new[]
                                {
                                    new ShortcutMenuItem
                                        {
                                            Description = "Update CityEstate",
                                            Filename = @"D:\Documents\Batch\Update CityEstate.cmd"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "Update SVNDocs",
                                            Filename = @"D:\Documents\Batch\Update SVNDocs.cmd"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "Update WebMedia",
                                            Filename = @"D:\Documents\Batch\Update WebMedia.cmd"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "Update AdSender",
                                            Filename = @"D:\Documents\Batch\Update AdSender.cmd"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "Update AvitoTools",
                                            Filename = @"D:\Documents\Batch\Update AvitoTools.cmd"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "Update ParseReports",
                                            Filename = @"D:\Documents\Batch\Update ParseReports.cmd"
                                        }
                                })
                        });
            shortcutMenus.Add
                (
                    new ShortcutMenu
                        {
                            Description = "Открыть",
                            Shortcut = Keys.F12,
                            Modifiers = Keys.Control | Keys.Alt | Keys.Shift,
                            SubItems = new List<ShortcutMenu>(new[]
                                {
                                    new ShortcutMenuItem
                                        {
                                            Description = "CityEstate",
                                            Filename = @"C:\Industry\Win32\CityEstate\CityEstate.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "WebMedia",
                                            Filename = @"C:\Industry\Win32\WebMedia\WebMedia.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "MediaEditor",
                                            Filename =
                                                @"C:\Industry\Win32\CityEstate\Utility\MediaEditor\MediaEditor.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "ChainEditor",
                                            Filename =
                                                @"C:\Industry\Win32\CityEstate\Utility\ChainEditor\ChainEditor.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "MediaServices",
                                            Filename =
                                                @"C:\Industry\Win32\CityEstate\Utility\MediaServices\MediaServices.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "WebMediaDatabase",
                                            Filename = @"C:\Industry\Win32\WebMedia\DB\WebMediaDatabase.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "CityEstateDatabase",
                                            Filename = @"C:\Industry\Win32\CityEstate\DB\CityEstateDatabase.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "WebMediaCMS",
                                            Filename = @"C:\Industry\Win32\WebMedia\Main\WebMediaCMS\WebMediaCMS.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "AdSending",
                                            Filename = @"C:\industry\Win32\AdSending\AdSending.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "AvitoTools",
                                            Filename = @"C:\Industry\Win32\AvitoTools\AvitoTools.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "AvitoAgentDB",
                                            Filename = @"C:\Industry\Win32\AvitoTools\DB\AvitoAgentDB.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "RTServer",
                                            Filename = @"C:\Industry\Databases\RTServer\RTServer.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "MediaProviderDatabase",
                                            Filename = @"C:\Industry\Databases\MediaProvider\MediaProviderDatabase.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "NMarketMedia",
                                            Filename =
                                                @"C:\Industry\Win32\CityEstate\Utility\NMarketMedia\NMarketMedia.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "RealTime",
                                            Filename = @"C:\Industry\BI.Realtime\RealTime.sln"
                                        },
                                    new ShortcutMenuItem
                                        {
                                            Description = "AdLinks.Collectors",
                                            Filename = @"C:\Industry\Win32\ParseReports\AdLinks.Collectors.sln"
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

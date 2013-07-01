using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomShortcutMenu
{
    public partial class CustomizationForm : Form
    {
        public CustomizationForm()
        {
            InitializeComponent();
        }

        public List<ShortcutMenu> ShortcutMenus { get; set; }

        private void BuildItem(ShortcutMenu shortcutMenu, TreeNodeCollection nodes)
        {
            var treeNode = nodes.Add(shortcutMenu.ToString());
            treeNode.Tag = shortcutMenu;
            if (shortcutMenu.SubItems!=null)
                foreach (var subItem in shortcutMenu.SubItems)
                    BuildItem(subItem, treeNode.Nodes);
        }

        private void CustomizationForm_Load(object sender, System.EventArgs e)
        {
            foreach (var shortcutMenu in ShortcutMenus)
                BuildItem(shortcutMenu, treeView1.Nodes);
            treeView1.ExpandAll();
        }

        private ShortcutMenu GetSelectedMenu(TreeNode node)
        {
            return node != null ? node.Tag as ShortcutMenu : null;
        }

        private void buttonEdit_Click(object sender, System.EventArgs e)
        {
            if (treeView1.SelectedNode != null && treeView1.SelectedNode.Level == 0)
            {
                var menu = GetSelectedMenu(treeView1.SelectedNode);
                var form = new CustomizeShortcutForm { ShortcutMenu = menu };
                form.ShowDialog();
            }
        }

        private void buttonAddSubItem_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonAddNewMenu_Click(object sender, System.EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, System.EventArgs e)
        {

        }
    }
}

namespace CustomShortcutMenu
{
    partial class CustomizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonAddNewMenu = new System.Windows.Forms.Button();
            this.buttonAddSubItem = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(361, 282);
            this.treeView1.TabIndex = 0;
            // 
            // buttonAddNewMenu
            // 
            this.buttonAddNewMenu.Location = new System.Drawing.Point(379, 70);
            this.buttonAddNewMenu.Name = "buttonAddNewMenu";
            this.buttonAddNewMenu.Size = new System.Drawing.Size(191, 23);
            this.buttonAddNewMenu.TabIndex = 1;
            this.buttonAddNewMenu.Text = "Добавить новое меню";
            this.buttonAddNewMenu.UseVisualStyleBackColor = true;
            this.buttonAddNewMenu.Click += new System.EventHandler(this.buttonAddNewMenu_Click);
            // 
            // buttonAddSubItem
            // 
            this.buttonAddSubItem.Location = new System.Drawing.Point(379, 41);
            this.buttonAddSubItem.Name = "buttonAddSubItem";
            this.buttonAddSubItem.Size = new System.Drawing.Size(191, 23);
            this.buttonAddSubItem.TabIndex = 2;
            this.buttonAddSubItem.Text = "Добавить вложенный элемент";
            this.buttonAddSubItem.UseVisualStyleBackColor = true;
            this.buttonAddSubItem.Click += new System.EventHandler(this.buttonAddSubItem_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(379, 12);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(191, 23);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(379, 99);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(191, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // CustomizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 306);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAddSubItem);
            this.Controls.Add(this.buttonAddNewMenu);
            this.Controls.Add(this.treeView1);
            this.Name = "CustomizationForm";
            this.Text = "CustomizationForm";
            this.Load += new System.EventHandler(this.CustomizationForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonAddNewMenu;
        private System.Windows.Forms.Button buttonAddSubItem;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
    }
}
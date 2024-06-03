namespace General_Tree
{
    partial class Form1
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonInsertNode = new System.Windows.Forms.Button();
            this.buttonDeleteNode = new System.Windows.Forms.Button();
            this.buttonSearchNode = new System.Windows.Forms.Button();
            this.buttonAddItem = new System.Windows.Forms.Button();
            this.buttonRemoveItem = new System.Windows.Forms.Button();
            this.buttonFindItem = new System.Windows.Forms.Button();
            this.buttonMKGTree = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.listBox = new System.Windows.Forms.ListBox();
            this.buttonDeSelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox.Location = new System.Drawing.Point(312, 12);
            this.textBox.MaxLength = 20;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(219, 29);
            this.textBox.TabIndex = 1;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // buttonInsertNode
            // 
            this.buttonInsertNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonInsertNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInsertNode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonInsertNode.Location = new System.Drawing.Point(537, 12);
            this.buttonInsertNode.Name = "buttonInsertNode";
            this.buttonInsertNode.Size = new System.Drawing.Size(220, 63);
            this.buttonInsertNode.TabIndex = 3;
            this.buttonInsertNode.Text = "Insert Node";
            this.buttonInsertNode.UseVisualStyleBackColor = false;
            this.buttonInsertNode.Click += new System.EventHandler(this.buttonInsertNode_Click);
            // 
            // buttonDeleteNode
            // 
            this.buttonDeleteNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonDeleteNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteNode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDeleteNode.Location = new System.Drawing.Point(537, 81);
            this.buttonDeleteNode.Name = "buttonDeleteNode";
            this.buttonDeleteNode.Size = new System.Drawing.Size(220, 63);
            this.buttonDeleteNode.TabIndex = 4;
            this.buttonDeleteNode.Text = "Delete Node";
            this.buttonDeleteNode.UseVisualStyleBackColor = false;
            this.buttonDeleteNode.Click += new System.EventHandler(this.buttonDeleteNode_Click);
            // 
            // buttonSearchNode
            // 
            this.buttonSearchNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonSearchNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSearchNode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSearchNode.Location = new System.Drawing.Point(537, 150);
            this.buttonSearchNode.Name = "buttonSearchNode";
            this.buttonSearchNode.Size = new System.Drawing.Size(220, 63);
            this.buttonSearchNode.TabIndex = 5;
            this.buttonSearchNode.Text = "Search Node";
            this.buttonSearchNode.UseVisualStyleBackColor = false;
            this.buttonSearchNode.Click += new System.EventHandler(this.buttonSearchNode_Click);
            // 
            // buttonAddItem
            // 
            this.buttonAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonAddItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddItem.Location = new System.Drawing.Point(537, 219);
            this.buttonAddItem.Name = "buttonAddItem";
            this.buttonAddItem.Size = new System.Drawing.Size(220, 63);
            this.buttonAddItem.TabIndex = 6;
            this.buttonAddItem.Text = "Add Item";
            this.buttonAddItem.UseVisualStyleBackColor = false;
            this.buttonAddItem.Click += new System.EventHandler(this.buttonAddItem_Click);
            // 
            // buttonRemoveItem
            // 
            this.buttonRemoveItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemoveItem.Location = new System.Drawing.Point(537, 288);
            this.buttonRemoveItem.Name = "buttonRemoveItem";
            this.buttonRemoveItem.Size = new System.Drawing.Size(220, 63);
            this.buttonRemoveItem.TabIndex = 7;
            this.buttonRemoveItem.Text = "Remove Item";
            this.buttonRemoveItem.UseVisualStyleBackColor = false;
            this.buttonRemoveItem.Click += new System.EventHandler(this.buttonRemoveItem_Click);
            // 
            // buttonFindItem
            // 
            this.buttonFindItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonFindItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFindItem.Location = new System.Drawing.Point(537, 357);
            this.buttonFindItem.Name = "buttonFindItem";
            this.buttonFindItem.Size = new System.Drawing.Size(220, 63);
            this.buttonFindItem.TabIndex = 8;
            this.buttonFindItem.Text = "Find Item";
            this.buttonFindItem.UseVisualStyleBackColor = false;
            this.buttonFindItem.Click += new System.EventHandler(this.buttonFindItem_Click);
            // 
            // buttonMKGTree
            // 
            this.buttonMKGTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonMKGTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMKGTree.Location = new System.Drawing.Point(537, 426);
            this.buttonMKGTree.Name = "buttonMKGTree";
            this.buttonMKGTree.Size = new System.Drawing.Size(220, 81);
            this.buttonMKGTree.TabIndex = 9;
            this.buttonMKGTree.Text = "Make General Tree";
            this.buttonMKGTree.UseVisualStyleBackColor = false;
            this.buttonMKGTree.Click += new System.EventHandler(this.buttonMKGTree_Click);
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.treeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView.Location = new System.Drawing.Point(12, 12);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(294, 495);
            this.treeView.TabIndex = 10;
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 24;
            this.listBox.Location = new System.Drawing.Point(312, 71);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(219, 436);
            this.listBox.TabIndex = 13;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // buttonDeSelectAll
            // 
            this.buttonDeSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonDeSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeSelectAll.Location = new System.Drawing.Point(312, 45);
            this.buttonDeSelectAll.Name = "buttonDeSelectAll";
            this.buttonDeSelectAll.Size = new System.Drawing.Size(219, 23);
            this.buttonDeSelectAll.TabIndex = 14;
            this.buttonDeSelectAll.Text = "ClearTextBox and DeSelect";
            this.buttonDeSelectAll.UseVisualStyleBackColor = false;
            this.buttonDeSelectAll.Click += new System.EventHandler(this.buttonDeSelectAll_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 513);
            this.Controls.Add(this.buttonDeSelectAll);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.buttonMKGTree);
            this.Controls.Add(this.buttonFindItem);
            this.Controls.Add(this.buttonRemoveItem);
            this.Controls.Add(this.buttonAddItem);
            this.Controls.Add(this.buttonSearchNode);
            this.Controls.Add(this.buttonDeleteNode);
            this.Controls.Add(this.buttonInsertNode);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "General Tree";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonInsertNode;
        private System.Windows.Forms.Button buttonDeleteNode;
        private System.Windows.Forms.Button buttonSearchNode;
        private System.Windows.Forms.Button buttonAddItem;
        private System.Windows.Forms.Button buttonRemoveItem;
        private System.Windows.Forms.Button buttonFindItem;
        private System.Windows.Forms.Button buttonMKGTree;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button buttonDeSelectAll;
    }
}


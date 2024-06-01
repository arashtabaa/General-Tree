using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace General_Tree
{
    public partial class Form1 : Form
    {
        private TreeNode GeneralTreeNode; // نود اصلی درخت عمومی
        private List<TreeNode> InsertNodes; // لیست نودهایی که با InsertNode اضافه شده‌اند
        private List<TreeNode> AddItemNodes; // لیست نودهایی که با AddItem اضافه شده‌اند
        private List<string> ListBoxItems; // لیست آیتم‌های لیست‌باکس

        public Form1()
        {
            InitializeComponent();
            InsertNodes = new List<TreeNode>();
            AddItemNodes = new List<TreeNode>();
            ListBoxItems = new List<string>();
        }

        // رویداد کلیک برای دکمه AddItem
        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();

            // بررسی خالی نبودن ورودی
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a valid name or number.");
                return;
            }

            // بررسی وجود آیتم تکراری در لیست باکس
            if (listBox.Items.Contains(input))
            {
                MessageBox.Show("Duplicate name is not allowed.");
                return;
            }

            listBox.Items.Add(input);
            ListBoxItems.Add(input); // اضافه کردن آیتم به لیست آیتم‌ها
            textBox.Clear();
        }

        // رویداد کلیک برای دکمه تبدیل آیتم به درخت اصلی
        private void buttonMKGTree_Click(object sender, EventArgs e)
        {
            // بررسی آیا حداقل یک آیتم در لیست باکس انتخاب شده است
            if (listBox.SelectedItem != null)
            {
                // بررسی آیا متنی در تکست باکس وارد شده است یا خیر
                if (string.IsNullOrEmpty(textBox.Text.Trim()))
                {
                    MessageBox.Show("Please enter a name for the main tree.");
                    return;
                }

                // انتخاب نام برای ساخت درخت اصلی
                string input = textBox.Text.Trim();

                // بررسی وجود نام تکراری در لیست باکس
                if (listBox.Items.Contains(input))
                {
                    MessageBox.Show("A tree with this name already exists.");
                    return;
                }

                // بررسی وجود نام تکراری در درخت
                if (TreeContainsName(input, GeneralTreeNode))
                {
                    MessageBox.Show("A tree with this name already exists.");
                    return;
                }

                // نمایش پیام تأیید
                DialogResult result = MessageBox.Show("You are about to create a new main tree. Are you sure?",
                                                      "Confirm Create New Main Tree",
                                                      MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // ساخت درخت اصلی جدید
                    TreeNode rootNode = new TreeNode(input);
                    treeView.Nodes.Clear();
                    treeView.Nodes.Add(rootNode);
                    GeneralTreeNode = rootNode;

                    InsertNodes.Clear();
                    AddItemNodes.Clear();

                    // اضافه کردن نام درخت جدید به لیست باکس و پاک کردن سایر آیتم‌ها
                    listBox.Items.Clear();
                    listBox.Items.Add(input);

                    UpdateListBox();
                    treeView.ExpandAll();

                    // پاک کردن محتوای textBox
                    textBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please select an item from the list to create a new main tree.");
            }
        }

        // رویداد کلیک برای دکمه InsertNode
        private void buttonInsertNode_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem == null || treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select an item from the list and a node from the tree.");
                return;
            }

            string input = listBox.SelectedItem.ToString();
            TreeNode selectedNode = treeView.SelectedNode;

            // بررسی عدم وجود نود تکراری و عدم افزودن نود با نام نود اصلی به درخت
            if (selectedNode.Nodes.Cast<TreeNode>().Any(node => node.Text.Equals(input, StringComparison.OrdinalIgnoreCase)) ||
                input.Equals(GeneralTreeNode.Text, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Duplicate name or adding the main tree node name is not allowed.");
                return;
            }

            // بررسی تطابق نام نود جدید با نام نودهای زیرمجموعه
            foreach (TreeNode node in selectedNode.Nodes)
            {
                if (node.Text.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Duplicate name within subtree is not allowed.");
                    return;
                }
            }

            // بررسی تطابق نام نود جدید با نام نودهای اضافه شده به درخت
            if (TreeContainsName(input, GeneralTreeNode))
            {
                MessageBox.Show("Duplicate name already exists in the tree.");
                return;
            }

            TreeNode newNode = new TreeNode(input);
            selectedNode.Nodes.Add(newNode);
            InsertNodes.Add(newNode);

            // اضافه کردن نام نود جدید به لیست آیتم‌ها
            ListBoxItems.Add(input);

            UpdateListBox();
            treeView.ExpandAll();
            textBox.Clear();
        }

        // متد برای بررسی وجود نام در درخت
        private bool TreeContainsName(string name, TreeNode rootNode)
        {
            if (rootNode == null)
                return false;

            if (rootNode.Text.Equals(name, StringComparison.OrdinalIgnoreCase))
                return true;

            foreach (TreeNode node in rootNode.Nodes)
            {
                if (TreeContainsName(name, node))
                    return true;
            }

            return false;
        }

        // بروزرسانی ListBox
        private void UpdateListBox()
        {
            listBox.Items.Clear();

            // اضافه کردن درخت اصلی به لیست باکس
            if (GeneralTreeNode != null)
            {
                listBox.Items.Add(GeneralTreeNode.Text);
            }

            // اضافه کردن نودهای درخت اصلی به لیست باکس
            foreach (TreeNode node in GeneralTreeNode.Nodes)
            {
                listBox.Items.Add(node.Text);
            }

            // اضافه کردن نودهای InsertNodes به لیست باکس
            foreach (TreeNode node in InsertNodes)
            {
                // بررسی اینکه نود در لیست باکس وجود ندارد
                if (!listBox.Items.Contains(node.Text))
                {
                    listBox.Items.Add(node.Text);
                }
            }

            // اضافه کردن آیتم‌های باقی‌مانده به لیست باکس
            foreach (string item in ListBoxItems)
            {
                // بررسی اینکه آیتم در لیست باکس وجود ندارد و آیتم درخت اصلی نیست
                if (!listBox.Items.Contains(item) && item != GeneralTreeNode.Text)
                {
                    listBox.Items.Add(item);
                }
            }
        }

        // رویداد کلیک برای دکمه DeleteItem
        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            // بررسی اینکه آیا آیتمی در لیست باکس انتخاب شده است یا خیر
            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an item to remove.");
                return;
            }

            string selectedItem = listBox.SelectedItem.ToString();

            // بررسی اینکه آیا آیتم انتخاب شده در لیست باکس، نام اولین درخت است
            if (treeView.Nodes.Count > 0 && selectedItem.Equals(treeView.Nodes[0].Text))
            {
                // نمایش پیام هشداری برای تأیید حذف درخت اصلی
                DialogResult result = MessageBox.Show("Are you sure you want to delete the main tree and all its items?",
                                                      "Confirm Delete",
                                                      MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // پاک کردن همه درخت‌ها و لیست آیتم‌ها
                    treeView.Nodes.Clear();
                    listBox.Items.Clear();
                    ListBoxItems.Clear();
                    GeneralTreeNode = null;

                    MessageBox.Show("Main tree and all its items have been deleted successfully.");
                    textBox.Clear();
                }
            }
            else
            {
                // نمایش پیام هشداری برای تأیید حذف آیتم
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?",
                                                      "Confirm Delete",
                                                      MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    // حذف آیتم از لیست باکس
                    listBox.Items.Remove(selectedItem);
                    ListBoxItems.Remove(selectedItem); // اختیاری: حذف آیتم از لیست موقت آیتم‌ها

                    // حذف نود از درخت در صورتی که وجود داشته باشد
                    TreeNode nodeToRemove = FindNodeByText(GeneralTreeNode, selectedItem);
                    if (nodeToRemove != null)
                    {
                        nodeToRemove.Remove();
                    }

                    MessageBox.Show("Item deleted successfully.");
                    textBox.Clear();
                }
            }

            // بررسی اینکه آیا لیست باکس خالی شده است
            if (listBox.Items.Count == 0)
            {
                GeneralTreeNode = null;
                MessageBox.Show("There are no items in the list. Please create a new tree.");
            }
        }

        // جستجوی نود بر اساس متن
        private TreeNode FindNodeByText(TreeNode rootNode, string text)
        {
            if (rootNode == null)
                return null;

            if (rootNode.Text.Equals(text, StringComparison.OrdinalIgnoreCase))
                return rootNode;

            foreach (TreeNode node in rootNode.Nodes)
            {
                TreeNode foundNode = FindNodeByText(node, text);
                if (foundNode != null)
                    return foundNode;
            }

            return null;
        }

        // رویداد کلیک برای دکمه FindItem - جستجوی آیتم و انتخاب آن در لیست باکس
        private void buttonFindItem_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a valid name or number.");
                return;
            }

            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (listBox.Items[i].ToString().Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    listBox.SelectedIndex = i;
                    MessageBox.Show("Item found and selected in list box.");
                    return;
                }
            }

            MessageBox.Show("Item not found in list box.");
        }

        // رویداد تغییر متن در تکست باکس
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            string input = textBox.Text;
            textBox.Text = RemoveExtraSpaces(input);
            textBox.SelectionStart = textBox.Text.Length;
        }

        // حذف فاصله‌های اضافی از متن ورودی
        private string RemoveExtraSpaces(string input)
        {
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }
            return input;
        }

        // رویداد کلید Enter برای textBox
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            // بررسی فشرده شدن کلید Enter
            if (e.KeyCode == Keys.Enter)
            {
                string input = textBox.Text.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Please enter a valid name or number.");
                    return;
                }

                if (listBox.Items.Contains(input))
                {
                    MessageBox.Show("Duplicate name is not allowed.");
                    return;
                }

                if (GeneralTreeNode == null)
                {
                    DialogResult result = MessageBox.Show("No general tree found. Do you want to create a new tree with this name?",
                                                          "Create New Tree",
                                                          MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TreeNode rootNode = new TreeNode(input);
                        treeView.Nodes.Clear();
                        treeView.Nodes.Add(rootNode);
                        GeneralTreeNode = rootNode;

                        InsertNodes.Clear();
                        AddItemNodes.Clear();

                        listBox.Items.Add(input);
                        ListBoxItems.Add(input); // اضافه کردن آیتم به لیست آیتم‌ها
                        textBox.Clear();
                    }
                }
                else
                {
                    listBox.Items.Add(input);
                    ListBoxItems.Add(input); // اضافه کردن آیتم به لیست آیتم‌ها
                    textBox.Clear();
                }

                e.SuppressKeyPress = true; // جلوگیری از بوق سیستم
            }
        }

        private void buttonSearchNode_Click(object sender, EventArgs e)
        {
            string searchText = textBox.Text.Trim();

            // بررسی اینکه آیا متن وارد شده خالی نیست
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a valid search text.");
                return;
            }

            // جستجوی نود با متن وارد شده
            TreeNode foundNode = FindNodeWithText(GeneralTreeNode, searchText);

            // بررسی اینکه آیا نود با متن وارد شده پیدا شده یا خیر
            if (foundNode != null)
            {
                // انتخاب نود پیداشده در درخت
                treeView.SelectedNode = foundNode;
                treeView.SelectedNode.Expand();
                treeView.Focus();
                MessageBox.Show("Node found and selected.");
            }
            else
            {
                MessageBox.Show("Node not found.");
            }
        }

        // جستجوی نود با متن مورد نظر
        private TreeNode FindNodeWithText(TreeNode rootNode, string searchText)
        {
            // بررسی اینکه آیا روت نود نال است یا خیر
            if (rootNode == null)
                return null;

            // بررسی متن روت نود
            if (rootNode.Text.Equals(searchText, StringComparison.OrdinalIgnoreCase))
                return rootNode;

            // حلقه‌ی تکرار بر روی تمامی نودهای زیرمجموعه روت نود
            foreach (TreeNode node in rootNode.Nodes)
            {
                // جستجوی نود با متن مورد نظر در زیرمجموعه‌ها
                TreeNode foundNode = FindNodeWithText(node, searchText);
                // اگر نود پیدا شده است، آن را برگردان
                if (foundNode != null)
                    return foundNode;
            }

            // اگر نود با متن مورد نظر پیدا نشد، نال برگردان
            return null;
        }

        private void buttonDeleteNode_Click(object sender, EventArgs e)
        {
            // بررسی اینکه آیا نودی انتخاب شده است یا خیر
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a node to delete.");
                return;
            }

            TreeNode selectedNode = treeView.SelectedNode;

            // نمایش پیام هشدار برای تأیید حذف نود
            DialogResult result = MessageBox.Show("Are you sure you want to delete this node and all its children?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // حذف نود و تمامی زیرمجموعه‌های آن
                selectedNode.Remove();
                UpdateListBox();
                MessageBox.Show("Node and its children deleted successfully.");
                textBox.Clear();
            }
        }

        private void buttonDeSelectAll_Click_1(object sender, EventArgs e)
        {
            textBox.Clear();
            // بررسی تمامی آیتم‌های ListBox
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                // بررسی اینکه آیا آیتم جاری انتخاب شده است یا خیر
                if (listBox.GetSelected(i))
                {
                    // حذف انتخاب از آیتم جاری
                    listBox.SetSelected(i, false);
                }
            }
        }

        // رویداد انتخاب آیتم در لیست باکس
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // انتقال نام آیتم انتخاب شده در لیست باکس به تکست باکس
            if (listBox.SelectedItem != null)
            {
                textBox.Text = listBox.SelectedItem.ToString();
            }
        }
    }
}

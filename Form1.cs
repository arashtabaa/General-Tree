using System;
using System.Runtime.Remoting.Lifetime;
using System.Windows.Forms;
using System.Xml.Linq;

namespace General_Tree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox.SelectionMode = SelectionMode.None; // غیرفعال کردن انتخاب آیتم‌های لیست باکس
        }

        // ویژگی برای مشخص کردن اولین درخت عمومی انتخاب شده
        private bool IsFirstNodeOfTree(TreeNode node)
        {
            return node == treeView.Nodes[0];
        }

        // رویداد کلیک دکمه buttonMKGTree برای ایجاد ریشه درخت
        private void buttonMKGTree_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();

            // بررسی خالی بودن متن ورودی
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a valid name or number.");
                return;
            }

            // بررسی وجود درخت عمومی و نمایش پیام تاییدیه
            if (treeView.Nodes.Count > 0)
            {
                DialogResult result = MessageBox.Show("You are about to delete the existing general tree. Are you sure?",
                                                      "Confirm Create New Tree",
                                                      MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    return;
                }
            }

            // ایجاد ریشه جدید و پاک کردن ریشه‌های قبلی
            TreeNode rootNode = new TreeNode(input);
            treeView.Nodes.Clear();
            treeView.Nodes.Add(rootNode);
            // تنظیم ویژگی IsFirstNodeOfTree برای اولین درخت عمومی انتخاب شده
            rootNode.Tag = "FirstTree";

            // پاک کردن و افزودن نام ریشه به لیست
            listBox.Items.Clear();
            listBox.Items.Add(input);

            // باز کردن تمام نودها و زیرمجموعه‌ها
            treeView.ExpandAll();

            textBox.Clear();
        }

        // رویداد کلیک دکمه buttonInsertNode برای افزودن نود به درخت
        private void buttonInsertNode_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();

            // بررسی خالی بودن متن ورودی
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a valid name or number.");
                return;
            }

            // بررسی انتخاب نود در درخت
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a node to add an item.");
                return;
            }

            // بررسی آیا نود انتخاب شده درخت عمومی است یا نه
            if (!IsFirstNodeOfTree(treeView.SelectedNode))
            {
                MessageBox.Show("You can only add items to nodes under the main general tree.");
                return;
            }

            // بررسی تکراری نبودن نام نود
            TreeNode selectedNode = treeView.SelectedNode;
            foreach (TreeNode node in selectedNode.Nodes)
            {
                if (node.Text.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Duplicate name is not allowed.");
                    return;
                }
            }

            // افزودن نود جدید به زیرمجموعه‌های نود انتخاب شده
            TreeNode newNode = new TreeNode(input);
            selectedNode.Nodes.Add(newNode);


            // به روزرسانی لیست
            UpdateListBox();

            // باز کردن تمام نودها و زیرمجموعه‌ها
            treeView.ExpandAll();

            textBox.Clear();
        }

        // متد برای به روزرسانی لیست بر اساس ساختار درخت
        private void UpdateListBox()
        {
            listBox.Items.Clear();
            foreach (TreeNode node in treeView.Nodes)
            {
                AddNodeToListBox(node, 0);
            }
        }

        // متد برای افزودن نود به لیست با رعایت سطح درخت
        private void AddNodeToListBox(TreeNode node, int level)
        {
            string indent = new string(' ', level * 2);
            listBox.Items.Add(indent + node.Text);

            foreach (TreeNode childNode in node.Nodes)
            {
                AddNodeToListBox(childNode, level + 1);
            }
        }

        // رویداد کلیک دکمه buttonDeleteNode برای حذف نود انتخاب شده
        private void buttonDeleteNode_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a node in the tree to delete.");
                return;
            }

            TreeNode selectedNode = treeView.SelectedNode;

            // نمایش پیام تایید حذف نود
            DialogResult result = MessageBox.Show("Are you sure you want to delete this node and all its children?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                selectedNode.Remove();
                UpdateListBox();
            }
        }

        // رویداد کلیک دکمه buttonSearchNode برای جستجوی نود
        private void buttonSearchNode_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();

            // بررسی خالی بودن متن ورودی
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a valid name or number.");
                return;
            }

            TreeNode selectedNode = treeView.SelectedNode;

            // بررسی اینکه آیا نود انتخاب شده نود اولین درخت عمومی است یا نه
            if (selectedNode != null && IsFirstNodeOfTree(selectedNode))
            {
                // گرفتن اولین نود که درخت عمومی است
                TreeNode mainGeneralTree = treeView.Nodes[0];

                // جستجوی نود در نود‌های مستقیم درخت عمومی
                foreach (TreeNode node in mainGeneralTree.Nodes)
                {
                    if (node.Text.Equals(input, StringComparison.OrdinalIgnoreCase))
                    {
                        // نمایش نود موردنظر اگر در نود‌های مستقیم درخت عمومی پیدا شود
                        treeView.SelectedNode = node;
                        treeView.SelectedNode.Expand();
                        treeView.Focus();
                        MessageBox.Show("Node found and selected.");
                        return; // پس از یافتن نود، از حلقه خارج شوید
                    }
                }

                // اگر نود موردنظر یافت نشد، نمایش پیام مناسب
                MessageBox.Show("Node not found.");
            }
            else
            {
                // در صورتی که نود اولین درخت عمومی انتخاب نشده باشد، نمایش پیام مناسب
                MessageBox.Show("You can only search in the main general tree.");
            }
        }

        // متد بازگشتی برای جستجوی نود در نودهای مستقیم درخت
        private TreeNode FindNode(TreeNodeCollection nodes, string text)
        {
            foreach (TreeNode node in nodes)
            {
                // اگر متن نود فعلی با متن ورودی برابر باشد، نود فعلی را برمی‌گرداند
                if (node.Text.Equals(text, StringComparison.OrdinalIgnoreCase))
                {
                    return node;
                }

                // اگر نود فعلی فرزند نداشته باشد، این قسمت را از دست می‌دهد
                // در غیر این صورت، به طور بازگشتی در زیرمجموعه‌های نود فعلی جستجو می‌کند
                TreeNode foundNode = FindNode(node.Nodes, text);
                if (foundNode != null)
                {
                    return foundNode;
                }
            }

            // اگر نودی با متن ورودی پیدا نشود، null برمی‌گردد
            return null;
        }

        // رویداد کلیک دکمه buttonAddItem برای افزودن آیتم به زیر مجموعه نود انتخاب شده
        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();

            // بررسی خالی بودن متن ورودی
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a valid name or number.");
                return;
            }

            // بررسی انتخاب نود در درخت
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a node to add an item.");
                return;
            }

            // بررسی آیا نود انتخاب شده درخت عمومی است یا نه
            if (treeView.SelectedNode.Parent == null && IsFirstNodeOfTree(treeView.SelectedNode) && treeView.SelectedNode.Tag?.ToString() == "FirstTree")
            {
                MessageBox.Show("You can only insert nodes under the main general tree.");
                return;
            }

            // بررسی تکراری نبودن نام نود
            foreach (TreeNode node in treeView.SelectedNode.Nodes)
            {
                if (node.Text.Equals(input, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Duplicate name is not allowed.");
                    return;
                }
            }

            // افزودن نود جدید به زیرمجموعه‌های نود انتخاب شده
            TreeNode selectedNode = treeView.SelectedNode;
            TreeNode newNode = new TreeNode(input);
            selectedNode.Nodes.Add(newNode);

            // به روزرسانی لیست
            UpdateListBox();

            // باز کردن تمام نودها و زیرمجموعه‌ها
            treeView.ExpandAll();

            textBox.Clear();
        }

        // رویداد کلیک دکمه buttonRemoveItem برای حذف آیتم از زیر مجموعه نود انتخاب شده
        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode == null)
            {
                MessageBox.Show("Please select a node to remove an item.");
                return;
            }

            TreeNode selectedNode = treeView.SelectedNode;

            // بررسی آیا نود انتخاب شده درخت عمومی اصلی است یا نه
            if (IsFirstNodeOfTree(selectedNode) || IsSubNodeOfFirstTree(selectedNode))
            {
                MessageBox.Show("You cannot remove items from the main general tree.");
                return;
            }

            // نمایش پیام تایید حذف نود
            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?",
                                                  "Confirm Delete",
                                                  MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                selectedNode.Remove();
                UpdateListBox();
            }
        }

        // متد برای بررسی اینکه آیا نود مورد نظر زیرمجموعه‌ی درخت عمومی اصلی است یا نه
        private bool IsSubNodeOfFirstTree(TreeNode node)
        {
            TreeNode firstNode = treeView.Nodes[0];
            return firstNode.Nodes.Contains(node);
        }

        // رویداد کلیک دکمه buttonFindItem برای جستجوی آیتم در زیر مجموعه نود انتخاب شده
        private void buttonFindItem_Click(object sender, EventArgs e)
        {
            string input = textBox.Text.Trim();

            // بررسی خالی بودن متن ورودی
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Please enter a valid name or number.");
                return;
            }

            TreeNode selectedNode = treeView.SelectedNode;

            // بررسی انتخاب نود در درخت
            if (selectedNode == null)
            {
                MessageBox.Show("Please select a node to search its items.");
                return;
            }

            // بررسی آیا نود انتخاب شده درخت عمومی اصلی است یا نه
            if (IsFirstNodeOfTree(selectedNode))
            {
                MessageBox.Show("You cannot search within the main general tree.");
                return;
            }

            // جستجوی آیتم در زیر مجموعه نود انتخاب شده
            TreeNode foundNode = FindNode(selectedNode.Nodes, input);

            if (foundNode != null)
            {
                treeView.SelectedNode = foundNode;
                treeView.SelectedNode.Expand();
                treeView.Focus();
                MessageBox.Show("Item found and selected.");
            }
            else
            {
                MessageBox.Show("Item not found, please make sure you have selected a node.");
            }
        }

        // رویداد TextChanged برای محدود کردن تعداد فضاها
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            string input = textBox.Text;
            textBox.Text = RemoveExtraSpaces(input);
            // مکان‌نما را به انتهای متن برگردانید
            textBox.SelectionStart = textBox.Text.Length;
        }

        // تابع برای حذف فضاهای اضافی
        private string RemoveExtraSpaces(string input)
        {
            // حذف فضاهای متوالی و جایگزینی آنها با یک فضای واحد
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }
            return input;
        }
    }
}

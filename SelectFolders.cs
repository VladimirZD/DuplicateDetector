using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace DuplicateDetector
{
    public partial class SelectFolders : UserControl
    {


        public SelectFolders()
        {
            InitializeComponent();
            RefreshPriorityItemsButtons();
        }


        public StringCollection SelectedItems
        {
            get
            {
                StringCollection selectedItems = new StringCollection();
                foreach (ListViewItem item in lstPriorityFolders.Items)
                {
                    selectedItems.Add(item.Text);
                }
                return selectedItems;
            }
            set
            {
                StringCollection selectedItems = value;
                var items = selectedItems;
                if (items != null)
                {
                    foreach (string item in items)
                    {
                        lstPriorityFolders.Items.Add(item);
                    }
                }
                RefreshPriorityItemsButtons();
            }
        }

        public string Description
        {
            get
            {
                return lblPriorityFolderLocations.Text;
            }
            set
            {
                lblPriorityFolderLocations.Text=value;
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstPriorityFolders.SelectedItems)
            {
                lstPriorityFolders.Items.Remove(item);
            }
            RefreshPriorityItemsButtons();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (selectFolderDialog.ShowDialog() == DialogResult.OK)
            {
                lstPriorityFolders.Items.Add(selectFolderDialog.SelectedPath);
            }
            RefreshPriorityItemsButtons();
        }

        private void RefreshPriorityItemsButtons()
        {
            btnRemoveItem.Enabled = (lstPriorityFolders.Items.Count != 0);
        }

    }
}

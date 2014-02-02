using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextAdventure.Classes;

namespace TextAdventure.Forms
{
    public partial class frmContainers : Form
    {
        private Scene _scene;

        public frmContainers(ref Scene scene)
        {
            InitializeComponent();
            _scene = scene;

            foreach (TextAdventure.Classes.Container container in _scene.Containers.Values)
            {
                cboContainers.Items.Add(container.Key);
               
            }
            if ( cboContainers.Items.Count > 0)
                cboContainers.SelectedIndex = 0;    

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _scene.Containers[cboContainers.Text].CItems.Clear();

            foreach (string item in lstItemsInContainer.Items)
            {


                _scene.Containers[cboContainers.Text].CItems.Add(item, new ContainerItem(item, txtItemDescription.Text));


            }
        }

        private void cboContainers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescription.Text = _scene.Containers[cboContainers.Text].Description;
            lstItemsInContainer.Items.Clear();

            foreach (string item in _scene.Containers[cboContainers.Text].CItems.Keys)
            {
                lstItemsInContainer.Items.Add(item);
            }
        }

        private void btnNewContainer_Click(object sender, EventArgs e)
        {
            cboContainers.Text = string.Empty;
            txtDescription.Text = string.Empty;
            lstItemsInContainer.Items.Clear();

        }

        private void btnSaveContainer_Click(object sender, EventArgs e)
        {
            if( _scene.Containers.Keys.Contains(cboContainers.Text))
            {
                _scene.Containers[cboContainers.Text].Description = txtDescription.Text;
            }
            else
            {
                _scene.Containers.Add(cboContainers.Text.ToLower(), new Classes.Container(cboContainers.Text.ToLower(), txtDescription.Text));
                cboContainers.Items.Add(cboContainers.Text.ToLower());
            }

        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtItem.Text) && !lstItemsInContainer.Items.Contains(txtItem.Text.ToLower()))
            {
                lstItemsInContainer.Items.Add(txtItem.Text.ToLower());
                txtItem.Clear();
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (lstItemsInContainer.SelectedItem != null)
            {
                lstItemsInContainer.Items.Remove(lstItemsInContainer.SelectedItem);
            }
        }

        private void lstItemsInContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sitem = lstItemsInContainer.SelectedItems[0].ToString();
            txtItemDescription.Text = _scene.Containers[cboContainers.Text].CItems[sitem].Description;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }
    }
}

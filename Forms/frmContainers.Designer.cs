namespace TextAdventure.Forms
{
    partial class frmContainers
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
            this.cboContainers = new System.Windows.Forms.ComboBox();
            this.lstItemsInContainer = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveContainer = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNewContainer = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtItemDescription = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboContainers
            // 
            this.cboContainers.FormattingEnabled = true;
            this.cboContainers.Location = new System.Drawing.Point(6, 19);
            this.cboContainers.Name = "cboContainers";
            this.cboContainers.Size = new System.Drawing.Size(482, 21);
            this.cboContainers.TabIndex = 0;
            this.cboContainers.SelectedIndexChanged += new System.EventHandler(this.cboContainers_SelectedIndexChanged);
            // 
            // lstItemsInContainer
            // 
            this.lstItemsInContainer.FormattingEnabled = true;
            this.lstItemsInContainer.Location = new System.Drawing.Point(6, 54);
            this.lstItemsInContainer.Name = "lstItemsInContainer";
            this.lstItemsInContainer.Size = new System.Drawing.Size(250, 186);
            this.lstItemsInContainer.TabIndex = 2;
            this.lstItemsInContainer.SelectedIndexChanged += new System.EventHandler(this.lstItemsInContainer_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(242, 246);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(326, 246);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(440, 500);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveContainer);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnNewContainer);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.cboContainers);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(503, 192);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Containers:";
            // 
            // btnSaveContainer
            // 
            this.btnSaveContainer.Location = new System.Drawing.Point(94, 153);
            this.btnSaveContainer.Name = "btnSaveContainer";
            this.btnSaveContainer.Size = new System.Drawing.Size(75, 23);
            this.btnSaveContainer.TabIndex = 4;
            this.btnSaveContainer.Text = "Save";
            this.btnSaveContainer.UseVisualStyleBackColor = true;
            this.btnSaveContainer.Click += new System.EventHandler(this.btnSaveContainer_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(175, 153);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnNewContainer
            // 
            this.btnNewContainer.Location = new System.Drawing.Point(12, 152);
            this.btnNewContainer.Name = "btnNewContainer";
            this.btnNewContainer.Size = new System.Drawing.Size(75, 23);
            this.btnNewContainer.TabIndex = 2;
            this.btnNewContainer.Text = "New";
            this.btnNewContainer.UseVisualStyleBackColor = true;
            this.btnNewContainer.Click += new System.EventHandler(this.btnNewContainer_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 47);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(482, 99);
            this.txtDescription.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.txtItemDescription);
            this.groupBox3.Controls.Add(this.txtItem);
            this.groupBox3.Controls.Add(this.lstItemsInContainer);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Controls.Add(this.btnRemove);
            this.groupBox3.Location = new System.Drawing.Point(18, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(497, 277);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Items in container:";
            // 
            // txtItem
            // 
            this.txtItem.Location = new System.Drawing.Point(6, 28);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(250, 20);
            this.txtItem.TabIndex = 5;
            // 
            // txtItemDescription
            // 
            this.txtItemDescription.Location = new System.Drawing.Point(263, 28);
            this.txtItemDescription.Multiline = true;
            this.txtItemDescription.Name = "txtItemDescription";
            this.txtItemDescription.Size = new System.Drawing.Size(219, 212);
            this.txtItemDescription.TabIndex = 7;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(408, 245);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmContainers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 535);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmContainers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scene Containers";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboContainers;
        private System.Windows.Forms.ListBox lstItemsInContainer;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNewContainer;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSaveContainer;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtItemDescription;
        private System.Windows.Forms.Button btnUpdate;
    }
}
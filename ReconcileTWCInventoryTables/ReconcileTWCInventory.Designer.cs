namespace ReconcileTWCInventoryTables
{
    partial class ReconcileTWCInventory
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnterPartNumber = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtPartNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTWCQuantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtWarehouseID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtWarehouseQuantity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExplaination = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboWarehouse = new System.Windows.Forms.ComboBox();
            this.txtDescripton = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(371, 416);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 52);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ReconcileTWCInventoryTables.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(183, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(12, 107);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(509, 50);
            this.Label1.TabIndex = 52;
            this.Label1.Text = "Time Warner Inventory Reconcile Program";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 32);
            this.label2.TabIndex = 54;
            this.label2.Text = "Enter Part Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEnterPartNumber
            // 
            this.txtEnterPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEnterPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnterPartNumber.Location = new System.Drawing.Point(204, 172);
            this.txtEnterPartNumber.Name = "txtEnterPartNumber";
            this.txtEnterPartNumber.Size = new System.Drawing.Size(150, 27);
            this.txtEnterPartNumber.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(371, 160);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 44);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPartNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartNumber.Location = new System.Drawing.Point(204, 313);
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.ReadOnly = true;
            this.txtPartNumber.Size = new System.Drawing.Size(150, 27);
            this.txtPartNumber.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 32);
            this.label4.TabIndex = 61;
            this.label4.Text = "Part Number";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPartID
            // 
            this.txtPartID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPartID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPartID.Location = new System.Drawing.Point(204, 280);
            this.txtPartID.Name = "txtPartID";
            this.txtPartID.ReadOnly = true;
            this.txtPartID.Size = new System.Drawing.Size(150, 27);
            this.txtPartID.TabIndex = 60;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 32);
            this.label5.TabIndex = 59;
            this.label5.Text = "Part ID";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTWCQuantity
            // 
            this.txtTWCQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTWCQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTWCQuantity.Location = new System.Drawing.Point(204, 408);
            this.txtTWCQuantity.Name = "txtTWCQuantity";
            this.txtTWCQuantity.Size = new System.Drawing.Size(150, 27);
            this.txtTWCQuantity.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 405);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 32);
            this.label6.TabIndex = 65;
            this.label6.Text = "TWC Quantity";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWarehouseID
            // 
            this.txtWarehouseID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWarehouseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarehouseID.Location = new System.Drawing.Point(204, 375);
            this.txtWarehouseID.Name = "txtWarehouseID";
            this.txtWarehouseID.ReadOnly = true;
            this.txtWarehouseID.Size = new System.Drawing.Size(150, 27);
            this.txtWarehouseID.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(26, 372);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 32);
            this.label7.TabIndex = 63;
            this.label7.Text = "Warehouse ID";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(371, 361);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 52);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtWarehouseQuantity
            // 
            this.txtWarehouseQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWarehouseQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWarehouseQuantity.Location = new System.Drawing.Point(204, 441);
            this.txtWarehouseQuantity.Name = "txtWarehouseQuantity";
            this.txtWarehouseQuantity.Size = new System.Drawing.Size(150, 27);
            this.txtWarehouseQuantity.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(26, 438);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 32);
            this.label8.TabIndex = 68;
            this.label8.Text = "Warehouse Quantity";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExplaination
            // 
            this.txtExplaination.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExplaination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExplaination.Location = new System.Drawing.Point(204, 474);
            this.txtExplaination.Multiline = true;
            this.txtExplaination.Name = "txtExplaination";
            this.txtExplaination.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtExplaination.Size = new System.Drawing.Size(150, 74);
            this.txtExplaination.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(26, 495);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 32);
            this.label9.TabIndex = 70;
            this.label9.Text = "Explaination";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(26, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(172, 32);
            this.label10.TabIndex = 72;
            this.label10.Text = "Select Table";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.Location = new System.Drawing.Point(204, 217);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(150, 28);
            this.cboWarehouse.TabIndex = 1;
            this.cboWarehouse.SelectedIndexChanged += new System.EventHandler(this.cboWarehouse_SelectedIndexChanged);
            // 
            // txtDescripton
            // 
            this.txtDescripton.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripton.Location = new System.Drawing.Point(204, 344);
            this.txtDescripton.Name = "txtDescripton";
            this.txtDescripton.ReadOnly = true;
            this.txtDescripton.Size = new System.Drawing.Size(150, 27);
            this.txtDescripton.TabIndex = 75;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 341);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 32);
            this.label3.TabIndex = 74;
            this.label3.Text = "Description";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ReconcileTWCInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 573);
            this.ControlBox = false;
            this.Controls.Add(this.txtDescripton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboWarehouse);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtExplaination);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtWarehouseQuantity);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtTWCQuantity);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtWarehouseID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPartNumber);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPartID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtEnterPartNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnClose);
            this.Name = "ReconcileTWCInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReconcileTWCInventory";
            this.Load += new System.EventHandler(this.ReconcileTWCInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnterPartNumber;
        internal System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtPartNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPartID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTWCQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtWarehouseID;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtWarehouseQuantity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtExplaination;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboWarehouse;
        private System.Windows.Forms.TextBox txtDescripton;
        private System.Windows.Forms.Label label3;
    }
}
namespace Improved_CRUD_WinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSensorName = new TextBox();
            txtSensorType = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dataRecordsView = new DataGridView();
            label3 = new Label();
            idLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dataRecordsView).BeginInit();
            SuspendLayout();
            // 
            // txtSensorName
            // 
            txtSensorName.Font = new Font("Segoe UI", 9.75F);
            txtSensorName.Location = new Point(365, 92);
            txtSensorName.Multiline = true;
            txtSensorName.Name = "txtSensorName";
            txtSensorName.Size = new Size(216, 31);
            txtSensorName.TabIndex = 0;
            // 
            // txtSensorType
            // 
            txtSensorType.Font = new Font("Segoe UI", 9.75F);
            txtSensorType.Location = new Point(365, 172);
            txtSensorType.Multiline = true;
            txtSensorType.Name = "txtSensorType";
            txtSensorType.Size = new Size(216, 31);
            txtSensorType.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label1.Location = new Point(365, 69);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 1;
            label1.Text = "Sensor Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label2.Location = new Point(365, 149);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 1;
            label2.Text = "Sensor Type:";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(128, 255, 128);
            btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(365, 230);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(68, 37);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(255, 192, 128);
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.Location = new Point(439, 230);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(68, 37);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(255, 128, 128);
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDelete.Location = new Point(513, 230);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(68, 37);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // dataRecordsView
            // 
            dataRecordsView.AllowUserToAddRows = false;
            dataRecordsView.AllowUserToDeleteRows = false;
            dataRecordsView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataRecordsView.Location = new Point(12, 31);
            dataRecordsView.Name = "dataRecordsView";
            dataRecordsView.ReadOnly = true;
            dataRecordsView.RowHeadersVisible = false;
            dataRecordsView.ScrollBars = ScrollBars.Vertical;
            dataRecordsView.Size = new Size(339, 236);
            dataRecordsView.TabIndex = 3;
            dataRecordsView.CellClick += dataRecordsView_CellClick;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);
            label3.Location = new Point(365, 31);
            label3.Name = "label3";
            label3.Size = new Size(29, 20);
            label3.TabIndex = 1;
            label3.Text = "ID:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idLabel.Location = new Point(400, 31);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(27, 20);
            idLabel.TabIndex = 1;
            idLabel.Text = "ID:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 293);
            Controls.Add(dataRecordsView);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(label2);
            Controls.Add(idLabel);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtSensorType);
            Controls.Add(txtSensorName);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataRecordsView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSensorName;
        private TextBox txtSensorType;
        private Label label1;
        private Label label2;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private DataGridView dataRecordsView;
        private Label label3;
        private Label idLabel;
    }
}

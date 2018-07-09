namespace Student_Violation_Records
{
    partial class ReportGeneral
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
            this.lvGenReport = new MaterialSkin.Controls.MaterialListView();
            this.label4 = new System.Windows.Forms.Label();
            this.lblyrEnd = new System.Windows.Forms.Label();
            this.lblyrStart = new System.Windows.Forms.Label();
            this.lblSem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lvGenReport
            // 
            this.lvGenReport.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvGenReport.Depth = 0;
            this.lvGenReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGenReport.FullRowSelect = true;
            this.lvGenReport.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvGenReport.Location = new System.Drawing.Point(13, 172);
            this.lvGenReport.MouseLocation = new System.Drawing.Point(-1, -1);
            this.lvGenReport.MouseState = MaterialSkin.MouseState.OUT;
            this.lvGenReport.Name = "lvGenReport";
            this.lvGenReport.OwnerDraw = true;
            this.lvGenReport.Size = new System.Drawing.Size(1120, 377);
            this.lvGenReport.TabIndex = 2;
            this.lvGenReport.UseCompatibleStateImageBehavior = false;
            this.lvGenReport.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(599, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 18);
            this.label4.TabIndex = 71;
            this.label4.Text = "-";
            // 
            // lblyrEnd
            // 
            this.lblyrEnd.AutoSize = true;
            this.lblyrEnd.BackColor = System.Drawing.Color.Transparent;
            this.lblyrEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblyrEnd.Location = new System.Drawing.Point(619, 142);
            this.lblyrEnd.Name = "lblyrEnd";
            this.lblyrEnd.Size = new System.Drawing.Size(51, 18);
            this.lblyrEnd.TabIndex = 70;
            this.lblyrEnd.Text = "yrEnd";
            // 
            // lblyrStart
            // 
            this.lblyrStart.AutoSize = true;
            this.lblyrStart.BackColor = System.Drawing.Color.Transparent;
            this.lblyrStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblyrStart.Location = new System.Drawing.Point(545, 142);
            this.lblyrStart.Name = "lblyrStart";
            this.lblyrStart.Size = new System.Drawing.Size(58, 18);
            this.lblyrStart.TabIndex = 69;
            this.lblyrStart.Text = "yrStart";
            // 
            // lblSem
            // 
            this.lblSem.AutoSize = true;
            this.lblSem.BackColor = System.Drawing.Color.Transparent;
            this.lblSem.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSem.Location = new System.Drawing.Point(464, 142);
            this.lblSem.Name = "lblSem";
            this.lblSem.Size = new System.Drawing.Size(59, 18);
            this.lblSem.TabIndex = 68;
            this.lblSem.Text = "lblSem";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(406, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 25);
            this.label1.TabIndex = 67;
            this.label1.Text = "Student Violation Records System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Student_Violation_Records.Properties.Resources.Report1Design_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1145, 89);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 72;
            this.pictureBox1.TabStop = false;
            // 
            // ReportGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 563);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblyrEnd);
            this.Controls.Add(this.lblyrStart);
            this.Controls.Add(this.lblSem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvGenReport);
            this.Name = "ReportGeneral";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.ReportGeneral_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialListView lvGenReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblyrEnd;
        private System.Windows.Forms.Label lblyrStart;
        private System.Windows.Forms.Label lblSem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
namespace Student_Violation_Records
{
    partial class ForgotPassword
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
            this.txtNewPass = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblNewPass = new MaterialSkin.Controls.MaterialLabel();
            this.txtConfirmPass = new MaterialSkin.Controls.MaterialLabel();
            this.txtConfirm = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnReset = new MaterialSkin.Controls.MaterialFlatButton();
            this.txtAnswer = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNewPass
            // 
            this.txtNewPass.Depth = 0;
            this.txtNewPass.Hint = "";
            this.txtNewPass.Location = new System.Drawing.Point(220, 189);
            this.txtNewPass.MaxLength = 20;
            this.txtNewPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '\0';
            this.txtNewPass.SelectedText = "";
            this.txtNewPass.SelectionLength = 0;
            this.txtNewPass.SelectionStart = 0;
            this.txtNewPass.Size = new System.Drawing.Size(144, 23);
            this.txtNewPass.TabIndex = 0;
            this.txtNewPass.TabStop = false;
            this.txtNewPass.UseSystemPasswordChar = false;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Depth = 0;
            this.lblNewPass.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNewPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNewPass.Location = new System.Drawing.Point(101, 193);
            this.lblNewPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(113, 19);
            this.lblNewPass.TabIndex = 1;
            this.lblNewPass.Text = "New Password:";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.AutoSize = true;
            this.txtConfirmPass.Depth = 0;
            this.txtConfirmPass.Font = new System.Drawing.Font("Roboto", 11F);
            this.txtConfirmPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtConfirmPass.Location = new System.Drawing.Point(77, 225);
            this.txtConfirmPass.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(137, 19);
            this.txtConfirmPass.TabIndex = 2;
            this.txtConfirmPass.Text = "Confirm Password:";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Depth = 0;
            this.txtConfirm.Hint = "";
            this.txtConfirm.Location = new System.Drawing.Point(220, 221);
            this.txtConfirm.MaxLength = 20;
            this.txtConfirm.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '\0';
            this.txtConfirm.SelectedText = "";
            this.txtConfirm.SelectionLength = 0;
            this.txtConfirm.SelectionStart = 0;
            this.txtConfirm.Size = new System.Drawing.Size(144, 23);
            this.txtConfirm.TabIndex = 3;
            this.txtConfirm.TabStop = false;
            this.txtConfirm.UseSystemPasswordChar = false;
            // 
            // btnReset
            // 
            this.btnReset.AutoSize = true;
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Depth = 0;
            this.btnReset.Icon = null;
            this.btnReset.Location = new System.Drawing.Point(174, 274);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReset.Name = "btnReset";
            this.btnReset.Primary = false;
            this.btnReset.Size = new System.Drawing.Size(139, 36);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset Password";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Depth = 0;
            this.txtAnswer.Hint = "";
            this.txtAnswer.Location = new System.Drawing.Point(275, 120);
            this.txtAnswer.MaxLength = 20;
            this.txtAnswer.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.PasswordChar = '\0';
            this.txtAnswer.SelectedText = "";
            this.txtAnswer.SelectionLength = 0;
            this.txtAnswer.SelectionStart = 0;
            this.txtAnswer.Size = new System.Drawing.Size(144, 23);
            this.txtAnswer.TabIndex = 6;
            this.txtAnswer.TabStop = false;
            this.txtAnswer.UseSystemPasswordChar = false;
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(30, 126);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(61, 16);
            this.lblQuestion.TabIndex = 7;
            this.lblQuestion.Text = "Question";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.Image = global::Student_Violation_Records.Properties.Resources.LoginHeader;
            this.pictureBox2.Location = new System.Drawing.Point(-1, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(467, 74);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Student_Violation_Records.Properties.Resources.border_1;
            this.pictureBox1.Location = new System.Drawing.Point(171, 272);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 45);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 348);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.txtAnswer);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ForgotPassword";
            this.Text = "Password Reset";
            this.Load += new System.EventHandler(this.ForgotPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtNewPass;
        private MaterialSkin.Controls.MaterialLabel lblNewPass;
        private MaterialSkin.Controls.MaterialLabel txtConfirmPass;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtConfirm;
        private MaterialSkin.Controls.MaterialFlatButton btnReset;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtAnswer;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
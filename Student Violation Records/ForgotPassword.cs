using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Data.SqlClient;

namespace Student_Violation_Records
{
    public partial class ForgotPassword : MaterialForm
    {
        public string userID;
        public string question;
        public string answer;

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            lblQuestion.Text = question;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text.Equals(answer))
            {
                SqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                if (txtNewPass.Text.Equals(txtConfirm.Text))
                {
                    using (SqlCommand cmd = new SqlCommand("UPDATE Accounts SET Password = @password, loginAttempts = @loginAttempts WHERE userID = @userID", conn))
                    {
                        cmd.Parameters.AddWithValue("@password", txtNewPass.Text);
                        cmd.Parameters.AddWithValue("@loginAttempts", 0);
                        cmd.Parameters.AddWithValue("@userID", userID);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password has been changed.");
                    }
                }
                else
                    MessageBox.Show("New password and confirmation password do no match.");
            }

            else
                MessageBox.Show("Security answer is wrong");
        }
    }
}

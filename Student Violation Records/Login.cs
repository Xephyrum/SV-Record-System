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
using Microsoft.VisualBasic;    

namespace Student_Violation_Records
{
    public partial class frmLogin : MaterialForm
    {
        
        public frmLogin()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
               Primary.Blue800, Primary.Blue900,
               Primary.Blue500, Accent.LightBlue200,
               TextShade.WHITE
               );

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtUser.Text = "Login";
            txtPass.Text = "Password";
        }
        public void passRemoveText(object sender, EventArgs e)
        {
            if (txtPass.Text == "Password")
            {
                txtPass.Text = "";
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUser.Text))
            {
                txtUser.Text = "Login";
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPass.Text))
            {
                txtPass.Text = "Password";
            }
        }

        private void userRemoveText(object sender, EventArgs e)
        {
            if (txtUser.Text == "Login")
            {
                txtUser.Text = "";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Main mn = new Main();
            string user, pass;
            user = txtUser.Text;
            pass = txtPass.Text;

            if (txtUser.Text == "" && txtPass.Text == "")
            {
                txtUser.Focus();
                MessageBox.Show("No input!");
            }
            else if (txtPass.Text == "")
            {
                MessageBox.Show("No Password input");
                txtPass.Focus();
            }
            else if (txtUser.Text == "")
            {
                MessageBox.Show("No Username input!");
                txtUser.Focus();
            }
            else
            {
                SqlConnection conn = DBUtils.GetDBConnection();
                conn.Open();

                Nullable<int> loginAttempts;
                int userLevel;

                using (SqlCommand cmd = new SqlCommand("Select loginAttempts FROM Accounts WHERE userID = @userID", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", user);
                    loginAttempts = Convert.ToInt32(cmd.ExecuteScalar());
                }

                if (loginAttempts < 5)
                {
                    string un = txtUser.Text;
                    string pw = txtPass.Text;

                    using (SqlCommand cmd = new SqlCommand("Select * from Accounts where userID = @userID AND Password = @password", conn))
                    {
                        cmd.Parameters.AddWithValue("@userID", un);
                        cmd.Parameters.AddWithValue("@password", pw);
                        SqlDataReader dr = cmd.ExecuteReader();                     

                        if (dr.HasRows)
                        {
                            string lName, fName, mName;
                            dr.Read();
                            lName = dr.GetString(2);
                            fName = dr.GetString(3);
                            mName = dr.GetString(4);

                            SqlCommand cmd2 = new SqlCommand("UPDATE Accounts SET loginAttempts = 0", conn);
                            int ordinal = 0;
                            //dr.Read();
                            ordinal = dr.GetOrdinal("userLevel");
                            userLevel = dr.GetInt32(ordinal);
                            dr.Close();
                            dr.Dispose();
                            cmd2.ExecuteNonQuery();
                            MessageBox.Show("Login Successful");
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\ActivityLogs.txt", true))
                            {
                                string time = DateTime.Now.ToString();
                                file.WriteLine(time + " Account Name: " + lName + ", " + fName + " " + mName + " has logged in.");
                            }
                        }

                        else
                        {
                            using (SqlCommand cmd2 = new SqlCommand("Select userID from Accounts where userID = @userID", conn))
                            {
                                cmd2.Parameters.AddWithValue("@userID", un);
                                dr.Close();
                                dr.Dispose();
                                dr = cmd2.ExecuteReader();
                                int ordinal = 0;
                                string value = "";

                                if (dr.Read())
                                {
                                    ordinal = dr.GetOrdinal("userID");
                                    value = dr.GetString(ordinal);
                                    if (value.Equals(un))
                                    {
                                        SqlCommand cmd3 = new SqlCommand("UPDATE Accounts SET loginAttempts += 1 WHERE userID = @un", conn);
                                        cmd3.Parameters.AddWithValue("@un", un);
                                        dr.Close();
                                        dr.Dispose();
                                        cmd3.ExecuteNonQuery();
                                        cmd3.Dispose();
                                    }
                                }
                            }
                            MessageBox.Show("User ID or Password is invalid");
                            return;
                        }
                    }
                    txtPass.Text = "";
                    txtUser.Text = "";
                    mn.Activated += new EventHandler(mn_Activated);
                    mn.FormClosed += new FormClosedEventHandler(mn_FormClosed);
                    if (userLevel == 2)
                        mn.permission = false;
                    else
                        mn.permission = true;
                    mn.Show();
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Due to multiple login attempts, your account has been locked. \nWould you like to unlock it?", "Account Recovery", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            SqlConnection cnn = DBUtils.GetDBConnection();
                            cnn.Open();
                            string question = "", answer = "";
                            int ordinal = 0;

                            using (SqlCommand cmd = new SqlCommand("Select * from Accounts where userID = @userID", cnn))
                            {
                                cmd.Parameters.AddWithValue("@userID", txtUser.Text);
                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.Read())
                                {
                                    ordinal = reader.GetOrdinal("securityQuestion");
                                    question = reader.GetString(ordinal);
                                    ordinal = reader.GetOrdinal("securityAnswer");
                                    answer = reader.GetString(ordinal);
                                }
                                reader.Close();
                            }
                            string input = Interaction.InputBox(question, "Account Recovery", "");

                            if (input.Equals(answer))
                            {
                                SqlCommand cmd2 = new SqlCommand("UPDATE Accounts SET loginAttempts = 0 WHERE userID = @un", cnn);
                                cmd2.Parameters.AddWithValue("@un", txtUser.Text);
                                cmd2.ExecuteNonQuery();
                                cmd2.Dispose();
                                MessageBox.Show("Account has been unlocked");
                            }
                            else
                                MessageBox.Show("Your answer is wrong");
                            break;

                        case DialogResult.No: break;
                    }
                }
                //Validation codes END
            }
        }
            private void mn_Activated(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void mn_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            string userID = "";
            string question = "";
            string answer = "";

            using (SqlCommand cmd = new SqlCommand("Select * from Accounts where userID = @userID", conn))
            {
                cmd.Parameters.AddWithValue("@userID", txtUser.Text);      
                SqlDataReader reader = cmd.ExecuteReader();
                int ordinal = 0;
                
                if (reader.Read())
                {
                    ordinal = reader.GetOrdinal("userID");
                    userID = reader.GetString(ordinal);
                    ordinal = reader.GetOrdinal("securityQuestion");
                    question = reader.GetString(ordinal);
                    ordinal = reader.GetOrdinal("securityAnswer");
                    answer = reader.GetString(ordinal);
                }
                else
                {
                    MessageBox.Show("Account does not exist.");
                    return;
                }                  
                reader.Close();
            }

            ForgotPassword fg = new ForgotPassword();
            fg.Activated += new EventHandler(mn_Activated);
            fg.FormClosed += new FormClosedEventHandler(mn_FormClosed);
            fg.userID = userID;
            fg.question = question;
            fg.answer = answer;
            fg.Show();             
        }

        private void lblForgot_MouseEnter(object sender, EventArgs e)
        {
            lblForgot.Font = new Font(lblForgot.Font.Name, lblForgot.Font.SizeInPoints, FontStyle.Underline);
        }

        private void lblForgot_MouseLeave(object sender, EventArgs e)
        {
            lblForgot.Font = new Font(lblForgot.Font.Name, lblForgot.Font.SizeInPoints, FontStyle.Regular);
        }
    }
}

using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Student_Violation_Records
{
    public partial class Main : MaterialForm
    {
        int value = 0;
        string time;
        public Boolean permission;

        public Main()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
               Primary.Blue700, Primary.Blue900,
               Primary.Blue900, Accent.LightBlue200,
               TextShade.WHITE
               );
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            txtDate.Text = DateTime.Today.ToString("d");
            hideFields();
            disableFields();
            btnEditProb.Enabled = permission;
            btnDeleteRecord.Enabled = permission;
            btnGenGenReport.Enabled = permission;
            btnSpeGenReport.Enabled = permission;
            using (SqlCommand sql = new SqlCommand("Select ViolationType, ViolationName from ViolationDetails where ViolationType ='Departmental'", conn))
            {
                using (DbDataReader reader = sql.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ViolationName = reader["ViolationName"].ToString();
                            cmbDepartmental.Items.Add(ViolationName);
                        }
                    }
                }
            }
            using (SqlCommand sql = new SqlCommand("Select ViolationType, ViolationName from ViolationDetails where ViolationType ='Institutional'", conn))
            {
                using (DbDataReader reader = sql.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ViolationName = reader["ViolationName"].ToString();
                            cmbInstitutional.Items.Add(ViolationName);
                        }
                    }
                }
            }

            using (SqlCommand sql = new SqlCommand("Select ViolationType, ViolationName from ViolationDetails where ViolationType ='Academic'", conn))
            {
                using (DbDataReader reader = sql.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ViolationName = reader["ViolationName"].ToString();
                            cmbAcademic.Items.Add(ViolationName);
                        }
                    }
                }
            }
            conn.Close();
        }
        //start RECORD TAB
        private void cmbViolate_TextChanged(object sender, EventArgs e)
        {
            if (cmbViolate.Text == "Departmental")
            {
                lblViolationType.Text = "Departmental: ";
                lblViolationType.Visible = true;
                cmbDepartmental.Visible = true;
                cmbInstitutional.Visible = false;
                cmbAcademic.Visible = false;
                lblLastChance.Visible = true;
                chkYesLC.Visible = true;
                chkNoLC.Visible = true;
                cmbInstitutional.Text = "";
                cmbAcademic.Text = "";
                lblRemarks.Visible = true;
                txtRemarks.Visible = true;
            }
            else if (cmbViolate.Text == "Institutional")
            {
                lblViolationType.Text = "Institutional: ";
                lblViolationType.Visible = true;
                cmbInstitutional.Visible = true;
                cmbDepartmental.Visible = false;
                cmbAcademic.Visible = false;
                lblLastChance.Visible = false;
                chkYesLC.Visible = false;
                chkNoLC.Visible = false;
                cmbDepartmental.Text = "";
                cmbAcademic.Text = "";
                lblRemarks.Visible = true;
                txtRemarks.Visible = true;
                lblProbi.Visible = false;
                chkYesProb.Visible = false;
                chkNoProb.Visible = false;
            }
            else if (cmbViolate.Text == "Academic")
            {
                lblViolationType.Text = "Academic: ";
                lblViolationType.Visible = true;
                cmbAcademic.Visible = true;
                cmbInstitutional.Visible = false;
                cmbDepartmental.Visible = false;
                lblLastChance.Visible = true;
                chkYesLC.Visible = true;
                chkNoLC.Visible = true;
                cmbDepartmental.Text = "";
                cmbInstitutional.Text = "";
                lblRemarks.Visible = true;
                txtRemarks.Visible = true;
                lblProbi.Visible = true;
                chkYesProb.Visible = true;
                chkNoProb.Visible = true;
            }
            else
            {
                lblViolationType.Visible = false;
                cmbDepartmental.Text = "";
                cmbInstitutional.Text = "";
                cmbAcademic.Text = "";
                cmbInstitutional.Visible = false;
                cmbDepartmental.Visible = false;
                cmbAcademic.Visible = false;
                lblLastChance.Visible = false;
                chkYesLC.Visible = true;
                chkNoLC.Visible = true;
                lblProbi.Visible = false;
                chkYesProb.Visible = false;
                chkNoProb.Visible = false;
            }
        }
        private void cmbInstiOrDept_TextChanged(object sender, EventArgs e)
        {
            if (cmbInstitutional.Text == "Others (Please specify)" || cmbDepartmental.Text == "Others (Please specify)" || cmbAcademic.Text == "Others (Please specify)")
            {
                txtSpecify.Visible = true;
                lblSpecify.Visible = true;
                lblViolateDesc.Visible = true;
                txtViolateDesc.Visible = true;
            }
            else
            {
                txtSpecify.Visible = false;
                lblSpecify.Visible = false;
                lblViolateDesc.Visible = false;
                txtViolateDesc.Visible = false;
                txtSpecify.Text = "";
                txtViolateDesc.Text = "";
            }
        }
        private void chkNo_Click(object sender, EventArgs e)
        {
            if (chkNoLC.Checked == true)
            {
                chkYesLC.Checked = false;
            }
        }
        private void chkYes_Click(object sender, EventArgs e)
        {
            if (chkYesLC.Checked == true)
            {
                chkNoLC.Checked = false;
            }
        }
        private void chkYesProb_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkYesProb.Checked == true)
            {
                chkNoProb.Checked = false;
            }
        }
        private void chkNoProb_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoProb.Checked == true)
            {
                chkYesProb.Checked = false;
            }
        }
        //start button functions
        private void txtStudNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtStudNo.Text == "")
                {
                    MessageBox.Show("Please input student number!");
                    txtStudNo.Text = "";
                }
                else
                {
                    SqlConnection conn = DBUtils.GetDBConnection();
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select COUNT(1) from StudentInfo where studentNo =" + txtStudNo.Text, conn))
                    {
                        int studCount;
                        int check;
                        if (!int.TryParse(txtStudNo.Text, out check))
                        {
                            MessageBox.Show("Invalid Input!");
                            return;
                        }
                        else
                        {
                            studCount = (int)cmd.ExecuteScalar();
                        }
                        if (studCount > 0)
                        {
                            string studentNumber = txtStudNo.Text;
                            using (SqlCommand cmd1 = new SqlCommand("Select * from StudentInfo where studentNo = @studentNo", conn))
                            {
                                cmd1.Parameters.AddWithValue("@studentNo", studentNumber);
                                cmd1.Connection = conn;
                                using (DbDataReader reader = cmd1.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        reader.Read();
                                        //1
                                        int studNo = Convert.ToInt32(reader.GetValue(0));
                                        //2
                                        int lNameIndex = reader.GetOrdinal("lastName");
                                        string lName = Convert.ToString(reader.GetValue(lNameIndex));
                                        //3
                                        int fNameIndex = reader.GetOrdinal("givenName");
                                        string fName = Convert.ToString(reader.GetValue(fNameIndex));
                                        //4
                                        int mNameIndex = reader.GetOrdinal("middleName");
                                        string mName = Convert.ToString(reader.GetValue(mNameIndex));
                                        //5
                                        int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                        string residenceStatus = Convert.ToString(reader.GetValue(residenceIndex));
                                        //6
                                        int instiIndex = reader.GetOrdinal("CounterInsti");
                                        int counterInsti = Convert.ToInt32(reader.GetValue(instiIndex));
                                        //7
                                        int deptIndex = reader.GetOrdinal("CounterDept");
                                        int counterDepart = Convert.ToInt32(reader.GetValue(deptIndex));
                                        //8
                                        int acadIndex = reader.GetOrdinal("CounterAcad");
                                        int counterAcad = Convert.ToInt32(reader.GetValue(acadIndex));

                                        txtStudNo.Text = studNo.ToString();
                                        txtLName.Text = lName;
                                        txtFName.Text = fName;
                                        txtMName.Text = mName;
                                        cmbResidence.Text = residenceStatus;
                                        txtInstiViolation.Text = counterInsti.ToString();
                                        txtDepartViolation.Text = counterDepart.ToString();
                                        txtAcademicViolation.Text = counterAcad.ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no record of that user!");
                        }
                    }
                    conn.Close();
                }
            }
        }
        private void btnDeleteProb_Click(object sender, EventArgs e)
        {
            if (txtStudNo.Text == "" || txtLName.Text == "" || txtFName.Text == "" || txtMName.Text == "" || cmbResidence.Text == "")
            {
                MessageBox.Show("Please fill up the missing fields!");
            }
            else
            {
                if (value == 2)
                {
                    DialogResult dr = MessageBox.Show("Do you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            SqlConnection conn = DBUtils.GetDBConnection();
                            conn.Open();
                            using (SqlCommand cnt = new SqlCommand("Select COUNT(1) from StudentInfoArchive where studentNo =" + txtStudNo.Text, conn))
                            {
                                int studCount;
                                int check;
                                if (!int.TryParse(txtStudNo.Text, out check))
                                {
                                    MessageBox.Show("Invalid Input!");
                                    return;
                                }
                                else
                                {
                                    studCount = (int)cnt.ExecuteScalar();
                                }
                                if (studCount > 0)
                                {
                                    int studNo = Convert.ToInt32(txtStudNo.Text);
                                    MessageBox.Show("Student " + txtStudNo.Text + " has an record in the archive! (Student has been archived before)");
                                    SqlCommand command = new SqlCommand("Delete from StudentInfo where studentNo=" + txtStudNo.Text + ";", conn);
                                    command.ExecuteNonQuery();
                                    using (SqlCommand cmd = new SqlCommand("Insert Into RecordDetailsArchive(studentNo, ViolationCode, dateCommitted, Period, SY, remarks) select StudentNo, ViolationCode, dateCommitted, Period, SY, remarks from RecordDetails where studentNo =" + studNo, conn))
                                    {
                                        cmd.ExecuteNonQuery();
                                        SqlCommand cmd1 = new SqlCommand("Delete from RecordDetails where studentNo=" + txtStudNo.Text, conn);
                                        cmd1.ExecuteNonQuery();
                                    }
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + ": User with the student no: " + txtStudNo.Text + " already exists in the student info. archive table, updating the archive record table with additional details if there are any.");
                                    }
                                    emptyTextbox();
                                    emptyComboBox();
                                }
                                else
                                {
                                    using (SqlCommand cmd = new SqlCommand("Insert Into StudentInfoArchive(studentNo, LastName, GivenName, MiddleName, ResidenceStatus, CounterLastChance, CounterDept, CounterAcad, CounterProbi, CounterInsti) select * from StudentInfo where studentNo =" + txtStudNo.Text, conn))
                                    {
                                        cmd.ExecuteNonQuery();
                                        SqlCommand command = new SqlCommand("Delete from StudentInfo where studentNo=" + txtStudNo.Text, conn);
                                        int count = command.ExecuteNonQuery();
                                        if (count == 1)
                                        {
                                            MessageBox.Show("User record has been deleted!");
                                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                            {
                                                time = DateTime.Now.ToString();
                                                file.WriteLine(time + ": Archive user with student no:" + txtStudNo.Text);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("User does not exist!");
                                            return;
                                        }
                                    }
                                    int studNo = Convert.ToInt32(txtStudNo.Text);
                                    using (SqlCommand cmd = new SqlCommand("Insert Into RecordDetailsArchive(studentNo, ViolationCode, dateCommitted, Period, SY, remarks) select StudentNo, ViolationCode, dateCommitted, Period, SY, remarks from RecordDetails where studentNo =" + studNo, conn))
                                    {
                                        cmd.ExecuteNonQuery();
                                        SqlCommand cmd1 = new SqlCommand("Delete from RecordDetails where studentNo=" + txtStudNo.Text, conn);
                                        cmd1.ExecuteNonQuery();
                                    }
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + ": Archived user with student no: " + txtStudNo.Text + " violation records.");
                                    }
                                    txtStudNo.Enabled = true;
                                    emptyTextbox();
                                    emptyComboBox();
                                    conn.Close();
                                    conn.Dispose();
                                }
                            }
                            conn.Close();
                            conn.Dispose();
                            break;

                        case DialogResult.No: break;
                    }
                }
                else
                {
                    MessageBox.Show("Please click Edit button first to be able to delete!");
                }
            }
        }
        private void btnAddProb_Click(object sender, EventArgs e)
        {
            value = 1;
            enableFields();
        }
        private void btnEditProb_Click(object sender, EventArgs e)
        {
            value = 2;
            enableFields();
            cmbPeriod.Enabled = false;
            cmbSY.Enabled = false;
            cmbViolate.Enabled = false;
            cmbInstitutional.Enabled = false;
            cmbDepartmental.Enabled = false;
            cmbAcademic.Enabled = false;

        }
        private void btnSaveProb_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            if (value == 1)
            {
                if (txtStudNo.Text == "" || txtLName.Text == "" || txtFName.Text == "" || cmbResidence.Text == "" || cmbPeriod.Text == "" || cmbSY.Text == "" || cmbViolate.Text == "")
                {
                    MessageBox.Show("Please fill up the missing fields!");
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select COUNT(1) from StudentInfo where studentNo =" + txtStudNo.Text, conn))
                    {
                        int studNo;
                        int check;
                        int studCount;
                        if (!int.TryParse(txtStudNo.Text, out check))
                        {
                            MessageBox.Show("Invalid Input!");
                            return;
                        }
                        else
                        {
                            studCount = (int)cmd.ExecuteScalar();
                        }
                        if (studCount > 0)
                        {
                            studNo = int.Parse(txtStudNo.Text);
                            string lastName = txtLName.Text;
                            string firstName = txtFName.Text;
                            string middleName = txtMName.Text;
                            string residence = cmbResidence.Text;
                            string period = cmbPeriod.Text;
                            string sy = cmbSY.Text;
                            string violationType = cmbViolate.Text;
                            string violationName = "";
                            string violationDesc = "";
                            int countInsti = 0;
                            int countDepart = 0;
                            int countAcademic = 0;
                            int countProbi = 0;
                            int countLastChance = 0;
                            if (cmbViolate.Text == "Departmental")
                            {
                                if (cmbDepartmental.Text == "Others (Please specify)")
                                {
                                    if (txtSpecify.Text == "" || txtViolateDesc.Text == "")
                                    {
                                        MessageBox.Show("Please specify Violation Name and its description");
                                        return;
                                    }
                                    else
                                    {
                                        violationName = txtSpecify.Text;
                                        violationDesc = txtViolateDesc.Text;
                                        using (SqlCommand command = new SqlCommand("Insert into ViolationDetails Values (@violationType, @violationName, @violationDesc) ", conn))
                                        {
                                            command.Parameters.AddWithValue("@violationType", violationType);
                                            command.Parameters.AddWithValue("@violationName", violationName);
                                            command.Parameters.AddWithValue("@violationDesc", violationDesc);
                                            try
                                            {
                                                command.ExecuteNonQuery();
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + ": Violation Name:" + violationName + " added to database!");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + "Error:" + ex);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (cmbDepartmental.Text == "")
                                {
                                    MessageBox.Show("There is no violation selected!");
                                    return;
                                }
                                else
                                {
                                    violationName = cmbDepartmental.Text;
                                }
                                countDepart = 1;
                            }
                            else if (cmbViolate.Text == "Institutional")
                            {
                                if (cmbInstitutional.Text == "Others (Please specify)")
                                {
                                    if (txtSpecify.Text == "" || txtViolateDesc.Text == "")
                                    {
                                        MessageBox.Show("Please specify Violation Name and its description");
                                        return;
                                    }
                                    else
                                    {
                                        violationName = txtSpecify.Text;
                                        violationDesc = txtViolateDesc.Text;
                                        using (SqlCommand command = new SqlCommand("Insert into ViolationDetails Values (@violationType, @violationName, @violationDesc) ", conn))
                                        {
                                            command.Parameters.AddWithValue("@violationType", violationType);
                                            command.Parameters.AddWithValue("@violationName", violationName);
                                            command.Parameters.AddWithValue("@violationDesc", violationDesc);
                                            try
                                            {
                                                command.ExecuteNonQuery();
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + ": Violation Name:" + violationName + " added to database!");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + "Error:" + ex);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (cmbInstitutional.Text == "")
                                {
                                    MessageBox.Show("There is no violation selected!");
                                    return;
                                }
                                else
                                {
                                    violationName = cmbInstitutional.Text;
                                }
                                countInsti = 1;
                            }
                            else if (cmbViolate.Text == "Academic")
                            {
                                if (cmbAcademic.Text == "Others (Please specify)")
                                {
                                    if (txtSpecify.Text == "" || txtViolateDesc.Text == "")
                                    {
                                        MessageBox.Show("Please specify Violation Name and its description");
                                        return;
                                    }
                                    else
                                    {
                                        violationName = txtSpecify.Text;
                                        violationDesc = txtViolateDesc.Text;
                                        using (SqlCommand command = new SqlCommand("Insert into ViolationDetails Values (@violationType, @violationName, @violationDesc) ", conn))
                                        {
                                            command.Parameters.AddWithValue("@violationType", violationType);
                                            command.Parameters.AddWithValue("@violationName", violationName);
                                            command.Parameters.AddWithValue("@violationDesc", violationDesc);
                                            try
                                            {
                                                command.ExecuteNonQuery();
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + ": Violation Name:" + violationName + " added to database!");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + "Error:" + ex);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (cmbAcademic.Text == "")
                                {
                                    MessageBox.Show("There is no violation selected!");
                                    return;
                                }
                                else
                                {
                                    violationName = cmbAcademic.Text;
                                }
                                countAcademic = 1;
                            }
                            string remarks;
                            if (txtRemarks.Text == "")
                            {
                                remarks = "None";
                            }
                            else
                            {
                                remarks = txtRemarks.Text;
                            }
                            string date = txtDate.Text;

                            using (SqlCommand command = new SqlCommand("Update StudentInfo set CounterInsti = CounterInsti + @counterInsti, CounterDept = CounterDept + @counterDept, CounterAcad = CounterAcad + @counterAcad, CounterLastChance = CounterLastChance + @CounterLastChance, CounterProbi = CounterProbi + @CounterProbi where studentNo=" + txtStudNo.Text, conn))
                            {

                                command.Parameters.AddWithValue("@counterInsti", countInsti);
                                command.Parameters.AddWithValue("@counterDept", countDepart);
                                command.Parameters.AddWithValue("@counterAcad", countAcademic);
                                if (chkYesLC.Checked)
                                {
                                    countLastChance = 1;
                                }
                                else if (chkNoLC.Checked)
                                {
                                    countLastChance = 0;
                                }
                                command.Parameters.AddWithValue("@CounterLastChance", countLastChance);
                                if (chkYesProb.Checked)
                                {
                                    countProbi = 1;
                                }
                                else if (chkNoProb.Checked)
                                {
                                    countProbi = 0;
                                }
                                command.Parameters.AddWithValue("@CounterProbi", countProbi);

                                try
                                {
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Added Successfully");
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + ": student no:" + studNo + " added to database!");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + "Error:" + ex);
                                    }
                                }
                            }
                            using (SqlCommand cmd2 = new SqlCommand("Select ViolationCode from ViolationDetails where violationName = '" + violationName + "'", conn))
                            {
                                int violationCode = 0;
                                using (DbDataReader reader = cmd2.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        reader.Read();
                                        violationCode = Convert.ToInt32(reader.GetValue(0));
                                    }
                                }

                                using (SqlCommand command = new SqlCommand("INSERT INTO RecordDetails VALUES (@studentNo, @ViolationCode, @dateCommitted, @Period, @SY, @Remarks)", conn))
                                {
                                    command.Parameters.AddWithValue("@studentNo", studNo);
                                    command.Parameters.AddWithValue("@ViolationCode", violationCode);
                                    command.Parameters.AddWithValue("@dateCommitted", date);
                                    command.Parameters.AddWithValue("@Period", period);
                                    command.Parameters.AddWithValue("@SY", sy);
                                    command.Parameters.AddWithValue("@Remarks", remarks);

                                    try
                                    {
                                        command.ExecuteNonQuery();
                                        MessageBox.Show("Added Successfully");
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                        {
                                            time = DateTime.Now.ToString();
                                            file.WriteLine(time + ": student no:" + studNo + " added to database!");
                                        }
                                        emptyTextbox();
                                        emptyComboBox();
                                    }
                                    catch (Exception ex)
                                    {
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                        {
                                            time = DateTime.Now.ToString();
                                            file.WriteLine(time + "Error: " + ex);
                                            MessageBox.Show("Error has been encountered! Log has been updated with the error");
                                        }
                                        emptyTextbox();
                                        emptyComboBox();
                                    }
                                }
                            }
                            disableFields();
                            hideFields();
                        }
                        else
                        {
                            try
                            {
                                if (!int.TryParse(txtStudNo.Text, out check))
                                {
                                    MessageBox.Show("Invalid Input!");
                                    return;
                                }
                                else
                                {
                                    studNo = int.Parse(txtStudNo.Text);
                                }
                            }
                            catch (SqlException)
                            {
                                MessageBox.Show("Please enter value for Student No.");
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                {

                                    time = DateTime.Now.ToString();
                                    file.WriteLine(time + ": Invalid user input for student number.");
                                }
                                return;
                            }
                            string lastName = txtLName.Text;
                            string firstName = txtFName.Text;
                            string middleName = txtMName.Text;
                            string residence = cmbResidence.Text;
                            string period = cmbPeriod.Text;
                            string sy = cmbSY.Text;
                            string violationType = cmbViolate.Text;
                            string violationName = "";
                            string violationDesc = "";
                            int countInsti = 0;
                            int countDepart = 0;
                            int countAcademic = 0;
                            int countProbi = 0;
                            int countLastChance = 0;
                            if (cmbViolate.Text == "Departmental")
                            {
                                if (cmbDepartmental.Text == "Others (Please specify)")
                                {
                                    if (txtSpecify.Text == "" || txtViolateDesc.Text == "")
                                    {
                                        MessageBox.Show("Please specify Violation Name and its description");
                                        return;
                                    }
                                    else
                                    {
                                        violationName = txtSpecify.Text;
                                        violationDesc = txtViolateDesc.Text;
                                        using (SqlCommand command = new SqlCommand("Insert into ViolationDetails Values (@violationType, @violationName, @violationDesc) ", conn))
                                        {
                                            command.Parameters.AddWithValue("@violationType", violationType);
                                            command.Parameters.AddWithValue("@violationName", violationName);
                                            command.Parameters.AddWithValue("@violationDesc", violationDesc);
                                            try
                                            {
                                                command.ExecuteNonQuery();
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + ": Violation Name:" + violationName + " added to database!");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + "Error:" + ex);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (cmbDepartmental.Text == "")
                                {
                                    MessageBox.Show("There is no violation selected!");
                                    return;
                                }
                                else
                                {
                                    violationName = cmbDepartmental.Text;
                                }
                                countDepart = 1;
                            }
                            else if (cmbViolate.Text == "Institutional")
                            {
                                if (cmbInstitutional.Text == "Others (Please specify)")
                                {
                                    if (txtSpecify.Text == "" || txtViolateDesc.Text == "")
                                    {
                                        MessageBox.Show("Please specify Violation Name and its description");
                                        return;
                                    }
                                    else
                                    {
                                        violationName = txtSpecify.Text;
                                        violationDesc = txtViolateDesc.Text;
                                        using (SqlCommand command = new SqlCommand("Insert into ViolationDetails Values (@violationType, @violationName, @violationDesc) ", conn))
                                        {
                                            command.Parameters.AddWithValue("@violationType", violationType);
                                            command.Parameters.AddWithValue("@violationName", violationName);
                                            command.Parameters.AddWithValue("@violationDesc", violationDesc);
                                            try
                                            {
                                                command.ExecuteNonQuery();
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + ": Violation Name:" + violationName + " added to database!");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + "Error:" + ex);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (cmbInstitutional.Text == "")
                                {
                                    MessageBox.Show("There is no violation selected!");
                                    return;
                                }
                                else
                                {
                                    violationName = cmbInstitutional.Text;
                                }
                                countInsti = 1;
                            }
                            else if (cmbViolate.Text == "Academic")
                            {
                                if (cmbAcademic.Text == "Others (Please specify)")
                                {
                                    if (txtSpecify.Text == "" || txtViolateDesc.Text == "")
                                    {
                                        MessageBox.Show("Please specify Violation Name and its description");
                                        return;
                                    }
                                    else
                                    {
                                        violationName = txtSpecify.Text;
                                        violationDesc = txtViolateDesc.Text;
                                        using (SqlCommand command = new SqlCommand("Insert into ViolationDetails Values (@violationType, @violationName, @violationDesc) ", conn))
                                        {
                                            command.Parameters.AddWithValue("@violationType", violationType);
                                            command.Parameters.AddWithValue("@violationName", violationName);
                                            command.Parameters.AddWithValue("@violationDesc", violationDesc);
                                            try
                                            {
                                                command.ExecuteNonQuery();
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + ": Violation Name:" + violationName + " added to database!");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                                {
                                                    time = DateTime.Now.ToString();
                                                    file.WriteLine(time + "Error:" + ex);
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (cmbAcademic.Text == "")
                                {
                                    MessageBox.Show("There is no violation selected!");
                                    return;
                                }
                                else
                                {
                                    violationName = cmbAcademic.Text;
                                }
                                countAcademic = 1;
                            }
                            string remarks;
                            if (txtRemarks.Text == "")
                            {
                                remarks = "None";
                            }
                            else
                            {
                                remarks = txtRemarks.Text;
                            }
                            string date = txtDate.Text;

                            using (SqlCommand command = new SqlCommand("INSERT INTO StudentInfo VALUES (@studentNo, @LName, @GName, @MName, @residenceStatus, @counterLastChance, @counterDept, @counterAcad , @counterProbi, @counterInsti)", conn))
                            {
                                command.Parameters.AddWithValue("@studentNo", studNo);
                                command.Parameters.AddWithValue("@LName", lastName);
                                command.Parameters.AddWithValue("@GName", firstName);
                                command.Parameters.AddWithValue("@MName", middleName);
                                command.Parameters.AddWithValue("@residenceStatus", residence);
                                command.Parameters.AddWithValue("@counterInsti", countInsti);
                                command.Parameters.AddWithValue("@CounterDept", countDepart);
                                command.Parameters.AddWithValue("@CounterAcad", countAcademic);
                                command.Parameters.AddWithValue("@CounterProbi", countProbi);
                                if (chkYesLC.Checked)
                                {
                                    countLastChance = 1;
                                }
                                else if (chkNoLC.Checked)
                                {
                                    countLastChance = 0;
                                }
                                command.Parameters.AddWithValue("@CounterLastChance", countLastChance);
                                try
                                {
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Added Successfully");
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + ": student no:" + studNo + " added to database!");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + "Error:" + ex);
                                    }
                                }
                            }
                            using (SqlCommand cmd2 = new SqlCommand("Select ViolationCode from ViolationDetails where violationName = '" + violationName + "'", conn))
                            {
                                int violationCode = 0;
                                using (DbDataReader reader = cmd2.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        reader.Read();
                                        violationCode = Convert.ToInt32(reader.GetValue(0));
                                    }
                                }

                                using (SqlCommand command = new SqlCommand("INSERT INTO RecordDetails VALUES (@studentNo, @ViolationCode, @dateCommitted, @Period, @SY, @Remarks)", conn))
                                {
                                    command.Parameters.AddWithValue("@studentNo", studNo);
                                    command.Parameters.AddWithValue("@ViolationCode", violationCode);
                                    command.Parameters.AddWithValue("@dateCommitted", date);
                                    command.Parameters.AddWithValue("@Period", period);
                                    command.Parameters.AddWithValue("@SY", sy);
                                    command.Parameters.AddWithValue("@Remarks", remarks);

                                    try
                                    {
                                        command.ExecuteNonQuery();
                                        MessageBox.Show("Added Successfully");
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                        {
                                            time = DateTime.Now.ToString();
                                            file.WriteLine(time + ": student no:" + studNo + " added to database!");
                                        }
                                        emptyTextbox();
                                        emptyComboBox();
                                    }
                                    catch (Exception ex)
                                    {
                                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                        {
                                            time = DateTime.Now.ToString();
                                            file.WriteLine(time + "Error: " + ex);
                                        }
                                        emptyTextbox();
                                        emptyComboBox();
                                    }
                                }
                            }
                            disableFields();
                            hideFields();
                        }
                    }
                    conn.Close();
                }
            }
            else if (value == 2)
            {
                if (txtLName.Text == "" || txtFName.Text == "" || cmbResidence.Text == "")
                {
                    MessageBox.Show("Please fill up the missing fields!");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Do you want to update the record?", "Edit Record", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            string lastName = txtLName.Text;
                            string firstName = txtFName.Text;
                            string middleName = txtMName.Text;
                            string residence = cmbResidence.Text;
                            using (SqlCommand cmd = new SqlCommand("UPDATE StudentInfo SET LastName = @LName, GivenName = @FName, MiddleName = @MName, ResidenceStatus = @residence where studentNo =" + txtStudNo.Text, conn))
                            {
                                cmd.Parameters.AddWithValue("@LName", lastName);
                                cmd.Parameters.AddWithValue("@FName", firstName);
                                cmd.Parameters.AddWithValue("@MName", middleName);
                                cmd.Parameters.AddWithValue("@residence", residence);

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Updated Successfully");
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + ": Updated Information for student no:" + txtStudNo.Text);
                                    }
                                }
                                catch (SqlException ex)
                                {
                                    MessageBox.Show("Error: " + ex);
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + "Error: " + ex);
                                    }
                                }
                            }
                            txtStudNo.Enabled = true;
                            emptyTextbox();
                            emptyComboBox();
                            conn.Close();
                            break;

                        case DialogResult.No: break;
                    }
                }
            }
        }
        //end button functions

        //start manipulate fields
        private void emptyComboBox()
        {
            cmbResidence.ResetText();
            cmbResidence.SelectedIndex = -1;
            cmbPeriod.ResetText();
            cmbPeriod.SelectedIndex = -1;
            cmbSY.ResetText();
            cmbSY.SelectedIndex = -1;
            cmbViolate.ResetText();
            cmbViolate.SelectedIndex = -1;
            cmbAcademic.ResetText();
            cmbAcademic.SelectedIndex = -1;
            cmbInstitutional.ResetText();
            cmbInstitutional.SelectedIndex = -1;
            cmbDepartmental.ResetText();
            cmbDepartmental.SelectedIndex = -1;

            cmbRes.ResetText();
            cmbRes.SelectedIndex = -1;
            cmbViolationType.ResetText();
            cmbViolationType.SelectedIndex = -1;
        }
        private void emptyTextbox()
        {
            txtStudNo.Text = "";
            txtFName.Text = "";
            txtMName.Text = "";
            txtLName.Text = "";
            txtSpecify.Text = "";
            txtAcademicViolation.Text = "";
            txtDepartViolation.Text = "";
            txtInstiViolation.Text = "";
            txtViolateDesc.Text = "";
            txtRemarks.Text = "";

            txtStudentNo.Text = "";
            txtLastN.Text = "";
            txtFirstN.Text = "";
            txtMiddleN.Text = "";
            txtCounterA.Text = "";
            txtCounterD.Text = "";
            txtCounterI.Text = "";

            txtViolationName.Text = "";
            txtViolationDesc.Text = "";
            txtViolationCode.Text = "";
        }
        private void disableFields()
        {
            txtLName.Enabled = false;
            txtFName.Enabled = false;
            txtMName.Enabled = false;
            cmbResidence.Enabled = false;
            cmbPeriod.Enabled = false;
            cmbSY.Enabled = false;
            cmbViolate.Enabled = false;
            chkYesLC.Enabled = false;
            chkNoLC.Enabled = false;
            txtRemarks.Enabled = false;

            txtStudentNo.Enabled = false;
            txtLastN.Enabled = false;
            txtFirstN.Enabled = false;
            txtMiddleN.Enabled = false;
            cmbRes.Enabled = false;
            txtCounterA.Enabled = false;
            txtCounterD.Enabled = false;
            txtCounterI.Enabled = false;

            cmbViolationType.Enabled = false;
            txtViolationName.Enabled = false;
            txtViolationDesc.Enabled = false;
        }
        private void enableFields()
        {
            txtStudNo.Enabled = true;
            txtLName.Enabled = true;
            txtFName.Enabled = true;
            txtMName.Enabled = true;
            cmbResidence.Enabled = true;
            cmbPeriod.Enabled = true;
            cmbSY.Enabled = true;
            cmbViolate.Enabled = true;
            chkYesLC.Enabled = true;
            chkNoLC.Enabled = true;
            cmbAcademic.Enabled = true;
            cmbDepartmental.Enabled = true;
            cmbInstitutional.Enabled = true;
            txtRemarks.Enabled = true;

            txtStudentNo.Enabled = true;
            txtLastN.Enabled = true;
            txtFirstN.Enabled = true;
            txtMiddleN.Enabled = true;
            cmbRes.Enabled = true;
            txtCounterA.Enabled = true;
            txtCounterD.Enabled = true;
            txtCounterI.Enabled = true;

            cmbViolationType.Enabled = true;
            txtViolationName.Enabled = true;
            txtViolationDesc.Enabled = true;
        }
        private void hideFields()
        {
            chkYesLC.Visible = false;
            chkNoLC.Visible = false;
            cmbAcademic.Visible = false;
            cmbDepartmental.Visible = false;
            cmbInstitutional.Visible = false;
            chkYesProb.Visible = false;
            chkNoProb.Visible = false;
            lblLastChance.Visible = false;
            lblProbi.Visible = false;
            lblRemarks.Visible = false;
            txtRemarks.Visible = false;
            lblSpecify.Visible = false;
            txtRemarks.Visible = false;

            txtViolationCode.Visible = false;
            lblViolationCode.Visible = false;
        }
        //end manipulate fields

        //end RECORD TAB

        //start REPORT TAB
        private void btnSpeGenReport_Click(object sender, EventArgs e)
        {
            ReportStudent rs = new ReportStudent();
            try
            {
                rs.studNo = Convert.ToInt32(txtStudNoSearch.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill up all the fields.");
            }
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("Select COUNT(1) from StudentInfo where studentNo =" + txtStudNoSearch.Text, conn))
            {
                if (txtStudNoSearch.Text == "")
                {
                    MessageBox.Show("No user input!");
                }
                else
                {
                    int studCount;
                    if (!int.TryParse(txtStudNoSearch.Text, out studCount))
                    {
                        MessageBox.Show("Invalid Input!");
                        return;
                    }
                    else
                    {
                        string name, residence;
                        int studNo;

                        studCount = (int)cmd.ExecuteScalar();
                        if (studCount > 0)
                        {
                            SqlCommand cmd2 = new SqlCommand("Select * from StudentInfo WHERE StudentNo = @studNo", conn);
                            cmd2.Parameters.AddWithValue("@studNo", txtStudNoSearch.Text);
                            SqlDataReader dr = cmd2.ExecuteReader();
                            dr.Read();
                            studNo = dr.GetInt32(0);
                            residence = dr.GetString(4);
                            name = dr.GetString(1) + ", " + dr.GetString(2) + " " + dr.GetString(3);

                            rs.studNo = studNo;
                            rs.residence = residence;
                            rs.fullName = name;
                            rs.Activated += new EventHandler(rs_Activated);
                            rs.FormClosed += new FormClosedEventHandler(rs_FormClosed);
                            rs.Show();
                        }
                        else
                        {
                            MessageBox.Show("Student does not exist!");
                        }
                    }
                }
            }
            conn.Close();
            conn.Dispose();
        }
        private void btnGenGenReport_Click(object sender, EventArgs e)
        {
            ReportGeneral rg = new ReportGeneral();
            if (cmbSearchViolate.Text == "" || cmbSearchResidence.Text == "" || cmbSearchPeriod.Text == "" || cmbSYFrom.Text == "" || cmbSYTo.Text == "")
            {
                MessageBox.Show("Please fill up the missing field(s)!");
            }
            else
            {
                rg.violationType = cmbSearchViolate.Text;
                rg.residence = cmbSearchResidence.Text;
                rg.period = cmbSearchPeriod.Text;
                rg.syFrom = cmbSYFrom.Text;
                rg.syTo = cmbSYTo.Text;
                rg.Activated += new EventHandler(rg_Activated);
                rg.FormClosed += new FormClosedEventHandler(rg_FormClosed);
                rg.Show();
            }
        }
        private void rs_Activated(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void rs_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        private void rg_Activated(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void rg_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }
        //end REPORT TAB
        //start USER ACCOUNT TAB
        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            string gName = txtGivenName.Text;
            string mName = txtMiddleName.Text;
            string lName = txtLastName.Text;
            string un = txtUsername.Text;
            string pw = txtPassword.Text;
            string cp = txtConfirm.Text;
            string sq = cmbQuestion.Text;
            string sa = txtAnswer.Text;
            int userLevel = 0;

            if (cmbUserLevel.Text.Equals("Administrator"))
                userLevel = 1;
            else if (cmbUserLevel.Text.Equals("Student Assistant"))
                userLevel = 2;

            int loginAttempts = 0;

            if (String.IsNullOrEmpty(txtLastName.Text) || String.IsNullOrEmpty(txtGivenName.Text) || String.IsNullOrEmpty(txtMiddleName.Text) || String.IsNullOrEmpty(txtUsername.Text)
                || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtConfirm.Text) || String.IsNullOrEmpty(cmbQuestion.Text) || String.IsNullOrEmpty(txtAnswer.Text) || String.IsNullOrEmpty(cmbUserLevel.Text))
            {
                MessageBox.Show("Please fill up all the missing fields");
                return;
            }

            if (txtPassword.Text.Equals(txtConfirm.Text))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Accounts VALUES (@userID, @Password, @LastName, @GivenName, @MiddleName, @securityQuestion, @securityAnswer, @userLevel, @loginAttempts)", conn))
                {
                    cmd.Parameters.AddWithValue("@userID", un);
                    cmd.Parameters.AddWithValue("@Password", pw);
                    cmd.Parameters.AddWithValue("@LastName", lName);
                    cmd.Parameters.AddWithValue("@GivenName", gName);
                    cmd.Parameters.AddWithValue("@MiddleName", mName);
                    cmd.Parameters.AddWithValue("@securityQuestion", sq);
                    cmd.Parameters.AddWithValue("@securityAnswer", sa);
                    cmd.Parameters.AddWithValue("@userLevel", userLevel);
                    cmd.Parameters.AddWithValue("@loginAttempts", loginAttempts);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registered successfully");
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\ActivityLogs.txt", true))
                        {
                            time = DateTime.Now.ToString();
                            file.WriteLine(time + " Account Name: " + lName + ", " + gName + " " + mName + " has been created");
                        }
                    }
                    catch (SqlException)
                    {
                        MessageBox.Show("Error: A user with the same User ID already exists.");
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\ActivityLogs.txt", true))
                        {
                            time = DateTime.Now.ToString();
                            file.WriteLine(time + " Error: A user with the same User ID already exists.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Your password and confirmation password do not match.");
            }
        }
        //end USER ACCOUNT TAB

        //start STUDENT RECORD TAB
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            value = 1;
            enableFields();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            value = 2;
            enableFields();
        }

        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            int studNo;
            int check;

            if (value == 1)
            {
                if (txtStudentNo.Text == "" || txtLastN.Text == "" || txtFirstN.Text == "" || txtMiddleN.Text == "" || cmbRes.Text == "")
                {
                    MessageBox.Show("Please fill up the missing fields!");
                    return;
                }

                try
                {
                    if (!int.TryParse(txtStudentNo.Text, out check))
                    {
                        MessageBox.Show("Invalid Input!");
                        return;
                    }
                    else
                        studNo = int.Parse(txtStudentNo.Text);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Please enter a value for Student No.");
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                    {
                        time = DateTime.Now.ToString();
                        file.WriteLine(time + ": Invalid user input for student number.");
                    }
                    return;
                }

                studNo = int.Parse(txtStudentNo.Text);
                string lastName = txtLastN.Text;
                string firstName = txtFirstN.Text;
                string middleName = txtMiddleN.Text;
                string residence = cmbRes.Text;
                int counterA = 0;
                int counterD = 0;
                int counterI = 0;
                try
                {
                    counterA = int.Parse(txtCounterA.Text);
                    counterD = int.Parse(txtCounterD.Text);
                    counterI = int.Parse(txtCounterI.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("No. of Violations must be numeric");
                    return;
                }
                int counter = 0;
               

                using (SqlCommand cmd = new SqlCommand("SELECT studentNo FROM StudentInfo WHERE studentNo = @studentNo", conn))
                {                 
                    cmd.Parameters.AddWithValue("@studentNo", studNo);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("A record with the same Student No. already exists");
                        return;
                    }
                    else
                    {
                        dr.Close();
                        using (SqlCommand command = new SqlCommand("INSERT INTO StudentInfo VALUES (@studentNo, @LName, @GName, @MName, @residenceStatus, @counterLastChance, @counterDept, @counterAcad , @counterProbi, @counterInsti)", conn))
                        {
                            command.Parameters.AddWithValue("@studentNo", studNo);
                            command.Parameters.AddWithValue("@LName", lastName);
                            command.Parameters.AddWithValue("@GName", firstName);
                            command.Parameters.AddWithValue("@MName", middleName);
                            command.Parameters.AddWithValue("@residenceStatus", residence);
                            command.Parameters.AddWithValue("@counterInsti", counterI);
                            command.Parameters.AddWithValue("@CounterDept", counterD);
                            command.Parameters.AddWithValue("@CounterAcad", counterA);
                            command.Parameters.AddWithValue("@CounterProbi", counter);
                            command.Parameters.AddWithValue("@counterLastChance", counter);

                            try
                            {
                                command.ExecuteNonQuery();
                                MessageBox.Show("Added Successfully");
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                {
                                    time = DateTime.Now.ToString();
                                    file.WriteLine(time + ": student no:" + studNo + " added to database!");
                                }
                                emptyComboBox();
                                emptyTextbox();
                            }
                            catch (Exception ex)
                            {
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                {
                                    time = DateTime.Now.ToString();
                                    file.WriteLine(time + "Error:" + ex);
                                }
                            }
                        }
                    }
                }           
            }

            else if(value == 2)
            {
                if (txtStudentNo.Text == "" || txtLastN.Text == "" || txtFirstN.Text == "" || txtMiddleN.Text == "" || cmbRes.Text == "")
                {
                    MessageBox.Show("Please fill up the missing fields!");
                    return;
                }

                else
                {
                    DialogResult dr = MessageBox.Show("Do you want to update the record?", "Edit Record", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            string lastName = txtLastN.Text;
                            string firstName = txtFirstN.Text;
                            string middleName = txtMiddleN.Text;
                            string residence = cmbRes.Text;
                            string counterA = txtCounterA.Text;
                            string counterD = txtCounterD.Text;
                            string counterI = txtCounterI.Text;
                            using (SqlCommand cmd = new SqlCommand("UPDATE StudentInfo SET LastName = @LName, GivenName = @FName, MiddleName = @MName, ResidenceStatus = @residence, CounterDept = @counterD, CounterInsti = @counterI, CounterAcad = @counterA where studentNo =" + txtStudentNo.Text, conn))
                            {
                                cmd.Parameters.AddWithValue("@LName", lastName);
                                cmd.Parameters.AddWithValue("@FName", firstName);
                                cmd.Parameters.AddWithValue("@MName", middleName);
                                cmd.Parameters.AddWithValue("@residence", residence);
                                cmd.Parameters.AddWithValue("@counterA", counterA);
                                cmd.Parameters.AddWithValue("@counterD", counterD);
                                cmd.Parameters.AddWithValue("@counterI", counterI);

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Updated Successfully");
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + ": Updated Information for student no:" + txtStudNo.Text);
                                    }
                                }
                                catch (SqlException ex)
                                {
                                    MessageBox.Show("Error: " + ex);
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + "Error: " + ex);
                                    }
                                }
                            }
                            txtStudNo.Enabled = true;
                            emptyTextbox();
                            emptyComboBox();
                            conn.Close();
                            break;

                        case DialogResult.No: break;
                    }
                }
            }
        }

        private void txtStudentNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtStudentNo.Text == "")
                {
                    MessageBox.Show("Please input student number!");
                    txtStudentNo.Text = "";
                }
                else
                {
                    SqlConnection conn = DBUtils.GetDBConnection();
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select COUNT(1) from StudentInfo where studentNo =" + txtStudentNo.Text, conn))
                    {
                        int studCount;
                        int check;
                        if (!int.TryParse(txtStudentNo.Text, out check))
                        {
                            MessageBox.Show("Invalid Input!");
                            return;
                        }
                        else
                        {
                            studCount = (int)cmd.ExecuteScalar();
                        }
                        if (studCount > 0)
                        {
                            string studentNumber = txtStudentNo.Text;
                            using (SqlCommand cmd1 = new SqlCommand("Select * from StudentInfo where studentNo = @studentNo", conn))
                            {
                                cmd1.Parameters.AddWithValue("@studentNo", studentNumber);
                                cmd1.Connection = conn;
                                using (DbDataReader reader = cmd1.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        reader.Read();
                                        //1
                                        int studNo = Convert.ToInt32(reader.GetValue(0));
                                        //2
                                        int lNameIndex = reader.GetOrdinal("lastName");
                                        string lName = Convert.ToString(reader.GetValue(lNameIndex));
                                        //3
                                        int fNameIndex = reader.GetOrdinal("givenName");
                                        string fName = Convert.ToString(reader.GetValue(fNameIndex));
                                        //4
                                        int mNameIndex = reader.GetOrdinal("middleName");
                                        string mName = Convert.ToString(reader.GetValue(mNameIndex));
                                        //5
                                        int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                        string residenceStatus = Convert.ToString(reader.GetValue(residenceIndex));
                                        //6
                                        int instiIndex = reader.GetOrdinal("CounterInsti");
                                        int counterInsti = Convert.ToInt32(reader.GetValue(instiIndex));
                                        //7
                                        int deptIndex = reader.GetOrdinal("CounterDept");
                                        int counterDepart = Convert.ToInt32(reader.GetValue(deptIndex));
                                        //8
                                        int acadIndex = reader.GetOrdinal("CounterAcad");
                                        int counterAcad = Convert.ToInt32(reader.GetValue(acadIndex));

                                        txtStudentNo.Text = studNo.ToString();
                                        txtLastN.Text = lName;
                                        txtFirstN.Text = fName;
                                        txtMiddleN.Text = mName;
                                        cmbRes.Text = residenceStatus;
                                        txtCounterA.Text = counterAcad.ToString();
                                        txtCounterD.Text = counterDepart.ToString();
                                        txtCounterI.Text = counterInsti.ToString();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no record of that user!");
                        }
                    }
                    conn.Close();
                }

            }
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (txtStudentNo.Text == "" || txtLastN.Text == "" || txtFirstN.Text == "" || txtMiddleN.Text == "" || cmbRes.Text == "")
            {
                MessageBox.Show("Please fill up the missing fields!");
                return;
            }
            else
            {
                if (value == 2)
                {
                    DialogResult dr = MessageBox.Show("Do you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            SqlConnection conn = DBUtils.GetDBConnection();
                            conn.Open();
                            SqlCommand command = new SqlCommand("Delete from StudentInfo where studentNo=" + txtStudentNo.Text, conn);
                            int count = command.ExecuteNonQuery();
                            if (count == 1)
                            {
                                MessageBox.Show("User record has been deleted!");
                                emptyTextbox();
                                emptyComboBox();
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                {
                                    time = DateTime.Now.ToString();
                                    file.WriteLine(time + ": Deleted user with student no:" + txtStudentNo.Text);
                                }
                            }
                            else
                            {
                                MessageBox.Show("User does not exist!");
                                return;
                            }
                            break;

                        case DialogResult.No: break;
                    }
                }
                else
                {
                    MessageBox.Show("Please click Edit button first to be able to delete!");
                }
            }      
        }
        //end STUDENT RECORD TAB

        //start VIOLATION RECORD TAB
        private void btnAddViolation_Click(object sender, EventArgs e)
        {
            value = 1;
            enableFields();
            hideFields();
        }

        private void btnEditViolation_Click(object sender, EventArgs e)
        {
            value = 2;
            enableFields();
            txtViolationCode.Visible = true;
            lblViolationCode.Visible = true;
        }

        private void btnSaveViolation_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            String violationType, violationName, violationDesc;

            if (value == 1)
            {
                if (txtViolationName.Text == "" || txtViolationDesc.Text == "" || cmbViolationType.Text == "")
                {
                    MessageBox.Show("Please fill in the missing fields");
                    return;
                }
                else
                {
                    violationType = cmbViolationType.Text;
                    violationName = txtViolationName.Text;
                    violationDesc = txtViolationDesc.Text;

                    using (SqlCommand command = new SqlCommand("Insert into ViolationDetails Values (@violationType, @violationName, @violationDesc) ", conn))
                    {
                        command.Parameters.AddWithValue("@violationType", violationType);
                        command.Parameters.AddWithValue("@violationName", violationName);
                        command.Parameters.AddWithValue("@violationDesc", violationDesc);
                        try
                        {
                            command.ExecuteNonQuery();
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                            {
                                time = DateTime.Now.ToString();
                                file.WriteLine(time + ": Violation Name:" + violationName + " added to database!");
                            }
                            MessageBox.Show("Added Successfully");
                        }
                        catch (Exception ex)
                        {
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                            {
                                time = DateTime.Now.ToString();
                                file.WriteLine(time + "Error:" + ex);
                            }
                        }
                    }
                }
            }
            else if (value == 2)
            {
                if (txtViolationName.Text == "" || txtViolationDesc.Text == "" || cmbViolationType.Text == "" || txtViolationCode.Text == "")
                {
                    MessageBox.Show("Please fill in the missing fields");
                    return;
                }

                else
                {
                    DialogResult dr = MessageBox.Show("Do you want to update the record?", "Edit Record", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            int violationCode = int.Parse(txtViolationCode.Text);
                            violationName = txtViolationName.Text;
                            violationDesc = txtViolationDesc.Text;
                            violationType = cmbViolationType.Text;
                            
                            using (SqlCommand cmd = new SqlCommand("UPDATE ViolationDetails SET ViolationType = @vt, ViolationName = @vn, ViolationDesc = @vd where ViolationCode =" + violationCode, conn))
                            {
                                cmd.Parameters.AddWithValue("@vt", violationType);
                                cmd.Parameters.AddWithValue("@vn", violationName);
                                cmd.Parameters.AddWithValue("@vd", violationDesc);
                                
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Updated Successfully");
                                    hideFields();
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + ": Updated Information for Violation Code:" + txtViolationCode.Text);
                                    }
                                }
                                catch (SqlException ex)
                                {
                                    MessageBox.Show("Error: " + ex);
                                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                    {
                                        time = DateTime.Now.ToString();
                                        file.WriteLine(time + "Error: " + ex);
                                    }
                                }
                            }
                            txtViolationCode.Enabled = true;
                            emptyTextbox();
                            emptyComboBox();
                            conn.Close();
                            break;

                        case DialogResult.No: break;
                    }
                }
            }
        }

        private void txtViolationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtViolationCode.Text == "")
                {
                    MessageBox.Show("Please input Violation Code!");
                    txtViolationCode.Text = "";
                }
                else
                {
                    SqlConnection conn = DBUtils.GetDBConnection();
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select COUNT(1) from ViolationDetails where ViolationCode =" + txtViolationCode.Text, conn))
                    {
                        int violationCount;
                        int check;
                        if (!int.TryParse(txtViolationCode.Text, out check))
                        {
                            MessageBox.Show("Invalid Input!");
                            return;
                        }
                        else
                        {
                            violationCount = (int)cmd.ExecuteScalar();
                        }
                        if (violationCount > 0)
                        {
                            string violationCode = txtViolationCode.Text;
                            using (SqlCommand cmd1 = new SqlCommand("Select * from ViolationDetails where ViolationCode = @violationCode", conn))
                            {
                                cmd1.Parameters.AddWithValue("@violationCode", violationCode);
                                cmd1.Connection = conn;
                                using (DbDataReader reader = cmd1.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        reader.Read();
                                        //1
                                        int vCode = Convert.ToInt32(reader.GetValue(0));
                                        //2
                                        int vTypeIndex = reader.GetOrdinal("ViolationType");
                                        string violationType = Convert.ToString(reader.GetValue(vTypeIndex));
                                        //3
                                        int vNameIndex = reader.GetOrdinal("ViolationName");
                                        string violationName = Convert.ToString(reader.GetValue(vNameIndex));
                                        //4
                                        int vDescIndex = reader.GetOrdinal("ViolationDesc");
                                        string violationDesc = Convert.ToString(reader.GetValue(vDescIndex));


                                        txtViolationCode.Text = vCode.ToString();
                                        cmbViolationType.Text = violationType;
                                        txtViolationName.Text = violationName;
                                        txtViolationDesc.Text = violationDesc;
                                        
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("There is no record of that violation!");
                        }
                    }
                    conn.Close();
                }

            }
        }

        private void btnDeleteViolation_Click(object sender, EventArgs e)
        {
            if (txtViolationName.Text == "" || txtViolationDesc.Text == "" || cmbViolationType.Text == "" || txtViolationCode.Text == "")
            {
                MessageBox.Show("Please fill in the missing fields");
                return;
            }
            else
            {
                if (value == 2)
                {
                    DialogResult dr = MessageBox.Show("Do you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            SqlConnection conn = DBUtils.GetDBConnection();
                            conn.Open();
                            SqlCommand command = new SqlCommand("Delete from ViolationDetails where ViolationCode=" + txtViolationCode.Text, conn);
                            int count = command.ExecuteNonQuery();
                            if (count == 1)
                            {
                                MessageBox.Show("Violation record has been deleted!");
                                emptyTextbox();
                                emptyComboBox();
                                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Logs\Logs.txt", true))
                                {
                                    time = DateTime.Now.ToString();
                                    file.WriteLine(time + ": Deleted Violation with Violation Code:" + txtViolationCode.Text);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Violation record does not exist!");
                                return;
                            }
                            break;

                        case DialogResult.No: break;
                    }
                }
                else
                {
                    MessageBox.Show("Please click Edit button first to be able to delete!");
                }
            }
        }


        //end VIOLATION RECORD TAB
    }
}

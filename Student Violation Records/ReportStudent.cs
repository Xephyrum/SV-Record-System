using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Data.SqlClient;

namespace Student_Violation_Records
{
    public partial class ReportStudent : MaterialForm
    {
        public int studNo, institutionalCount, departmentalCount;
        public string residence, fullName;

        string[] records = new string[8];

        public ReportStudent()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            txtStudNo.Text = studNo.ToString();
            txtResidence.Text = residence;
            txtFullName.Text = fullName;
            lvReport.Columns.Add("Record No.", 150);       
            lvReport.Columns.Add("Date Committed", 150);
            lvReport.Columns.Add("Semester", 130);
            lvReport.Columns.Add("School Year", 130);
            lvReport.Columns.Add("Violation Code", 130);
            lvReport.Columns.Add("Violation Type", 130);
            lvReport.Columns.Add("Violation Name", 120);
            lvReport.Columns.Add("Remarks", 120);

            txtStudNo.Text = studNo.ToString();
            
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM RecordDetails INNER JOIN ViolationDetails ON ViolationDetails.ViolationCode = RecordDetails.ViolationCode WHERE RecordDetails.StudentNo = @studNo", conn))
            {
                lvReport.Items.Clear();
                cmd.Parameters.AddWithValue("@studNo", studNo);
                SqlDataReader dr = cmd.ExecuteReader();             
               
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {                
                        int recordNo = Convert.ToInt32(dr.GetValue(0));                       
                        
                        int dateIndex = dr.GetOrdinal("DateCommitted");
                        DateTime myDate = dr.GetDateTime(dateIndex);
                        string date = myDate.ToString("MM/dd/yyyy");

                        int periodIndex = dr.GetOrdinal("Period");
                        string period = Convert.ToString(dr.GetValue(periodIndex));
                        
                        int syIndex = dr.GetOrdinal("SY");
                        string sy = Convert.ToString(dr.GetValue(syIndex));

                        int violationCode = Convert.ToInt32(dr.GetValue(2));

                        int violationTypeIndex = dr.GetOrdinal("ViolationType");
                        string violationType = Convert.ToString(dr.GetValue(violationTypeIndex));

                        if (violationType.Equals("Institutional"))
                            institutionalCount += 1;
                        else if (violationType.Equals("Departmental"))
                            departmentalCount += 1;

                        int violationNameIndex = dr.GetOrdinal("ViolationName");
                        string violationName = Convert.ToString(dr.GetValue(violationNameIndex));

                        int remarksIndex = dr.GetOrdinal("Remarks");
                        string remarks = Convert.ToString(dr.GetValue(remarksIndex));                    
                   
                        records[0] = recordNo.ToString();
                        records[1] = date;
                        records[2] = period;
                        records[3] = sy;
                        records[4] = violationCode.ToString();
                        records[5] = violationType;
                        records[6] = violationName;
                        records[7] = remarks;

                        ListViewItem record = new ListViewItem(records);
                        lvReport.Items.Add(record);
                        txtDepartViolation.Text = departmentalCount.ToString();
                        txtInstiViolation.Text = institutionalCount.ToString();
                    }
                }

            }
        }
    }
}

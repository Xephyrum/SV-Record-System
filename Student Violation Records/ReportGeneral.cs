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
using System.Data.Common;
using System.Data.SqlClient;

namespace Student_Violation_Records
{
    public partial class ReportGeneral : MaterialForm
    {
        public string period; //check
        public string syFrom; //check
        public string syTo; //check
        public string violationType; //check
        public string residence; //check
        string[] genRep = new string[10];

        public ReportGeneral()
        {
            InitializeComponent();
        }

        private void ReportGeneral_Load(object sender, EventArgs e)
        {
            lvGenReport.Font = new Font("Roboto", 12, FontStyle.Regular);
            lvGenReport.Columns.Add("#", 30);
            lvGenReport.Columns.Add("Record No.", 150);
            lvGenReport.Columns.Add("Student No.", 150);
            lvGenReport.Columns.Add("Full name", 200);
            lvGenReport.Columns.Add("Residence", 120);
            lvGenReport.Columns.Add("Date Committed", 120);
            lvGenReport.Columns.Add("Violation Code", 130);
            lvGenReport.Columns.Add("Violation Type", 130);
            lvGenReport.Columns.Add("Violation Name", 150);
            lvGenReport.Columns.Add("Last Chance", 120);
            lvGenReport.Columns.Add("Remarks", 150);
            lblSem.Text = period;
            lblyrStart.Text = syFrom;
            lblyrEnd.Text = syTo;
            updateListView();
        }
        
        private void updateListView()
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            if (period == "ALL" && violationType == "ALL" && residence == "ALL")
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rd.RecordNo as RecordNo, rd.StudentNo as StudentNo, rd.ViolationCode as ViolationCode, rd.DateCommitted as DateCommitted, si.LastName + ', ' + si.GivenName + ' ' + si.MiddleName AS 'Full Name', si.ResidenceStatus as ResidenceStatus, rd.Period as Period, rd.SY as SY, rd.Remarks as Remarks, vd.ViolationType as ViolationType, vd.ViolationName FROM RecordDetails AS rd INNER JOIN StudentInfo AS si ON rd.StudentNo = si.StudentNo INNER JOIN ViolationDetails AS vd ON rd.ViolationCode = vd.ViolationCode WHERE (year(DateCommitted) between " + syFrom + " and " + syTo + ")", conn))
                {
                    lvGenReport.Items.Clear();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 1;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //1
                                int recordNo = Convert.ToInt32(reader.GetValue(0));
                                //2
                                int studNoIndex = reader.GetOrdinal("StudentNo");
                                int studNo = Convert.ToInt32(reader.GetValue(studNoIndex));
                                //3
                                int fullNameIndex = reader.GetOrdinal("Full Name");
                                string fullName = Convert.ToString(reader.GetValue(fullNameIndex));
                                //4
                                int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                string residence = Convert.ToString(reader.GetValue(residenceIndex));
                                //5
                                int dateIndex = reader.GetOrdinal("dateCommitted");
                                DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                                string date = myDate.ToString("MM/dd/yyyy");
                                //6
                                int violationCodeIndex = reader.GetOrdinal("ViolationCode");
                                int violationCode = Convert.ToInt32(reader.GetValue(violationCodeIndex));
                                //7
                                int violationTypeIndex = reader.GetOrdinal("ViolationType");
                                string violationType = Convert.ToString(reader.GetValue(violationTypeIndex));
                                //8
                                int violationNameIndex = reader.GetOrdinal("ViolationName");
                                string violationName = Convert.ToString(reader.GetValue(violationNameIndex));
                                //9
                                int remarksIndex = reader.GetOrdinal("remarks");
                                string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                                genRep[0] = i.ToString();
                                genRep[1] = recordNo.ToString();
                                genRep[2] = studNo.ToString();
                                genRep[3] = fullName;
                                genRep[4] = residence;
                                genRep[5] = date;
                                genRep[6] = violationCode.ToString();
                                genRep[7] = violationType;
                                genRep[8] = violationName;
                                genRep[9] = remarks;
                                ListViewItem lvGen = new ListViewItem(genRep);
                                lvGenReport.Items.Add(lvGen);
                                i++;
                            }
                        }
                    }
                }
            }
            else if (period == "ALL" && violationType == "ALL")
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rd.RecordNo as RecordNo, rd.StudentNo as StudentNo, rd.ViolationCode as ViolationCode, rd.DateCommitted as DateCommitted, si.LastName + ', ' + si.GivenName + ' ' + si.MiddleName AS 'Full Name', si.ResidenceStatus as ResidenceStatus, rd.Period as Period, rd.SY as SY, rd.Remarks as Remarks, vd.ViolationType as ViolationType, vd.ViolationName FROM RecordDetails AS rd INNER JOIN StudentInfo AS si ON rd.StudentNo = si.StudentNo INNER JOIN ViolationDetails AS vd ON rd.ViolationCode = vd.ViolationCode WHERE (year(DateCommitted) between " + syFrom + " and " + syTo + ") AND (si.ResidenceStatus = '" + residence + "')", conn))
                {
                    lvGenReport.Items.Clear();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 1;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //1
                                int recordNo = Convert.ToInt32(reader.GetValue(0));
                                //2
                                int studNoIndex = reader.GetOrdinal("StudentNo");
                                int studNo = Convert.ToInt32(reader.GetValue(studNoIndex));
                                //3
                                int fullNameIndex = reader.GetOrdinal("Full Name");
                                string fullName = Convert.ToString(reader.GetValue(fullNameIndex));
                                //4
                                int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                string residence = Convert.ToString(reader.GetValue(residenceIndex));
                                //5
                                int dateIndex = reader.GetOrdinal("dateCommitted");
                                DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                                string date = myDate.ToString("MM/dd/yyyy");
                                //6
                                int violationCodeIndex = reader.GetOrdinal("ViolationCode");
                                int violationCode = Convert.ToInt32(reader.GetValue(violationCodeIndex));
                                //7
                                int violationTypeIndex = reader.GetOrdinal("ViolationType");
                                string violationType = Convert.ToString(reader.GetValue(violationTypeIndex));
                                //8
                                int violationNameIndex = reader.GetOrdinal("ViolationName");
                                string violationName = Convert.ToString(reader.GetValue(violationNameIndex));
                                //9
                                int remarksIndex = reader.GetOrdinal("remarks");
                                string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                                genRep[0] = i.ToString();
                                genRep[1] = recordNo.ToString();
                                genRep[2] = studNo.ToString();
                                genRep[3] = fullName;
                                genRep[4] = residence;
                                genRep[5] = date;
                                genRep[6] = violationCode.ToString();
                                genRep[7] = violationType;
                                genRep[8] = violationName;
                                genRep[9] = remarks;
                                ListViewItem lvGen = new ListViewItem(genRep);
                                lvGenReport.Items.Add(lvGen);
                                i++;
                            }
                        }
                    }
                }
            }
            else if (period == "ALL" && residence == "ALL")
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rd.RecordNo as RecordNo, rd.StudentNo as StudentNo, rd.ViolationCode as ViolationCode, rd.DateCommitted as DateCommitted, si.LastName + ', ' + si.GivenName + ' ' + si.MiddleName AS 'Full Name', si.ResidenceStatus as ResidenceStatus, rd.Period as Period, rd.SY as SY, rd.Remarks as Remarks, vd.ViolationType as ViolationType, vd.ViolationName FROM RecordDetails AS rd INNER JOIN StudentInfo AS si ON rd.StudentNo = si.StudentNo INNER JOIN ViolationDetails AS vd ON rd.ViolationCode = vd.ViolationCode WHERE (vd.ViolationType = '" + violationType + "') AND (year(DateCommitted) between " + syFrom + " and " + syTo + ")", conn))
                {
                    lvGenReport.Items.Clear();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 1;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //1
                                int recordNo = Convert.ToInt32(reader.GetValue(0));
                                //2
                                int studNoIndex = reader.GetOrdinal("StudentNo");
                                int studNo = Convert.ToInt32(reader.GetValue(studNoIndex));
                                //3
                                int fullNameIndex = reader.GetOrdinal("Full Name");
                                string fullName = Convert.ToString(reader.GetValue(fullNameIndex));
                                //4
                                int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                string residence = Convert.ToString(reader.GetValue(residenceIndex));
                                //5
                                int dateIndex = reader.GetOrdinal("dateCommitted");
                                DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                                string date = myDate.ToString("MM/dd/yyyy");
                                //6
                                int violationCodeIndex = reader.GetOrdinal("ViolationCode");
                                int violationCode = Convert.ToInt32(reader.GetValue(violationCodeIndex));
                                //7
                                int violationTypeIndex = reader.GetOrdinal("ViolationType");
                                string violationType = Convert.ToString(reader.GetValue(violationTypeIndex));
                                //8
                                int violationNameIndex = reader.GetOrdinal("ViolationName");
                                string violationName = Convert.ToString(reader.GetValue(violationNameIndex));
                                //9
                                int remarksIndex = reader.GetOrdinal("remarks");
                                string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                                genRep[0] = i.ToString();
                                genRep[1] = recordNo.ToString();
                                genRep[2] = studNo.ToString();
                                genRep[3] = fullName;
                                genRep[4] = residence;
                                genRep[5] = date;
                                genRep[6] = violationCode.ToString();
                                genRep[7] = violationType;
                                genRep[8] = violationName;
                                genRep[9] = remarks;
                                ListViewItem lvGen = new ListViewItem(genRep);
                                lvGenReport.Items.Add(lvGen);
                                i++;
                            }
                        }
                    }
                }
            }
            else if (violationType == "ALL" && residence == "ALL")
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rd.RecordNo as RecordNo, rd.StudentNo as StudentNo, rd.ViolationCode as ViolationCode, rd.DateCommitted as DateCommitted, si.LastName + ', ' + si.GivenName + ' ' + si.MiddleName AS 'Full Name', si.ResidenceStatus as ResidenceStatus, rd.Period as Period, rd.SY as SY, rd.Remarks as Remarks, vd.ViolationType as ViolationType, vd.ViolationName FROM RecordDetails AS rd INNER JOIN StudentInfo AS si ON rd.StudentNo = si.StudentNo INNER JOIN ViolationDetails AS vd ON rd.ViolationCode = vd.ViolationCode WHERE (rd.Period = '" + period + "') AND (year(DateCommitted) between " + syFrom + " and " + syTo + ")", conn))
                {
                    lvGenReport.Items.Clear();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 1;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //1
                                int recordNo = Convert.ToInt32(reader.GetValue(0));
                                //2
                                int studNoIndex = reader.GetOrdinal("StudentNo");
                                int studNo = Convert.ToInt32(reader.GetValue(studNoIndex));
                                //3
                                int fullNameIndex = reader.GetOrdinal("Full Name");
                                string fullName = Convert.ToString(reader.GetValue(fullNameIndex));
                                //4
                                int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                string residence = Convert.ToString(reader.GetValue(residenceIndex));
                                //5
                                int dateIndex = reader.GetOrdinal("dateCommitted");
                                DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                                string date = myDate.ToString("MM/dd/yyyy");
                                //6
                                int violationCodeIndex = reader.GetOrdinal("ViolationCode");
                                int violationCode = Convert.ToInt32(reader.GetValue(violationCodeIndex));
                                //7
                                int violationTypeIndex = reader.GetOrdinal("ViolationType");
                                string violationType = Convert.ToString(reader.GetValue(violationTypeIndex));
                                //8
                                int violationNameIndex = reader.GetOrdinal("ViolationName");
                                string violationName = Convert.ToString(reader.GetValue(violationNameIndex));
                                //9
                                int remarksIndex = reader.GetOrdinal("remarks");
                                string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                                genRep[0] = i.ToString();
                                genRep[1] = recordNo.ToString();
                                genRep[2] = studNo.ToString();
                                genRep[3] = fullName;
                                genRep[4] = residence;
                                genRep[5] = date;
                                genRep[6] = violationCode.ToString();
                                genRep[7] = violationType;
                                genRep[8] = violationName;
                                genRep[9] = remarks;
                                ListViewItem lvGen = new ListViewItem(genRep);
                                lvGenReport.Items.Add(lvGen);
                                i++;
                            }
                        }
                    }
                }
            }
            else if (violationType == "ALL")
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rd.RecordNo as RecordNo, rd.StudentNo as StudentNo, rd.ViolationCode as ViolationCode, rd.DateCommitted as DateCommitted, si.LastName + ', ' + si.GivenName + ' ' + si.MiddleName AS 'Full Name', si.ResidenceStatus as ResidenceStatus, rd.Period as Period, rd.SY as SY, rd.Remarks as Remarks, vd.ViolationType as ViolationType, vd.ViolationName FROM RecordDetails AS rd INNER JOIN StudentInfo AS si ON rd.StudentNo = si.StudentNo INNER JOIN ViolationDetails AS vd ON rd.ViolationCode = vd.ViolationCode WHERE (rd.Period = '" + period + "') AND (year(DateCommitted) between " + syFrom + " and " + syTo + ") AND (si.ResidenceStatus = '" + residence + "')", conn))
                {
                    lvGenReport.Items.Clear();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 1;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //1
                                int recordNo = Convert.ToInt32(reader.GetValue(0));
                                //2
                                int studNoIndex = reader.GetOrdinal("StudentNo");
                                int studNo = Convert.ToInt32(reader.GetValue(studNoIndex));
                                //3
                                int fullNameIndex = reader.GetOrdinal("Full Name");
                                string fullName = Convert.ToString(reader.GetValue(fullNameIndex));
                                //4
                                int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                string residence = Convert.ToString(reader.GetValue(residenceIndex));
                                //5
                                int dateIndex = reader.GetOrdinal("dateCommitted");
                                DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                                string date = myDate.ToString("MM/dd/yyyy");
                                //6
                                int violationCodeIndex = reader.GetOrdinal("ViolationCode");
                                int violationCode = Convert.ToInt32(reader.GetValue(violationCodeIndex));
                                //7
                                int violationTypeIndex = reader.GetOrdinal("ViolationType");
                                string violationType = Convert.ToString(reader.GetValue(violationTypeIndex));
                                //8
                                int violationNameIndex = reader.GetOrdinal("ViolationName");
                                string violationName = Convert.ToString(reader.GetValue(violationNameIndex));
                                //9
                                int remarksIndex = reader.GetOrdinal("remarks");
                                string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                                genRep[0] = i.ToString();
                                genRep[1] = recordNo.ToString();
                                genRep[2] = studNo.ToString();
                                genRep[3] = fullName;
                                genRep[4] = residence;
                                genRep[5] = date;
                                genRep[6] = violationCode.ToString();
                                genRep[7] = violationType;
                                genRep[8] = violationName;
                                genRep[9] = remarks;
                                ListViewItem lvGen = new ListViewItem(genRep);
                                lvGenReport.Items.Add(lvGen);
                                i++;
                            }
                        }
                    }
                }
            }
            else if (period == "ALL")
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rd.RecordNo as RecordNo, rd.StudentNo as StudentNo, rd.ViolationCode as ViolationCode, rd.DateCommitted as DateCommitted, si.LastName + ', ' + si.GivenName + ' ' + si.MiddleName AS 'Full Name', si.ResidenceStatus as ResidenceStatus, rd.Period as Period, rd.SY as SY, rd.Remarks as Remarks, vd.ViolationType as ViolationType, vd.ViolationName FROM RecordDetails AS rd INNER JOIN StudentInfo AS si ON rd.StudentNo = si.StudentNo INNER JOIN ViolationDetails AS vd ON rd.ViolationCode = vd.ViolationCode WHERE (vd.ViolationType = '" + violationType + "') AND (year(DateCommitted) between " + syFrom + " and " + syTo + ") AND (si.ResidenceStatus = '" + residence + "')", conn))
                {
                    lvGenReport.Items.Clear();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 1;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //1
                                int recordNo = Convert.ToInt32(reader.GetValue(0));
                                //2
                                int studNoIndex = reader.GetOrdinal("StudentNo");
                                int studNo = Convert.ToInt32(reader.GetValue(studNoIndex));
                                //3
                                int fullNameIndex = reader.GetOrdinal("Full Name");
                                string fullName = Convert.ToString(reader.GetValue(fullNameIndex));
                                //4
                                int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                string residence = Convert.ToString(reader.GetValue(residenceIndex));
                                //5
                                int dateIndex = reader.GetOrdinal("dateCommitted");
                                DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                                string date = myDate.ToString("MM/dd/yyyy");
                                //6
                                int violationCodeIndex = reader.GetOrdinal("ViolationCode");
                                int violationCode = Convert.ToInt32(reader.GetValue(violationCodeIndex));
                                //7
                                int violationTypeIndex = reader.GetOrdinal("ViolationType");
                                string violationType = Convert.ToString(reader.GetValue(violationTypeIndex));
                                //8
                                int violationNameIndex = reader.GetOrdinal("ViolationName");
                                string violationName = Convert.ToString(reader.GetValue(violationNameIndex));
                                //9
                                int remarksIndex = reader.GetOrdinal("remarks");
                                string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                                genRep[0] = i.ToString();
                                genRep[1] = recordNo.ToString();
                                genRep[2] = studNo.ToString();
                                genRep[3] = fullName;
                                genRep[4] = residence;
                                genRep[5] = date;
                                genRep[6] = violationCode.ToString();
                                genRep[7] = violationType;
                                genRep[8] = violationName;
                                genRep[9] = remarks;
                                ListViewItem lvGen = new ListViewItem(genRep);
                                lvGenReport.Items.Add(lvGen);
                                i++;
                            }
                        }
                    }
                }
            }
            else if (residence == "ALL")
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rd.RecordNo as RecordNo, rd.StudentNo as StudentNo, rd.ViolationCode as ViolationCode, rd.DateCommitted as DateCommitted, si.LastName + ', ' + si.GivenName + ' ' + si.MiddleName AS 'Full Name', si.ResidenceStatus as ResidenceStatus, rd.Period as Period, rd.SY as SY, rd.Remarks as Remarks, vd.ViolationType as ViolationType, vd.ViolationName FROM RecordDetails AS rd INNER JOIN StudentInfo AS si ON rd.StudentNo = si.StudentNo INNER JOIN ViolationDetails AS vd ON rd.ViolationCode = vd.ViolationCode WHERE (vd.ViolationType = '" + violationType + "') AND (rd.Period = '" + period + "') AND (year(DateCommitted) between " + syFrom + " and " + syTo + ")", conn))
                {
                    lvGenReport.Items.Clear();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 1;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //1
                                int recordNo = Convert.ToInt32(reader.GetValue(0));
                                //2
                                int studNoIndex = reader.GetOrdinal("StudentNo");
                                int studNo = Convert.ToInt32(reader.GetValue(studNoIndex));
                                //3
                                int fullNameIndex = reader.GetOrdinal("Full Name");
                                string fullName = Convert.ToString(reader.GetValue(fullNameIndex));
                                //4
                                int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                string residence = Convert.ToString(reader.GetValue(residenceIndex));
                                //5
                                int dateIndex = reader.GetOrdinal("dateCommitted");
                                DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                                string date = myDate.ToString("MM/dd/yyyy");
                                //6
                                int violationCodeIndex = reader.GetOrdinal("ViolationCode");
                                int violationCode = Convert.ToInt32(reader.GetValue(violationCodeIndex));
                                //7
                                int violationTypeIndex = reader.GetOrdinal("ViolationType");
                                string violationType = Convert.ToString(reader.GetValue(violationTypeIndex));
                                //8
                                int violationNameIndex = reader.GetOrdinal("ViolationName");
                                string violationName = Convert.ToString(reader.GetValue(violationNameIndex));
                                //9
                                int remarksIndex = reader.GetOrdinal("remarks");
                                string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                                genRep[0] = i.ToString();
                                genRep[1] = recordNo.ToString();
                                genRep[2] = studNo.ToString();
                                genRep[3] = fullName;
                                genRep[4] = residence;
                                genRep[5] = date;
                                genRep[6] = violationCode.ToString();
                                genRep[7] = violationType;
                                genRep[8] = violationName;
                                genRep[9] = remarks;
                                ListViewItem lvGen = new ListViewItem(genRep);
                                lvGenReport.Items.Add(lvGen);
                                i++;
                            }
                        }
                    }
                }
            }
            else
            {
                using (SqlCommand cmd = new SqlCommand("SELECT rd.RecordNo as RecordNo, rd.StudentNo as StudentNo, rd.ViolationCode as ViolationCode, rd.DateCommitted as DateCommitted, si.LastName + ', ' + si.GivenName + ' ' + si.MiddleName AS 'Full Name', si.ResidenceStatus as ResidenceStatus, rd.Period as Period, rd.SY as SY, rd.Remarks as Remarks, vd.ViolationType as ViolationType, vd.ViolationName FROM RecordDetails AS rd INNER JOIN StudentInfo AS si ON rd.StudentNo = si.StudentNo INNER JOIN ViolationDetails AS vd ON rd.ViolationCode = vd.ViolationCode WHERE (vd.ViolationType = '" + violationType + "') AND (rd.Period = '" + period + "') AND (year(DateCommitted) between " + syFrom + " and " + syTo + ") AND (si.ResidenceStatus = '" + residence + "')", conn))
                {
                    lvGenReport.Items.Clear();
                    using (DbDataReader reader = cmd.ExecuteReader())
                    {
                        int i = 1;
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                //1
                                int recordNo = Convert.ToInt32(reader.GetValue(0));
                                //2
                                int studNoIndex = reader.GetOrdinal("StudentNo");
                                int studNo = Convert.ToInt32(reader.GetValue(studNoIndex));
                                //3
                                int fullNameIndex = reader.GetOrdinal("Full Name");
                                string fullName = Convert.ToString(reader.GetValue(fullNameIndex));
                                //4
                                int residenceIndex = reader.GetOrdinal("ResidenceStatus");
                                string residence = Convert.ToString(reader.GetValue(residenceIndex));
                                //5
                                int dateIndex = reader.GetOrdinal("dateCommitted");
                                DateTime myDate = Convert.ToDateTime(reader.GetValue(dateIndex));
                                string date = myDate.ToString("MM/dd/yyyy");
                                //6
                                int violationCodeIndex = reader.GetOrdinal("ViolationCode");
                                int violationCode = Convert.ToInt32(reader.GetValue(violationCodeIndex));
                                //7
                                int violationTypeIndex = reader.GetOrdinal("ViolationType");
                                string violationType = Convert.ToString(reader.GetValue(violationTypeIndex));
                                //8
                                int violationNameIndex = reader.GetOrdinal("ViolationName");
                                string violationName = Convert.ToString(reader.GetValue(violationNameIndex));
                                //9
                                int remarksIndex = reader.GetOrdinal("remarks");
                                string remarks = Convert.ToString(reader.GetValue(remarksIndex));
                                genRep[0] = i.ToString();
                                genRep[1] = recordNo.ToString();
                                genRep[2] = studNo.ToString();
                                genRep[3] = fullName;
                                genRep[4] = residence;
                                genRep[5] = date;
                                genRep[6] = violationCode.ToString();
                                genRep[7] = violationType;
                                genRep[8] = violationName;
                                genRep[9] = remarks;
                                ListViewItem lvGen = new ListViewItem(genRep);
                                lvGenReport.Items.Add(lvGen);
                                i++;
                            }
                        }
                    }
                }
            }
            conn.Close();
        }
    }
}

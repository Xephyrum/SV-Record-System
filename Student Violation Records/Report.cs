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

namespace Student_Violation_Records
{
    public partial class Report : MaterialForm
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            lvReport.Columns.Add("Record No.", 150);
            lvReport.Columns.Add("Date", 120);
            lvReport.Columns.Add("Violation Type", 130);
            lvReport.Columns.Add("Violation Name", 130);
            lvReport.Columns.Add("Last Chance", 120);
            lvReport.Columns.Add("Remarks", 150);
        }
    }
}

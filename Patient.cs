using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sjukhus
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        private void btnVisaLäkartid_Click(object sender, EventArgs e)
        {
            VisaBokning visaBokning = new VisaBokning();
            visaBokning.ShowDialog();
        }

        private void btnBokaTid_Click(object sender, EventArgs e)
        {
            Boka boka = new Boka();
            boka.ShowDialog();
        }
    }
}

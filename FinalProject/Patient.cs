using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalProject
{
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hrich\OneDrive\Documents\BloodBank_DB.mdf;Integrated Security=True;Connect Timeout=30");

        private void Reset()
        {
            PNameTB.Text = "";
            PAgeTB.Text = "";
            PPhoneTB.Text = "";
            PAddressTB.Text = "";
            PGenderTB.SelectedIndex = -1;
            PBldGrpTB.SelectedIndex = -1;
        }
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (PNameTB.Text == "" || PPhoneTB.Text == "" || PAgeTB.Text == "" || PAddressTB.Text == "" || PGenderTB.SelectedIndex == -1 || PBldGrpTB.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "Insert into PatientTbl values('" + PNameTB.Text + "'," + PAgeTB.Text + ",'" + PGenderTB.SelectedItem.ToString() + "','" + PPhoneTB.Text + "','" + PAddressTB.Text + "','" + PBldGrpTB.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Saved");
                    Con.Close();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Patient_Load(object sender, EventArgs e)
        {

        }
    }
}
       
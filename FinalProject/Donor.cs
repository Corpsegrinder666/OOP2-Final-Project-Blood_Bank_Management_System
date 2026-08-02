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
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }

        private void Donor_Load(object sender, EventArgs e)
        {

        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hrich\OneDrive\Documents\BloodBank_DB.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void Reset()
        {
            DNameTb.Text = "";
            DAgeTb.Text = "";
            DPhoneTb.Text = "";
            DAddressTb.Text = "";
            DGenderTb.SelectedIndex = -1;
            DBldGrpTb.SelectedIndex = -1;
        }
       

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if(DNameTb.Text=="" || DPhoneTb.Text=="" || DAgeTb.Text == "" || DAddressTb.Text == "" || DGenderTb.SelectedIndex == -1 || DBldGrpTb.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string query = "Insert into DonorTbl values('" + DNameTb.Text + "'," + DAgeTb.Text + ",'" + DGenderTb.SelectedItem.ToString() + "','" + DPhoneTb.Text + "','"+DAddressTb.Text+"','" + DBldGrpTb.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Saved");
                    Con.Close();
                    Reset();

                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BanckProject
{
    public partial class Form1 : Form
    {
        int count = 3;

        public Form1()
        {
            InitializeComponent();

        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
            btnLoggin.Enabled = false;


        }

        private void btnLoggin_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            this.Enabled = false;
            label5.Visible = true;
            timer2.Enabled = true;      
        }
 
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblMess.Text =  "";
            timer1.Stop();
         }
 
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text == "")
            {
                e.Cancel = true;

                txtPassword.Focus();

                errorProvider1.SetError(txtPassword, "Password Is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");

            }
        }
       
        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 1;

            if (progressBar1.Value >= 100)
            {
                if (txtUserName.Text != "Admin1" || txtPassword.Text != "test")
                {
                    this.Enabled = true;

                    count--;

                    if (count == 0)
                    {
                        progressBar1.Value = 0;
                        progressBar1.Visible = false;
                        label5.Visible = false;
                        timer2.Enabled = false;
 
                        MessageBox.Show("Your Account Is Blocked...,Contact The Banck For More", "Errror", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        Application.Exit();
                    }
                    else
                    {
                        lblMess.Text = "Wrong Account Number/Password, Try Again, You Have " + count.ToString() + " More Tries Left";
                        timer1.Enabled = true;
                        progressBar1.Value = 0;
                        progressBar1.Visible = false;
                        label5.Visible = false;
                        timer2.Enabled = false;
                        Form1_Load(sender, e);
                    }
                }
                else
                {
                    this.Enabled = true;

                    Form frm = new Main();
                    count = 3;

                    this.Hide();
                    frm.Show();

                    timer2.Enabled = false;
                    progressBar1.Value = progressBar1.Value - 1;

                    if (checkBox1.Checked == false)
                    {
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        progressBar1.Value = 0;


                        progressBar1.Visible = false;
                        label5.Visible = false;
                    }
                    else
                    {

                        progressBar1.Value = 0;
 

                        progressBar1.Visible = false;
                        label5.Visible = false;
                    }
                }
            }
        }
  
    

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
 
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                btnLoggin.Enabled = true;

            }
        }

        private void txtAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            if (txtUserName.Text == ""  )
            {
                e.Cancel = true;

                txtUserName.Focus();

                errorProvider1.SetError(txtUserName, "User Name Is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");

            }
        }

        private void txtAccountNumber_MouseDown(object sender, MouseEventArgs e)
        {
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                btnLoggin.Enabled = true;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
  
        private void iconButton3_Click(object sender, EventArgs e)
        {
 
            if (txtPassword.Text.Contains("*"))
            {
                txtPassword.Text = "test";
                return;
            }
            txtPassword.Text = "****";
       
        }
    }
}

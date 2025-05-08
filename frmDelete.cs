using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanckProject
{
    public partial class frmDelete : Form
    {
        public frmDelete()
        {
            InitializeComponent();
        }



        private void iconButton1_Click(object sender, EventArgs e)
        {

            string enteredAccount = txtSerch.Text;

            if (comboBox1.SelectedIndex == 0)
            {
                foreach (Client client in ClientData.Clients)
                {
                    if (client.AccountNumber.ToLower() == txtSerch.Text.ToLower())
                    {
                        Form frmD = new detaillsDelete(client);
                        frmD.ShowDialog();
                        return;

                    }

                }

                MessageBox.Show("Client With Account Number " + txtSerch.Text + " Not Found in The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                foreach (Client client in ClientData.Clients)
                {
                    if (client.FirstName.ToLower() == txtSerch.Text.ToLower())
                    {
                        Form frmD = new detaillsDelete(client);
                        frmD.ShowDialog();
                        return;
                    }

                }
                MessageBox.Show("Client With Name " + txtSerch.Text + " Not Found in The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                foreach (Client client in ClientData.Clients)
                {
                    if (client.PinCode.ToLower() == txtSerch.Text.ToLower())
                    {
                        Form frmD = new detaillsDelete(client);
                        frmD.ShowDialog();
                        return;
                    }
                }


                MessageBox.Show("Client With Pin Code " + txtSerch.Text + " Not Found in The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmDelete_Load(object sender, EventArgs e)
        {

            iconButton1.Enabled = false;

            txtSerch.Enabled = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSerch.Enabled = true;
            txtSerch.Text = "Enter " + comboBox1.SelectedItem.ToString();
            iconButton1.Enabled = true;
        }

        private void txtSerch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSerch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSerch.Text = "";

        }
 
    }
}

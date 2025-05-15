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
    public partial class Transfare : Form
    {
        public Transfare()
        {
            InitializeComponent();
        }

        Client SenterInfo = null;
        Client ResiverInfo = null;
        private int _SenderBalance = 0;
        private int _ResiverBalance = 0;
        private int _Amount = 0;
        private void Transfare_Load(object sender, EventArgs e)
        {
            txtSerch.Enabled = true;
            txtSerch2.Enabled = true;

            comboBox1.SelectedIndex = 0;
            txtSerch.Text = comboBox1.Text;       
            
            comboBox2.SelectedIndex = 0;
            txtSerch2.Text = comboBox2.Text;
        }

        private void txtSerch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSerch.Text = "";
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
     
            string enteredAccount = txtSerch.Text;

            foreach (Client client in ClientData.Clients)
            {
                if (client.AccountNumber.ToLower() == txtSerch.Text.ToLower())
                {
                    txtSerch.Enabled = false;
                    iconButton1.Enabled = false;

                    tcInfo.Visible = true;
                    comboBox2.Visible = true;
                    lblTO.Visible = true;
                    txtSerch2.Visible = true;
                    iconButton2.Visible = true;    
                   // btnDeposit.Visible = true;
                   // label6.Visible = true;

                    lblAccountNumber.Text = client.AccountNumber;
                    lblBalance.Text = client.Balance + " $";
                    lblFName.Text = client.FirstName;
                    lblLName.Text = client.LastName;
                    SenterInfo = client;

                    return;
                }
            }

            MessageBox.Show("Client With Account Number " + txtSerch.Text + " Not Found in The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "" || !int.TryParse(comboBox3.Text, out _))
            {
                _Amount = 0;
            }
            else
            {
                _Amount = int.Parse(comboBox3.Text);
            }
            _SenderBalance = int.Parse(SenterInfo.Balance);
            _ResiverBalance = int.Parse(ResiverInfo.Balance);

            if (_Amount > _SenderBalance)
            {
                MessageBox.Show("Amount You Entered " + _Amount + " Excede Your Balance, Your Balance Is " + _SenderBalance, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (_Amount <= 0)
            {
                MessageBox.Show("Can't Transfare Amount " + _Amount + " Enter a Positive Integer ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("Are You Sure You Want To Performe This Operation", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SenterInfo.Balance = (_SenderBalance - _Amount).ToString();
                ResiverInfo.Balance = (_ResiverBalance + _Amount).ToString();
                lblBalance.Text = SenterInfo.Balance.ToString() + " $";
                lblRBalance.Text = ResiverInfo.Balance.ToString() + " $";
                MessageBox.Show("Amount Transfared Successfuly (: New Balance IS " + SenterInfo.Balance + " $", "Transfared Succesfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSerch2_MouseEnter(object sender, EventArgs e)
        {
        }

        private void txtSerch2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSerch2_MouseClick(object sender, MouseEventArgs e)
        {
            txtSerch2.Text = "";

        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
  
            string enteredAccount = txtSerch2.Text;

            foreach (Client client in ClientData.Clients)
            {
                if (client.AccountNumber.ToLower() == txtSerch2.Text.ToLower())
                {
                    if (enteredAccount == SenterInfo.AccountNumber.ToLower())
                    {
                        MessageBox.Show("Sender Can't Be a Resvier At The Same Time Enter anothe Account Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                        return;
                    }
                    else
                    {               

                        txtSerch2.Enabled = false;
                        iconButton2.Enabled = false;

                        btnDeposit.Visible = true;
                        label6.Visible = true;
                        comboBox3.Visible = true;



                        lblRAccountNumber.Text = client.AccountNumber;
                        lblRBalance.Text = client.Balance + " $";
                        lblRFName.Text = client.FirstName;
                        lblRLName.Text = client.LastName;
                        ResiverInfo = client;

                        return;
                    }
                }
            }

            MessageBox.Show("Client With Account Number " + txtSerch.Text + " Not Found in The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;           
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

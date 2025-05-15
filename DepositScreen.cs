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
    public partial class DepositScreen : Form
    {
        public DepositScreen()
        {
            InitializeComponent();
        }

        private int _Balance = 0;
        private int _Amount = 0;
        Client PC = null;
        private void DepositScreen_Load(object sender, EventArgs e)
        {
            iconButton1.Enabled = false;

            txtSerch.Enabled = false;
        }

        private void txtSerch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSerch.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSerch.Enabled = true;
            txtSerch.Text = "Enter " + comboBox1.SelectedItem.ToString();
            iconButton1.Enabled = true;
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == ""|| !int.TryParse(comboBox2.Text, out _))
            {
                _Amount = 0;
            }
            else
            {
                _Amount = int.Parse(comboBox2.Text);
            }
            _Balance = int.Parse(PC.Balance);

            if (_Amount <= 0)
            {
                MessageBox.Show("Can't Deposit Amount " + _Amount + " Enter a Positive Integer ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult result = MessageBox.Show("Are You Sure You Want To Performe This Operation", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PC.Balance = (_Balance + _Amount).ToString();
                lblBalance.Text = PC.Balance.ToString() + " $";
                MessageBox.Show("Amount Deposit Successfuly (: New Balance IS " + PC.Balance + " $", "Deposit Succesfuly", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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
                        panel2.Visible = true;
                        comboBox2.Visible = true;
                        btnDeposit.Visible = true;
                        label6.Visible = true;

                        lblAccountNumber.Text = client.AccountNumber;
                        string Balance = "";
                        Balance = client.Balance +" $";

                        lblBalance.Text = Balance;
                        lblFName.Text = client.FirstName;
                        lblLName.Text = client.LastName;
                        PC = client;

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
                        panel2.Visible = true;
                        comboBox2.Visible = true;
                        btnDeposit.Visible = true;
                        label6.Visible = true;

                        lblAccountNumber.Text = client.AccountNumber;
                        string Balance = "";
                        Balance = client.Balance + " $";

                        lblBalance.Text = Balance;
                        lblFName.Text = client.FirstName;
                        lblLName.Text = client.LastName;
                        PC = client;

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
                        panel2.Visible = true;
                        comboBox2.Visible = true;
                        btnDeposit.Visible = true;
                        label6.Visible = true;

                        lblAccountNumber.Text = client.AccountNumber;
                        string Balance = "";
                        Balance = client.Balance + " $";

                        lblBalance.Text = Balance;
                        lblFName.Text = client.FirstName;
                        lblLName.Text = client.LastName;
                        PC = client;
                        return;
                    }
                }


                MessageBox.Show("Client With Pin Code " + txtSerch.Text + " Not Found in The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtSerch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

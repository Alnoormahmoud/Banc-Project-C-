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
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
        }

        Form4 Frm = new Form4();
         Main Frm1 = new Main();


        private bool DateIsFull()
        {
            if (circularProgressBar1.Value != 100)
            {

                return false;
            }
            else
            {
                btnAdd.Enabled = true;
                return true;
            }
        }

        private void Reset()
        {
            txtAdderes.Text = "";
            txtAdderes.Enabled = true;

            txtAccNumber.Text = "";
            txtAccNumber.Enabled = true;

            txtBalance.Text = "";
            txtBalance.Enabled = true;

            txtEmail.Text = "";
            txtEmail.Enabled = true;

            txtFName.Text = "";
            txtFName.Enabled = true;

            txtLName.Text = "";
            txtLName.Enabled = true;

            txtPhoneNum.Text = "";
            txtPhoneNum.Enabled = true;

            txtPinCode.Text = "";
            txtPinCode.Enabled = true;

            radioButton1.Checked = false;
            radioButton1.Enabled = true;


            radioButton2.Checked = false;
            radioButton2.Enabled = true;


            pbPhoto.Image = Properties.Resources.test;
            btnSelectPhoto.Enabled = true;

            tt.Enabled = true;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Assuming you have a Client class that holds the client details
            foreach (Client c in ClientData.Clients)
            {
                if(txtAccNumber.Text == c.AccountNumber )
                {
                    MessageBox.Show("Account Number "+txtAccNumber.Text +" Already Exist, Enter Another One", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // return;
                    txtAccNumber.Enabled = true ;
                    txtAccNumber.Text = "";
                    txtAccNumber.Focus();
                    circularProgressBar1.Value -= 10;
                    return;

                }
            }
            Client newClient = new Client()
            {
                AccountNumber = txtAccNumber.Text,
                FirstName = txtFName.Text,
                LastName = txtLName.Text,
                Email = txtEmail.Text,
                PinCode = txtPinCode.Text,
                PhoneNumber = txtPhoneNum.Text,
                DateOfBirth = dateTimePicker2.Value.ToString(),
                Adderes = txtAdderes.Text,
                Gender = groupBox1.Text,
                Balance = txtBalance.Text,

            };

            // Add to the static list (if using ClientData as a static holder)
            ClientData.Clients.Add(newClient);

            // Call the UpdateClientList method to refresh the data in Form4

            Frm.UpdateClientList();
            btnAdd.Enabled = false;
            MessageBox.Show("Client Added Successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Reset();
        }

        private void txtFName_Validating(object sender, CancelEventArgs e)
        {
            if (txtFName.Text == "")
            {
                e.Cancel = true;

                txtFName.Focus();

                errorProvider1.SetError(txtFName, "First Name Is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtFName, "");
                circularProgressBar1.Value += 10;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";
                txtFName.Enabled = false;

            }
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            DateIsFull();
        }

        private void txtLName_Validating(object sender, CancelEventArgs e)
        {
            if (txtLName.Text == "")
            {
                e.Cancel = true;

                txtLName.Focus();

                errorProvider1.SetError(txtLName, "Last NameIs Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtLName, "");
                circularProgressBar1.Value += 10;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";
                txtLName.Enabled = false;

            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text != "" && txtEmail.Text.Contains(".com"))
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
                circularProgressBar1.Value += 10;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";
                txtEmail.Enabled = false;



            }
            else
            {
                e.Cancel = true;

                txtEmail.Focus();

                errorProvider1.SetError(txtEmail, "Not Valid Email");
            }
        }

        private void txtPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (txtPinCode.Text == "" || !int.TryParse(txtPinCode.Text, out _))
            {
                e.Cancel = true;

                txtPinCode.Focus();

                errorProvider1.SetError(txtPinCode, "Pin Code Is Not Valid");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPinCode, "");
                circularProgressBar1.Value += 10;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";
                txtPinCode.Enabled = false;

            }
        }

        private void txtPhoneNum_Validating(object sender, CancelEventArgs e)
        {
            if (txtPhoneNum.Text == "" || !int.TryParse(txtPhoneNum.Text, out _))
            {
                e.Cancel = true;

                txtPhoneNum.Focus();

                errorProvider1.SetError(txtPhoneNum, "Not Valid Phone Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPhoneNum, "");
                circularProgressBar1.Value += 10;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";
                txtPhoneNum.Enabled = false;

            }
        }

        private void txtAccNumber_Validating(object sender, CancelEventArgs e)
        {
            if (txtAccNumber.Text == "" || !int.TryParse(txtAccNumber.Text, out _))
            {
                e.Cancel = true;

                txtAccNumber.Focus();

                errorProvider1.SetError(txtAccNumber, "Not Valid Account Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAccNumber, "");
                circularProgressBar1.Value += 10;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";
                txtAccNumber.Enabled = false;

            }
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            circularProgressBar1.Value = 0;
            lblValue.Text = circularProgressBar1.Value.ToString() + "%";

        }

        private void txtAccNumber_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            DateIsFull();

        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {
            DateIsFull();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            DateIsFull();
        }

        private void txtPinCode_TextChanged(object sender, EventArgs e)
        {
            DateIsFull();
        }

        private void txtPhoneNum_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            DateIsFull();
        }
        private void btnSelectPhoto_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select an Image";
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbPhoto.Image = Image.FromFile(openFileDialog.FileName);
                circularProgressBar1.Value += 10;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";
                btnSelectPhoto.Enabled = false;
                DateIsFull();
            }
        }

        private void txtAdderes_TextChanged(object sender, EventArgs e)
        {
            DateIsFull();
        }

        private void txtAdderes_Validating(object sender, CancelEventArgs e)
        {
            if (txtAdderes.Text == "")
            {
                e.Cancel = true;

                txtAdderes.Focus();

                errorProvider1.SetError(txtAdderes, "Adderes Is Empty");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtAdderes, "");
                circularProgressBar1.Value += 10;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";
                txtAdderes.Enabled = false;

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                circularProgressBar1.Value += 10;
            }
            groupBox1.Text = radioButton1.Text.ToString();
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            lblValue.Text = circularProgressBar1.Value.ToString() + "%";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                circularProgressBar1.Value += 10;
            }
            groupBox1.Text = radioButton1.Text.ToString();
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            lblValue.Text = circularProgressBar1.Value.ToString() + "%";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // dateTimePicker2.Enabled = false;
        }

        private void txtBalance_TextChanged(object sender, EventArgs e)
        {
            DateIsFull();
        }

        private void txtBalance_Validating_1(object sender, CancelEventArgs e)
        {

            if (txtBalance.Text == "" || !int.TryParse(txtBalance.Text, out _))
            {
                e.Cancel = true;

                txtBalance.Focus();

                errorProvider1.SetError(txtBalance, "Not Valid integer Balance");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtBalance, "");
                circularProgressBar1.Value += 10;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";
                txtBalance.Enabled = false;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tt_Tick(object sender, EventArgs e)
        {
            {
                circularProgressBar1.Value = circularProgressBar1.Value - 1;
                lblValue.Text = circularProgressBar1.Value.ToString() + "%";


                if (circularProgressBar1.Value == 0)
                {
                    circularProgressBar1.Value = 0;
                    tt.Enabled = false;
                    btnAdd.Enabled = false;
                }
            }

        }
    }
}

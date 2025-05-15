using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BanckProject
{
    public partial class UpdateDetails : Form
    {
        Client client;
        string FName = "";
        string LName = "";
        string AccN = "";
        string Adderess = "";
        string Phone = "";
        string Email = "";
        string PinCode = "";
        string Balance = "";
        public UpdateDetails(Client sc)
        {
            InitializeComponent();
            Adderess = sc.Adderes.ToString();
            AccN = sc.AccountNumber.ToString();
            FName = sc.FirstName.ToString();
            LName = sc.LastName.ToString();
            Balance = sc.Balance.ToString() + " $";
            PinCode = sc.PinCode.ToString();
            Email = sc.Email.ToString();
            Phone = sc.PhoneNumber.ToString();
            client = sc;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDetails_Load(object sender, EventArgs e)
        {

            txtAccountNumber.Text = AccN;
            txtFName.Text = FName;
            txtLName.Text = LName;
            txtPhone.Text = Phone;
            txtPin.Text = PinCode;
            txtADderes.Text = Adderess;
            txtBalance.Text = Balance;
            txtEmail.Text = Email;
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You Sure You Want To Update This Cient", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                client.PinCode = txtPin.Text;
                client.Email = txtEmail.Text;
                client.Adderes = txtADderes.Text;
                client.FirstName = txtFName.Text;
                client.LastName = txtLName.Text;
                client.PhoneNumber = txtPhone.Text;
                MessageBox.Show("Client Updated Successfuly", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }

    }
}

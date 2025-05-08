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
    public partial class detaillsDelete : Form
    {
        string FName = "";
        string LName = "";
        string AccN = "";
        string Adderess = "";
        string Phone = "";
        string Email = "";
        string PinCode = "";
        string Balance = "";
        public detaillsDelete(Client sc)
        {
            InitializeComponent();
            Adderess = sc.Adderes.ToString();
            AccN = sc.AccountNumber.ToString();
            FName = sc.FirstName.ToString();
            LName = sc.LastName.ToString();
            Balance = sc.Balance.ToString();
            PinCode = sc.PinCode.ToString();
            Email = sc.Email.ToString();
            Phone = sc.PhoneNumber.ToString();

        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
 

        private void detaillsDelete_Load(object sender, EventArgs e)
        {
            lblAccountNumber.Text = AccN;
            lblFName.Text = FName;
            lblLName.Text = LName;
            lblPhoneNum.Text = Phone;
            lblEmail.Text = Email;
            lblPinCode.Text = PinCode;
            lblBirth.Text = Balance;
            lblAdderess.Text = Adderess;
         }

        private void Delete()
        {
            foreach (Client c in ClientData.Clients)
            {
               if(c.AccountNumber == lblAccountNumber.Text)
                {
                    c.Balance = "";
                    c.FirstName  = "";
                    c.LastName  = "";
                    c.AccountNumber  = "";
                    c.Gender  = "";
                    c.DateOfBirth   = "";
                    c.PhoneNumber   = "";
                    c.PinCode   = "";
                    c.Email    = "";
                    c.Adderes     = "";
                    return;
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
          DialogResult result=  MessageBox.Show("Are You Sure You Want To Delete This Cient","Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Delete();
                MessageBox.Show("Client Deleted Successfully","Confirmed",MessageBoxButtons.OK, MessageBoxIcon.Information );
                this.Close();
            }
            else
            {

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class frmDetails : Form
    {
        string FName = "";
        string LName = "";
        string AccN = "";
        string Adderess = "";
        string Phone = "";
        string Email = "";
        string PinCode = "";
        string Balance = "";


        public frmDetails(Client sc)
        {
            InitializeComponent();
         Adderess= sc.Adderes .ToString();
         AccN= sc.AccountNumber .ToString();
         FName = sc.FirstName .ToString();
         LName = sc.LastName .ToString();
            Balance = sc.Balance.ToString() + " $";
         PinCode = sc.PinCode  .ToString();
         Email  = sc.Email  .ToString();
         Phone = sc.PhoneNumber  .ToString();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDetails_Load(object sender, EventArgs e)
        {
            lblAccountNumber.Text = AccN;
            lblFName .Text = FName ;
            lblLName  .Text = LName  ;
            lblPhoneNum  .Text = Phone ;
            lblEmail   .Text = Email ;
            lblPinCode   .Text = PinCode  ;
            lblBirth   .Text = Balance   ;
            lblAdderess  .Text = Adderess ;
        }
    }
}

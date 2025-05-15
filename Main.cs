using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanckProject
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;


        }

        private void CustomiseDesign()
        {

            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void ShowSubMenues(Panel SubMName)
        {
            if (SubMName.Visible == false)
            {
                SubMName.Visible = true;
            }
            else
                SubMName.Visible = false;
        }

        private Form activeForm = null;
        public void OpenChaildForm(Form ChaildForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = ChaildForm;
            ChaildForm.TopLevel = false;
            ChaildForm.FormBorderStyle = FormBorderStyle.None;
            ChaildForm.Dock = DockStyle.Fill;
            panelChaildForm.Controls.Add(ChaildForm);
            panelChaildForm.Tag = ChaildForm;
            ChaildForm.BringToFront();
            ChaildForm.Show();
        }
        public void SetOtherOp()
        {

            ibClientsList.BackColor = Color.Black;
            ibAddClient.BackColor = Color.Black;
            ibLogOut.BackColor = Color.Black;
            ibPro.BackColor = Color.Black;
            ibUpdate.BackColor = Color.Black;
            ibDelete.BackColor = Color.Black;
            ibBalances.BackColor = Color.Black;
            ibTransfare.BackColor = Color.Black;
            ibWithdrow.BackColor = Color.Black;
            ibDeposit.BackColor = Color.Black;

            ibAddClient.ForeColor = Color.LightSeaGreen;
            ibDelete.ForeColor = Color.LightSeaGreen;
            ibClientsList.ForeColor = Color.LightSeaGreen;
            ibUpdate.ForeColor = Color.LightSeaGreen;
            ibLogOut.ForeColor = Color.LightSeaGreen;
            ibPro.ForeColor = Color.LightSeaGreen;
            ibBalances.ForeColor = Color.LightSeaGreen;
            ibTransfare.ForeColor = Color.LightSeaGreen;
            ibWithdrow.ForeColor = Color.LightSeaGreen;
            ibDeposit.ForeColor = Color.LightSeaGreen;

            ibAddClient.IconColor = Color.LightSeaGreen;
            ibClientsList.IconColor = Color.LightSeaGreen;
            ibUpdate.IconColor = Color.LightSeaGreen;
            ibLogOut.IconColor = Color.LightSeaGreen;
            ibDelete.IconColor = Color.LightSeaGreen;
            ibPro.IconColor = Color.LightSeaGreen;
            ibBalances.IconColor = Color.LightSeaGreen;
            ibTransfare.IconColor = Color.LightSeaGreen;
            ibWithdrow.IconColor = Color.LightSeaGreen;
            ibDeposit.IconColor = Color.LightSeaGreen;

            ibAddClient.TextAlign = ContentAlignment.MiddleCenter;
            ibUpdate.TextAlign = ContentAlignment.MiddleCenter;
            ibDelete.TextAlign = ContentAlignment.MiddleCenter;
            ibLogOut.TextAlign = ContentAlignment.MiddleCenter;
            ibClientsList.TextAlign = ContentAlignment.MiddleCenter;
            ibPro.TextAlign = ContentAlignment.MiddleCenter;
            ibBalances.TextAlign = ContentAlignment.MiddleCenter;
            ibTransfare.TextAlign = ContentAlignment.MiddleCenter;
            ibWithdrow.TextAlign = ContentAlignment.MiddleCenter;
            ibDeposit.TextAlign = ContentAlignment.MiddleCenter;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Start();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            string AmorPM = DateTime.Now.ToString("tt");
            string Hour = DateTime.Now.ToString("hh");


            if (AmorPM == "AM")
            {
                lblGreeting.Text = "Good Morning : ";
            }
            else
            {
                lblGreeting.Text = "Good Evening : ";
            }

        }

        private void ibUsers_Click_1(object sender, EventArgs e)
        {
            SetOtherOp();

            ibClientsList.ForeColor = Color.Fuchsia;
            ibClientsList.IconColor = Color.Fuchsia;
            ibClientsList.TextAlign = ContentAlignment.MiddleRight;
            ibClientsList.BackColor = panelChaildForm.BackColor;

            OpenChaildForm(new Form4());
        }

        private void ibCllients_Click_1(object sender, EventArgs e)
        {
            //Form3 frm3 = new Form3();
            SetOtherOp();
            ibAddClient.ForeColor = Color.DeepPink;
            ibAddClient.IconColor = Color.DeepPink;
            ibAddClient.TextAlign = ContentAlignment.MiddleRight;
            ibAddClient.BackColor = panelChaildForm.BackColor;

            OpenChaildForm(new Form3());
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            SetOtherOp();
            if (activeForm != null)
                activeForm.Close();
        }

        private void panelChaildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ibTransactions_Click(object sender, EventArgs e)
        {
            SetOtherOp();

            ibDelete.ForeColor = Color.Red;
            ibDelete.IconColor = Color.Red;
            ibDelete.TextAlign = ContentAlignment.MiddleRight;
            ibDelete.BackColor = panelChaildForm.BackColor;

            OpenChaildForm(new frmDelete());
        }

        private void ibCurrency_Click(object sender, EventArgs e)
        {
            SetOtherOp();
            ibUpdate.ForeColor = Color.BlueViolet;
            ibUpdate.IconColor = Color.BlueViolet;
            ibUpdate.TextAlign = ContentAlignment.MiddleRight;
            ibUpdate.BackColor = panelChaildForm.BackColor;

            OpenChaildForm(new Update());
        }

        private void ibDeposit_Click(object sender, EventArgs e)
        {
          SetOtherOp();
         ibDeposit.ForeColor = Color.SaddleBrown;
         ibDeposit.IconColor = Color.SaddleBrown;
         ibDeposit.TextAlign = ContentAlignment.MiddleRight;
         ibDeposit.BackColor = panelChaildForm.BackColor;

            OpenChaildForm(new DepositScreen());
        }

        private void ibPro_Click_1(object sender, EventArgs e)
        {
            SetOtherOp();

            ibPro.ForeColor = Color.DeepPink;
            ibPro.IconColor = Color.DeepPink;
            ibPro.TextAlign = ContentAlignment.MiddleRight;
            ibPro.BackColor = panelChaildForm.BackColor;

            OpenChaildForm(new Profile());
        }

        private void ibBalances_Click_1(object sender, EventArgs e)
        {
            SetOtherOp();
            ibBalances.ForeColor = Color.Violet;
            ibBalances.IconColor = Color.Violet;
            ibBalances.TextAlign = ContentAlignment.MiddleRight;
            ibBalances.BackColor = panelChaildForm.BackColor;

            OpenChaildForm(new TotalBalanves());
        }

        private void ibTransfare_Click(object sender, EventArgs e)
        {
            SetOtherOp();
            ibTransfare.ForeColor = Color.Tomato;
            ibTransfare.IconColor = Color.Tomato;
            ibTransfare.TextAlign = ContentAlignment.MiddleRight;
            ibTransfare.BackColor = panelChaildForm.BackColor;

            OpenChaildForm(new Transfare());
        }

        private void ibWithdrow_Click_1(object sender, EventArgs e)
        {
            SetOtherOp();
            ibWithdrow.ForeColor = Color.RoyalBlue;
            ibWithdrow.IconColor = Color.RoyalBlue;
            ibWithdrow.TextAlign = ContentAlignment.MiddleRight;
            ibWithdrow.BackColor = panelChaildForm.BackColor;

            OpenChaildForm(new WithdrawScreen());
        }

        private void ibLogOut_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Are You Sure You Want To LogOut", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                Application.OpenForms[0].Show();

                this.Close();
            }
        }
    }
}
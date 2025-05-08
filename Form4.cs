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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush backBrush = new SolidBrush(Color.Fuchsia))
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            {
                e.Graphics.FillRectangle(backBrush, e.Bounds);
                e.Graphics.DrawString(e.Header.Text, listView1.Font, textBrush, e.Bounds);
            }
        }

        private void ListView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
 
        public void UpdateClientList()
        {
            int Index = 0;
            listView1.Items.Clear();

            foreach (Client client in ClientData.Clients)
            {
                if (client.AccountNumber != "")
                {
                    Index++;
                    ListViewItem item = new ListViewItem(Index.ToString());

                    item.SubItems.Add(client.AccountNumber );
                    item.SubItems.Add(client.FirstName);
                    item.SubItems.Add(client.LastName);
                    item.SubItems.Add(client.Email);
                    item.SubItems.Add(client.PinCode);
                    item.SubItems.Add(client.PhoneNumber);
                    item.SubItems.Add(client.DateOfBirth);
                    item.SubItems.Add(client.Adderes);
                    item.SubItems.Add(client.Balance); ;
                    listView1.Items.Add(item);
                    lblClient.Text = Index.ToString() + " Client(s)";
                }
             }
            listView1.DrawColumnHeader += ListView1_DrawColumnHeader;
            listView1.DrawItem += ListView1_DrawItem;
         }
 
        private void Form4_Load(object sender, EventArgs e)
        {
            iconButton1.Enabled = false;

            txtSerch.Enabled = false;
           UpdateClientList();
           listView1.Font = new Font("FontAwesome", 12);
            //LoadClientsFromJson();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSerch.Enabled = true;
            txtSerch.Text = "Enter "+comboBox1.SelectedItem.ToString();
            iconButton1.Enabled = true;
        }
 
        private Client EmClient()
        {
            Client Emclient = new Client();

            Emclient.Email = "";
            Emclient.Adderes = "";
            Emclient.AccountNumber  = "";
            Emclient.FirstName  = "";
            Emclient.LastName  = "";
            Emclient.PhoneNumber  = "";
            Emclient.PinCode  = "";
            Emclient.Gender   = "";
            Emclient.DateOfBirth   = "";


            return Emclient;

        }

         public void iconButton1_Click(object sender, EventArgs e)
        {

            string enteredAccount = txtSerch.Text;
            listView1.SelectedItems.Clear(); // optional

            if (comboBox1.SelectedIndex == 0)
            {
                foreach (Client client in ClientData.Clients)
                {
                    if (client.AccountNumber.ToLower() == txtSerch.Text.ToLower())
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            if (item.SubItems[1].Text == client.AccountNumber)
                            {
                                item.Selected = true;
                                listView1.Focus(); // Optional: brings focus to the list
                                 Form frmD = new frmDetails(client);
                                frmD.ShowDialog();


                                return ;
                            }
                        }
                    }
                }


                MessageBox.Show("Client With Account Number " + txtSerch.Text + " Not Found in The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                foreach (Client client in ClientData.Clients)
                {
                    if (client.FirstName.ToLower() == txtSerch.Text.ToLower())
                    {
                        foreach (ListViewItem item in listView1.Items)
                        {
                            if (item.SubItems[2].Text.ToLower() == client.FirstName.ToLower())
                            {
                                item.Selected = true;
                                listView1.Focus(); // Optional: brings focus to the list
                                 Form frmD = new frmDetails(client);
                                frmD.ShowDialog();
                                return;
                            }
                        }
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
                        foreach (ListViewItem item in listView1.Items)
                        {
                            if (item.SubItems[3].Text.ToLower() == client.PinCode.ToLower())
                            {
                                item.Selected = true;
                                listView1.Focus(); // Optional: brings focus to the list
                                  Form frmD = new frmDetails(client);
                                frmD.ShowDialog();

                                return;
                            }
                        }
                    }
                }


                MessageBox.Show("Client With Pin Code " + txtSerch.Text + " Not Found in The System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
         }

        private void txtSerch_MouseClick(object sender, MouseEventArgs e)
        {
            txtSerch.Text = "";
        }

        private void txtSerch_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}

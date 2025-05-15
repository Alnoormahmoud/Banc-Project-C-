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
    public partial class TotalBalanves : Form
    {
        public TotalBalanves()
        {
            InitializeComponent();
        }
        private float Total = 0;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ListView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (SolidBrush backBrush = new SolidBrush(Color.Violet))
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
            listView1.Items.Clear();

            foreach (Client c in ClientData.Clients)
            {
                if (c.AccountNumber != "")
                {
                    ListViewItem item = new ListViewItem(c.AccountNumber);

                    item.SubItems.Add(c.FirstName);
                    item.SubItems.Add(c.LastName);
                    item.SubItems.Add(c.Balance + " $");

                    Total += float.Parse(c.Balance);

                    listView1.Items.Add(item);
                 }
                lblTotal.Text = Total.ToString() + " $";

                listView1.DrawColumnHeader += ListView1_DrawColumnHeader;
                listView1.DrawItem += ListView1_DrawItem;
            }
        }

        private void TotalBalanves_Load(object sender, EventArgs e)
        {
            listView1.Font = new Font("FontAwesome", 12);

            UpdateClientList();
        }
    }
}

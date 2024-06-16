using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking_App
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void fDFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Withdraw withdraw = new Withdraw();
            withdraw.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_account newac = new New_account();
            newac.Show();
        }

        private void searchAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Show();
        }

        private void allCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            All_account all_Ac =new All_account();
            all_Ac.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deposit deposit =new Deposit();
            deposit.Show();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transfer transfer =new Transfer();
            transfer.Show();
        }

        private void fDFOrmToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Balancesheet balancesheet =new Balancesheet();
            balancesheet.Show();
        }

        private void viewFDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFD viewFD =new ViewFD();
            viewFD.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePass changePass =new ChangePass();
            changePass.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

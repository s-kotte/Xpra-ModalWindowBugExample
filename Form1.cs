using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenDialogClick(object sender, EventArgs e)
        {
            new ModalForm().ShowDialog();
        }
    }
}
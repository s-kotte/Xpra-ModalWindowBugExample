using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class ModalForm : Form
    {
        private static readonly Random Random = new Random(DateTime.Now.Millisecond);
        public ModalForm()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            Height = Random.Next(485, 650);
        }
    }
}
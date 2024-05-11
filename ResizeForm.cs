using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryoutsmth
{
    public partial class ResizeForm : Form
    {

        public int NewWidth => int.Parse(textBox1.Text);
        public int NewHeight => int.Parse(textBox2.Text);



        public ResizeForm()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();


        }

        private void btn_okay_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
                DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool ValidateInput()
        {
            bool isValid = true;



           
            if (!int.TryParse(textBox1.Text, out int width) || width <= 0)
            {
                MessageBox.Show("Please enter a valid value for Width.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            
            if (!int.TryParse(textBox2.Text, out int height) || height <= 0)
            {
                MessageBox.Show("Please enter a valid value for Height.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }

            return isValid;
        }

    }






}





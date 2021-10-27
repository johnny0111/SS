using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SS_OpenCV
{
    public partial class NonUniform : Form
    {
        public float[,] matrix = new float[3,3];
        public float offSet, Weight;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.Equals("Realce de Contornos"))
            {
                textBox1.Text = "-1";
                textBox2.Text = "-1";
                textBox3.Text = "-1";
                textBox4.Text = "-1";
                textBox5.Text = "9";
                textBox6.Text = "-1";
                textBox7.Text = "-1";
                textBox8.Text = "-1";
                textBox9.Text = "-1";
                textBox10.Text = "1";
                textBox11.Text = "0";
            }
            else if (comboBox1.SelectedItem.Equals("Gaussiano"))
            {
                textBox1.Text = "1";
                textBox2.Text = "2";
                textBox3.Text = "1";
                textBox4.Text = "2";
                textBox5.Text = "4";
                textBox6.Text = "2";
                textBox7.Text = "1";
                textBox8.Text = "2";
                textBox9.Text = "1";
                textBox10.Text = "16";
                textBox11.Text = "0";
            }
            else if (comboBox1.SelectedItem.Equals("Laplacian Hard"))
            {
                textBox1.Text = "1";
                textBox2.Text = "-2";
                textBox3.Text = "1";
                textBox4.Text = "-2";
                textBox5.Text = "4";
                textBox6.Text = "-2";
                textBox7.Text = "1";
                textBox8.Text = "-2";
                textBox9.Text = "1";
                textBox10.Text = "1";
                textBox11.Text = "0";
            }
            else if (comboBox1.SelectedItem.Equals("Linhas Verticais"))
            {
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
                textBox4.Text = "-1";
                textBox5.Text = "2";
                textBox6.Text = "-1";
                textBox7.Text = "0";
                textBox8.Text = "0";
                textBox9.Text = "0";
                textBox10.Text = "1";
                textBox11.Text = "0";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            matrix[0,0] = float.Parse(textBox1.Text);
            matrix[0,1] = float.Parse(textBox2.Text);
            matrix[0,2] = float.Parse(textBox3.Text);
            matrix[1,0] = float.Parse(textBox4.Text);
            matrix[1,1] = float.Parse(textBox5.Text);
            matrix[1,2] = float.Parse(textBox6.Text);
            matrix[2,0] = float.Parse(textBox7.Text);
            matrix[2,1] = float.Parse(textBox8.Text);
            matrix[2,2] = float.Parse(textBox9.Text);
            offSet = float.Parse(textBox11.Text);
            Weight = float.Parse(textBox10.Text);
            Close();
            
        }

        public NonUniform()
        {
            InitializeComponent();
        }

        
    }
}

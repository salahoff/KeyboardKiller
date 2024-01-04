using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = textBox1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int seconds = 10;
            int i = 0;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
                timer.Interval = 1000 * seconds; // s -> ms
                timer.Enabled = true;
                timer.Tick += (ts, te) =>
                {
                    InputSimulator sim = new InputSimulator();

                    string str = textBox1.Text + " ";

                    int sec = Convert.ToInt32(textBox2.Text);
                    
                    
                    while (true)
                    {
                        i++;
                        foreach (char c in str)
                        {

                            sim.Keyboard.TextEntry(c);
                            Thread.Sleep(sec);
                        }
                    }
                
                    timer.Stop();
                };
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int plus = Convert.ToInt32(textBox2.Text);
            plus += 10;
            textBox2.Text = plus.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int plus = Convert.ToInt32(textBox2.Text);
            plus -= 10;
            textBox2.Text = plus.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            string new_text = Regex.Replace(text, $"[ ]+", " ").Trim();
            textBox1.Text = new_text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                int i = 0;
                label4.Visible=true;

                string text = textBox1.Text;
                string[] word = text.Split(' ');

                foreach (string c in word)
                {
                    i++;
                    label4.Text = "Всего слов: " + i;
                }

                if (textBox1.Text=="") { label4.Visible = false; }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\text.txt", false))
            {
                file.WriteLine(textBox1.Text);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\text.txt", false))
            {
                textBox1.Text = file.ReadToEnd();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int k = Int32.Parse(textBox3.Text);
            
            string[] word = text.Split('\n');

            textBox1.Clear();

            foreach (string c in word)
            {
                string at = string.Join("", Enumerable.Repeat(c+"\n", k));
                textBox1.Text += at;
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            int plus = Convert.ToInt32(textBox3.Text);
            plus -= 1;
            textBox3.Text = plus.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int plus = Convert.ToInt32(textBox3.Text);
            plus += 1;
            textBox3.Text = plus.ToString();
        }
    }
}

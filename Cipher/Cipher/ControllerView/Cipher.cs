using Cipher.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Cipher
{
    public partial class CipherForm : Form
    {

        //Thread[] numberOfThreads;

        readonly CipherModel model = new CipherModel();

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void encryptCaesar(byte[] sentence1, int key1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void decryptCaesar(byte[] sentence1, int key1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void encryptVigenere(byte[] sentence1, byte[] keyword1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void decryptVigenere(byte[] sentence1, byte[] keyword1, byte[] buf);

        public CipherForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            model.countCores(CoresLabel);
            model.countLogicalProcessors(LogicalLabel);
            model.countPhysicalProcessors(PhysicalLabel);
            ActiveThreadsComboBox.SelectedItem = model.countLogicalProcessorsForActiveThreads();
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {

            if (CaesarCipherRadioButton.Checked == true)
            {
                string str = SentenceTextBox.Text;
                byte[] byteSentence = Encoding.ASCII.GetBytes(str);
                byte[] buf = new byte[1000];
                int key = 0;
                if (!Int32.TryParse(ShiftPasswordTextBox.Text, out key))
                {}
                encryptCaesar(byteSentence, key, buf);
                string result = Encoding.ASCII.GetString(buf);
                ResultTextBox.Text = result;
            }
            else
            {
                string str = SentenceTextBox.Text;
                byte[] byteSentence = Encoding.ASCII.GetBytes(str);
                byte[] buf = new byte[1000];
                byte[] keyword = Encoding.ASCII.GetBytes(ShiftPasswordTextBox.Text); 
                encryptVigenere(byteSentence, keyword, buf);
                string result = Encoding.ASCII.GetString(buf);
                ResultTextBox.Text = result;
            }
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {

            if (CaesarCipherRadioButton.Checked == true)
            {
                string str = SentenceTextBox.Text;
                byte[] byteSentence = Encoding.ASCII.GetBytes(str);
                byte[] buf = new byte[1000];
                int key = 0;
                if (!Int32.TryParse(ShiftPasswordTextBox.Text, out key))
                {}
                decryptCaesar(byteSentence, key, buf);
                string result = Encoding.ASCII.GetString(buf);
                ResultTextBox.Text = result;
            }
            else
            {
                string str = SentenceTextBox.Text;
                byte[] byteSentence = Encoding.ASCII.GetBytes(str);
                byte[] buf = new byte[1000];
                byte[] keyword = Encoding.ASCII.GetBytes(ShiftPasswordTextBox.Text);
                decryptVigenere(byteSentence, keyword, buf);
                string result = Encoding.ASCII.GetString(buf);
                ResultTextBox.Text = result;
            }   
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CaesarCipherRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

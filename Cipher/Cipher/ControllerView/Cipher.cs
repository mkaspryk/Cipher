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
        Thread[] arrayOfThreads;
        object[] arrayOfArguments;
        public byte[] sentence;
        readonly CipherModel model = new CipherModel();

        /// <summary>
        ///  
        /// </summary>
        public CipherForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender">  </param>
        /// <param name="e">  </param>
        /// <returns> void </returns>
        private void Form_Load(object sender, EventArgs e)
        {
            model.countCores(CoresLabel);
            model.countLogicalProcessors(LogicalLabel);
            model.countPhysicalProcessors(PhysicalLabel);
            ActiveThreadsComboBox.SelectedItem = model.countLogicalProcessorsForActiveThreads();
            if (!(model.checkCompatibilityOfFramework()))
            {
                MessageBox.Show("Not compatibility framework. Required is 4.7.2 or newer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender">  </param>
        /// <param name="e">  </param>
        /// <returns> void </returns>
        private void Encrypt_Click(object sender, EventArgs e)
        {
            bool encrypt = true;
            bool decrypt = false;
            try
            {
                bool result = managerDLL(encrypt, decrypt, model.returnSelectedItem(ActiveThreadsComboBox));
                if (result)
                {
                    model.stopChrono();
                    ResultTextBox.Text = System.Text.Encoding.ASCII.GetString(sentence);
                    logTextBox.Text = ("Encryption/Decryption time " + model.getChrono() + "ms");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender">  </param>
        /// <param name="e">  </param>
        /// <returns> void </returns>
        private void Decrypt_Click(object sender, EventArgs e)
        {
            bool encrypt = false;
            bool decrypt = true;
            try
            {
                bool result = managerDLL(encrypt, decrypt, model.returnSelectedItem(ActiveThreadsComboBox));
                if (result)
                {
                    model.stopChrono();
                    ResultTextBox.Text = System.Text.Encoding.ASCII.GetString(sentence);
                    logTextBox.Text = ("Encryption/Decryption time " + model.getChrono() + "ms");
                }
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="encrypt">  </param>
        /// <param name="decrypt">  </param>
        /// <param name="threads">  </param>
        /// <returns> bool </returns>
        public bool managerDLL(bool encrypt, bool decrypt, int threads)
        {
            int select = selectDLL(encrypt, decrypt);
            if (select % 2 != 0)
            {
                if (!model.isAlphabetic(ShiftPasswordTextBox.Text))
                {
                    MessageBox.Show("Not alfabetic password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                int keyInt;
                if (!Int32.TryParse(ShiftPasswordTextBox.Text, out keyInt))
                {
                    MessageBox.Show("Invalid shift (only numbers)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (keyInt > 26 || keyInt < 0)
                {
                    MessageBox.Show("Wrong shift range (correct range 0-26) !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            prepareTasks(threads, select);
            createThreads();
            waitForThreads();
            return true;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="threads">  </param>
        /// <param name="select">  </param>
        /// <returns> void </returns>
        public void prepareTasks(int threads, int select)
        {
            int indexStart;
            int indexStop;
            int size = SentenceTextBox.TextLength;
            sentence = new byte[size];
            string sentenceUpper = SentenceTextBox.Text.ToUpper();
            sentence = Encoding.ASCII.GetBytes(sentenceUpper);
            string key = ShiftPasswordTextBox.Text;
            if (size < 64)
            {
                indexStart = 0;
                indexStop = size;
                arrayOfThreads = new Thread[1];
                arrayOfArguments = new object[1];
                prepareDelegate(select, 0, sentence, key, indexStart, indexStop);
            }
            else
            {
                arrayOfThreads = new Thread[threads];
                arrayOfArguments = new object[threads];
                int shift = size / threads;
                int plus = size % threads;
                indexStart = 0;
                indexStop = 0;
                string tmp = key;
                int indexTmp = 0;
                for (int i = 0; i < arrayOfThreads.GetLength(0); i++)
                {
                    if ((arrayOfThreads.GetLength(0) - 1) == i)
                    {
                        indexStart = indexStop;
                        indexStop += shift + plus;
                        if (select % 2 != 0)
                        {
                            key = "";
                            while (indexStop - indexStart > key.Length)
                            {
                                key += tmp[indexTmp];
                                indexTmp++;
                                if (indexTmp == tmp.Length)
                                    indexTmp = 0;
                            }
                        }
                    }
                    else
                    {
                        indexStart = indexStop;
                        indexStop += shift;
                        if (select % 2 != 0)
                        {
                            key = "";
                            while (indexStop - indexStart > key.Length)
                            {
                                key += tmp[indexTmp];
                                indexTmp++;
                                if (indexTmp == tmp.Length)
                                    indexTmp = 0;
                            }
                        }
                    }
                    prepareDelegate(select, i, sentence, key, indexStart, indexStop);
                }
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="select">  </param>
        /// <param name="i">  </param>
        /// <param name="sentence">  </param>
        /// <param name="key">  </param>
        /// <param name="indexStart">  </param>
        /// <param name="indexStop">  </param>
        /// <returns> void </returns>
        public void prepareDelegate(int select, int i, byte[] sentence, string key, int indexStart, int indexStop)
        {
            arrayOfArguments[i] = new object[4] { sentence, key, indexStart, indexStop };
            switch (select)
            {
                case 0:
                    arrayOfThreads[i] = new Thread(new ParameterizedThreadStart(model.encryptCaesarAsm));
                    break;
                case 1:
                    arrayOfThreads[i] = new Thread(new ParameterizedThreadStart(model.encryptVigenereAsm));
                    break;
                case 2:
                    arrayOfThreads[i] = new Thread(new ParameterizedThreadStart(model.caesarEncrypt));
                    break;
                case 3:
                    arrayOfThreads[i] = new Thread(new ParameterizedThreadStart(model.vigenereEncrypt));
                    break;
                case 4:
                    arrayOfThreads[i] = new Thread(new ParameterizedThreadStart(model.decryptCaesarAsm));
                    break;
                case 5:
                    arrayOfThreads[i] = new Thread(new ParameterizedThreadStart(model.decryptVigenereAsm));
                    break;
                case 6:
                    arrayOfThreads[i] = new Thread(new ParameterizedThreadStart(model.caesarDecrypt));
                    break;
                case 7:
                    arrayOfThreads[i] = new Thread(new ParameterizedThreadStart(model.vigenereDecrypt));
                    break;
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="encrypt">  </param>
        /// <param name="decrypt">  </param>
        /// <returns> int </returns>
        public int selectDLL(bool encrypt, bool decrypt)
        {
            if (encrypt)
            {
                if (ASMRadioButton.Checked == true)
                {
                    if (CaesarCipherRadioButton.Checked == true) // return 0
                    { return 0; }
                    else                                         // return 1
                    { return 1; }
                }
                else
                {
                    if (CaesarCipherRadioButton.Checked == true) // return 2
                    { return 2; }
                    else                                         // return 3
                    { return 3; }
                }
            }
            else
            {
                if (ASMRadioButton.Checked == true)
                {
                    if (CaesarCipherRadioButton.Checked == true) // return 4
                    { return 4; }
                    else                                         // return 5
                    { return 5; }
                }
                else
                {
                    if (CaesarCipherRadioButton.Checked == true) // return 6
                    { return 6; }
                    else                                         // return 7
                    { return 7; }
                }
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns> void </returns>
        public void createThreads()
        {
            if (arrayOfThreads == null)
                return;
            else
            {
                model.startChrono();
                for (int i = 0; i < arrayOfThreads.GetLength(0); i++)
                {
                    try
                    {
                        arrayOfThreads[i].Start(arrayOfArguments[i]);
                    }
                    catch (ThreadStateException e)
                    {
                        MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns> void </returns>
        public void waitForThreads()
        {
            if (arrayOfThreads == null)
                return;
            bool endOfThread = false;
            while (!endOfThread)
            {
                endOfThread = true;
                for (int i = 0; i < arrayOfThreads.GetLength(0); i++)
                {
                    endOfThread &= (arrayOfThreads[i] == null || !arrayOfThreads[i].IsAlive);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e){}
        private void textBox1_TextChanged(object sender, EventArgs e){}
        private void label2_Click(object sender, EventArgs e){}
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e){}
        private void groupBox1_Enter(object sender, EventArgs e){}
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {}
        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e){}
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){}
        private void groupBox2_Enter(object sender, EventArgs e){}
        private void CaesarCipherRadioButton_CheckedChanged(object sender, EventArgs e){}
    }
}

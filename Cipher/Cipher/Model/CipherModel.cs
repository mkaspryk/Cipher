using System.Diagnostics;
using System.IO;
using System;
using System.Management;
using System.Management.Instrumentation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Text;

namespace Cipher.Model
{
    class CipherModel
    {
        // --------------------------------------------------------------------------
        // CPP DLL

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void encryptCaesar(byte[] sentence1, int key1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void decryptCaesar(byte[] sentence1, int key1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void encryptVigenere(byte[] sentence1, byte[] keyword1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        private static extern void decryptVigenere(byte[] sentence1, byte[] keyword1, byte[] buf);

        public void caesarEncrypt(object args)
        {
            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string key = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);

            byte[] buf = new byte[indexStop];
            int keyInt = 0;
            if (!Int32.TryParse(key, out keyInt))
            {
                MessageBox.Show("Invalid shift (only numbers)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (keyInt > 26 || keyInt < 0)
                {
                    MessageBox.Show("Wrong shift range (correct range 0-26) !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    byte[] tmp = new byte[indexStop];
                    for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                    {
                        tmp[j] = (byte)sentence[i];
                    }
                    encryptCaesar(tmp, keyInt, buf);
                    for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                    {
                        sentence[i] = (byte)buf[j];
                    }
                }
            }
        }

        public void caesarDecrypt(object args)
        {

            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string key = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);

            byte[] buf = new byte[indexStop];
            int keyInt = 0;
            if (!Int32.TryParse(key, out keyInt))
            {
                MessageBox.Show("Invalid shift (only numbers)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (keyInt > 26 || keyInt < 0)
                {
                    MessageBox.Show("Wrong shift range (correct range 0-26) !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    byte[] tmp = new byte[indexStop];
                    for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                    {
                        tmp[j] = (byte)sentence[i];
                    }
                    decryptCaesar(tmp, keyInt, buf);
                    for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                    {
                        sentence[i] = (byte)buf[j];
                    }
                }

            }
        }

        public void vigenereEncrypt(object args)
        {

            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string keyword = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);

            byte[] key = Encoding.ASCII.GetBytes(keyword);
            if (!(isAlphabetic(key)))
                MessageBox.Show("Not alfabetic password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                byte[] buf = new byte[indexStop];
                byte[] tmp = new byte[indexStop];
                for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                {
                    tmp[j] = (byte)sentence[i];
                }
                encryptVigenere(tmp, key, buf);
                for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                {
                    sentence[i] = (byte)buf[j];
                }
            }
        }

        public void vigenereDecrypt(object args)
        {

            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string keyword = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);

            byte[] key = Encoding.ASCII.GetBytes(keyword);
            if (!(isAlphabetic(key)))
                MessageBox.Show("Not alfabetic password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                byte[] buf = new byte[indexStop];
                byte[] tmp = new byte[indexStop];
                for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                {
                    tmp[j] = (byte)sentence[i];
                }
                decryptVigenere(tmp, key, buf);
                for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                {
                    sentence[i] = (byte)buf[j];
                }
            }
        }

        public bool checkCompatibilityOfFramework()
        {

            const string subsystemKey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
            using (var tmpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subsystemKey))
            {
                if (tmpKey != null && tmpKey.GetValue("Release") != null)
                {
                    if (CheckFourSevenTwoVersion((int)tmpKey.GetValue("Release")))
                        return true;
                }
                else
                {
                    return false;
                }
                return false;
            }
            bool CheckFourSevenTwoVersion(int releaseKey)
            {
                if (releaseKey >= 461808) // framework 4.7.2
                    return true;
                else
                    return false;
            }
        }

        // --------------------------------------------------------------------------
        // ASM DLL 


        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe public static extern void encryptCaesarAsm(byte* sentence1, int key1, byte* buf);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe public static extern void decryptCaesarAsm(byte* sentence1, int key1, byte* buf);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe public static extern void encryptVigenereAsm(byte* sentence1, byte* key1, byte* buf);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe public static extern void decryptVigenereAsm(byte* sentence1, byte* key1, byte* buf);

        unsafe public void encryptCaesarAsm(object args)
        {

            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string key = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);

            byte[] buf = new byte[indexStop];
            int keyInt = 0;
            if (!Int32.TryParse(key, out keyInt))
            {
                MessageBox.Show("Invalid shift (only numbers)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (keyInt > 26 || keyInt < 0)
                {
                    MessageBox.Show("Wrong shift range (correct range 0-26) !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        byte[] tmp = new byte[indexStop];
                        for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                        {
                            tmp[j] = (byte)sentence[i];
                        }
                        //ASM encryptCaesar function
                        fixed (byte* ptr1 = &tmp[0])
                        {
                            fixed (byte* ptr2 = &buf[0])
                            {
                                encryptCaesarAsm(ptr1, keyInt, ptr2);
                            }
                        }
                        for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                        {
                            sentence[i] = (byte)buf[j];
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Out of range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        unsafe public void decryptCaesarAsm(object args)
        {

            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string key = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);

            byte[] buf = new byte[indexStop];
            int keyInt = 0;
            if (!Int32.TryParse(key, out keyInt))
            {
                MessageBox.Show("Invalid shift (only numbers)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (keyInt > 26 || keyInt < 0)
                {
                    MessageBox.Show("Wrong shift range (correct range 0-26) !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        byte[] tmp = new byte[indexStop];
                        for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                        {
                            tmp[j] = (byte)sentence[i];
                        }
                        //ASM decryptCaesar function
                        fixed (byte* ptr1 = &tmp[0])
                        {
                            fixed (byte* ptr2 = &buf[0])
                            {
                                decryptCaesarAsm(ptr1, keyInt, ptr2);
                            }
                        }
                        for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                        {
                            sentence[i] = (byte)buf[j];
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Out of range!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        unsafe public void encryptVigenereAsm(object args)
        {
            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string keyword = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);

            byte[] key = Encoding.ASCII.GetBytes(keyword);
            if (!(isAlphabetic(key)))
                MessageBox.Show("Not alfabetic password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                byte[] buf = new byte[indexStop];
                byte[] tmp = new byte[indexStop];
                for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                {
                    tmp[j] = (byte)sentence[i];
                }
                //ASM encryptVigenere
                fixed (byte* ptr1 = &tmp[0])
                {
                    fixed (byte* ptr2 = &buf[0])
                    {
                        fixed (byte* ptrKey = &key[0])
                        {
                            encryptVigenereAsm(ptr1, ptrKey, ptr2);
                        }
                    }
                }
                for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                {
                    sentence[i] = (byte)buf[j];
                }
            }
        }

        unsafe public void decryptVigenereAsm(object args)
        {
            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string keyword = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);

            byte[] key = Encoding.ASCII.GetBytes(keyword);
            if (!(isAlphabetic(key)))
                MessageBox.Show("Not alfabetic password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                byte[] buf = new byte[indexStop];
                byte[] tmp = new byte[indexStop];
                for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                {
                    tmp[j] = (byte)sentence[i];
                }
                //ASM decryptVigenere
                fixed (byte* ptr1 = &tmp[0])
                {
                    fixed (byte* ptr2 = &buf[0])
                    {
                        fixed (byte* ptrKey = &key[0])
                        {
                            decryptVigenereAsm(ptr1, ptrKey, ptr2);
                        }
                    }
                }
                for (int i = indexStart, j = 0; i < indexStop; i++, j++)
                {
                    sentence[i] = (byte)buf[j];
                }
            }
        }

        // --------------------------------------------------------------------------
        // chrono

        readonly Stopwatch chrono = new Stopwatch();

        public void startChrono()
        {
            chrono.Start();
        }

        public void stopChrono()
        {
            chrono.Stop();
        }

        public string getChrono()
        {
            string chronoElapsedMs = chrono.ElapsedMilliseconds.ToString();
            chrono.Reset();
            return chronoElapsedMs;
        }

        // --------------------------------------------------------------------------
        // is Alphabetic

        public bool isAlphabetic(byte[] s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        // --------------------------------------------------------------------------
        // Active Threads ComboBox

        public int returnSelectedItem(ComboBox ActiveThreadsComboBox)
        {
            if (ActiveThreadsComboBox.SelectedItem == null)
                return 0;
            else
            {
                int selected = Int32.Parse(ActiveThreadsComboBox.SelectedItem.ToString());
                return selected;
            }
        }

        // --------------------------------------------------------------------------
        // logical processors

        public void setLogicalProcessors(Label logicalProcessorsLabel, String logicalProcessors)
        {
            logicalProcessorsLabel.Text = logicalProcessors;
        }

        public void countLogicalProcessors(Label logicalProcessorsLabel)
        {
            String number = Environment.ProcessorCount.ToString();
            setLogicalProcessors(logicalProcessorsLabel, number);
        }

        public String countLogicalProcessorsForActiveThreads()
        {
            String number = Environment.ProcessorCount.ToString();
            int logicalProcessors = Convert.ToInt32(number) - 1;
            return logicalProcessors.ToString();
        }

        // --------------------------------------------------------------------------
        // physical processors

        public void setPhysicalProcessors(Label physicalProcessorsLabel, String physicalProcessors)
        {
            physicalProcessorsLabel.Text = physicalProcessors;
        }

        public void countPhysicalProcessors(Label physicalProcessorsLabel)
        {
            int number = 0;
            foreach (var i in new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem").Get())
            {
                number += int.Parse(i["NumberOfProcessors"].ToString());
            }
            setPhysicalProcessors(physicalProcessorsLabel, number.ToString());
        }

        // --------------------------------------------------------------------------
        // cores

        public void countCores(Label countCoresLabel)
        {
            int number = 0;
            foreach (var i in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                number += int.Parse(i["NumberOfCores"].ToString());
            }
            setCores(countCoresLabel, number.ToString());
        }

        public void setCores(Label countCoresLabel, String cores)
        {
            countCoresLabel.Text = cores;
        }

    }
}

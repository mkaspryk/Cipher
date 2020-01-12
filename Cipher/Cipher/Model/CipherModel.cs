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
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sentence1">  </param>
        /// <param name="key1">  </param>
        /// <param name="buf">  </param>
        /// <returns> void </returns>
        private static extern void encryptCaesar(byte[] sentence1, int key1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sentence1">  </param>
        /// <param name="key1">  </param>
        /// <param name="buf">  </param>
        /// <returns> void </returns>
        private static extern void decryptCaesar(byte[] sentence1, int key1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sentence1">  </param>
        /// <param name="keyword1">  </param>
        /// <param name="buf">  </param>
        /// <returns> void </returns>
        private static extern void encryptVigenere(byte[] sentence1, byte[] keyword1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sentence1">  </param>
        /// <param name="keyword1">  </param>
        /// <param name="buf">  </param>
        /// <returns> void </returns>
        private static extern void decryptVigenere(byte[] sentence1, byte[] keyword1, byte[] buf);

        /// <summary>
        ///  
        /// </summary>
        /// <param name="args">  </param>
        /// <returns> void </returns>
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
            Int32.TryParse(key, out keyInt);
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

        /// <summary>
        ///  
        /// </summary>
        /// <param name="args">  </param>
        /// <returns> void </returns>
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
            Int32.TryParse(key, out keyInt);
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

        /// <summary>
        ///  
        /// </summary>
        /// <param name="args">  </param>
        /// <returns> void </returns>
        public void vigenereEncrypt(object args)
        {
            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string keyword = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);
            byte[] key = Encoding.ASCII.GetBytes(keyword);
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

        /// <summary>
        ///  
        /// </summary>
        /// <param name="args">  </param>
        /// <returns> void </returns>
        public void vigenereDecrypt(object args)
        {
            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string keyword = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);
            byte[] key = Encoding.ASCII.GetBytes(keyword);
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

        /// <summary>
        ///  
        /// </summary>
        /// <returns> bool value </returns>
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
        unsafe public static extern void enCaesarAsm(byte[] sentence1, int key1, int size);
        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe public static extern void deCaesarAsm(byte[] sentence1, int key1, int size);
        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe public static extern void enVigenereAsm(byte[] sentence1, byte[] key1, int sizeSentence, int sizeKeyword);
        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        unsafe public static extern void deVigenereAsm(byte[] sentence1, byte[] key1, int sizeSentence, int sizeKeyword);


        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sentence1">  </param>
        /// <param name="key1">  </param>
        /// <param name="size">  </param>
        /// <returns> void </returns>
        unsafe public static extern void encryptCaesarAsm(byte[] sentence1, int key1, int size);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sentence1">  </param>
        /// <param name="key1">  </param>
        /// <param name="size">  </param>
        /// <returns> void </returns>
        unsafe public static extern void decryptCaesarAsm(byte[] sentence1, int key1, int size);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sentence1">  </param>
        /// <param name="key1">  </param>
        /// <param name="sizeSentence">  </param>
        /// <param name="sizeKeyword">  </param>
        /// <returns> void </returns>
        unsafe public static extern void encryptVigenereAsm(byte[] sentence1, byte[] key1, int sizeSentence, int sizeKeyword);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sentence1">  </param>
        /// <param name="key1">  </param>
        /// <param name="sizeSentence">  </param>
        /// <param name="sizeKeyword">  </param>
        /// <returns> void </returns>
        unsafe public static extern void decryptVigenereAsm(byte[] sentence1, byte[] key1, int sizeSentence, int sizeKeyword);

        /// <summary>
        ///  
        /// </summary>
        /// <param name="args">  </param>
        /// <returns> void </returns>
        unsafe public void encryptCaesarAsm(object args)
        {
            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string key = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);
            int keyInt = 0;
            Int32.TryParse(key, out keyInt);
            byte[] tmp = new byte[indexStop];
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                tmp[j] = (byte)sentence[i];
            }
            encryptCaesarAsm(tmp, keyInt, tmp.Length);
            //enCaesarAsm(tmp, keyInt, tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="args">  </param>
        /// <returns> void </returns>
        unsafe public void decryptCaesarAsm(object args)
        {
            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string key = (string)arguments.GetValue(1);
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);
            int keyInt = 0;
            Int32.TryParse(key, out keyInt);
            byte[] tmp = new byte[indexStop];
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                tmp[j] = (byte)sentence[i];
            }
            decryptCaesarAsm(tmp, keyInt, tmp.Length);
            //deCaesarAsm(tmp, keyInt, tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="args">  </param>
        /// <returns> void </returns>
        unsafe public void encryptVigenereAsm(object args)
        {
            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string keyword = (string)arguments.GetValue(1);
            keyword = keyword.ToUpper();
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);
            byte[] key = Encoding.ASCII.GetBytes(keyword);
            byte[] tmp = new byte[indexStop];
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                tmp[j] = (byte)sentence[i];
            }
            //encryptVigenereAsm(tmp, key, tmp.Length, key.Length);
            enVigenereAsm(tmp, key, tmp.Length, key.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="args">  </param>
        /// <returns> void </returns>
        unsafe public void decryptVigenereAsm(object args)
        {
            Array arguments = new object[4];
            arguments = (Array)args;
            byte[] sentence = (byte[])arguments.GetValue(0);
            string keyword = (string)arguments.GetValue(1);
            keyword = keyword.ToUpper();
            int indexStart = (int)arguments.GetValue(2);
            int indexStop = (int)arguments.GetValue(3);
            byte[] key = Encoding.ASCII.GetBytes(keyword);
            byte[] tmp = new byte[indexStop];
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                tmp[j] = (byte)sentence[i];
            }
            //decryptVigenereAsm(tmp, key, tmp.Length, key.Length);
            deVigenereAsm(tmp, key, tmp.Length, key.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        // --------------------------------------------------------------------------
        // chrono

        readonly Stopwatch chrono = new Stopwatch();

        /// <summary>
        ///  
        /// </summary>
        /// <returns> void </returns>
        public void startChrono()
        {
            chrono.Start();
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns> void </returns>
        public void stopChrono()
        {
            chrono.Stop();
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns> void </returns>
        public string getChrono()
        {
            string chronoElapsedMs = chrono.ElapsedMilliseconds.ToString();
            chrono.Reset();
            return chronoElapsedMs;
        }

        // --------------------------------------------------------------------------
        // is Alphabetic

        /// <summary>
        ///  
        /// </summary>
        /// <param name="s">  </param>
        /// <returns> void </returns>
        public bool isAlphabetic(string s)
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

        /// <summary>
        ///  
        /// </summary>
        /// <param name="activeThreadsComboBox">  </param>
        /// <returns> void </returns>
        public int returnSelectedItem(ComboBox activeThreadsComboBox)
        {
            if (activeThreadsComboBox.SelectedItem == null)
                return 0;
            else
            {
                int selected = Int32.Parse(activeThreadsComboBox.SelectedItem.ToString());
                return selected;
            }
        }

        // --------------------------------------------------------------------------
        // logical processors

        /// <summary>
        ///  
        /// </summary>
        /// <param name="logicalProcessorsLabel">  </param>
        /// <param name="logicalProcessors">  </param>
        /// <returns> void </returns>
        public void setLogicalProcessors(Label logicalProcessorsLabel, String logicalProcessors)
        {
            logicalProcessorsLabel.Text = logicalProcessors;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="logicalProcessorsLabel"> </param>
        /// <returns> void </returns>
        public void countLogicalProcessors(Label logicalProcessorsLabel)
        {
            String number = Environment.ProcessorCount.ToString();
            setLogicalProcessors(logicalProcessorsLabel, number);
        }

        /// <summary>
        ///  
        /// </summary>
        /// <returns> String </returns>
        public String countLogicalProcessorsForActiveThreads()
        {
            String number = Environment.ProcessorCount.ToString();
            int logicalProcessors = Convert.ToInt32(number) - 1;
            return logicalProcessors.ToString();
        }

        // --------------------------------------------------------------------------
        // physical processors

        /// <summary>
        ///  
        /// </summary>
        /// <param name="physicalProcessorsLabel">  </param>
        /// <param name="physicalProcessors">  </param>
        /// <returns> void </returns>
        public void setPhysicalProcessors(Label physicalProcessorsLabel, String physicalProcessors)
        {
            physicalProcessorsLabel.Text = physicalProcessors;
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="physicalProcessorsLabel">  </param>
        /// <returns> void </returns>
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

        /// <summary>
        ///  
        /// </summary>
        /// <param name="countCoresLabel">  </param>
        /// <returns> void </returns>
        public void countCores(Label countCoresLabel)
        {
            int number = 0;
            foreach (var i in new System.Management.ManagementObjectSearcher("Select * from Win32_Processor").Get())
            {
                number += int.Parse(i["NumberOfCores"].ToString());
            }
            setCores(countCoresLabel, number.ToString());
        }

        /// <summary>
        ///  
        /// </summary>
        /// <param name="countCoresLabel">  </param>
        /// <param name="cores">  </param>
        /// <returns> void </returns>
        public void setCores(Label countCoresLabel, String cores)
        {
            countCoresLabel.Text = cores;
        }
    }
}

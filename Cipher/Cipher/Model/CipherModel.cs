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
        /// [DLL] C++ Method "encrypt" Caesar Cipher uses SIMD instructions
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">shift</param>
        /// <param name="size">size of sentence</param>
        /// <returns>void</returns>
        private static extern void encryptCaesarSIMD(byte[] sentence1, int key1, int size);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] C++ Method "decrypt" Caesar Cipher uses SIMD instructions
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">shift</param>
        /// <param name="size">size of sentence</param>
        /// <returns>void</returns>
        private static extern void decryptCaesarSIMD(byte[] sentence1, int key1, int size);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] C++ Method "encrypt" Vigenere Cipher uses SIMD instructions
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">alphabetic password</param>
        /// <param name="sizeSentence">size of sentence</param>
        /// <returns>void</returns>
        private static extern void encryptVigenereSIMD(byte[] sentence1, byte[] key1, int sizeSentence);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] C++ Method "decrypt" Vigenere Cipher uses SIMD instructions
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">alphabetic password</param>
        /// <param name="sizeSentence">size of sentence</param>
        /// <returns>void</returns>
        private static extern void decryptVigenereSIMD(byte[] sentence1, byte[] key1, int sizeSentence);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] C++ Method "encrypt" Caesar Cipher
        /// </summary>
        /// <param name="sentence1">sentence to encrypt</param>
        /// <param name="key1">shift</param>
        /// <param name="buf">buffer for encrypted sentence</param>
        /// <returns>void</returns>
        private static extern void encryptCaesar(byte[] sentence1, int key1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] C++ Method "decrypt" Caesar Cipher
        /// </summary>
        /// <param name="sentence1">sentence to encrypt</param>
        /// <param name="key1">shift</param>
        /// <param name="buf">buffer for encrypted sentence</param>
        /// <returns>void</returns>
        private static extern void decryptCaesar(byte[] sentence1, int key1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] C++ Method "encrypt" Vigenere Cipher
        /// </summary>
        /// <param name="sentence1">sentence to encrypt</param>
        /// <param name="keyword1">alphabetic password</param>
        /// <param name="buf">buffer for encrypted sentence</param>
        /// <returns>void</returns>
        private static extern void encryptVigenere(byte[] sentence1, byte[] keyword1, byte[] buf);

        [DllImport("CIPHERCPPDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] C++ Method "decrypt" Vigenere Cipher
        /// </summary>
        /// <param name="sentence1">sentence to encrypt</param>
        /// <param name="keyword1">alphabetic password</param>
        /// <param name="buf">buffer for encrypted sentence</param>
        /// <returns>void</returns>
        private static extern void decryptVigenere(byte[] sentence1, byte[] keyword1, byte[] buf);

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
        public void caesarEncryptSIMD(object args)
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
            encryptCaesarSIMD(tmp, keyInt, tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
        public void caesarDecryptSIMD(object args)
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
            decryptCaesarSIMD(tmp, keyInt, tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
        unsafe public void vigenereEncryptSIMD(object args)
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
            encryptVigenereSIMD(tmp, key, tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
        unsafe public void vigenereDecryptSIMD(object args)
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
            decryptVigenereSIMD(tmp, key, tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
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
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
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
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
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
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
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
        /// Method checks the compatibility of used framework
        /// </summary>
        /// <returns> bool value (false - not supported framework)</returns>
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
                if (releaseKey >= 461808)  // framework 4.7.2
                    return true;
                else
                    return false;
            }
        }

        // --------------------------------------------------------------------------
        // ASM DLL 

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] ASM Method "encrypt" Caesar Cipher uses SIMD instructions
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">shift</param>
        /// <param name="size">size of sentence</param>
        /// <returns>void</returns>
        unsafe public static extern void encryptCaesarAsmSIMD(byte[] sentence1, int key1, int size);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] ASM Method "decrypt" Caesar Cipher uses SIMD instructions
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">shift</param>
        /// <param name="size">size of sentence</param>
        /// <returns>void</returns>
        unsafe public static extern void decryptCaesarAsmSIMD(byte[] sentence1, int key1, int size);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] ASM Method "encrypt" Vigenere Cipher uses SIMD instructions
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">alphabetic password</param>
        /// <param name="sizeSentence">size of sentence</param>
        /// <returns>void</returns>
        unsafe public static extern void encryptVigenereAsmSIMD(byte[] sentence1, byte[] key1, int sizeSentence);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] ASM Method "decrypt" Vigenere Cipher uses SIMD instructions
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">alphabetic password</param>
        /// <param name="size">size of sentence</param>
        /// <returns>void</returns>
        unsafe public static extern void decryptVigenereAsmSIMD(byte[] sentence1, byte[] key1, int sizeSentence);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] ASM Method "encrypt" Caesar Cipher
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">shift</param>
        /// <param name="size">size of sentence</param>
        /// <returns>void</returns>
        unsafe public static extern void encryptCaesarAsm(byte[] sentence1, int key1, int size);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] ASM Method "decrypt" Caesar Cipher uses SIMD instructions
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">shift</param>
        /// <param name="size">size of sentence</param>
        /// <returns>void</returns>
        unsafe public static extern void decryptCaesarAsm(byte[] sentence1, int key1, int size);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] ASM Method "encrypt" Vigenere Cipher
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">alphabetic password</param>
        /// <param name="sizeSentence">size of sentence</param>
        /// <param name="sizeKeyword">size of keyword</param>
        /// <returns>void</returns>
        unsafe public static extern void encryptVigenereAsm(byte[] sentence1, byte[] key1, int sizeSentence, int sizeKeyword);

        [DllImport("CIPHERASMDLL.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
        /// <summary>
        /// [DLL] ASM Method "decrypt" Vigenere Cipher
        /// </summary>
        /// <param name="sentence1">sentence to encrypt and buffer of encrypted sentence</param>
        /// <param name="key1">alphabetic password</param>
        /// <param name="sizeSentence">size of sentence</param>
        /// <param name="sizeKeyword">size of keyword</param>
        /// <returns>void</returns>
        unsafe public static extern void decryptVigenereAsm(byte[] sentence1, byte[] key1, int sizeSentence, int sizeKeyword);

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
        unsafe public void encryptCaesarAsmSIMD(object args)
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
            encryptCaesarAsmSIMD(tmp, keyInt, tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
        unsafe public void decryptCaesarAsmSIMD(object args)
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
            decryptCaesarAsmSIMD(tmp, keyInt, tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
        unsafe public void encryptVigenereAsmSIMD(object args)
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
            encryptVigenereAsmSIMD(tmp, key,tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
        unsafe public void decryptVigenereAsmSIMD(object args)
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
            decryptVigenereAsmSIMD(tmp, key, tmp.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
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
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
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
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
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
            encryptVigenereAsm(tmp, key, tmp.Length, key.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        /// <summary>
        /// Method prepares variables for DLL function
        /// </summary>
        /// <param name="args">Array with arguments</param>
        /// <returns>void</returns>
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
            decryptVigenereAsm(tmp, key, tmp.Length, key.Length);
            for (int i = indexStart, j = 0; i < indexStop; i++, j++)
            {
                sentence[i] = (byte)tmp[j];
            }
        }

        // --------------------------------------------------------------------------
        // chrono

        /// <summary>
        /// Creates Stopwatch object
        /// </summary>
        readonly Stopwatch chrono = new Stopwatch();

        /// <summary>
        /// Method starts chronograf
        /// </summary>
        /// <returns>void</returns>
        public void startChrono()
        {
            chrono.Start();
        }

        /// <summary>
        /// Method stops chronograf
        /// </summary>
        /// <returns> void </returns>
        public void stopChrono()
        {
            chrono.Stop();
        }

        /// <summary>
        /// Method get the measured time and reset chronograf
        /// </summary>
        /// <returns>void</returns>
        public string getChrono()
        {
            string chronoElapsedMs = chrono.ElapsedMilliseconds.ToString();
            chrono.Reset();
            return chronoElapsedMs;
        }

        // --------------------------------------------------------------------------
        // is Alphabetic

        /// <summary>
        /// Method checks the letters in string
        /// </summary>
        /// <param name="s">string (password)</param>
        /// <returns>void</returns>
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
        /// Method returns number of selected threads in combo box
        /// </summary>
        /// <param name="activeThreadsComboBox">number of selected threads</param>
        /// <returns>int (number of selected threads)</returns>
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
        /// Method sets the number of logical processors
        /// </summary>
        /// <param name="logicalProcessorsLabel">label</param>
        /// <param name="logicalProcessors">number of logical processors</param>
        /// <returns>void</returns>
        public void setLogicalProcessors(Label logicalProcessorsLabel, String logicalProcessors)
        {
            logicalProcessorsLabel.Text = logicalProcessors;
        }

        /// <summary>
        /// Method gets the number of logical processors
        /// </summary>
        /// <param name="logicalProcessorsLabel">label</param>
        /// <returns>void</returns>
        public void countLogicalProcessors(Label logicalProcessorsLabel)
        {
            String number = Environment.ProcessorCount.ToString();
            setLogicalProcessors(logicalProcessorsLabel, number);
        }

        /// <summary>
        /// Method gets the number of active threads
        /// </summary>
        /// <returns>String (active threads)</returns>
        public String countLogicalProcessorsForActiveThreads()
        {
            String number = Environment.ProcessorCount.ToString();
            int logicalProcessors = Convert.ToInt32(number) - 1;
            return logicalProcessors.ToString();
        }

        // --------------------------------------------------------------------------
        // physical processors

        /// <summary>
        /// Method sets the number of physical processors
        /// </summary>
        /// <param name="physicalProcessorsLabel">label</param>
        /// <param name="physicalProcessors">number of physical processors</param>
        /// <returns>void</returns>
        public void setPhysicalProcessors(Label physicalProcessorsLabel, String physicalProcessors)
        {
            physicalProcessorsLabel.Text = physicalProcessors;
        }

        /// <summary>
        /// Method gets the number of physical processors
        /// </summary>
        /// <param name="physicalProcessorsLabel">label</param>
        /// <returns>void</returns>
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
        /// Methos gets the number of cores
        /// </summary>
        /// <param name="countCoresLabel">label</param>
        /// <returns>void</returns>
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
        /// Method sets the cores
        /// </summary>
        /// <param name="countCoresLabel">label</param>
        /// <param name="cores">number of cores</param>
        /// <returns>void</returns>
        public void setCores(Label countCoresLabel, String cores)
        {
            countCoresLabel.Text = cores;
        }
    }
}

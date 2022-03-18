using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

// KEY value: 111111111111111111111111111111111111

        int[] REGISTER = new int[36];
        bool MODE = true;


        // SIMULATION OF LFSR REGISTER WORK
        // just output info how change triggers states in register
        public void ShowRegister(int[] register)
        {
            string tmp = String.Empty;
            for (int i = 0; i < register.Length; i++)
            {
                tmp += register[i].ToString();
            }
            txtBoxRegState.Text += '\t' + tmp +  '\t' + '\t' + shiftRegister(register) +  '\n' ;
        }

        //filling register with with specified value(key)
        public void FillRegister(string key, int[] register)
        {
            for (int i = 0; i < key.Length; i++)
            {
                register[i] = key[i] - '0';
            }
        }

        // simulation of changing triggers states inside register
        // register represent as array and triggers as array cells
        public int shiftRegister(int[] register)
        {
            int resValue = register[register.Length - 1];
            int newValue = register[register.Length - 1] ^ register[10];

            for (int i = register.Length - 1; i > 0; i--)
            {
                register[i] = register[i - 1];
            }

            register[0] = newValue;

            return resValue;
        }
        


        // WORKING WITH FILES
        // open file and write its content to textBox
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                txtBoxText.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        // create file with parsed text
        private void CreateFile(string text)
        {
            try
            {
                string fileName = "";

                if (MODE)
                {
                    fileName = @"E:\win\UnivTasks\InformationTheory\lab2\tests\CipheredFile.txt";
                } else fileName = @"E:\win\UnivTasks\InformationTheory\lab2\tests\UncipheredFile.txt";

                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (FileStream fs = File.Create(fileName))
                {
                    Byte[] title = new UTF8Encoding(true).GetBytes(text);
                    fs.Write(title, 0, title.Length);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }


        // CLEAR FIELDS

        public void ClearAll()
        {
            txtBoxText.Clear();
            txtBoxCipherText.Clear();
            txtBoxKey.Clear();
            txtBoxRegState.Clear();
        }

        //BUTTONS WORKING
        //decorative button just to show where is text/cipher text
        //swap the content of two labels
        private void btnReverse_Click(object sender, RoutedEventArgs e)
        {
            string tmp;
            tmp = (string)lbText.Content;
            lbText.Content = lbCipherText.Content;
            lbCipherText.Content = tmp;
            ClearAll();
            MODE = !MODE;

        }

        // clear all fields
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
            lbText.Content = "Text";
            lbCipherText.Content = "Cipher text";
        }


  
        // CIPHERING PART
        // convertin string to byes arr
        public byte[] Str2Bin(string text)
        {
            //return bytes of characters via unicode
            return Encoding.UTF8.GetBytes(text);

        }

        // change bytes in array via xor operation and convert new array of bytes to string 
        public string Ciphering(byte[] bytes, int[] register)
        {
            byte[] cipheredArr = new byte[bytes.Length];
            int[] CPregister = new int[36];
            register.CopyTo(CPregister, 0);

            for (int i =0; i < bytes.Length; i++)
            {
                ShowRegister(CPregister);
                cipheredArr[i] = (byte)(bytes[i] ^ shiftRegister(register));
            }

            return Encoding.UTF8.GetString(cipheredArr);
        }



        //CHECK FOR CORRECT VALUE

        //check key 
        public bool checkKey(string key)
        {
            
            if (String.IsNullOrEmpty(key))
            {
                MessageBox.Show("Empty Key");
                return false;
               
            }

            for(int i = 0; i < key.Length; i++)
            {
                if ( !(key[i] == '0' | key[i] == '1'))
                {
                    MessageBox.Show("Key contains invalid value");
                    return false;
                }
            }

            if ( key.Length != 36)
            {
                MessageBox.Show("Incorrect key length");
                return false;
            }

            if (!NullableKey(key))
            {
                MessageBox.Show("Key consists only from zero");
                return false;
            }
            
            return true;
        }

        //check if key consists only from zeros
        public bool NullableKey(string key)
        {
            for (int i = 0; i < key.Length; i++)
            {
                if (key [i] != '0')
                {
                    return true;
                }
            }

            return false;
        }

        //check txtField

        //check if txtField contains only white spaces
        public bool CheckWhiteSpaces(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ')
                {
                    return true;
                }
            }
            MessageBox.Show("Text field contains only spaces!!!");
            return false;
        }
        public bool checkTxt(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                MessageBox.Show("Txt field is empty");
                return false;
            }

            bool whiteSpc = CheckWhiteSpaces(text);

            if (!whiteSpc)
            {
                return false;
            }

            return true;
        }

        //Button that start ciphering/unciphering
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            txtBoxKey.Text = txtBoxKey.Text.Replace(" ", String.Empty);
            txtBoxCipherText.Clear();
            txtBoxRegState.Clear();

            if (checkKey(txtBoxKey.Text) & checkTxt(txtBoxText.Text))
            {
                FillRegister(txtBoxKey.Text, REGISTER);

                byte[] bytes = Str2Bin(txtBoxText.Text);

                txtBoxCipherText.Text = Ciphering(bytes, REGISTER);

                CreateFile(txtBoxCipherText.Text);
            }
            else
            {
                MessageBox.Show("Try one more time!!!");
            }        
        }
    }
}

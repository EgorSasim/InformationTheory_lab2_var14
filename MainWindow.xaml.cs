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

        public void ShowRegister(int[] register)
        {
            string tmp = String.Empty;
            for (int i = 0; i < register.Length; i++)
            {
                tmp += register[i].ToString();
            }
            txtBoxRegState.Text += '\t' + tmp +  '\t' + '\t' + shiftRegister(register) +  '\n' ;
        }

        public void FillRegister(string key, int[] register)
        {
            for (int i = 0; i < key.Length; i++)
            {
                register[i] = key[i] - '0';
            }
        }

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
        
       
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                txtBoxText.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void btnReverse_Click(object sender, RoutedEventArgs e)
        {
            string tmp;
            tmp = (string)lbText.Content;
            lbText.Content = lbCipherText.Content;
            lbCipherText.Content = tmp;
            txtBoxText.Clear();
            txtBoxCipherText.Clear();
            txtBoxKey.Clear();
            txtBoxRegState.Clear();

        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtBoxText.Clear();
            txtBoxCipherText.Clear();
            txtBoxKey.Clear();
            txtBoxRegState.Clear();
            lbText.Content = "Text";
            lbCipherText.Content = "Cipher text";
        }


  

        public byte[] Str2Bin(string text)
        {
            //return bytes of characters via unicode
            return Encoding.Unicode.GetBytes(text);

        }

 
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

            return Encoding.Unicode.GetString(cipheredArr);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            FillRegister(txtBoxKey.Text, REGISTER);

            byte[] bytes = Str2Bin(txtBoxText.Text);

            txtBoxCipherText.Text = Ciphering(bytes, REGISTER);



          
                       
        }
    }
}

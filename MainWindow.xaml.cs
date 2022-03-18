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


        public string Str2Bin(string text)
        {
            string tmp = "";
            

            foreach(char c in text)
            {
                tmp += Convert.ToString(c, 2).PadLeft(8, '0');
            }

            MessageBox.Show($"str2binOut: ", tmp);
            return tmp;
        }

        public string Ciphering(string binText, int[] register)
        {
            string tmp = "";
            string regTmp = "";
            int[] CPregister = new int[36];
            register.CopyTo(CPregister, 0);

          
             for(int i = 0; i < binText.Length; i++)
             {
                ShowRegister(CPregister);
              
                tmp += binText[i] ^ shiftRegister(register);
             }

            MessageBox.Show($"cipherOUT: ", tmp);
            return tmp;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            FillRegister(txtBoxKey.Text, REGISTER);

            txtBoxCipherText.Text = Ciphering(Str2Bin("hi"), REGISTER);
            //txtBoxCipherText.Text = Convert.ToBase64String( Str2Bin(txtBoxText.Text));
           
                       
        }
    }
}

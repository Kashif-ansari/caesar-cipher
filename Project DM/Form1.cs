using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_DM
{
    public partial class Form1 : Form
    {
        public int shift;
        public Form1()
        {
            InitializeComponent();
        }

        private string Encryption(string txt,int key)
        {
            string plainCapital = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string plainSmall = "abcdefghijklmnopqrstuvwxyz ";
            this.shift = key;
            string cipher = "";
            char space = ' '; 
            for (int i= 0;i<txt.Length;i++)
            {
                if(char.IsUpper(txt[i]))
                {
                    for (int j = 0; j < plainCapital.Length; j++)
                    {
                        if (txt[i] == plainCapital[j])
                        {
                            cipher = cipher + plainCapital[(j + shift) % 26];
                        }
                    }
                }
                else if (txt[i] == space)
                {
                    cipher = cipher + " ";
                }
                else
                {
                    for (int j = 0; j < plainSmall.Length; j++)
                    {
                        if (txt[i] == plainSmall[j])
                        {
                            cipher = cipher + plainSmall[(j + shift) % 26];
                        }
                    }
                }
            }
            return cipher;
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtPlain.Text != "" && txtShift.Text != "" && txtPlain.Text != null && txtShift.Text != null)
            {
                txtCipherEnc.Text = Encryption(txtPlain.Text, Convert.ToInt32(txtShift.Text));
            }
            else
            {
                MessageBox.Show("Please Enter Plain Text or Code Number To Proceed Further", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void combobox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPlain.Enabled = true;
            txtShift.Enabled = true;
            
            
        }
        private string Decryption(string txt)
        {
            string plainCapital = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string plainSmall = "abcdefghijklmnopqrstuvwxyz";
            string CipherDec = "";
            char space = ' ';
            for (int i = 0; i < txt.Length; i++)
            {
                if (char.IsUpper(txt[i]))
                {
                    for (int j = 0; j < plainCapital.Length; j++)
                    {
                        if (txt[i] == plainCapital[j])
                        {
                            if (j >= shift)
                            {
                                CipherDec = CipherDec + plainCapital[(j - shift) % 26];
                            }
                            else
                            {
                                int NonNegativeIndex = ((shift-j) % 26);
                                CipherDec = CipherDec + plainCapital[26-NonNegativeIndex];
                            }
                            
                        }
                    }
                }
                else if (txt[i] == space)
                {
                    CipherDec = CipherDec + " ";
                }
                else
                {
                    for (int j = 0; j < plainSmall.Length; j++)
                    {
                        if (txt[i] == plainSmall[j])
                        {
                            if (j >= shift)
                            {
                                CipherDec = CipherDec + plainSmall[(j - shift) % 26];
                            }
                            else
                            {
                                int NonNegativeIndex = ((shift - j) % 26);
                                CipherDec = CipherDec + plainSmall[26 - NonNegativeIndex];
                            }

                        }
                    }
                }
            }
            return CipherDec;
        }
        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtCipherEnc.Text!=null && txtCipherEnc.Text!="")
            {
                txtCipherDec.Text = Decryption(txtCipherEnc.Text);
            }
            else
            {
                MessageBox.Show("To Proceed Further You Need Cipher Text", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCipherDec.Text = "";
            txtCipherEnc.Text = "";
            txtPlain.Text = "";
            txtShift.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtShift_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!(Char.IsDigit(ch)) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPlain_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtShift_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

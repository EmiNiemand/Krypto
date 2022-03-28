using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypto
{
    public partial class Form1 : Form
    {
        DES des = new DES();
        DES desFile = new DES();
        byte[] fileContent;
        byte[] text;

        public Form1()
        {
            InitializeComponent();
            generateRandomKeyButton_Click(this, new EventArgs());
        }

        private void messageTextBox_TextChanged(object sender, EventArgs e)
        {
            encryptButton.Enabled = true;
            decryptButton.Enabled = true;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string strfilename = openFileDialog.InitialDirectory + openFileDialog.FileName;
                fileContent = File.ReadAllBytes(strfilename);
            }
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            resoultGroupBox.Enabled = true;
            text = des.Cipher(des.StringToBytes(messageTextBox.Text), currentKeyLabel.Text);
            outputTextBox.Text = des.BytesToString(text);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            resoultGroupBox.Enabled = true;
            messageTextBox.Text = des.BytesToString(des.Decipher(text, currentKeyLabel.Text));
        }

        private void newKeyButton_Click(object sender, EventArgs e)
        {
            currentKeyLabel.Text = newKeyTextBox.Text;
            newKeyTextBox.Text = "";
        }

        private void newKeyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (newKeyTextBox.Text.Length == 8)
            {
                newKeyButton.Enabled = true;
            }
            if (newKeyTextBox.Text.Length != 8)
            {
                newKeyButton.Enabled = false;
            }
        }

        private void generateRandomKeyButton_Click(object sender, EventArgs e)
        {
            currentKeyLabel.Text = des.GenerateKey();
        }

        private void saveButtonCipher_Click(object sender, EventArgs e)
        {
            byte[] byteArray = desFile.Cipher(fileContent, currentKeyLabel.Text);

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    myStream.Write(byteArray, 0, byteArray.Length);
                    myStream.Close();
                }
            }
        }

        private void saveButtonDecipher_Click(object sender, EventArgs e)
        {
            byte[] byteArray = desFile.Decipher(fileContent, currentKeyLabel.Text);

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream myStream;
                if ((myStream = saveFileDialog.OpenFile()) != null)
                {
                    myStream.Write(byteArray, 0, byteArray.Length);
                    myStream.Close();
                }
            }
        }
    }
}

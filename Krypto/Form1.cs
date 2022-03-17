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

        public Form1()
        {
            InitializeComponent();
            generateRandomKeyButton_Click(this, new EventArgs());
        }

        private void messageTextBox_TextChanged(object sender, EventArgs e)
        {
            if(messageTextBox.Text == "")
            {
                encryptButton.Enabled = false;
                decryptButton.Enabled = false;
            }
            if(messageTextBox.Text != "")
            {
                encryptButton.Enabled = true;
                decryptButton.Enabled = true;
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            String fileContent = String.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "Documents";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }

            messageTextBox.Text = fileContent;
        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            resoultGroupBox.Enabled = true;
            outputTextBox.Text = des.Cipher(messageTextBox.Text, currentKeyLabel.Text);
        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            resoultGroupBox.Enabled = true;
            outputTextBox.Text = des.Decipher(messageTextBox.Text, currentKeyLabel.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(outputTextBox.Text);

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "*.txt|*.txt";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

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
    }
}

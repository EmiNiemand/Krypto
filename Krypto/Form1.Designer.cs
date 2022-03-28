namespace Krypto
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.generateRandomKeyButton = new System.Windows.Forms.Button();
            this.encryptButton = new System.Windows.Forms.Button();
            this.decryptButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.currentKeyLabel = new System.Windows.Forms.Label();
            this.newKeyTextBox = new System.Windows.Forms.TextBox();
            this.newKeyButton = new System.Windows.Forms.Button();
            this.saveButtonCipher = new System.Windows.Forms.Button();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.resoultGroupBox = new System.Windows.Forms.GroupBox();
            this.saveButtonDecipher = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.resoultGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateRandomKeyButton
            // 
            this.generateRandomKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.generateRandomKeyButton.Location = new System.Drawing.Point(706, 127);
            this.generateRandomKeyButton.Name = "generateRandomKeyButton";
            this.generateRandomKeyButton.Size = new System.Drawing.Size(164, 53);
            this.generateRandomKeyButton.TabIndex = 0;
            this.generateRandomKeyButton.Text = "Generuj losowy klucz";
            this.generateRandomKeyButton.UseVisualStyleBackColor = true;
            this.generateRandomKeyButton.Click += new System.EventHandler(this.generateRandomKeyButton_Click);
            // 
            // encryptButton
            // 
            this.encryptButton.Enabled = false;
            this.encryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.encryptButton.Location = new System.Drawing.Point(280, 143);
            this.encryptButton.Name = "encryptButton";
            this.encryptButton.Size = new System.Drawing.Size(132, 51);
            this.encryptButton.TabIndex = 5;
            this.encryptButton.Text = "Szyfruj";
            this.encryptButton.UseVisualStyleBackColor = true;
            this.encryptButton.Click += new System.EventHandler(this.encryptButton_Click);
            // 
            // decryptButton
            // 
            this.decryptButton.Enabled = false;
            this.decryptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.decryptButton.Location = new System.Drawing.Point(280, 231);
            this.decryptButton.Name = "decryptButton";
            this.decryptButton.Size = new System.Drawing.Size(132, 57);
            this.decryptButton.TabIndex = 6;
            this.decryptButton.Text = "Deszyfruj";
            this.decryptButton.UseVisualStyleBackColor = true;
            this.decryptButton.Click += new System.EventHandler(this.decryptButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(703, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Aktualny klucz:";
            // 
            // currentKeyLabel
            // 
            this.currentKeyLabel.AutoSize = true;
            this.currentKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentKeyLabel.Location = new System.Drawing.Point(713, 82);
            this.currentKeyLabel.Name = "currentKeyLabel";
            this.currentKeyLabel.Size = new System.Drawing.Size(52, 22);
            this.currentKeyLabel.TabIndex = 12;
            this.currentKeyLabel.Text = "*key*";
            // 
            // newKeyTextBox
            // 
            this.newKeyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newKeyTextBox.Location = new System.Drawing.Point(706, 284);
            this.newKeyTextBox.MaxLength = 8;
            this.newKeyTextBox.Name = "newKeyTextBox";
            this.newKeyTextBox.Size = new System.Drawing.Size(164, 28);
            this.newKeyTextBox.TabIndex = 13;
            this.newKeyTextBox.TextChanged += new System.EventHandler(this.newKeyTextBox_TextChanged);
            // 
            // newKeyButton
            // 
            this.newKeyButton.Enabled = false;
            this.newKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newKeyButton.Location = new System.Drawing.Point(706, 337);
            this.newKeyButton.Name = "newKeyButton";
            this.newKeyButton.Size = new System.Drawing.Size(164, 42);
            this.newKeyButton.TabIndex = 19;
            this.newKeyButton.Text = "Zmień klucz";
            this.newKeyButton.UseVisualStyleBackColor = true;
            this.newKeyButton.Click += new System.EventHandler(this.newKeyButton_Click);
            // 
            // saveButtonCipher
            // 
            this.saveButtonCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButtonCipher.Location = new System.Drawing.Point(27, 290);
            this.saveButtonCipher.Name = "saveButtonCipher";
            this.saveButtonCipher.Size = new System.Drawing.Size(84, 57);
            this.saveButtonCipher.TabIndex = 17;
            this.saveButtonCipher.Text = "Zaszyfruj i zapisz";
            this.saveButtonCipher.UseVisualStyleBackColor = true;
            this.saveButtonCipher.Click += new System.EventHandler(this.saveButtonCipher_Click);
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(16, 37);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(205, 230);
            this.outputTextBox.TabIndex = 9;
            // 
            // resoultGroupBox
            // 
            this.resoultGroupBox.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.resoultGroupBox.Controls.Add(this.saveButtonDecipher);
            this.resoultGroupBox.Controls.Add(this.outputTextBox);
            this.resoultGroupBox.Controls.Add(this.saveButtonCipher);
            this.resoultGroupBox.Enabled = false;
            this.resoultGroupBox.Location = new System.Drawing.Point(418, 47);
            this.resoultGroupBox.Name = "resoultGroupBox";
            this.resoultGroupBox.Size = new System.Drawing.Size(236, 361);
            this.resoultGroupBox.TabIndex = 20;
            this.resoultGroupBox.TabStop = false;
            this.resoultGroupBox.Text = "Wynik";
            // 
            // saveButtonDecipher
            // 
            this.saveButtonDecipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButtonDecipher.Location = new System.Drawing.Point(117, 290);
            this.saveButtonDecipher.Name = "saveButtonDecipher";
            this.saveButtonDecipher.Size = new System.Drawing.Size(84, 57);
            this.saveButtonDecipher.TabIndex = 18;
            this.saveButtonDecipher.Text = "Odszyfruj i zapisz";
            this.saveButtonDecipher.UseVisualStyleBackColor = true;
            this.saveButtonDecipher.Click += new System.EventHandler(this.saveButtonDecipher_Click);
            // 
            // loadButton
            // 
            this.loadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.loadButton.Location = new System.Drawing.Point(52, 298);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(132, 57);
            this.loadButton.TabIndex = 18;
            this.loadButton.Text = "Wczytaj z pliku";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(7, 43);
            this.messageTextBox.Multiline = true;
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.messageTextBox.Size = new System.Drawing.Size(213, 230);
            this.messageTextBox.TabIndex = 2;
            this.messageTextBox.TextChanged += new System.EventHandler(this.messageTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.messageTextBox);
            this.groupBox2.Controls.Add(this.loadButton);
            this.groupBox2.Location = new System.Drawing.Point(30, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 369);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Wynik";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(903, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.resoultGroupBox);
            this.Controls.Add(this.newKeyButton);
            this.Controls.Add(this.newKeyTextBox);
            this.Controls.Add(this.currentKeyLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.decryptButton);
            this.Controls.Add(this.encryptButton);
            this.Controls.Add(this.generateRandomKeyButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Krypto";
            this.resoultGroupBox.ResumeLayout(false);
            this.resoultGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateRandomKeyButton;
        private System.Windows.Forms.Button encryptButton;
        private System.Windows.Forms.Button decryptButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label currentKeyLabel;
        private System.Windows.Forms.TextBox newKeyTextBox;
        private System.Windows.Forms.Button newKeyButton;
        private System.Windows.Forms.Button saveButtonCipher;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.GroupBox resoultGroupBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button saveButtonDecipher;
    }
}


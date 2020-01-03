namespace Cipher
{
    partial class CipherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SentenceLabel = new System.Windows.Forms.Label();
            this.SentenceTextBox = new System.Windows.Forms.TextBox();
            this.ShiftPasswordTextBox = new System.Windows.Forms.TextBox();
            this.ShiftPasswordLabel = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.DLLTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.CppCipherRadioButton = new System.Windows.Forms.RadioButton();
            this.ASMRadioButton = new System.Windows.Forms.RadioButton();
            this.InputGroupBox = new System.Windows.Forms.GroupBox();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.CipherTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.VigenereCipherRadioButton = new System.Windows.Forms.RadioButton();
            this.CaesarCipherRadioButton = new System.Windows.Forms.RadioButton();
            this.ActiveThreadsGroupBox = new System.Windows.Forms.GroupBox();
            this.CoresLabel = new System.Windows.Forms.Label();
            this.PhysicalLabel = new System.Windows.Forms.Label();
            this.LogicalLabel = new System.Windows.Forms.Label();
            this.ActiveThreadsComboBox = new System.Windows.Forms.ComboBox();
            this.CoresTitleLabel = new System.Windows.Forms.Label();
            this.PhysicalProcessorsTitleLabel = new System.Windows.Forms.Label();
            this.LogicalProcessorsTitleLabel = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.Encrypt = new System.Windows.Forms.Button();
            this.Decrypt = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DLLTypeGroupBox.SuspendLayout();
            this.InputGroupBox.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            this.logGroupBox.SuspendLayout();
            this.CipherTypeGroupBox.SuspendLayout();
            this.ActiveThreadsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SentenceLabel
            // 
            this.SentenceLabel.AutoSize = true;
            this.SentenceLabel.Location = new System.Drawing.Point(6, 47);
            this.SentenceLabel.Name = "SentenceLabel";
            this.SentenceLabel.Size = new System.Drawing.Size(72, 17);
            this.SentenceLabel.TabIndex = 1;
            this.SentenceLabel.Text = "Sentence:";
            this.SentenceLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // SentenceTextBox
            // 
            this.SentenceTextBox.Location = new System.Drawing.Point(84, 47);
            this.SentenceTextBox.Name = "SentenceTextBox";
            this.SentenceTextBox.Size = new System.Drawing.Size(346, 22);
            this.SentenceTextBox.TabIndex = 2;
            this.SentenceTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ShiftPasswordTextBox
            // 
            this.ShiftPasswordTextBox.Location = new System.Drawing.Point(120, 108);
            this.ShiftPasswordTextBox.Name = "ShiftPasswordTextBox";
            this.ShiftPasswordTextBox.Size = new System.Drawing.Size(310, 22);
            this.ShiftPasswordTextBox.TabIndex = 3;
            // 
            // ShiftPasswordLabel
            // 
            this.ShiftPasswordLabel.AutoSize = true;
            this.ShiftPasswordLabel.Location = new System.Drawing.Point(6, 111);
            this.ShiftPasswordLabel.Name = "ShiftPasswordLabel";
            this.ShiftPasswordLabel.Size = new System.Drawing.Size(105, 17);
            this.ShiftPasswordLabel.TabIndex = 4;
            this.ShiftPasswordLabel.Text = "Shift/Password:";
            this.ShiftPasswordLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(6, 47);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(52, 17);
            this.ResultLabel.TabIndex = 5;
            this.ResultLabel.Text = "Result:";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(64, 44);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(349, 22);
            this.ResultTextBox.TabIndex = 8;
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(15, 35);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(43, 17);
            this.TimeLabel.TabIndex = 9;
            this.TimeLabel.Text = "Time:";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(73, 32);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(340, 22);
            this.logTextBox.TabIndex = 10;
            // 
            // DLLTypeGroupBox
            // 
            this.DLLTypeGroupBox.Controls.Add(this.CppCipherRadioButton);
            this.DLLTypeGroupBox.Controls.Add(this.ASMRadioButton);
            this.DLLTypeGroupBox.Location = new System.Drawing.Point(12, 313);
            this.DLLTypeGroupBox.Name = "DLLTypeGroupBox";
            this.DLLTypeGroupBox.Size = new System.Drawing.Size(200, 95);
            this.DLLTypeGroupBox.TabIndex = 11;
            this.DLLTypeGroupBox.TabStop = false;
            this.DLLTypeGroupBox.Text = "DLL Type";
            this.DLLTypeGroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // CppCipherRadioButton
            // 
            this.CppCipherRadioButton.AutoSize = true;
            this.CppCipherRadioButton.Location = new System.Drawing.Point(9, 62);
            this.CppCipherRadioButton.Name = "CppCipherRadioButton";
            this.CppCipherRadioButton.Size = new System.Drawing.Size(54, 21);
            this.CppCipherRadioButton.TabIndex = 19;
            this.CppCipherRadioButton.TabStop = true;
            this.CppCipherRadioButton.Text = "C++";
            this.CppCipherRadioButton.UseVisualStyleBackColor = true;
            // 
            // ASMRadioButton
            // 
            this.ASMRadioButton.AutoSize = true;
            this.ASMRadioButton.Checked = true;
            this.ASMRadioButton.Location = new System.Drawing.Point(9, 35);
            this.ASMRadioButton.Name = "ASMRadioButton";
            this.ASMRadioButton.Size = new System.Drawing.Size(58, 21);
            this.ASMRadioButton.TabIndex = 18;
            this.ASMRadioButton.TabStop = true;
            this.ASMRadioButton.Text = "ASM";
            this.ASMRadioButton.UseVisualStyleBackColor = true;
            // 
            // InputGroupBox
            // 
            this.InputGroupBox.Controls.Add(this.SentenceTextBox);
            this.InputGroupBox.Controls.Add(this.SentenceLabel);
            this.InputGroupBox.Controls.Add(this.ShiftPasswordTextBox);
            this.InputGroupBox.Controls.Add(this.ShiftPasswordLabel);
            this.InputGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InputGroupBox.Name = "InputGroupBox";
            this.InputGroupBox.Size = new System.Drawing.Size(436, 169);
            this.InputGroupBox.TabIndex = 12;
            this.InputGroupBox.TabStop = false;
            this.InputGroupBox.Text = "Input";
            this.InputGroupBox.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.ResultTextBox);
            this.OutputGroupBox.Controls.Add(this.ResultLabel);
            this.OutputGroupBox.Location = new System.Drawing.Point(466, 12);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(419, 98);
            this.OutputGroupBox.TabIndex = 13;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "Output";
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.TimeLabel);
            this.logGroupBox.Controls.Add(this.logTextBox);
            this.logGroupBox.Location = new System.Drawing.Point(466, 129);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(419, 77);
            this.logGroupBox.TabIndex = 14;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "log";
            // 
            // CipherTypeGroupBox
            // 
            this.CipherTypeGroupBox.Controls.Add(this.VigenereCipherRadioButton);
            this.CipherTypeGroupBox.Controls.Add(this.CaesarCipherRadioButton);
            this.CipherTypeGroupBox.Location = new System.Drawing.Point(12, 207);
            this.CipherTypeGroupBox.Name = "CipherTypeGroupBox";
            this.CipherTypeGroupBox.Size = new System.Drawing.Size(200, 100);
            this.CipherTypeGroupBox.TabIndex = 15;
            this.CipherTypeGroupBox.TabStop = false;
            this.CipherTypeGroupBox.Text = "Cipher Type";
            // 
            // VigenereCipherRadioButton
            // 
            this.VigenereCipherRadioButton.AutoSize = true;
            this.VigenereCipherRadioButton.Location = new System.Drawing.Point(9, 58);
            this.VigenereCipherRadioButton.Name = "VigenereCipherRadioButton";
            this.VigenereCipherRadioButton.Size = new System.Drawing.Size(131, 21);
            this.VigenereCipherRadioButton.TabIndex = 19;
            this.VigenereCipherRadioButton.TabStop = true;
            this.VigenereCipherRadioButton.Text = "Vigenere Cipher";
            this.VigenereCipherRadioButton.UseVisualStyleBackColor = true;
            // 
            // CaesarCipherRadioButton
            // 
            this.CaesarCipherRadioButton.AutoSize = true;
            this.CaesarCipherRadioButton.Checked = true;
            this.CaesarCipherRadioButton.Location = new System.Drawing.Point(9, 31);
            this.CaesarCipherRadioButton.Name = "CaesarCipherRadioButton";
            this.CaesarCipherRadioButton.Size = new System.Drawing.Size(119, 21);
            this.CaesarCipherRadioButton.TabIndex = 18;
            this.CaesarCipherRadioButton.TabStop = true;
            this.CaesarCipherRadioButton.Text = "Caesar Cipher";
            this.CaesarCipherRadioButton.UseVisualStyleBackColor = true;
            this.CaesarCipherRadioButton.CheckedChanged += new System.EventHandler(this.CaesarCipherRadioButton_CheckedChanged);
            // 
            // ActiveThreadsGroupBox
            // 
            this.ActiveThreadsGroupBox.Controls.Add(this.CoresLabel);
            this.ActiveThreadsGroupBox.Controls.Add(this.PhysicalLabel);
            this.ActiveThreadsGroupBox.Controls.Add(this.LogicalLabel);
            this.ActiveThreadsGroupBox.Controls.Add(this.ActiveThreadsComboBox);
            this.ActiveThreadsGroupBox.Controls.Add(this.CoresTitleLabel);
            this.ActiveThreadsGroupBox.Controls.Add(this.PhysicalProcessorsTitleLabel);
            this.ActiveThreadsGroupBox.Controls.Add(this.LogicalProcessorsTitleLabel);
            this.ActiveThreadsGroupBox.Location = new System.Drawing.Point(466, 229);
            this.ActiveThreadsGroupBox.Name = "ActiveThreadsGroupBox";
            this.ActiveThreadsGroupBox.Size = new System.Drawing.Size(224, 170);
            this.ActiveThreadsGroupBox.TabIndex = 16;
            this.ActiveThreadsGroupBox.TabStop = false;
            this.ActiveThreadsGroupBox.Text = "Active Threads";
            // 
            // CoresLabel
            // 
            this.CoresLabel.AutoSize = true;
            this.CoresLabel.Location = new System.Drawing.Point(153, 136);
            this.CoresLabel.Name = "CoresLabel";
            this.CoresLabel.Size = new System.Drawing.Size(27, 17);
            this.CoresLabel.TabIndex = 20;
            this.CoresLabel.Text = "CN";
            // 
            // PhysicalLabel
            // 
            this.PhysicalLabel.AutoSize = true;
            this.PhysicalLabel.Location = new System.Drawing.Point(153, 105);
            this.PhysicalLabel.Name = "PhysicalLabel";
            this.PhysicalLabel.Size = new System.Drawing.Size(27, 17);
            this.PhysicalLabel.TabIndex = 19;
            this.PhysicalLabel.Text = "PN";
            // 
            // LogicalLabel
            // 
            this.LogicalLabel.AutoSize = true;
            this.LogicalLabel.Location = new System.Drawing.Point(153, 74);
            this.LogicalLabel.Name = "LogicalLabel";
            this.LogicalLabel.Size = new System.Drawing.Size(26, 17);
            this.LogicalLabel.TabIndex = 18;
            this.LogicalLabel.Text = "LN";
            // 
            // ActiveThreadsComboBox
            // 
            this.ActiveThreadsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ActiveThreadsComboBox.FormattingEnabled = true;
            this.ActiveThreadsComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63"});
            this.ActiveThreadsComboBox.Location = new System.Drawing.Point(6, 37);
            this.ActiveThreadsComboBox.Name = "ActiveThreadsComboBox";
            this.ActiveThreadsComboBox.Size = new System.Drawing.Size(174, 24);
            this.ActiveThreadsComboBox.TabIndex = 18;
            this.ActiveThreadsComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // CoresTitleLabel
            // 
            this.CoresTitleLabel.AutoSize = true;
            this.CoresTitleLabel.Location = new System.Drawing.Point(6, 136);
            this.CoresTitleLabel.Name = "CoresTitleLabel";
            this.CoresTitleLabel.Size = new System.Drawing.Size(45, 17);
            this.CoresTitleLabel.TabIndex = 18;
            this.CoresTitleLabel.Text = "Cores";
            // 
            // PhysicalProcessorsTitleLabel
            // 
            this.PhysicalProcessorsTitleLabel.AutoSize = true;
            this.PhysicalProcessorsTitleLabel.Location = new System.Drawing.Point(6, 105);
            this.PhysicalProcessorsTitleLabel.Name = "PhysicalProcessorsTitleLabel";
            this.PhysicalProcessorsTitleLabel.Size = new System.Drawing.Size(135, 17);
            this.PhysicalProcessorsTitleLabel.TabIndex = 17;
            this.PhysicalProcessorsTitleLabel.Text = "Physical Processors";
            // 
            // LogicalProcessorsTitleLabel
            // 
            this.LogicalProcessorsTitleLabel.AutoSize = true;
            this.LogicalProcessorsTitleLabel.Location = new System.Drawing.Point(6, 74);
            this.LogicalProcessorsTitleLabel.Name = "LogicalProcessorsTitleLabel";
            this.LogicalProcessorsTitleLabel.Size = new System.Drawing.Size(128, 17);
            this.LogicalProcessorsTitleLabel.TabIndex = 17;
            this.LogicalProcessorsTitleLabel.Text = "Logical Processors";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 425);
            this.splitter1.TabIndex = 17;
            this.splitter1.TabStop = false;
            // 
            // Encrypt
            // 
            this.Encrypt.Location = new System.Drawing.Point(30, 33);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Size = new System.Drawing.Size(150, 54);
            this.Encrypt.TabIndex = 18;
            this.Encrypt.Text = "Encrypt";
            this.Encrypt.UseVisualStyleBackColor = true;
            this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
            // 
            // Decrypt
            // 
            this.Decrypt.Location = new System.Drawing.Point(30, 108);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(150, 54);
            this.Decrypt.TabIndex = 19;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.UseVisualStyleBackColor = true;
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Encrypt);
            this.groupBox1.Controls.Add(this.Decrypt);
            this.groupBox1.Location = new System.Drawing.Point(248, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 176);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cipher Buttons";
            // 
            // CipherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 425);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.ActiveThreadsGroupBox);
            this.Controls.Add(this.CipherTypeGroupBox);
            this.Controls.Add(this.logGroupBox);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.InputGroupBox);
            this.Controls.Add(this.DLLTypeGroupBox);
            this.Name = "CipherForm";
            this.Text = "Cipher Military Program";
            this.Load += new System.EventHandler(this.Form_Load);
            this.DLLTypeGroupBox.ResumeLayout(false);
            this.DLLTypeGroupBox.PerformLayout();
            this.InputGroupBox.ResumeLayout(false);
            this.InputGroupBox.PerformLayout();
            this.OutputGroupBox.ResumeLayout(false);
            this.OutputGroupBox.PerformLayout();
            this.logGroupBox.ResumeLayout(false);
            this.logGroupBox.PerformLayout();
            this.CipherTypeGroupBox.ResumeLayout(false);
            this.CipherTypeGroupBox.PerformLayout();
            this.ActiveThreadsGroupBox.ResumeLayout(false);
            this.ActiveThreadsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label SentenceLabel;
        private System.Windows.Forms.TextBox SentenceTextBox;
        private System.Windows.Forms.TextBox ShiftPasswordTextBox;
        private System.Windows.Forms.Label ShiftPasswordLabel;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.GroupBox DLLTypeGroupBox;
        private System.Windows.Forms.GroupBox InputGroupBox;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.GroupBox CipherTypeGroupBox;
        private System.Windows.Forms.GroupBox ActiveThreadsGroupBox;
        private System.Windows.Forms.Label CoresTitleLabel;
        private System.Windows.Forms.Label PhysicalProcessorsTitleLabel;
        private System.Windows.Forms.Label LogicalProcessorsTitleLabel;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ComboBox ActiveThreadsComboBox;
        private System.Windows.Forms.Label CoresLabel;
        private System.Windows.Forms.Label PhysicalLabel;
        private System.Windows.Forms.Label LogicalLabel;
        private System.Windows.Forms.RadioButton CppCipherRadioButton;
        private System.Windows.Forms.RadioButton ASMRadioButton;
        private System.Windows.Forms.RadioButton VigenereCipherRadioButton;
        private System.Windows.Forms.RadioButton CaesarCipherRadioButton;
        private System.Windows.Forms.Button Encrypt;
        private System.Windows.Forms.Button Decrypt;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


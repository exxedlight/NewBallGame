namespace NewBallGame_WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            widthTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            heightTextBox = new TextBox();
            label3 = new Label();
            applySizeButton = new Button();
            GameFieldPanel = new Panel();
            energyTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            switchModeButton = new Button();
            saveGameButton = new Button();
            loadGameButton = new Button();
            loadFd = new OpenFileDialog();
            saveFd = new SaveFileDialog();
            creationProgressBar = new ProgressBar();
            SuspendLayout();
            // 
            // widthTextBox
            // 
            widthTextBox.Location = new Point(1134, 47);
            widthTextBox.Name = "widthTextBox";
            widthTextBox.Size = new Size(100, 33);
            widthTextBox.TabIndex = 1;
            widthTextBox.Text = "20";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1024, 51);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 2;
            label1.Text = "Ширина:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1024, 96);
            label2.Name = "label2";
            label2.Size = new Size(76, 25);
            label2.TabIndex = 3;
            label2.Text = "Висота:";
            // 
            // heightTextBox
            // 
            heightTextBox.Location = new Point(1134, 92);
            heightTextBox.Name = "heightTextBox";
            heightTextBox.Size = new Size(100, 33);
            heightTextBox.TabIndex = 4;
            heightTextBox.Text = "20";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1024, 12);
            label3.Name = "label3";
            label3.Size = new Size(231, 25);
            label3.TabIndex = 5;
            label3.Text = "---РОЗМІРИ ПОЛЯ-------";
            // 
            // applySizeButton
            // 
            applySizeButton.FlatStyle = FlatStyle.Flat;
            applySizeButton.Font = new Font("Segoe UI Black", 20.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            applySizeButton.Location = new Point(1072, 247);
            applySizeButton.Name = "applySizeButton";
            applySizeButton.Size = new Size(135, 45);
            applySizeButton.TabIndex = 6;
            applySizeButton.Text = "СТАРТ";
            applySizeButton.UseVisualStyleBackColor = true;
            applySizeButton.Click += applySizeButton_Click;
            // 
            // GameFieldPanel
            // 
            GameFieldPanel.BackColor = SystemColors.ActiveCaptionText;
            GameFieldPanel.BorderStyle = BorderStyle.FixedSingle;
            GameFieldPanel.Location = new Point(14, 12);
            GameFieldPanel.Name = "GameFieldPanel";
            GameFieldPanel.Size = new Size(996, 598);
            GameFieldPanel.TabIndex = 8;
            // 
            // energyTextBox
            // 
            energyTextBox.Location = new Point(1134, 193);
            energyTextBox.Name = "energyTextBox";
            energyTextBox.Size = new Size(100, 33);
            energyTextBox.TabIndex = 9;
            energyTextBox.Text = "10";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1024, 140);
            label4.Name = "label4";
            label4.Size = new Size(235, 25);
            label4.TabIndex = 10;
            label4.Text = "---КІЛЬКІСТЬ ЕНЕРГ.------";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1024, 196);
            label5.Name = "label5";
            label5.Size = new Size(80, 25);
            label5.TabIndex = 11;
            label5.Text = "Енергія:";
            // 
            // switchModeButton
            // 
            switchModeButton.Enabled = false;
            switchModeButton.FlatStyle = FlatStyle.Flat;
            switchModeButton.Location = new Point(1024, 542);
            switchModeButton.Name = "switchModeButton";
            switchModeButton.Size = new Size(220, 66);
            switchModeButton.TabIndex = 12;
            switchModeButton.Text = "Запустити м'яч";
            switchModeButton.UseVisualStyleBackColor = true;
            switchModeButton.Click += switchModeButton_Click;
            // 
            // saveGameButton
            // 
            saveGameButton.Enabled = false;
            saveGameButton.FlatStyle = FlatStyle.Flat;
            saveGameButton.Location = new Point(1025, 314);
            saveGameButton.Name = "saveGameButton";
            saveGameButton.Size = new Size(220, 66);
            saveGameButton.TabIndex = 13;
            saveGameButton.Text = "Зберегти гру";
            saveGameButton.UseVisualStyleBackColor = true;
            saveGameButton.Click += saveGameButton_Click;
            // 
            // loadGameButton
            // 
            loadGameButton.FlatStyle = FlatStyle.Flat;
            loadGameButton.Location = new Point(1025, 386);
            loadGameButton.Name = "loadGameButton";
            loadGameButton.Size = new Size(220, 66);
            loadGameButton.TabIndex = 14;
            loadGameButton.Text = "Завантажити гру";
            loadGameButton.UseVisualStyleBackColor = true;
            loadGameButton.Click += loadGameButton_Click;
            // 
            // loadFd
            // 
            loadFd.Filter = "Рівень|*.nbg";
            // 
            // saveFd
            // 
            saveFd.FileName = "level";
            saveFd.Filter = "Рівень|*.nbg";
            // 
            // creationProgressBar
            // 
            creationProgressBar.BackColor = Color.Black;
            creationProgressBar.ForeColor = SystemColors.Control;
            creationProgressBar.Location = new Point(1024, 476);
            creationProgressBar.Name = "creationProgressBar";
            creationProgressBar.Size = new Size(220, 23);
            creationProgressBar.Step = 1;
            creationProgressBar.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 52, 52);
            ClientSize = new Size(1257, 620);
            Controls.Add(creationProgressBar);
            Controls.Add(loadGameButton);
            Controls.Add(saveGameButton);
            Controls.Add(switchModeButton);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(energyTextBox);
            Controls.Add(GameFieldPanel);
            Controls.Add(applySizeButton);
            Controls.Add(label3);
            Controls.Add(heightTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(widthTextBox);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = SystemColors.ButtonFace;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(5);
            Name = "Form1";
            Text = "New Ball Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox widthTextBox;
        private Label label1;
        private Label label2;
        private TextBox heightTextBox;
        private Label label3;
        private Button applySizeButton;
        private Panel GameFieldPanel;
        private TextBox energyTextBox;
        private Label label4;
        private Label label5;
        private Button switchModeButton;
        private Button saveGameButton;
        private Button loadGameButton;
        private OpenFileDialog loadFd;
        private SaveFileDialog saveFd;
        private ProgressBar creationProgressBar;
    }
}
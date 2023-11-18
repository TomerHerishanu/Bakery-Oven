namespace Bakery_Oven
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
            onOff = new Label();
            currentTemp = new Label();
            currentTempNum = new Label();
            setTempButton = new Button();
            setTempLabel = new Label();
            comboBox1 = new ComboBox();
            inTheOvenLabel = new Label();
            inTheOvenNum = new Label();
            addLabel = new Label();
            chocolateButton = new Button();
            butterButton = new Button();
            almondButton = new Button();
            cheeseButton = new Button();
            readyLabel = new Label();
            readyNum = new Label();
            takeOutButton = new Button();
            SuspendLayout();
            // 
            // onOff
            // 
            onOff.AutoSize = true;
            onOff.Location = new Point(673, 6);
            onOff.Name = "onOff";
            onOff.Size = new Size(0, 25);
            onOff.TabIndex = 0;
            // 
            // currentTemp
            // 
            currentTemp.AutoSize = true;
            currentTemp.Location = new Point(10, 10);
            currentTemp.Name = "currentTemp";
            currentTemp.Size = new Size(177, 25);
            currentTemp.TabIndex = 1;
            currentTemp.Text = "Current Temperature:";
            // 
            // currentTempNum
            // 
            currentTempNum.AutoSize = true;
            currentTempNum.Location = new Point(183, 10);
            currentTempNum.Name = "currentTempNum";
            currentTempNum.Size = new Size(22, 25);
            currentTempNum.TabIndex = 2;
            currentTempNum.Text = "0";
            // 
            // setTempButton
            // 
            setTempButton.Location = new Point(289, 44);
            setTempButton.Name = "setTempButton";
            setTempButton.Size = new Size(112, 34);
            setTempButton.TabIndex = 3;
            setTempButton.Text = "Set";
            setTempButton.UseVisualStyleBackColor = true;
            setTempButton.Click += setTempButton_Click;
            // 
            // setTempLabel
            // 
            setTempLabel.AutoSize = true;
            setTempLabel.Location = new Point(10, 48);
            setTempLabel.Name = "setTempLabel";
            setTempLabel.Size = new Size(164, 25);
            setTempLabel.TabIndex = 4;
            setTempLabel.Text = "Set Temperature at:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(180, 45);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(94, 33);
            comboBox1.TabIndex = 5;
            // 
            // inTheOvenLabel
            // 
            inTheOvenLabel.AutoSize = true;
            inTheOvenLabel.Location = new Point(10, 152);
            inTheOvenLabel.Name = "inTheOvenLabel";
            inTheOvenLabel.Size = new Size(168, 25);
            inTheOvenLabel.TabIndex = 6;
            inTheOvenLabel.Text = "Pastries in the oven:";
            // 
            // inTheOvenNum
            // 
            inTheOvenNum.AutoSize = true;
            inTheOvenNum.Location = new Point(180, 152);
            inTheOvenNum.Name = "inTheOvenNum";
            inTheOvenNum.Size = new Size(22, 25);
            inTheOvenNum.TabIndex = 7;
            inTheOvenNum.Text = "0";
            // 
            // addLabel
            // 
            addLabel.AutoSize = true;
            addLabel.Location = new Point(10, 190);
            addLabel.Name = "addLabel";
            addLabel.Size = new Size(50, 25);
            addLabel.TabIndex = 8;
            addLabel.Text = "Add:";
            // 
            // chocolateButton
            // 
            chocolateButton.Location = new Point(75, 185);
            chocolateButton.Name = "chocolateButton";
            chocolateButton.Size = new Size(112, 34);
            chocolateButton.TabIndex = 9;
            chocolateButton.Text = "Chocolate";
            chocolateButton.UseVisualStyleBackColor = true;
            // 
            // butterButton
            // 
            butterButton.Location = new Point(226, 185);
            butterButton.Name = "butterButton";
            butterButton.Size = new Size(112, 34);
            butterButton.TabIndex = 10;
            butterButton.Text = "Butter";
            butterButton.UseVisualStyleBackColor = true;
            // 
            // almondButton
            // 
            almondButton.Location = new Point(75, 250);
            almondButton.Name = "almondButton";
            almondButton.Size = new Size(112, 34);
            almondButton.TabIndex = 11;
            almondButton.Text = "Almond";
            almondButton.UseVisualStyleBackColor = true;
            // 
            // cheeseButton
            // 
            cheeseButton.Location = new Point(226, 250);
            cheeseButton.Name = "cheeseButton";
            cheeseButton.Size = new Size(112, 34);
            cheeseButton.TabIndex = 12;
            cheeseButton.Text = "Cheese";
            cheeseButton.UseVisualStyleBackColor = true;
            // 
            // readyLabel
            // 
            readyLabel.AutoSize = true;
            readyLabel.Location = new Point(448, 152);
            readyLabel.Name = "readyLabel";
            readyLabel.Size = new Size(124, 25);
            readyLabel.TabIndex = 13;
            readyLabel.Text = "Pastries ready:";
            // 
            // readyNum
            // 
            readyNum.AutoSize = true;
            readyNum.Location = new Point(578, 152);
            readyNum.Name = "readyNum";
            readyNum.Size = new Size(22, 25);
            readyNum.TabIndex = 14;
            readyNum.Text = "0";
            // 
            // takeOutButton
            // 
            takeOutButton.Location = new Point(448, 185);
            takeOutButton.Name = "takeOutButton";
            takeOutButton.Size = new Size(112, 34);
            takeOutButton.TabIndex = 15;
            takeOutButton.Text = "Take them out!";
            takeOutButton.UseVisualStyleBackColor = true;
            takeOutButton.AutoSize = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(takeOutButton);
            Controls.Add(readyNum);
            Controls.Add(readyLabel);
            Controls.Add(cheeseButton);
            Controls.Add(almondButton);
            Controls.Add(butterButton);
            Controls.Add(chocolateButton);
            Controls.Add(addLabel);
            Controls.Add(inTheOvenNum);
            Controls.Add(inTheOvenLabel);
            Controls.Add(comboBox1);
            Controls.Add(setTempLabel);
            Controls.Add(setTempButton);
            Controls.Add(currentTempNum);
            Controls.Add(currentTemp);
            Controls.Add(onOff);
            Name = "Form1";
            Text = "Bakery Oven";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label onOff;
        private Label currentTemp;
        private Label currentTempNum;
        private Button setTempButton;
        private Label setTempLabel;
        private ComboBox comboBox1;
        private Label inTheOvenLabel;
        private Label inTheOvenNum;
        private Label addLabel;
        private Button chocolateButton;
        private Button butterButton;
        private Button almondButton;
        private Button cheeseButton;
        private Label readyLabel;
        private Label readyNum;
        private Button takeOutButton;
    }
}
namespace WinFormsApp
{
    partial class AdditionalForm
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
            maskedTextBox = new MaskedTextBox();
            textBoxName = new TextBox();
            buttonSave = new Button();
            buttonCancel = new Button();
            label = new Label();
            checkState = new CheckBox();
            checkDayOfTheWeek = new CheckBox();
            comboBox = new ComboBox();
            SuspendLayout();
            // 
            // maskedTextBox
            // 
            maskedTextBox.Font = new Font("Segoe UI", 32F, FontStyle.Regular, GraphicsUnit.Point);
            maskedTextBox.Location = new Point(12, 12);
            maskedTextBox.Mask = "00:00";
            maskedTextBox.Name = "maskedTextBox";
            maskedTextBox.Size = new Size(210, 64);
            maskedTextBox.TabIndex = 0;
            maskedTextBox.TextAlign = HorizontalAlignment.Center;
            maskedTextBox.ValidatingType = typeof(DateTime);
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 120);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(210, 23);
            textBoxName.TabIndex = 1;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 246);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(93, 23);
            buttonSave.TabIndex = 2;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(127, 246);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(95, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(12, 102);
            label.Name = "label";
            label.Size = new Size(127, 15);
            label.TabIndex = 4;
            label.Text = "Название будильника";
            // 
            // checkState
            // 
            checkState.AutoSize = true;
            checkState.Location = new Point(12, 149);
            checkState.Name = "checkState";
            checkState.Size = new Size(76, 19);
            checkState.TabIndex = 5;
            checkState.Text = "Включен";
            checkState.UseVisualStyleBackColor = true;
            // 
            // checkDayOfTheWeek
            // 
            checkDayOfTheWeek.AutoSize = true;
            checkDayOfTheWeek.Location = new Point(12, 174);
            checkDayOfTheWeek.Name = "checkDayOfTheWeek";
            checkDayOfTheWeek.Size = new Size(81, 19);
            checkDayOfTheWeek.TabIndex = 6;
            checkDayOfTheWeek.Text = "Выходной";
            checkDayOfTheWeek.UseVisualStyleBackColor = true;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(12, 199);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(210, 23);
            comboBox.TabIndex = 7;
            // 
            // AdditionalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 281);
            Controls.Add(comboBox);
            Controls.Add(checkDayOfTheWeek);
            Controls.Add(checkState);
            Controls.Add(label);
            Controls.Add(buttonCancel);
            Controls.Add(buttonSave);
            Controls.Add(textBoxName);
            Controls.Add(maskedTextBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AdditionalForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdditionalForm";
            Load += AdditionalForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox maskedTextBox;
        private TextBox textBoxName;
        private Button buttonSave;
        private Button buttonCancel;
        private Label label;
        private CheckBox checkState;
        private CheckBox checkDayOfTheWeek;
        private ComboBox comboBox;
    }
}
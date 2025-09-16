namespace Developer_Toolbox
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
            inRichTextBox = new RichTextBox();
            inLabel = new Label();
            outLabel = new Label();
            outRichTextBox = new RichTextBox();
            transformButton = new Button();
            tranformLabel = new Label();
            choseOptionComboBox = new ComboBox();
            autoCopyCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // inRichTextBox
            // 
            inRichTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inRichTextBox.BorderStyle = BorderStyle.FixedSingle;
            inRichTextBox.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            inRichTextBox.Location = new Point(12, 27);
            inRichTextBox.Name = "inRichTextBox";
            inRichTextBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            inRichTextBox.Size = new Size(624, 203);
            inRichTextBox.TabIndex = 1;
            inRichTextBox.Text = "";
            // 
            // inLabel
            // 
            inLabel.AutoSize = true;
            inLabel.Location = new Point(12, 9);
            inLabel.Name = "inLabel";
            inLabel.Size = new Size(36, 15);
            inLabel.TabIndex = 2;
            inLabel.Text = "Ввод:";
            // 
            // outLabel
            // 
            outLabel.AutoSize = true;
            outLabel.Location = new Point(12, 286);
            outLabel.Name = "outLabel";
            outLabel.Size = new Size(36, 15);
            outLabel.TabIndex = 4;
            outLabel.Text = "Ввод:";
            // 
            // outRichTextBox
            // 
            outRichTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            outRichTextBox.BorderStyle = BorderStyle.FixedSingle;
            outRichTextBox.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            outRichTextBox.Location = new Point(12, 304);
            outRichTextBox.Name = "outRichTextBox";
            outRichTextBox.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            outRichTextBox.Size = new Size(624, 203);
            outRichTextBox.TabIndex = 3;
            outRichTextBox.Text = "";
            // 
            // transformButton
            // 
            transformButton.Location = new Point(174, 251);
            transformButton.Name = "transformButton";
            transformButton.Size = new Size(273, 32);
            transformButton.TabIndex = 5;
            transformButton.Text = "Сделать магию!";
            transformButton.UseVisualStyleBackColor = true;
            transformButton.Click += Transform;
            // 
            // tranformLabel
            // 
            tranformLabel.AutoSize = true;
            tranformLabel.Location = new Point(12, 233);
            tranformLabel.Name = "tranformLabel";
            tranformLabel.Size = new Size(94, 15);
            tranformLabel.TabIndex = 6;
            tranformLabel.Text = "Преобразовать:";
            // 
            // choseOptionComboBox
            // 
            choseOptionComboBox.FormattingEnabled = true;
            choseOptionComboBox.Location = new Point(12, 257);
            choseOptionComboBox.Name = "choseOptionComboBox";
            choseOptionComboBox.Size = new Size(156, 23);
            choseOptionComboBox.TabIndex = 7;
            // 
            // autoCopyCheckBox
            // 
            autoCopyCheckBox.AutoSize = true;
            autoCopyCheckBox.Location = new Point(453, 259);
            autoCopyCheckBox.Name = "autoCopyCheckBox";
            autoCopyCheckBox.Size = new Size(183, 19);
            autoCopyCheckBox.TabIndex = 8;
            autoCopyCheckBox.Text = "Копировать в буфер обмена";
            autoCopyCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 519);
            Controls.Add(autoCopyCheckBox);
            Controls.Add(choseOptionComboBox);
            Controls.Add(tranformLabel);
            Controls.Add(transformButton);
            Controls.Add(outLabel);
            Controls.Add(outRichTextBox);
            Controls.Add(inLabel);
            Controls.Add(inRichTextBox);
            MaximumSize = new Size(664, 558);
            MinimizeBox = false;
            MinimumSize = new Size(664, 558);
            Name = "Form1";
            Text = "Преобразователь данных";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox inRichTextBox;
        private Label inLabel;
        private Label outLabel;
        private RichTextBox outRichTextBox;
        private Button transformButton;
        private Label tranformLabel;
        private ComboBox choseOptionComboBox;
        private CheckBox autoCopyCheckBox;
    }
}

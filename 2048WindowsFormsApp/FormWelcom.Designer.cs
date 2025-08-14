namespace _2048WindowsFormsApp
{
    partial class FormWelcom
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
            this.labelWelcom = new System.Windows.Forms.Label();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelMapSize = new System.Windows.Forms.Label();
            this.radioButtonSize4 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize5 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize6 = new System.Windows.Forms.RadioButton();
            this.radioButtonSize7 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // labelWelcom
            // 
            this.labelWelcom.AutoSize = true;
            this.labelWelcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcom.Location = new System.Drawing.Point(84, 114);
            this.labelWelcom.Name = "labelWelcom";
            this.labelWelcom.Size = new System.Drawing.Size(144, 16);
            this.labelWelcom.TabIndex = 0;
            this.labelWelcom.Text = "Введите свое имя:";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUserName.Location = new System.Drawing.Point(65, 147);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(180, 22);
            this.textBoxUserName.TabIndex = 1;
            this.textBoxUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUserName_KeyDown);
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(80, 200);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(148, 33);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "&Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelMapSize
            // 
            this.labelMapSize.AutoSize = true;
            this.labelMapSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMapSize.Location = new System.Drawing.Point(23, 19);
            this.labelMapSize.Name = "labelMapSize";
            this.labelMapSize.Size = new System.Drawing.Size(254, 16);
            this.labelMapSize.TabIndex = 3;
            this.labelMapSize.Text = "Выберите размер игрового поля:";
            // 
            // radioButtonSize4
            // 
            this.radioButtonSize4.AccessibleName = "4";
            this.radioButtonSize4.AutoSize = true;
            this.radioButtonSize4.Checked = true;
            this.radioButtonSize4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonSize4.Location = new System.Drawing.Point(26, 60);
            this.radioButtonSize4.Name = "radioButtonSize4";
            this.radioButtonSize4.Size = new System.Drawing.Size(48, 20);
            this.radioButtonSize4.TabIndex = 4;
            this.radioButtonSize4.TabStop = true;
            this.radioButtonSize4.Text = "4x4";
            this.radioButtonSize4.UseVisualStyleBackColor = true;
            // 
            // radioButtonSize5
            // 
            this.radioButtonSize5.AccessibleName = "5";
            this.radioButtonSize5.AutoSize = true;
            this.radioButtonSize5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonSize5.Location = new System.Drawing.Point(87, 60);
            this.radioButtonSize5.Name = "radioButtonSize5";
            this.radioButtonSize5.Size = new System.Drawing.Size(48, 20);
            this.radioButtonSize5.TabIndex = 5;
            this.radioButtonSize5.Text = "5x5";
            this.radioButtonSize5.UseVisualStyleBackColor = true;
            // 
            // radioButtonSize6
            // 
            this.radioButtonSize6.AccessibleName = "6";
            this.radioButtonSize6.AutoSize = true;
            this.radioButtonSize6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonSize6.Location = new System.Drawing.Point(159, 60);
            this.radioButtonSize6.Name = "radioButtonSize6";
            this.radioButtonSize6.Size = new System.Drawing.Size(48, 20);
            this.radioButtonSize6.TabIndex = 6;
            this.radioButtonSize6.Text = "6x6";
            this.radioButtonSize6.UseVisualStyleBackColor = true;
            // 
            // radioButtonSize7
            // 
            this.radioButtonSize7.AccessibleName = "7";
            this.radioButtonSize7.AutoSize = true;
            this.radioButtonSize7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonSize7.Location = new System.Drawing.Point(229, 60);
            this.radioButtonSize7.Name = "radioButtonSize7";
            this.radioButtonSize7.Size = new System.Drawing.Size(48, 20);
            this.radioButtonSize7.TabIndex = 7;
            this.radioButtonSize7.Text = "7x7";
            this.radioButtonSize7.UseVisualStyleBackColor = true;
            // 
            // FormWelcom
            // 
            this.AccessibleDescription = "4";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 275);
            this.Controls.Add(this.radioButtonSize7);
            this.Controls.Add(this.radioButtonSize6);
            this.Controls.Add(this.radioButtonSize5);
            this.Controls.Add(this.radioButtonSize4);
            this.Controls.Add(this.labelMapSize);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxUserName);
            this.Controls.Add(this.labelWelcom);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWelcom";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Представтесь";
            this.Load += new System.EventHandler(this.FormWelcom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcom;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelMapSize;
        private System.Windows.Forms.RadioButton radioButtonSize4;
        private System.Windows.Forms.RadioButton radioButtonSize5;
        private System.Windows.Forms.RadioButton radioButtonSize6;
        private System.Windows.Forms.RadioButton radioButtonSize7;
    }
}
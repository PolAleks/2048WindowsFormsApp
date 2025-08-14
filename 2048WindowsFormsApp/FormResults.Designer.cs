namespace _2048WindowsFormsApp
{
    partial class FormResults
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
            this.resultsDataGridView = new System.Windows.Forms.DataGridView();
            this.NameUserColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoreUserColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultsDataGridView
            // 
            this.resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameUserColumn,
            this.scoreUserColumn});
            this.resultsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.resultsDataGridView.Name = "resultsDataGridView";
            this.resultsDataGridView.Size = new System.Drawing.Size(462, 243);
            this.resultsDataGridView.TabIndex = 0;
            // 
            // NameUserColumn
            // 
            this.NameUserColumn.HeaderText = "Имя игрока";
            this.NameUserColumn.Name = "NameUserColumn";
            this.NameUserColumn.Width = 200;
            // 
            // scoreUserColumn
            // 
            this.scoreUserColumn.HeaderText = "Результат";
            this.scoreUserColumn.Name = "scoreUserColumn";
            this.scoreUserColumn.Width = 200;
            // 
            // FormResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 240);
            this.Controls.Add(this.resultsDataGridView);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormResults";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Результаты предыдущих игр";
            this.Load += new System.EventHandler(this.FormResults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameUserColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoreUserColumn;
    }
}
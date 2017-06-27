namespace Server_Storage
{
    partial class results
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
            this.results_dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.results_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // results_dgv
            // 
            this.results_dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.results_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.results_dgv.Location = new System.Drawing.Point(13, 8);
            this.results_dgv.Name = "results_dgv";
            this.results_dgv.Size = new System.Drawing.Size(240, 490);
            this.results_dgv.TabIndex = 0;
            this.results_dgv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.results_dgv_MouseClick);
            // 
            // results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 510);
            this.Controls.Add(this.results_dgv);
            this.Name = "results";
            this.Text = "results";
            this.Load += new System.EventHandler(this.results_Load);
            ((System.ComponentModel.ISupportInitialize)(this.results_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView results_dgv;
    }
}
namespace VisEx
{
    partial class FrmExperiment
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
            this.SuspendLayout();
            // 
            // FrmExperiment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(617, 382);
            this.Name = "FrmExperiment";
            this.Text = "Experiment";
            this.Load += new System.EventHandler(this.FrmExperiment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmExperiment_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FrmExperiment_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
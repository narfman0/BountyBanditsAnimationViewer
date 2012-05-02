namespace BountyBanditsAnimationViewer
{
    partial class UI
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
            this.loadButton = new System.Windows.Forms.Button();
            this.animLabel = new System.Windows.Forms.Label();
            this.animCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(13, 13);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // animLabel
            // 
            this.animLabel.AutoSize = true;
            this.animLabel.Location = new System.Drawing.Point(10, 46);
            this.animLabel.Name = "animLabel";
            this.animLabel.Size = new System.Drawing.Size(53, 13);
            this.animLabel.TabIndex = 1;
            this.animLabel.Text = "Animation";
            // 
            // animCombo
            // 
            this.animCombo.Enabled = false;
            this.animCombo.FormattingEnabled = true;
            this.animCombo.Location = new System.Drawing.Point(72, 43);
            this.animCombo.Name = "animCombo";
            this.animCombo.Size = new System.Drawing.Size(121, 21);
            this.animCombo.TabIndex = 2;
            this.animCombo.SelectedIndexChanged += new System.EventHandler(this.animCombo_SelectedIndexChanged);
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.animCombo);
            this.Controls.Add(this.animLabel);
            this.Controls.Add(this.loadButton);
            this.Name = "UI";
            this.Text = "UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label animLabel;
        public System.Windows.Forms.ComboBox animCombo;
    }
}
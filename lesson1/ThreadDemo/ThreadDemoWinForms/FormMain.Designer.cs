
namespace ThreadDemoWinForms
{
    partial class FormMain
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
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.textBoxFibonacci = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelInterval = new System.Windows.Forms.Label();
            this.labelFibonacci = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Location = new System.Drawing.Point(65, 60);
            this.numericUpDownInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(150, 27);
            this.numericUpDownInterval.TabIndex = 0;
            this.numericUpDownInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBoxFibonacci
            // 
            this.textBoxFibonacci.Location = new System.Drawing.Point(320, 60);
            this.textBoxFibonacci.Name = "textBoxFibonacci";
            this.textBoxFibonacci.Size = new System.Drawing.Size(125, 27);
            this.textBoxFibonacci.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(221, 147);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(94, 29);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(65, 37);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(58, 20);
            this.labelInterval.TabIndex = 3;
            this.labelInterval.Text = "Interval";
            // 
            // labelFibonacci
            // 
            this.labelFibonacci.AutoSize = true;
            this.labelFibonacci.Location = new System.Drawing.Point(320, 37);
            this.labelFibonacci.Name = "labelFibonacci";
            this.labelFibonacci.Size = new System.Drawing.Size(72, 20);
            this.labelFibonacci.TabIndex = 4;
            this.labelFibonacci.Text = "Fibonacci";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 245);
            this.Controls.Add(this.labelFibonacci);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxFibonacci);
            this.Controls.Add(this.numericUpDownInterval);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.TextBox textBoxFibonacci;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Label labelFibonacci;
    }
}


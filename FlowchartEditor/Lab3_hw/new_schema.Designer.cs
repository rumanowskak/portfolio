
namespace Lab3_hw
{
    partial class New_schema
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
            this.height = new System.Windows.Forms.NumericUpDown();
            this.width = new System.Windows.Forms.NumericUpDown();
            this.ok_button = new System.Windows.Forms.Button();
            this.height_label = new System.Windows.Forms.Label();
            this.width_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.height)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).BeginInit();
            this.SuspendLayout();
            // 
            // height
            // 
            this.height.Location = new System.Drawing.Point(107, 54);
            this.height.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.height.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.height.Name = "height";
            this.height.Size = new System.Drawing.Size(150, 27);
            this.height.TabIndex = 0;
            this.height.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.height.ValueChanged += new System.EventHandler(this.height_ValueChanged);
            // 
            // width
            // 
            this.width.Location = new System.Drawing.Point(108, 12);
            this.width.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.width.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.width.Name = "width";
            this.width.Size = new System.Drawing.Size(150, 27);
            this.width.TabIndex = 1;
            this.width.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.width.ValueChanged += new System.EventHandler(this.width_ValueChanged);
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(107, 109);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(68, 36);
            this.ok_button.TabIndex = 2;
            this.ok_button.Text = "OK";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // height_label
            // 
            this.height_label.AutoSize = true;
            this.height_label.Location = new System.Drawing.Point(24, 56);
            this.height_label.Name = "height_label";
            this.height_label.Size = new System.Drawing.Size(77, 20);
            this.height_label.TabIndex = 3;
            this.height_label.Text = "Wysokość:";
            this.height_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // width_label
            // 
            this.width_label.AutoSize = true;
            this.width_label.Location = new System.Drawing.Point(24, 14);
            this.width_label.Name = "width_label";
            this.width_label.Size = new System.Drawing.Size(78, 20);
            this.width_label.TabIndex = 4;
            this.width_label.Text = "Szerokość:";
            // 
            // New_schema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 157);
            this.Controls.Add(this.width_label);
            this.Controls.Add(this.height_label);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.width);
            this.Controls.Add(this.height);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "New_schema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nowy Schemat";
            this.Load += new System.EventHandler(this.new_schema_Load);
            ((System.ComponentModel.ISupportInitialize)(this.height)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.width)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Label height_label;
        private System.Windows.Forms.Label width_label;
    }
}
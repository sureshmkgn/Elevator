namespace ElevatorApp
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtFloor = new System.Windows.Forms.TextBox();
            this.lblFloor = new System.Windows.Forms.Label();
            this.lblElevators = new System.Windows.Forms.Label();
            this.txtElevators = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(377, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Press Down From 3rd Floor";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFloor
            // 
            this.txtFloor.Location = new System.Drawing.Point(341, 35);
            this.txtFloor.Name = "txtFloor";
            this.txtFloor.ReadOnly = true;
            this.txtFloor.Size = new System.Drawing.Size(100, 20);
            this.txtFloor.TabIndex = 1;
            this.txtFloor.Text = "12";
            // 
            // lblFloor
            // 
            this.lblFloor.AutoSize = true;
            this.lblFloor.Location = new System.Drawing.Point(237, 38);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(87, 13);
            this.lblFloor.TabIndex = 2;
            this.lblFloor.Text = "Number of Floors";
            this.lblFloor.UseWaitCursor = true;
            // 
            // lblElevators
            // 
            this.lblElevators.AutoSize = true;
            this.lblElevators.Location = new System.Drawing.Point(237, 80);
            this.lblElevators.Name = "lblElevators";
            this.lblElevators.Size = new System.Drawing.Size(103, 13);
            this.lblElevators.TabIndex = 6;
            this.lblElevators.Text = "Number of Elevators";
            this.lblElevators.UseWaitCursor = true;
            // 
            // txtElevators
            // 
            this.txtElevators.Location = new System.Drawing.Point(341, 77);
            this.txtElevators.Name = "txtElevators";
            this.txtElevators.ReadOnly = true;
            this.txtElevators.Size = new System.Drawing.Size(100, 20);
            this.txtElevators.TabIndex = 5;
            this.txtElevators.Text = "3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblElevators);
            this.Controls.Add(this.txtElevators);
            this.Controls.Add(this.lblFloor);
            this.Controls.Add(this.txtFloor);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFloor;
        private System.Windows.Forms.Label lblFloor;
        private System.Windows.Forms.Label lblElevators;
        private System.Windows.Forms.TextBox txtElevators;
    }
}


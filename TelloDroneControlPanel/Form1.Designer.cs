namespace TelloDroneControlPanel
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnTakeOff = new System.Windows.Forms.Button();
            this.btnLand = new System.Windows.Forms.Button();
            this.btnEmergency = new System.Windows.Forms.Button();
            this.lblConnection = new System.Windows.Forms.Label();
            this.btnCommand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(21, 22);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(115, 42);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(321, 74);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 47);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(469, 74);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(77, 47);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(394, 22);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(75, 46);
            this.btnUp.TabIndex = 3;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(394, 127);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 44);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // btnTakeOff
            // 
            this.btnTakeOff.Location = new System.Drawing.Point(21, 70);
            this.btnTakeOff.Name = "btnTakeOff";
            this.btnTakeOff.Size = new System.Drawing.Size(115, 59);
            this.btnTakeOff.TabIndex = 5;
            this.btnTakeOff.Text = "TakeOff";
            this.btnTakeOff.UseVisualStyleBackColor = true;
            this.btnTakeOff.Click += new System.EventHandler(this.BtnTakeOff_Click);
            // 
            // btnLand
            // 
            this.btnLand.Location = new System.Drawing.Point(142, 70);
            this.btnLand.Name = "btnLand";
            this.btnLand.Size = new System.Drawing.Size(115, 59);
            this.btnLand.TabIndex = 6;
            this.btnLand.Text = "Land";
            this.btnLand.UseVisualStyleBackColor = true;
            this.btnLand.Click += new System.EventHandler(this.BtnLand_Click);
            // 
            // btnEmergency
            // 
            this.btnEmergency.Location = new System.Drawing.Point(21, 135);
            this.btnEmergency.Name = "btnEmergency";
            this.btnEmergency.Size = new System.Drawing.Size(236, 42);
            this.btnEmergency.TabIndex = 7;
            this.btnEmergency.Text = "Emergency";
            this.btnEmergency.UseVisualStyleBackColor = true;
            this.btnEmergency.Click += new System.EventHandler(this.BtnEmergency_Click);
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblConnection.Location = new System.Drawing.Point(157, 22);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(0, 17);
            this.lblConnection.TabIndex = 8;
            // 
            // btnCommand
            // 
            this.btnCommand.Location = new System.Drawing.Point(21, 183);
            this.btnCommand.Name = "btnCommand";
            this.btnCommand.Size = new System.Drawing.Size(236, 42);
            this.btnCommand.TabIndex = 9;
            this.btnCommand.Text = "Command";
            this.btnCommand.UseVisualStyleBackColor = true;
            this.btnCommand.Click += new System.EventHandler(this.BtnCommand_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 296);
            this.Controls.Add(this.btnCommand);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.btnEmergency);
            this.Controls.Add(this.btnLand);
            this.Controls.Add(this.btnTakeOff);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnConnect);
            this.Name = "Form1";
            this.Text = "Drone Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnTakeOff;
        private System.Windows.Forms.Button btnLand;
        private System.Windows.Forms.Button btnEmergency;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Button btnCommand;
    }
}


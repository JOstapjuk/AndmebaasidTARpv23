namespace AndmebaasidTARpv23
{
    partial class Form2
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
            this.txtLaoNimetus = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddLadu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSuurus = new System.Windows.Forms.TextBox();
            this.txtKirjeldus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLaoNimetus
            // 
            this.txtLaoNimetus.Location = new System.Drawing.Point(220, 69);
            this.txtLaoNimetus.Name = "txtLaoNimetus";
            this.txtLaoNimetus.Size = new System.Drawing.Size(138, 26);
            this.txtLaoNimetus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lao nimetus";
            // 
            // btnAddLadu
            // 
            this.btnAddLadu.Location = new System.Drawing.Point(19, 275);
            this.btnAddLadu.Name = "btnAddLadu";
            this.btnAddLadu.Size = new System.Drawing.Size(117, 41);
            this.btnAddLadu.TabIndex = 2;
            this.btnAddLadu.Text = "Lisa ladu";
            this.btnAddLadu.UseVisualStyleBackColor = true;
            this.btnAddLadu.Click += new System.EventHandler(this.btnAddLadu_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 37);
            this.label2.TabIndex = 3;
            this.label2.Text = "Suurus";
            // 
            // txtSuurus
            // 
            this.txtSuurus.Location = new System.Drawing.Point(220, 132);
            this.txtSuurus.Name = "txtSuurus";
            this.txtSuurus.Size = new System.Drawing.Size(138, 26);
            this.txtSuurus.TabIndex = 4;
            // 
            // txtKirjeldus
            // 
            this.txtKirjeldus.Location = new System.Drawing.Point(220, 195);
            this.txtKirjeldus.Name = "txtKirjeldus";
            this.txtKirjeldus.Size = new System.Drawing.Size(138, 26);
            this.txtKirjeldus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "KIrjeldus";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(169, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 41);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Tühista";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKirjeldus);
            this.Controls.Add(this.txtSuurus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddLadu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLaoNimetus);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLaoNimetus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddLadu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSuurus;
        private System.Windows.Forms.TextBox txtKirjeldus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
    }
}
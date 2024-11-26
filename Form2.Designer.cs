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
            this.Uuenda_btn = new System.Windows.Forms.Button();
            this.Kustuta_btn = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.IdTxt = new System.Windows.Forms.TextBox();
            this.IdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLaoNimetus
            // 
            this.txtLaoNimetus.Location = new System.Drawing.Point(147, 45);
            this.txtLaoNimetus.Margin = new System.Windows.Forms.Padding(2);
            this.txtLaoNimetus.Name = "txtLaoNimetus";
            this.txtLaoNimetus.Size = new System.Drawing.Size(93, 20);
            this.txtLaoNimetus.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lao nimetus";
            // 
            // btnAddLadu
            // 
            this.btnAddLadu.Location = new System.Drawing.Point(13, 179);
            this.btnAddLadu.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddLadu.Name = "btnAddLadu";
            this.btnAddLadu.Size = new System.Drawing.Size(78, 27);
            this.btnAddLadu.TabIndex = 2;
            this.btnAddLadu.Text = "Lisa ladu";
            this.btnAddLadu.UseVisualStyleBackColor = true;
            this.btnAddLadu.Click += new System.EventHandler(this.btnAddLadu_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Suurus";
            // 
            // txtSuurus
            // 
            this.txtSuurus.Location = new System.Drawing.Point(147, 86);
            this.txtSuurus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSuurus.Name = "txtSuurus";
            this.txtSuurus.Size = new System.Drawing.Size(93, 20);
            this.txtSuurus.TabIndex = 4;
            // 
            // txtKirjeldus
            // 
            this.txtKirjeldus.Location = new System.Drawing.Point(147, 127);
            this.txtKirjeldus.Margin = new System.Windows.Forms.Padding(2);
            this.txtKirjeldus.Name = "txtKirjeldus";
            this.txtKirjeldus.Size = new System.Drawing.Size(93, 20);
            this.txtKirjeldus.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 26);
            this.label3.TabIndex = 6;
            this.label3.Text = "KIrjeldus";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(293, 179);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 27);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Tühista";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // Uuenda_btn
            // 
            this.Uuenda_btn.Location = new System.Drawing.Point(109, 179);
            this.Uuenda_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Uuenda_btn.Name = "Uuenda_btn";
            this.Uuenda_btn.Size = new System.Drawing.Size(78, 27);
            this.Uuenda_btn.TabIndex = 8;
            this.Uuenda_btn.Text = "Uuenda ladu";
            this.Uuenda_btn.UseVisualStyleBackColor = true;
            this.Uuenda_btn.Click += new System.EventHandler(this.Uuenda_btn_Click);
            // 
            // Kustuta_btn
            // 
            this.Kustuta_btn.Location = new System.Drawing.Point(201, 179);
            this.Kustuta_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Kustuta_btn.Name = "Kustuta_btn";
            this.Kustuta_btn.Size = new System.Drawing.Size(78, 27);
            this.Kustuta_btn.TabIndex = 9;
            this.Kustuta_btn.Text = "Kustuta ladu";
            this.Kustuta_btn.UseVisualStyleBackColor = true;
            this.Kustuta_btn.Click += new System.EventHandler(this.Kustuta_btn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(39, 258);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(446, 150);
            this.dataGridView2.TabIndex = 10;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // IdTxt
            // 
            this.IdTxt.Location = new System.Drawing.Point(322, 44);
            this.IdTxt.Margin = new System.Windows.Forms.Padding(2);
            this.IdTxt.Name = "IdTxt";
            this.IdTxt.Size = new System.Drawing.Size(93, 20);
            this.IdTxt.TabIndex = 11;
            // 
            // IdLabel
            // 
            this.IdLabel.AutoSize = true;
            this.IdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IdLabel.Location = new System.Drawing.Point(288, 39);
            this.IdLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.IdLabel.Name = "IdLabel";
            this.IdLabel.Size = new System.Drawing.Size(30, 26);
            this.IdLabel.TabIndex = 12;
            this.IdLabel.Text = "Id";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 420);
            this.Controls.Add(this.IdLabel);
            this.Controls.Add(this.IdTxt);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.Kustuta_btn);
            this.Controls.Add(this.Uuenda_btn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtKirjeldus);
            this.Controls.Add(this.txtSuurus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddLadu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLaoNimetus);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.Button Uuenda_btn;
        private System.Windows.Forms.Button Kustuta_btn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox IdTxt;
        private System.Windows.Forms.Label IdLabel;
    }
}
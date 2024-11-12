namespace AndmebaasidTARpv23
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Nimetus_txt = new System.Windows.Forms.TextBox();
            this.Kogus_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Hind_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.andmebaasDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Btn_lisa = new System.Windows.Forms.Button();
            this.andmebaas = new AndmebaasidTARpv23.Andmebaas();
            this.andmebaasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Btn_kustuta = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Id_txt = new System.Windows.Forms.TextBox();
            this.Uuenda_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaasDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(13, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nimetus";
            // 
            // Nimetus_txt
            // 
            this.Nimetus_txt.Location = new System.Drawing.Point(112, 84);
            this.Nimetus_txt.Name = "Nimetus_txt";
            this.Nimetus_txt.Size = new System.Drawing.Size(100, 20);
            this.Nimetus_txt.TabIndex = 1;
            // 
            // Kogus_txt
            // 
            this.Kogus_txt.Location = new System.Drawing.Point(112, 119);
            this.Kogus_txt.Name = "Kogus_txt";
            this.Kogus_txt.Size = new System.Drawing.Size(100, 20);
            this.Kogus_txt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(32, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kogus";
            // 
            // Hind_txt
            // 
            this.Hind_txt.Location = new System.Drawing.Point(112, 155);
            this.Hind_txt.Name = "Hind_txt";
            this.Hind_txt.Size = new System.Drawing.Size(100, 20);
            this.Hind_txt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.Location = new System.Drawing.Point(49, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hind";
            // 
            // Btn_lisa
            // 
            this.Btn_lisa.Location = new System.Drawing.Point(37, 195);
            this.Btn_lisa.Name = "Btn_lisa";
            this.Btn_lisa.Size = new System.Drawing.Size(89, 29);
            this.Btn_lisa.TabIndex = 7;
            this.Btn_lisa.Text = "Lisa andmed";
            this.Btn_lisa.UseVisualStyleBackColor = true;
            this.Btn_lisa.Click += new System.EventHandler(this.Btn_lisa_Click);
            // 
            // andmebaas
            // 
            this.andmebaas.DataSetName = "Andmebaas";
            this.andmebaas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // andmebaasBindingSource
            // 
            this.andmebaasBindingSource.DataSource = this.andmebaas;
            this.andmebaasBindingSource.Position = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(47, 258);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(677, 166);
            this.dataGridView1.TabIndex = 8;
            // 
            // Btn_kustuta
            // 
            this.Btn_kustuta.Location = new System.Drawing.Point(141, 195);
            this.Btn_kustuta.Name = "Btn_kustuta";
            this.Btn_kustuta.Size = new System.Drawing.Size(101, 29);
            this.Btn_kustuta.TabIndex = 9;
            this.Btn_kustuta.Text = "Kustuta andmed";
            this.Btn_kustuta.UseVisualStyleBackColor = true;
            this.Btn_kustuta.Click += new System.EventHandler(this.Btn_kustuta_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label4.Location = new System.Drawing.Point(310, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Id";
            // 
            // Id_txt
            // 
            this.Id_txt.Location = new System.Drawing.Point(346, 84);
            this.Id_txt.Name = "Id_txt";
            this.Id_txt.Size = new System.Drawing.Size(100, 20);
            this.Id_txt.TabIndex = 11;
            // 
            // Uuenda_btn
            // 
            this.Uuenda_btn.Location = new System.Drawing.Point(257, 195);
            this.Uuenda_btn.Name = "Uuenda_btn";
            this.Uuenda_btn.Size = new System.Drawing.Size(97, 29);
            this.Uuenda_btn.TabIndex = 12;
            this.Uuenda_btn.Text = "Uuenda andmed";
            this.Uuenda_btn.UseVisualStyleBackColor = true;
            this.Uuenda_btn.Click += new System.EventHandler(this.Uuenda_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Uuenda_btn);
            this.Controls.Add(this.Id_txt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn_kustuta);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Btn_lisa);
            this.Controls.Add(this.Hind_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Kogus_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Nimetus_txt);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.andmebaasDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.andmebaasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Nimetus_txt;
        private System.Windows.Forms.TextBox Kogus_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Hind_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource andmebaasDataSetBindingSource;
        private System.Windows.Forms.Button Btn_lisa;
        private System.Windows.Forms.BindingSource andmebaasBindingSource;
        private Andmebaas andmebaas;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Btn_kustuta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Id_txt;
        private System.Windows.Forms.Button Uuenda_btn;
    }
}


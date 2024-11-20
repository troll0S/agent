namespace lab1
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
            this.d_value = new System.Windows.Forms.ComboBox();
            this.n_value = new System.Windows.Forms.TextBox();
            this.b_value = new System.Windows.Forms.TextBox();
            this.a_value = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pk_Value = new System.Windows.Forms.TextBox();
            this.pn_Value = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.T_value = new System.Windows.Forms.TextBox();
            this.elita_value = new System.Windows.Forms.CheckBox();
            this.wykresButton = new System.Windows.Forms.Button();
            this.testyButon = new System.Windows.Forms.Button();
            this.dane = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1077, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "oblicz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // d_value
            // 
            this.d_value.FormattingEnabled = true;
            this.d_value.Location = new System.Drawing.Point(240, 31);
            this.d_value.Name = "d_value";
            this.d_value.Size = new System.Drawing.Size(78, 21);
            this.d_value.TabIndex = 1;
            this.d_value.SelectedIndexChanged += new System.EventHandler(this.d_value_SelectedIndexChanged);
            // 
            // n_value
            // 
            this.n_value.Location = new System.Drawing.Point(181, 32);
            this.n_value.Name = "n_value";
            this.n_value.Size = new System.Drawing.Size(22, 20);
            this.n_value.TabIndex = 2;
            this.n_value.TextChanged += new System.EventHandler(this.n_value_TextChanged);
            this.n_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.n_value_KeyPress);
            // 
            // b_value
            // 
            this.b_value.Location = new System.Drawing.Point(116, 32);
            this.b_value.Name = "b_value";
            this.b_value.Size = new System.Drawing.Size(26, 20);
            this.b_value.TabIndex = 3;
            this.b_value.TextChanged += new System.EventHandler(this.b_value_TextChanged);
            this.b_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.b_value_KeyPress);
            // 
            // a_value
            // 
            this.a_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.a_value.Location = new System.Drawing.Point(55, 32);
            this.a_value.Name = "a_value";
            this.a_value.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.a_value.Size = new System.Drawing.Size(24, 20);
            this.a_value.TabIndex = 4;
            this.a_value.TextChanged += new System.EventHandler(this.a_value_TextChanged);
            this.a_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.a_value_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "a = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "b = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = " N =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(209, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "d = ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1141, 415);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "pk =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "pn =";
            // 
            // pk_Value
            // 
            this.pk_Value.Location = new System.Drawing.Point(359, 32);
            this.pk_Value.Name = "pk_Value";
            this.pk_Value.Size = new System.Drawing.Size(46, 20);
            this.pk_Value.TabIndex = 12;
            this.pk_Value.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.pk_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pkValue_KeyPress);
            // 
            // pn_Value
            // 
            this.pn_Value.Location = new System.Drawing.Point(445, 34);
            this.pn_Value.Name = "pn_Value";
            this.pn_Value.Size = new System.Drawing.Size(64, 20);
            this.pn_Value.TabIndex = 13;
            this.pn_Value.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.pn_Value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.pnValue_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(515, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "T=";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(648, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "elita";
            // 
            // T_value
            // 
            this.T_value.Location = new System.Drawing.Point(542, 37);
            this.T_value.Name = "T_value";
            this.T_value.Size = new System.Drawing.Size(100, 20);
            this.T_value.TabIndex = 16;
            this.T_value.TextChanged += new System.EventHandler(this.T_value_TextChanged);
            this.T_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.T_value_KeyPress);
            // 
            // elita_value
            // 
            this.elita_value.AutoSize = true;
            this.elita_value.Checked = true;
            this.elita_value.CheckState = System.Windows.Forms.CheckState.Checked;
            this.elita_value.Location = new System.Drawing.Point(681, 41);
            this.elita_value.Name = "elita_value";
            this.elita_value.Size = new System.Drawing.Size(15, 14);
            this.elita_value.TabIndex = 17;
            this.elita_value.UseVisualStyleBackColor = true;
            this.elita_value.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // wykresButton
            // 
            this.wykresButton.Location = new System.Drawing.Point(915, 29);
            this.wykresButton.Name = "wykresButton";
            this.wykresButton.Size = new System.Drawing.Size(75, 23);
            this.wykresButton.TabIndex = 18;
            this.wykresButton.Text = "wykres";
            this.wykresButton.UseVisualStyleBackColor = true;
            this.wykresButton.Click += new System.EventHandler(this.wykresButton_Click);
            // 
            // testyButon
            // 
            this.testyButon.Location = new System.Drawing.Point(996, 29);
            this.testyButon.Name = "testyButon";
            this.testyButon.Size = new System.Drawing.Size(75, 23);
            this.testyButon.TabIndex = 19;
            this.testyButon.Text = "testy";
            this.testyButon.UseVisualStyleBackColor = true;
            this.testyButon.Click += new System.EventHandler(this.testyButon_Click);
            // 
            // dane
            // 
            this.dane.Location = new System.Drawing.Point(834, 29);
            this.dane.Name = "dane";
            this.dane.Size = new System.Drawing.Size(75, 23);
            this.dane.TabIndex = 20;
            this.dane.Text = "dane";
            this.dane.UseVisualStyleBackColor = true;
            this.dane.Click += new System.EventHandler(this.dane_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 781);
            this.Controls.Add(this.dane);
            this.Controls.Add(this.testyButon);
            this.Controls.Add(this.wykresButton);
            this.Controls.Add(this.elita_value);
            this.Controls.Add(this.T_value);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pn_Value);
            this.Controls.Add(this.pk_Value);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.a_value);
            this.Controls.Add(this.b_value);
            this.Controls.Add(this.n_value);
            this.Controls.Add(this.d_value);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox d_value;
        private System.Windows.Forms.TextBox n_value;
        private System.Windows.Forms.TextBox b_value;
        private System.Windows.Forms.TextBox a_value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pk_Value;
        private System.Windows.Forms.TextBox pn_Value;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox T_value;
        private System.Windows.Forms.CheckBox elita_value;
        private System.Windows.Forms.Button wykresButton;
        private System.Windows.Forms.Button testyButon;
        private System.Windows.Forms.Button dane;
    }
}


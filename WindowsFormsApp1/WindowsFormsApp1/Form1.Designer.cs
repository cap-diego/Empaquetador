namespace main
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
            this.cb_canios = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lw_caños = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.chkb_listo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_canios_agregados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lw_elegidos = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_canios
            // 
            this.cb_canios.FormattingEnabled = true;
            this.cb_canios.Location = new System.Drawing.Point(53, 65);
            this.cb_canios.Name = "cb_canios";
            this.cb_canios.Size = new System.Drawing.Size(121, 21);
            this.cb_canios.TabIndex = 0;
            this.cb_canios.SelectedIndexChanged += new System.EventHandler(this.cb_canios_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkb_listo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_canios_agregados);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_canios);
            this.groupBox1.Location = new System.Drawing.Point(25, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 282);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selección de caños";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lw_elegidos);
            this.groupBox2.Controls.Add(this.lw_caños);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(205, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 205);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caños  usados";
            // 
            // lw_caños
            // 
            this.lw_caños.Location = new System.Drawing.Point(185, 19);
            this.lw_caños.Name = "lw_caños";
            this.lw_caños.Size = new System.Drawing.Size(103, 137);
            this.lw_caños.TabIndex = 7;
            this.lw_caños.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 6;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkb_listo
            // 
            this.chkb_listo.AutoSize = true;
            this.chkb_listo.Location = new System.Drawing.Point(53, 226);
            this.chkb_listo.Name = "chkb_listo";
            this.chkb_listo.Size = new System.Drawing.Size(48, 17);
            this.chkb_listo.TabIndex = 5;
            this.chkb_listo.Text = "Listo";
            this.chkb_listo.UseVisualStyleBackColor = true;
            this.chkb_listo.CheckedChanged += new System.EventHandler(this.chkb_listo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Diametros";
            // 
            // lbl_canios_agregados
            // 
            this.lbl_canios_agregados.AutoSize = true;
            this.lbl_canios_agregados.Location = new System.Drawing.Point(152, 246);
            this.lbl_canios_agregados.Name = "lbl_canios_agregados";
            this.lbl_canios_agregados.Size = new System.Drawing.Size(0, 13);
            this.lbl_canios_agregados.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Caños agregados: ";
            // 
            // lw_elegidos
            // 
            this.lw_elegidos.Location = new System.Drawing.Point(6, 19);
            this.lw_elegidos.Name = "lw_elegidos";
            this.lw_elegidos.Size = new System.Drawing.Size(92, 137);
            this.lw_elegidos.TabIndex = 8;
            this.lw_elegidos.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(637, 366);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Distr caños";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_canios;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_canios_agregados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkb_listo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lw_caños;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lw_elegidos;
    }
}


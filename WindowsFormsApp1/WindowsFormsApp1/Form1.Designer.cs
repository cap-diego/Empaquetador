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
            this.label5 = new System.Windows.Forms.Label();
            this.lblCant = new System.Windows.Forms.Label();
            this.lblLargo = new System.Windows.Forms.Label();
            this.lblPeso = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lw_elegidos = new System.Windows.Forms.ListView();
            this.lw_cañosRta = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.chkb_listo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_canios_agregados = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
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
            this.cb_canios.SelectedIndexChanged += new System.EventHandler(this.cb_canios_SelectedIndexChanged_1);
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
            this.groupBox1.Size = new System.Drawing.Size(833, 282);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selección de caños";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblCant);
            this.groupBox2.Controls.Add(this.lblLargo);
            this.groupBox2.Controls.Add(this.lblPeso);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lw_elegidos);
            this.groupBox2.Controls.Add(this.lw_cañosRta);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(205, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(622, 227);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caños  usados";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Cant caños:";
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Location = new System.Drawing.Point(365, 202);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(0, 13);
            this.lblCant.TabIndex = 13;
            // 
            // lblLargo
            // 
            this.lblLargo.AutoSize = true;
            this.lblLargo.Location = new System.Drawing.Point(331, 182);
            this.lblLargo.Name = "lblLargo";
            this.lblLargo.Size = new System.Drawing.Size(0, 13);
            this.lblLargo.TabIndex = 12;
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.Location = new System.Drawing.Point(331, 164);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(0, 13);
            this.lblPeso.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Largo: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Peso: ";
            // 
            // lw_elegidos
            // 
            this.lw_elegidos.Location = new System.Drawing.Point(6, 19);
            this.lw_elegidos.Name = "lw_elegidos";
            this.lw_elegidos.Size = new System.Drawing.Size(203, 202);
            this.lw_elegidos.TabIndex = 8;
            this.lw_elegidos.UseCompatibleStateImageBehavior = false;
            // 
            // lw_cañosRta
            // 
            this.lw_cañosRta.Location = new System.Drawing.Point(435, 16);
            this.lw_cañosRta.Name = "lw_cañosRta";
            this.lw_cañosRta.Size = new System.Drawing.Size(181, 205);
            this.lw_cañosRta.TabIndex = 7;
            this.lw_cañosRta.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 83);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(521, 22);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Reiniciar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(870, 366);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Distr caños";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ListView lw_cañosRta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lw_elegidos;
        private System.Windows.Forms.Label lblLargo;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
    }
}


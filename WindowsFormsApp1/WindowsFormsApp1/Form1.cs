using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main
{

    public partial class Form1 : Form
    {
        public List<CheckedListBox> lista_espesores = new List<CheckedListBox>();
        /*ComboBox cb_canios = new ComboBox();
        ListView lw_elegidos = new ListView();
        ListView lw_cañosRta = new ListView();*/
        int indice_espesor_actual = 0;
        /*CheckBox chkb = new CheckBox();
        CheckBox chkb_listo = new CheckBox();
        Button button1 = new Button();
        Button button2 = new Button();*/
        //Label lblLargo, lblCant, lblMetros, lblPeso, lbl_canios_agregados = new Label();
        //GroupBox gbElementos = new GroupBox();
        //formulario.Controls.Add(item);
        //groupBox1.Controls.Add(item);
        List<Control> elementos = new List<Control>();
        Form1 formulario;
        OrganizadorCaños prog;
        caja empaquetado;

        public Form1()
        {
            iniciar_componentes();
            formulario = this;
            //InitializeComponent();
        }

        public void iniciar_componentes()
        {
            InitializeComponent();
        }


        private void AgregarControlesAlFormulario()
        {
            /*  elementos.Add(cb_canios);
              elementos.Add(lw_elegidos);
              elementos.Add(lw_cañosRta);

              elementos.Add(chkb_listo);
              elementos.Add(button1);
              elementos.Add(button2);
              elementos.Add(lblLargo);
              elementos.Add(lblCant);*/
            //elementos.Add(chkb);
            //elementos.Add(lblMetros);
            //elementos.Add(lblPeso);
            //elementos.Add(lbl_canios_agregados);
            //elementos.Add(gbElementos);

            foreach (var e in elementos)
            {
                Console.WriteLine("Metiendo " + e.Name.ToString());
                formulario.Controls.Add(e);
                //gbElementos.Controls.Add(e);
            }
            Console.WriteLine("ADs");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Cargar listbox de caños
            //En la check list box cargar los distintos espesores
            //Ejecutar algoritmo
            Console.WriteLine("Iniciando");
            Form1 f = this;
            List<Control> elementos = new List<Control>();
            button1.Enabled = false;
            List<string> info = new List<string>();

            foreach (Control ctrl in elementos)
            {

                elementos.Add(ctrl);

            }
            prog = new OrganizadorCaños(ref f, ref elementos, ref groupBox1, ref info );
            cb_canios.DataSource = info;//Cargamos los diametros de cada caño en la listbox

        }
        public void chkb_listo_CheckedChanged(object sender, EventArgs e)
        {

            lw_elegidos.Clear();
            int acum = 0;
            lw_cañosRta.Clear();
            lw_elegidos.Items.Clear();
            button1.Enabled = true;

            if (chkb_listo.Checked)
            {
                prog.ArmarListaEspesores(ref lista_espesores, ref lw_elegidos, ref acum);
            }
            lbl_canios_agregados.Text = acum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Paquete: selecc (Cant elem: "+ prog.paquetes_seleccionados.Count+")");
            foreach (var p in prog.paquetes_seleccionados)
            {
                Console.WriteLine(":" + p.denominacion);
            }
            //Aca se desarrolla el algoritmo y se manda la respuesta a lw_caños
            if (prog.paquetes_seleccionados.Count > 0)
            {
                prog.grasp();
                Console.Write(prog.empaquetado.Get_paquetes().Count);

                foreach (var paq in prog.empaquetado.Get_paquetes())
                {   
                    Console.Write("Diam:" + paq.diam + " Esp: " + paq.espesor); 
                    lw_cañosRta.Items.Add("Diam:" + paq.diam + " Esp: " + paq.espesor);
                }
                lblLargo.Text = prog.empaquetado._suma_largos_total + " mts";
                lblPeso.Text = prog.empaquetado._peso_total.ToString() + "/" + prog.empaquetado._peso_tope + " KGS";
                lblCant.Text = prog.empaquetado.Cant_caños().ToString() + " unidades";
            }else
            {
                Console.Write("No hay paquetes seleccionados");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("REINICIANDO");
        }
        public void cb_canios_SelectedIndexChanged(object sender, EventArgs e)
        {
            prog.actualizar_caños(indice_espesor_actual, ref lista_espesores, ref formulario);
        }
        public double ConseguirItemSelecc()
        {
            return double.Parse(cb_canios.SelectedItem.ToString());
        }

        private void cb_canios_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            formulario = this;
            if (prog != null)
            {
                Console.WriteLine("Cargando");
                prog.actualizar_caños(indice_espesor_actual, ref lista_espesores, ref formulario);
            }
        }
    }
}

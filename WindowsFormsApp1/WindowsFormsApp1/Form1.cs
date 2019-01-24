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
        const double h_tope = 2600, p_tope = 22000, largo = 12.5, ancho = 2500, altura_max = 2500;
        List<int> cant_canios_paq = new List<int>();
        List<double> diam = new List<double>();
        List<double> peso = new List<double>();
        List<double> altura = new List<double>();
        List<double> largos = new List<double>();
        List<double> espesor = new List<double>();
        List<double> canios_paq = new List<double>();
        List<canio> canios = new List<canio>();
        List<paquete> paquetes = new List<paquete>();
        List<paquete> paquetes_seleccionados = new List<paquete>();
        List<CheckedListBox> lista_espesores = new List<CheckedListBox>();
        int indice_espesor_actual = 0;
        caja empaquetado = new caja(altura_max, ancho, largo, h_tope, p_tope);

        public Form1()
        {
            InitializeComponent();
        }
        
        private void cargarInfo() {
            //var lines = File.ReadLines("asd.txt");
            Console.WriteLine("Inicianzo la carga de datos");
            string add = "../../io/datos_formateados.txt";
            string path = System.Reflection.Assembly.GetEntryAssembly().Location;
            int cant_canios;
            StreamReader reader = File.OpenText("datos_formateados.txt");
            try
            {
                List<string> text = new List<string>();
                while (!reader.EndOfStream)
                {
                    text.Add(reader.ReadLine());
                }
                
                Int32.TryParse(text[0],out cant_canios);
                Console.WriteLine(text.Count.ToString());
                cargarTipo(diam,text,1,cant_canios);
                cargarTipo(peso, text,cant_canios+1, 2*cant_canios);
                cargarTipo(altura, text,cant_canios*2+1, 3*cant_canios);
                cargarTipo(largos, text, cant_canios*3+1,4*cant_canios);
                cargarTipo(espesor, text, cant_canios*4+1,5*cant_canios);
                cargarTipo(canios_paq, text,cant_canios*5+1 , 6*cant_canios);

                Console.WriteLine("TAMAÑOS: " + canios_paq.Count.ToString() + " " + espesor.Count.ToString() + " " + largos.Count.ToString() + " " + altura.Count.ToString() + " "+ diam.Count.ToString() + " "+peso.Count.ToString());
                //Ahora armo los canios con todos los datos
                for (int j = 0; j < cant_canios; j++)
                {
                    string denom = diam[j] + "-" + espesor[j];
                    canio c = new canio(denom, peso[j], diam[j], largo, espesor[j]);
                    canios.Add(c);
                    //MessageBox.Show(canios.Count.ToString());
                }
                
                //Ahora armo los paquetes de cada canio
                for (int i = 0; i < cant_canios; i++)
                {
                    paquete p = new paquete(canios[i], Convert.ToInt32(canios_paq[i]), altura[i]); //REVISAR
                    paquetes.Add(p);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR AL ABRIR EL TXT:"+e.ToString());
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }

        }

        private void cb_canios_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizar_caños();

        }

        private void cargarTipo(List<double> lista,List<string> t, int ult_cargado, int cant)
        {
            for(int i = ult_cargado; i <= cant; i++)
            {
                lista.Add(double.Parse(t[i]));
            }
        }

        private void chkb_listo_CheckedChanged(object sender, EventArgs e)
        {
            int acum = 0;
            lw_caños.Clear();
            if (chkb_listo.Checked) {
                foreach(CheckedListBox chkLb in lista_espesores)
                {
                    acum += (chkLb.CheckedItems.Count);
                    foreach (double o in chkLb.CheckedItems)
                    {
                        lw_elegidos.Items.Add(o.ToString());
                    }
                    if(chkLb.SelectedItems.Count!=0)   Console.WriteLine(chkLb.CheckedItems.Count);
                }
            }
            lbl_canios_agregados.Text = acum.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Aca   se desarrolla el algoritmo y se manda la respuesta a lw_caños

            grasp(empaquetado);
            empaquetado.Mostrar_info();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Cargar listbox de caños
            //En la check list box cargar los distintos espesores
            //Label1=contador de caños marcados
            //Ejecutar algoritmo
            

            Console.WriteLine("Inicia - Carga info");
            cargarInfo();
            Console.WriteLine("Finaliza cargar info");
            List<string> info = new List<string>();
             foreach(paquete p in paquetes)
            {
                if (info.Count <1 || p.Get_diam().ToString() != info[info.Count - 1])
                {
                    info.Add(p.Get_diam().ToString());
                }
                    
            }
            cb_canios.DataSource = info;

            //Iniciamos las listas de los espesores de los dif caños
            inicializacion_caños();
        }
        private void grasp(caja emp_max)
        {
            caja aux = new caja(altura_max, ancho, largo, h_tope, p_tope);
            double proba = 1, shifter = 0.01;
            double val_metros = 0, val_aux;
            while (proba >= 0.5)
            {
                val_aux = solucion_golosa(aux, proba);
                if (val_aux > val_metros)
                {
                    val_metros = val_aux;
                    emp_max = aux;
                }
                proba -= shifter;
            }
        }

        private double solucion_golosa(caja empaquetado, double proba)
        {

            //Tomo la de mejor beneficio y la guardo en la caja
            //Repetir mientras pueda agregar.
            Random rnd = new Random();
            int paq_random = rnd.Next(paquetes_seleccionados.Count);
            int val_random = rnd.Next(2);
            int ultimo_agregado = 0;
            int indice_libre;
            while (ultimo_agregado != -1)
            {
                double val_max_ben = paquetes_seleccionados[0].Get_suma_de_largos();//paq[0].get_beneficio();
                int indice_max_ben = 0;
                indice_libre = rnd.Next(paquetes_seleccionados.Count);
                for (int i = 0; i < paquetes_seleccionados.Count; ++i)
                {
                    if (paquetes_seleccionados[i].Get_suma_de_largos() > val_max_ben)
                    {
                        indice_max_ben = i;
                        val_max_ben = paquetes_seleccionados[i].Get_beneficio();
                    }
                }
                if (rnd.Next(2) <= proba)
                {
                    indice_max_ben = indice_libre;
                    //std::cout << "Uso uno por proba y no por beneficio" << std::endl;
                }
                //std::cout<<"peso paq indice: "<<indice_max_ben<<" peso: "<<paq[indice_max_ben].get_peso_total()<<std::endl;
                ultimo_agregado = empaquetado.Agregar_paquete(paquetes_seleccionados[indice_max_ben]);
                //empaquetado.mostrar_info();
                //std::cout<<"ult: "<<ultimo_agregado<<std::endl;
            }
            //Aca tengo la caja cargada
            return empaquetado.Get_metros();
        }


        private void inicializacion_caños()
        {
            int i = 0, ult = 0;
            while (i < paquetes.Count)
            {
                if(ult== i || paquetes[i].Get_diam() != paquetes[ult].Get_diam())
                {
                    ult = i;
                    var item = new CheckedListBox
                    {
                        Name = "chkLb" + paquetes[i].Denominacion(),
                        Location = new System.Drawing.Point(50, 130),
                        Width = 120,
                        Height = 100,
                        Visible = false,
                        Text = "Lista:" + (lista_espesores.Count - 1)
                    };

                    lista_espesores.Add(item);
                    this.Controls.Add(item);
                    groupBox1.Controls.Add(item);
                    int indice = i;
                    //Ahora cargo el chklist correspondiente con los espesores
                    while (indice < paquetes.Count && paquetes[i].Get_diam() == paquetes[indice].Get_diam())
                    {
                        lista_espesores[lista_espesores.Count - 1].Items.Add(paquetes[indice].Get_espesor());
                        indice++;
                    }
                }

                i++;
            }

        }
        private void actualizar_caños()
        {
            //Ahora, segun el selected del combobox mostramos los distintos espesores
            if(indice_espesor_actual < lista_espesores.Count) lista_espesores[indice_espesor_actual].Visible = false;
            int indice = Get_index(double.Parse(cb_canios.SelectedItem.ToString()));
            int inicial = indice;
            int indice_lista_esp = 0;
            while(indice_lista_esp < lista_espesores.Count)
            {
                if (lista_espesores[indice_lista_esp].Name == "chkLb" + paquetes[indice].Denominacion())
                {
                    lista_espesores[indice_lista_esp].Visible = true;
                    indice_espesor_actual = indice_lista_esp;
                    break;
                }
                indice_lista_esp++;
            }
            
        }
        private int Get_index(double diam)
        {
            int i = 0;
            while(i < paquetes.Count && paquetes[i].Get_diam() !=diam){
                i++;
            }
            return i;
        }
    }

}

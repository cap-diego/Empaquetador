using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace main
{
    public class OrganizadorCaños
    {
        const double h_tope = 2100, p_tope = 25686, largo = 12.5, ancho = 2500, altura_max = 2500;
        List<int> cant_canios_paq = new List<int>();
        List<double> diam = new List<double>();
        List<double> diam_unicos = new List<double>();
        List<double> peso = new List<double>();
        List<double> altura = new List<double>();
        List<double> largos = new List<double>();
        List<double> espesor = new List<double>();
        List<double> canios_paq = new List<double>();
        List<canio> canios = new List<canio>();
        public List<paquete> paquetes = new List<paquete>();
        public List<paquete> paquetes_seleccionados = new List<paquete>();
        public caja empaquetado = new caja(altura_max, ancho, largo, h_tope, p_tope);
        Form1 formulario;

        
        public OrganizadorCaños(ref Form1 form, ref List<Control> elementos_inicio, ref GroupBox gb, ref List<string> info)
        {
            Console.WriteLine("Comenzando carga de recursos");
            formulario = form;
            Console.WriteLine("AD");            
            CargarInfo();
            
            Console.WriteLine("Finaliza cargar info, procedemos a armar estructura");
            foreach (paquete p in paquetes)
            {
                if (info.Count < 1 || p.diam.ToString() != info[info.Count - 1])
                {
                    info.Add(p.diam.ToString());
                }

            }
            

            //Iniciamos las listas de los espesores de los dif caños
            inicializacion_caños(ref form,ref gb);
            Console.Write("Fin armado de recursos");
        }
        private void CargarInfo()
        {
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

                Int32.TryParse(text[0], out cant_canios);
                //Console.WriteLine(text.Count.ToString());
                cargarTipo(diam, text, 1, cant_canios);
                cargarTipo(peso, text, cant_canios + 1, 2 * cant_canios);
                cargarTipo(altura, text, cant_canios * 2 + 1, 3 * cant_canios);
                cargarTipo(largos, text, cant_canios * 3 + 1, 4 * cant_canios);
                cargarTipo(espesor, text, cant_canios * 4 + 1, 5 * cant_canios);
                cargarTipo(canios_paq, text, cant_canios * 5 + 1, 6 * cant_canios);

                //Console.WriteLine("TAMAÑOS: " + canios_paq.Count.ToString() + " " + espesor.Count.ToString() + " " + largos.Count.ToString() + " " + altura.Count.ToString() + " "+ diam.Count.ToString() + " "+peso.Count.ToString());

                diam_unicos.Add(diam[0]);
                int ult_ag = 0;
                for (int i = 1; i < diam.Count; i++)
                {
                    if (diam_unicos[ult_ag] != diam[i])
                    {
                        diam_unicos.Add(diam[i]);
                        ult_ag++;
                    }


                }

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
                    canio c = canios[i];
                    paquete p = new paquete(ref c, Convert.ToInt32(canios_paq[i]), altura[i], largos[i]); //REVISAR
                    //Console.WriteLine("Diam: " + diam[i] + " esp: " + espesor[i] + " " + p.suma_de_largos + " largo caño: " + canios[i].largo);
                    paquetes.Add(p);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR AL ABRIR EL TXT:" + e.ToString());
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
            }

        }
        
 
        private void cargarTipo(List<double> lista, List<string> t, int ult_cargado, int cant)
        {
            for (int i = ult_cargado; i <= cant; i++)
            {
                lista.Add(double.Parse(t[i]));
            }
        }
        private paquete Get_paq_por_denom(string denom)
        {
            int i = 0;
            for (i = 0; i < paquetes.Count; i++)
            {
                Console.Write("comparando " + paquetes[i].denominacion + " con " + denom);
                if (paquetes[i].denominacion == denom)
                    break;
            }
            if (i == paquetes.Count)
            {
                return paquetes[0];
            }
            else
            {
                return paquetes[i];
            }

        }

        public void grasp()
            {
                caja aux = new caja(altura_max, ancho, largo, h_tope, p_tope);
                double a = solucion_golosa(ref empaquetado,1);
                Console.WriteLine("Solucion inicial " + a);
                double proba = 1, shifter = 0.01;
                double val_metros = 0, val_aux;
                while (proba >= 0.5)
                {
                    val_aux = solucion_golosa(ref aux, proba);
                    //MessageBox.Show("Comparando " + val_aux + " con " + val_metros);
                    if (val_aux > val_metros)
                    {
                        
                        val_metros = val_aux;
                        empaquetado = aux;
                    }
                    proba -= shifter;
                }
                empaquetado.Mostrar_info();
                //MessageBox.Show("Finalizado grasp, el empaquetado tiene " + empaquetado.Cant_caños());
            }

        private double solucion_golosa(ref caja emp, double proba)
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
                    double val_max_ben = paquetes_seleccionados[0].suma_de_largos;//paq[0].get_beneficio();
                    int indice_max_ben = 0;
                    indice_libre = rnd.Next(paquetes_seleccionados.Count);
                    for (int i = 0; i < paquetes_seleccionados.Count; ++i)
                    {
                        if (paquetes_seleccionados[i].suma_de_largos > val_max_ben)
                        {
                            indice_max_ben = i;
                            val_max_ben = paquetes_seleccionados[i].beneficio;
                        }
                    }
                    if (rnd.Next(2) <= proba)
                    {
                        indice_max_ben = indice_libre;
                    }
                    paquete p = paquetes_seleccionados[indice_max_ben];
                    
                    ultimo_agregado = emp.Agregar_paquete(ref p);
                    //MessageBox.Show("actualmente el emp tiene: " + emp.Cant_caños()+ " y largo: " + emp._suma_largos_total);
                }
                //Aca tengo la caja cargada
                empaquetado = emp;
                return emp._suma_largos_total;
            }
        public void ArmarListaEspesores(ref List<CheckedListBox> lista_espesores, ref ListView lw_elegidos, ref int acum)
        {
            
            int num_espesor = 0, recorridos = 0;
            foreach (CheckedListBox chkLb in lista_espesores)//Por cada lista de espesores de cada caño vemos cuantos están chequedados. Hay que enviar cada paquete seleccionado hacia el empaquetado
            {
                acum += (chkLb.CheckedItems.Count);
                foreach (double o in chkLb.CheckedItems)//Espesores chequeados
                {
                    lw_elegidos.Items.Add("DIAM: " + diam_unicos[recorridos] + " SESP: " + o.ToString());
                    string denom_caño_actual = diam_unicos[num_espesor] + "-" + o.ToString();
                    paquetes_seleccionados.Add(Get_paq_por_denom(denom_caño_actual));
                }

                num_espesor++;
                recorridos++;
            }

        }

        public void inicializacion_caños(ref Form1 f, ref GroupBox gb)
            {
                int i = 0, ult = 0;
                while (i < paquetes.Count)
                {
                    if (ult == i || paquetes[i].diam != paquetes[ult].diam)
                    {
                        ult = i;
                        var item = new CheckedListBox
                        {
                            Name = "chkLb" + paquetes[i].denominacion,
                            Location = new System.Drawing.Point(50, 130),
                            Width = 120,
                            Height = 100,
                            Visible = false,
                            Text = "Lista:" + (f.lista_espesores.Count - 1)
                        };

                        f.lista_espesores.Add(item);
                        f.Controls.Add(item);
                        gb.Controls.Add(item);
                        int indice = i;
                        //Ahora cargo el chklist correspondiente con los espesores
                        while (indice < paquetes.Count && paquetes[i].diam == paquetes[indice].diam)
                        {
                            f.lista_espesores[f.lista_espesores.Count - 1].Items.Add(paquetes[indice].espesor);
                            indice++;
                        }
                    }

                    i++;
                }

            }
        public void actualizar_caños(int indice_espesor_actual, ref List<CheckedListBox> lista_espesores, ref Form1 f)
            {
                //Ahora, segun el selected del combobox mostramos los distintos espesores
                if (indice_espesor_actual < lista_espesores.Count) lista_espesores[indice_espesor_actual].Visible = false;
                int indice = Get_index(f.ConseguirItemSelecc());
                int inicial = indice;
                int indice_lista_esp = 0;
                while (indice_lista_esp < lista_espesores.Count)
                {
                    if (lista_espesores[indice_lista_esp].Name == "chkLb" + paquetes[indice].denominacion)
                    {
                        lista_espesores[indice_lista_esp].Visible = true;
                        indice_espesor_actual = indice_lista_esp;
                        break;
                    }
                    indice_lista_esp++;
                }

            }
        int Get_index(double diam)
            {
                int i = 0;
                while (i < paquetes.Count && paquetes[i].diam != diam)
                {
                    i++;
                }
                return i;
            }

        

    }

}

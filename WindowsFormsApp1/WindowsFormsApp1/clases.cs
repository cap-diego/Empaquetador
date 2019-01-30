using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{   

    public class canio
    {
        public double espesor { get; }
        public double diametro { get;  }
        public double peso { get; }
        public double largo { get; }
        public string denominacion { get; set; }

        public canio(string denom, double p, double d, double l, double e)
        {
            this.denominacion = denom;
            this.peso = p;
            this.largo = l;
            this.diametro = d;
            this.espesor = e;
        }

        void Mostrar_info()
        {
            canio c = this;
            //std::cout << "Muestro info del caño: " << std::endl;
            Console.WriteLine("Caño: " + denominacion + "largo: " +largo + " peso: " + peso + " diametro: " + diametro + " espesor: " + espesor);
        }
 
    }

    public class paquete
    {

        public double beneficio { get; }
        public double diam { get; }
        public double espesor { get; }
        public double peso_tope { get; }//kg
        public int cant_canios { get; }//unidad de canios
        public double altura { get; }//mm
        public double suma_de_largos { get; }//mts
        private double dist_entre_centros;
        public string denominacion { get; set; }

        public paquete(ref canio c, int cant_canios, double h, double largo) {
            denominacion = c.denominacion;
            peso_tope = c.peso * cant_canios;
            suma_de_largos = largo; //c.Get_largo() * cant_canios;
            altura = h;
            diam = c.diametro;
            this.cant_canios=cant_canios;
            beneficio = suma_de_largos / peso_tope;
            espesor = c.espesor;
        }
        
        public static bool operator<(paquete p, paquete p2 )  {
            if(p.peso_tope < p.peso_tope){
            return true;
        }
            return false;
        }

        public static bool operator >(paquete p, paquete p2)
        {
            if (p.peso_tope > p.peso_tope)
            {
                return true;
            }
            return false;
        }
        
        public static bool operator==(paquete p,paquete p2){
            if(p.denominacion == p2.denominacion) return true;
            return false;
        }
        public static bool operator !=(paquete p, paquete p2)
        {
            if (p.denominacion != p2.denominacion) return true;
            return false;
        }
        public void Mostrar_info() {
            //std::cout<<"PAQUETE DE CAÑOS: "<<denominacion<<std::endl;
            Console.WriteLine("Cantidad de caños: " + cant_canios   + "Peso total: " + peso_tope +". Altura: " +altura +". Suma de largo: " +suma_de_largos + " Espesor: " +espesor +" Beneficio: " +beneficio+"\n");
            //std::cout<<std::endl;
        }

    }

    public class caja
    {
        List<paquete> paquetes;
        private double peso_total;
        public double _peso_total{ get { return peso_total; } set { peso_total = _peso_total; } }

        private double altura_total;
        public double _altura_total { get { return altura_total; } set { altura_total = _altura_total; } }

        public double _peso_tope { get { return peso_tope; } set { peso_tope = _peso_tope; } }
        private double peso_tope;
        

        public double _altura_tope { get { return altura_tope; } set { altura_tope = _altura_tope; } }
        private double altura_tope;

        private double suma_largos_total;
        public double _suma_largos_total { get { return suma_largos_total; } set { suma_largos_total = _suma_largos_total; } }


        public caja(double altura, double ancho, double largo, double h_tope, double p_tope)
        {
            paquetes = new List<paquete>();
            peso_total = 0;
            altura_total = 0;
            suma_largos_total = 0;
            peso_tope = p_tope;
            altura_tope = h_tope;
        }
        public int Cant_caños()//devuelvo la cantidad total de caños entre todos los paquetes que estan en la caja
        {
            int acum = 0;
            foreach (var p in paquetes)
            {
                acum  += p.cant_canios; //sumo cada cantidad de caños de cada paquete
            }
            return acum;
        }
        public List<paquete> Get_paquetes()
        {
            return paquetes;
        }
        
        public int Agregar_paquete(ref paquete p)
        {
            //Si el peso del camion y la altura me lo permite agrego el paquete y devuelvo 0, si no devuelvo -1
            if (p.peso_tope + peso_total <= peso_tope && p.altura + altura_total <= altura_tope)
            {
                peso_total += p.peso_tope;
                altura_total += p.altura;
                suma_largos_total += p.suma_de_largos;
                paquetes.Add(p);
              
            }
            else return -1;
            return 0;
        }

        public void asignar(ref caja c, ref caja c2) {
            c2.paquetes = c.paquetes;
            c2.peso_total = c.peso_total;
            c2.peso_tope = c.peso_tope;
            c2.altura_tope = c.altura_tope;
            c2.suma_largos_total = c.suma_largos_total;
            c2.altura_total = c.altura_total;
        }
        public void Mostrar_info() {
            for (int i = 0; i<paquetes.Count; ++i) {
                paquetes[i].Mostrar_info();
            }
            Console.WriteLine("Cantidad de paquetes: "+paquetes.Count+"Altura: "+altura_total+"/"+altura_tope+"Peso total: "+ peso_total+"/"+peso_tope+"Largo: "+suma_largos_total);
       

        }

        public void Eliminar_paquete(paquete p)
        {
            peso_total -= p.peso_tope;
            altura_total -= p.altura;
            suma_largos_total -= p.suma_de_largos;
            paquetes.Remove(p);
        }
    }

    }


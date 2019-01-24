using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{   
    public interface canioInt
    {

        double Get_largo();
        double Get_diametro();
        double Get_peso();
        void Set_largo(double l);
        void Set_diametro(double d);
        void Set_peso(double p);
        double Get_espesor();
        void Set_espesor(double e);
        void Mostrar_info();
        string Denom();
    }
    public class canio : canioInt
    {
        double espesor;
        double diametro;
        double peso;
        double largo;
        string denominacion;

        public canio(string denom, double p, double d, double l, double e)
        {
            denominacion = denom;
            peso = p;
            largo = l;
            diametro = d;
            espesor = e;
        }
        public string Denom()
        {
            return denominacion;
        }
        public double Get_diametro()
        {
            return diametro;
        }

        public double Get_largo()
        {
            return largo;
        }

        public double Get_peso()
        {
            return peso;
        }

        public void Set_espesor(double e)
        {
            espesor = e;
        }

        public double Get_espesor()
        {
            return espesor;
        }

        public void Mostrar_info()
        {
            canio c = this;
            //std::cout << "Muestro info del caño: " << std::endl;
            //std::cout << "Caño: " << c.denominacion << " largo: " << c.get_largo() << " peso: " << c.get_peso() << " diametro: " << c.get_diametro() << " espesor: " << c.get_espesor() << std::endl;
        }

        public void Set_diametro(double d)
        {
            diametro = d;
        }
        public void Set_largo(double l)
        {
            largo = l;
        }
        public void Set_peso(double p)
        {
            peso = p;
        }
 
    }

    public interface paqueteInt
    {
        
        double Get_peso_total();
        double Get_altura();
        double Get_suma_de_largos();
        //bool operator ==( paquete& p);
        //bool operator <( paquete& p);
        void Set_peso_total(double p);
        double Get_beneficio();
        void Set_altura(double h);
        void Mostrar_info();
        int Get_cant_canios();
        double Get_diam();
        double Get_espesor();
        string Get_info();
    }
    public class paquete : paqueteInt
    {

        double beneficio;
        double diam;
        double espesor;
        double peso_total;//kg
        int cant_canios;//unidad de canios
        double altura;//mm
        double suma_de_largos;//mts
        double dist_entre_centros;
        public string denominacion;

        public paquete(canio c, int cant_canios, double h) {
            denominacion = c.Denom();
            peso_total = c.Get_peso() * cant_canios;
            suma_de_largos = c.Get_largo() * cant_canios;
            altura = h;
            diam = c.Get_diametro();
            this.cant_canios=cant_canios;
            beneficio = suma_de_largos/peso_total;
            espesor=c.Get_espesor();
        }
        public string Denominacion()
        {
            return denominacion;
        }
        public string Get_info()
        {
            return diam + " " + espesor;
        }

        public double Get_altura(){
            return altura;
        }
        public double Get_diam() {
            return diam;
        }
        public double Get_peso_total(){
            return peso_total;
        }

        public double Get_espesor() {
            return espesor;
        }
        public double Get_suma_de_largos()
        {
            return suma_de_largos;
        }
        public int Get_cant_canios() {
            return cant_canios;
        }
        public void Set_altura(double h)
        {
            altura = h;
        }

        public static bool operator<(paquete p, paquete p2 )  {
            if(p.peso_total < p.peso_total){
            return true;
        }
            return false;
        }

        public static bool operator >(paquete p, paquete p2)
        {
            if (p.peso_total > p.peso_total)
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
        public double Get_beneficio(){
            return beneficio;
        }

        public void Mostrar_info() {
            //std::cout<<"PAQUETE DE CAÑOS: "<<denominacion<<std::endl;
            Console.WriteLine("Cantidad de caños: " + cant_canios   + "Peso total: " +peso_total +". Altura: " +altura +". Suma de largo: " +suma_de_largos + " Espesor: " +espesor +" Beneficio: " +beneficio+"\n");
            //std::cout<<std::endl;
        }

        public void Set_peso_total(double p)
        {
            peso_total = p;
        }
    }

    public interface cajaInt
    {

        int Agregar_paquete(paquete p);//0 si todo ok, -1 si no
        void Eliminar_paquete(paquete p);
        void Mostrar_info();
        double Get_metros();
        void asignar(caja c,caja c2);
    }
    public class caja :cajaInt
    {
        List<paquete> paquetes;
        double peso_total;
        double altura_total;
        double peso_tope;
        double altura_tope;
        double suma_largos_total;

        public caja(double altura, double ancho, double largo, double h_tope, double p_tope)
        {
            peso_total = 0;
            altura_total = 0;
            suma_largos_total = 0;
            peso_tope = p_tope;
            altura_tope = h_tope;
        }


        public int Agregar_paquete(paquete p)
        {
            //Si el peso del camion y la altura me lo permite agrego el paquete
            if (p.Get_peso_total() + peso_total <= peso_tope && p.Get_altura() + altura_total <= altura_tope)
            {
                peso_total += p.Get_peso_total();
                //std::cout<<"sumado peso: "<<p.get_peso_total()<<" sumada altura: "<< p.get_altura()<<std::endl;
                altura_total += p.Get_altura();
                suma_largos_total += p.Get_suma_de_largos();
                paquetes.Add(p);
              
            }
            else return -1;
            return 0;
        }

        public void asignar(caja c, caja c2) {
            c2.paquetes = c.paquetes;
            c2.peso_total = c.peso_total;
            c2.peso_tope = c.peso_tope;
            c2.altura_tope = c.altura_tope;
            c2.suma_largos_total = c.suma_largos_total;
            c2.altura_total = c.altura_total;
        }
        public double Get_metros() {
            return suma_largos_total;
        }

        public void Mostrar_info() {
            for (int i = 0; i<paquetes.Count; ++i) {
                paquetes[i].Mostrar_info();
            }
            Console.WriteLine("Cantidad de paquetes: "+paquetes.Count+"Altura: "+altura_total+"/"+altura_tope+"Peso total: "+ peso_total+"/"+peso_tope+"Largo: "+suma_largos_total);

        //std::cout<<"paquetes usados: "<<std::endl;

           /* for(auto p : paquetes){
                std::cout<<p.get_diam()<<":"<<p.get_espesor()<<", ";
            }  */ 

        }

        public void Eliminar_paquete(paquete p)
        {
            peso_total -= p.Get_peso_total();
            altura_total -= p.Get_altura();
            suma_largos_total -= p.Get_suma_de_largos();
            paquetes.Remove(p);
        }
    }
}


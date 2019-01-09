#include <iostream>
#include "clases_aux/canio.cpp"
#include "clases_aux/paquete.cpp"
#include "clases_aux/caja.cpp"
#include <tuple>
#include <list>


/* FUNCIONES */
void dinamica(std::vector<paquete> &, caja &);
int dinamica_aux(std::vector<paquete> &, int i,int j, float h, float p, float l, std::vector<std::vector<int> >& sol, std::vector<std::vector<std::vector<int> > >& );

bool is_number(const std::string& s);
void cargar_info(std::vector<paquete>&, std::vector<canio>& );
template <class T>
void cargar_tipo(std::vector<T>&, std::ifstream& in,int cant);
struct restricciones{
    float altura, peso;
    bool estado;
    restricciones(float h, float p):altura(0), peso(0),estado(true){    }
    void actualizar(paquete& p){
        altura += p.get_altura();
        peso += p.get_peso_total();
        if (altura>h_tope || peso > p_tope) estado = false;
    }
};
float solucion_golosa(std::vector<paquete> & paq, caja & empaquetado, float proba);
void grasp(std::vector<paquete> & paq, caja & empaquetado);

void filtrar_canios();

int main() {
    std::vector<paquete> paquetes;
    std::vector<canio> canios;
    std::vector<paquete> paq_rest;
    caja empaquetado(altura_max,ancho,largo,h_tope,p_tope);


    cargar_info(paquetes,canios);

    grasp(paquetes,empaquetado);



    std::cout<<"La solucion golosa es:"<<std::endl;
    empaquetado.mostrar_info();

    return 0;
}


void cargar_info(std::vector<paquete>& paquetes, std::vector<canio>& canios){
    std::ifstream in;
    std::vector<float> diam, peso, altura, largos, espesor;
    std::vector<int> cant_canios_paq;
    in.open(datos_formadeados, std::ifstream::in);
    int cant_canios;
    if(in.is_open()){
        std::cout <<"Comenzando a cargar datos"<<std::endl;
        std::string linea_actual;
        in>>linea_actual;//la primera linea es la cantidad de canios
        cant_canios = std::atoi(linea_actual.c_str());
        cargar_tipo(diam,in,cant_canios);
        cargar_tipo(peso,in,cant_canios);
        cargar_tipo(altura,in,cant_canios);
        cargar_tipo(largos,in,cant_canios);
        cargar_tipo(espesor,in,cant_canios);
        cargar_tipo(cant_canios_paq,in,cant_canios);
        std::cout<<diam.size()<<","<<espesor.size()<<","<<peso.size()<<","<<altura.size()<<","<<largos.size()<<std::endl;
    }else {
        std::cout << "Error abriendo el archivo" <<std::endl;
    }
    //Ahora armo los canios con todos los datos
    for (int j = 0; j < cant_canios; j++) {
        std::string denom = std::to_string(diam[j]) + "-" + std::to_string(espesor[j]);
        canio c(denom, peso[j],diam[j],largo,espesor[j]);
        canios.push_back(c);
    }
    //Ahora armo los paquetes de cada canio
    for (int i = 0; i < cant_canios; i++) {
        paquete p(canios[i],cant_canios_paq[i], altura[i]); //REVISAR
        paquetes.push_back(p);
    }

    in.close();
}


template <class T>
void cargar_tipo(std::vector<T>& v, std::ifstream& in, int cant){
    std::string act;
    int cant_cargados=0;

    while(cant_cargados<cant){ //mientras no se llegue a otra seccion cargo el vector actual
        in>>act;
        v.push_back(strtof(act.c_str(),0));
        //std::cout<<"Cargando: "<< act<<std::endl;
        cant_cargados++;
    }
}

bool is_number(const std::string& s){
    return !s.empty() && std::find_if(s.begin(),
                                      s.end(), [](char c) { return !std::isdigit(c); }) == s.end();
}

float solucion_golosa(std::vector<paquete> & paq, caja & empaquetado, float proba){

    //Tomo la de mejor beneficio y la guardo en la caja
    //Repetir mientras pueda agregar.
    std::mt19937 rng;
    rng.seed(std::random_device()());
    std::uniform_int_distribution<std::mt19937::result_type> paq_random(0,paq.size());
    std::uniform_int_distribution<std::mt19937::result_type> val_random(0,1);
    int ultimo_agregado = 0;
    int indice_libre;
    while(ultimo_agregado!=-1) {
        float val_max_ben = paq[0].get_suma_de_largos();//paq[0].get_beneficio();
        int indice_max_ben = 0;
        indice_libre = paq_random(rng);
        for (int i = 0; i < paq.size(); ++i) {
            if (paq[i].get_suma_de_largos() > val_max_ben) {
                indice_max_ben = i;
                val_max_ben = paq[i].get_beneficio();
            }
        }
        if(val_random(rng) <= proba) {
            indice_max_ben = indice_libre;
            //std::cout << "Uso uno por proba y no por beneficio" << std::endl;
        }
        //std::cout<<"peso paq indice: "<<indice_max_ben<<" peso: "<<paq[indice_max_ben].get_peso_total()<<std::endl;
        ultimo_agregado = empaquetado.agregar_paquete(paq[indice_max_ben]);
        //empaquetado.mostrar_info();
        //std::cout<<"ult: "<<ultimo_agregado<<std::endl;
    }
    //Aca tengo la caja cargada
    return empaquetado.get_metros();
}


void grasp(std::vector<paquete> & paq, caja & emp_max){
    caja aux(altura_max,ancho,largo,h_tope,p_tope);
    float proba = 1, shifter=0.01;
    float val_metros=0, val_aux;
    while(proba>=0.5){
        val_aux = solucion_golosa(paq,aux,proba);
        if(val_aux>val_metros){
            val_metros = val_aux;
            emp_max = aux;
        }
        proba -= shifter;
    }
}




void dinamica(std::vector<paquete> & vp, caja & c){
    std::vector<std::vector<int> > sol(p_tope,std::vector<int>(vp.size(),-1));
    std::vector<std::vector<std::vector<int> > > sol_vec(p_tope, std::vector<std::vector<int> >(vp.size(),std::vector<int>()));
    std::vector<int> elem;
    std::cout << "filas: "<< sol_vec.size()<< ". "<< sol_vec[0].size()<< ". "<<sol_vec[0][0].size()<<std::endl;
    std::cout << "filas: "<< sol.size()<< ". "<< sol[0].size()<< std::endl;
    int cant_elem = dinamica_aux(vp,p_tope-1,vp.size()-1,0,0,0,sol,sol_vec);
    std::cout<<"cant elem: "<<cant_elem<<std::endl;

}

int dinamica_aux(std::vector<paquete> & vp, int i, int j, float h, float p, float l, std::vector<std::vector<int> >& sol, std::vector<std::vector<std::vector<int> > >& elem){
    if(j<0) {
        return 0;
    }
    if(i<0) {
        return -INT64_MAX;
    }
    if(h > h_tope){
        return -INT64_MAX;
    }
    if(p > p_tope) {
        return -INT64_MAX;
    }
    if(sol[i][j] == -1)  {
        if (i  == vp[j].get_peso_total()) {
            sol[i][j] = 1;
            elem[i][j].push_back(j);

        }else if(i < vp[j].get_peso_total()) { //si el peso actual es menor al peso del paquete actual, como estan ordenados asc por pesos seguro que los demás tmb lo superan a i y a los i-k, porque va decreciendo
            //std::cout<<"aca entre"<<std::endl;
            sol[i][j] = dinamica_aux(vp,i,j-1,h,p,l,sol,elem);
        }else { //si el peso actual es mayor al peso del paquete actual entonces busco la mejor sol entre los posibles paquetes
            int val1= dinamica_aux(vp,i,j-1,h,p,l,sol,elem);
            int val2 = dinamica_aux(vp,i-vp[j].get_peso_total(),j-1, h+vp[j].get_altura(),p+vp[j].get_peso_total(),l+vp[j].get_suma_de_largos(),sol,elem);
            if(val1 < val2){
                if(i-vp[j].get_peso_total()>=0&&j-1>=0) {
                    elem[i][j]=elem[i-vp[j].get_peso_total()][j-1];
                }
                elem[i][j].push_back(j);

            }else{
                if(j-1>=1){
                    elem[i][j]=elem[i][j-1];
                }
                if(i-vp[j].get_peso_total()>=0&&j-1>=0) {
                    elem[i][j]=elem[i-vp[j].get_peso_total()][j-1];
                }
            }
            sol[i][j] = std::max(1 + val2, val1);
        }
    }
    return sol[i][j];
}
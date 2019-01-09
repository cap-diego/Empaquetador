#include "../headers/caja.h"


int caja::agregar_paquete(paquete &p) {
    //Si el peso del camion y la altura me lo permite agrego el paquete
    if(p.get_peso_total() + peso_total <= peso_tope && p.get_altura() + altura_total <= altura_tope) {
        peso_total += p.get_peso_total();
        //std::cout<<"sumado peso: "<<p.get_peso_total()<<" sumada altura: "<< p.get_altura()<<std::endl;
        altura_total += p.get_altura();
        suma_largos_total += p.get_suma_de_largos();
        paquetes.push_back(p);
    }else return -1;
    return 0;
}
void caja::operator=(const caja &c) {
    this->paquetes = c.paquetes;
    this->peso_total = c.peso_total;
    this->peso_tope = c.peso_tope;
    this->altura_tope = c.altura_tope;
    this->suma_largos_total = c.suma_largos_total;
    this->altura_total = c.altura_total;
}
float caja::get_metros() const {
    return suma_largos_total;
}
void caja::mostrar_info() const {
    for (int i = 0; i < paquetes.size(); ++i) {
        //paquetes[i].mostrar_info();
    }
    std::cout <<"Cantidad de paquetes: "<<paquetes.size()<<std::endl<<"Altura: "<<altura_total<<"/"<<altura_tope<<std::endl<<"Peso total: "<< peso_total<<"/"<<peso_tope<<std::endl<<"Largo: "<<suma_largos_total<<std::endl;

    std::cout<<"paquetes usados: "<<std::endl;

    for(auto& p : paquetes){
        std::cout<<p.get_diam()<<":"<<p.get_espesor()<<", ";
    }

}

void caja::eliminar_paquete(paquete &p) {
    peso_total -= p.get_peso_total();
    altura_total -= p.get_altura();
    suma_largos_total -= p.get_suma_de_largos();
    for (auto it = std::begin(paquetes); it!=std::end(paquetes); ++it){
        if((*it)==p){
            paquetes.erase(it);
            return;
        }
    }
}
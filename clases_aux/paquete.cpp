#include "../headers/paquete.h"

paquete::paquete(canio& c, int cant_canios, float h) {
    denominacion = c.denominacion;
    peso_total = c.get_peso() * cant_canios;
    suma_de_largos = c.get_largo() * cant_canios;
    altura = h;
    diam = c.get_diametro();
    this->cant_canios=cant_canios;
    beneficio = suma_de_largos/peso_total;
    espesor=c.get_espesor();
}
float paquete::get_altura() {
    return altura;
}
float paquete::get_diam() const {
    return diam;
}
float paquete::get_peso_total() {
    return peso_total;
}

float paquete::get_espesor() const {
    return espesor;
}
float paquete::get_suma_de_largos() {
    return suma_de_largos;
}
int paquete::get_cant_canios() const {
    return cant_canios;
}
void paquete::set_altura(float h) {
    altura=h;
}

bool paquete::operator<(const paquete &p) const {
    if(this->peso_total < p.peso_total){
        return true;
    }
    return false;
}

bool paquete::operator==(const paquete& p)const{
    if(p.denominacion == this->denominacion) return true;
    return false;
}
float paquete::get_beneficio()const{
    return beneficio;
}

void paquete::mostrar_info() const {
    std::cout<<"PAQUETE DE CAÑOS: "<<denominacion<<std::endl;
    std::cout<<"Cantidad de caños: "<<cant_canios<<std::endl <<"Peso total: "<<peso_total<<". Altura: "<<altura<<". Suma de largo: "<<suma_de_largos<<" Espesor: "<<espesor<<" Beneficio: "<<beneficio<<std::endl;
    std::cout<<std::endl;
}

void paquete::set_peso_total(float p) {
    peso_total=p;
}
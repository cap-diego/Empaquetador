#include "../headers/canio.h"


float canio::get_diametro() {
    return diametro;
}

float canio::get_largo() {
    return largo;
}

float canio::get_peso() {
    return peso;
}

void canio::set_espesor(float e) {
    espesor = e;
}

float canio::get_espesor() {
    return espesor;
}

void canio::mostrar_info() {
    canio c = *this;
    std::cout <<"Muestro info del caño: "<<std::endl;
    std::cout<<"Caño: " <<c.denominacion<<" largo: "<<c.get_largo()<<" peso: "<<c.get_peso()<<" diametro: "<<c.get_diametro()<<" espesor: "<<c.get_espesor()<<std::endl;
}

void canio::set_diametro(float d) {
    diametro=d;
}
void canio::set_largo(float l) {
    largo=l;
}
void canio::set_peso(float p) {
    peso=p;
}


#ifndef PRODUCCION_CAÑO_H
#define PRODUCCION_CAÑO_H

#include "utils.h"

class canio{
public:
    canio(std::string denom, float p, float d, float l, float e){
        denominacion=denom;
        peso=p;
        largo=l;
        diametro=d;
        espesor = e;
    }
    std::string denominacion;
    float get_largo();
    float get_diametro();
    float get_peso();
    void set_largo(float l);
    void set_diametro(float d);
    void set_peso(float p);
    float get_espesor();
    void set_espesor(float e);
    void mostrar_info();
private:
    float espesor;
    float diametro;
    float peso;
    float largo;

};

#endif //PRODUCCION_CAÑO_H

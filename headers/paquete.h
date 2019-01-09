#ifndef PRODUCCION_PAQUETE_H
#define PRODUCCION_PAQUETE_H

#include "canio.h"

class paquete{
public:
    paquete(canio& c, int cant_canios, float h);

    float get_peso_total();
    float get_altura();
    float get_suma_de_largos();
    bool operator==(const paquete& p)const;
    bool operator<(const paquete& p) const;
    void set_peso_total(float p);
    float get_beneficio() const;
    void set_altura(float h);
    void mostrar_info() const;
    std::string denominacion;
    int get_cant_canios()const;
    float get_diam() const;
    float get_espesor() const;

private:
    float beneficio;
    float diam;
    float espesor;
    float peso_total;//kg
    int cant_canios;//unidad de canios
    float altura;//mm
    float suma_de_largos;//mts
    float dist_entre_centros;
};

#endif //PRODUCCION_PAQUETE_H

#ifndef PRODUCCION_CAJA_H
#define PRODUCCION_CAJA_H

#include "paquete.h"

class caja{
public:
    caja(float altura, float ancho, float largo, float h_tope, float p_tope){
        peso_total=0;
        altura_total=0;
        suma_largos_total=0;
        peso_tope = p_tope;
        altura_tope = h_tope;
    }
    int agregar_paquete(paquete &p);//0 si todo ok, -1 si no
    void eliminar_paquete(paquete &p);
    void mostrar_info()const;
    float get_metros() const;
    void operator=(const caja& c);
private:
    std::vector<paquete> paquetes;
    float peso_total;
    float altura_total;
    float peso_tope;
    float altura_tope;
    float suma_largos_total;
};

#endif //PRODUCCION_CAJA_H

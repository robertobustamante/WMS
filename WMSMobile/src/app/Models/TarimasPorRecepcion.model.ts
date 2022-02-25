export interface TarimasPorRecepcion {
  operacion: number;
  planta_id: string;
  orden_compra_recepcion_id: number,
  tarima_id: string,
  secuencia_id: number,
  material_desc: string,
  cantidad_may_remfact: number,
  cantidad_men_remfact: number,
  unidad_mayor_desc: string,
  cantidad_may_recepcion: number,
  unidad_menor_desc: string,
  cantidad_men_recepcion: number,
  unidad_sistema_desc: string,
  cantidad_recepcion: string,
  asignado_a: string
}

export interface RecepcionModel {
  operacion: number;
  planta_id: number;
  planta_desc: string;
  orden_compra_recepcion_id: number;
  orden_compra_id: number;
  estatus_id: number;
  estatus_desc: string;
  almacen_id: number;
  almacen_desc: string;
  proveedor_id: number;
  proveedor_nombre: string;
  moneda_id: number;
  moneda_desc: string;
  tipo_cambio: string;
  remision_id: number;
  factura: string;
  observaciones: string;
  imprimir_etiquetas_ind: boolean;
  folio_mov_entrada: string;
  folio_mov_ajuste: string;
  usuario_recepcion_id: number;
  usuario_recepcion_desc: string;
  fecha_recepcion: string;
  usuario_alta_id: number;
  usuario_alta_desc: string;
  fecha_alta: string;
  usuario_modifica_id: number;
  usuario_modifica_desc: string;
  fecha_modifica: string;
  usuario_elimina_id: number;
  usuario_elimina_desc: string;
  fecha_elimina: string;
  microsip_folio: string;
  remision: string;
  recepcion: number;
  cantidad_tarimas: number;
  cantidad_may_remfact: number;
  cantidad_men_remfact: number;
  cantidad_may_recepcion: number;
  cantidad_men_recepcion: number;
}

export interface CodigoBarras {
  HayError: boolean;
  MensajeError: string;
  Respuesta: boolean;
  RespuestaLista: string;
  RespuestaEntidad: [{
    OPERACION: number;
    PLANTA_ID: string;
    ORDEN_COMPRA_RECEPCION_ID: number;
    TARIMA_ID: string;
    LADO: string;
    SECUENCIA: number;
    CONTENEDOR: string;
    MATERIAL: string;
    CANTIDAD_MAY: number;
    CANTIDAD_MEN: number;
    CANTIDAD: number;
  }];
  MensajeRespuesta: string;
  TipoRespuesta: number;
  ControlTag: string;
}

export interface CodigoBarras {
  hayError: boolean;
  mensajeError: string;
  respuesta: boolean;
  respuestaLista: string;
  respuestaEntidad: [{
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
  mensajeRespuesta: string;
  tipoRespuesta: number;
  valorSalida: string;
}

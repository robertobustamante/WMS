import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subscriber } from 'rxjs';
import { TarimasPorRecepcion } from '../Models/TarimasPorRecepcion.model';
import { DetalleLadosTarimaModel } from '../Models/DetalleLadosTarima.model';
import { DetalleProductoTarima } from '../Models/DetalleProductoTarima.model';
import { TarimaAbierta } from '../Models/TarimaAbierta.model';
import { EstatusTarima } from '../Models/EstatusTarima.model';
import { CodigoBarras } from '../Models/CodigoBarras.model';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class RecepcionesService {

  constructor(private http: HttpClient) {
  }

  getTarimasPorRecepcion (operacion: any, IdPlanta: any, OrdenCompraRecepcion: any): Observable<TarimasPorRecepcion[]> {
    const params = new HttpParams()
      .set('pOperacion', operacion)
      .set('pPlanta_id', IdPlanta)
      .set('pTarima_id', '')
      .set('pOrden_Compra_Recepcion_id', OrdenCompraRecepcion)
      .set('access-control-allow-origin', environment.apiUrl);
    return this.http.get<TarimasPorRecepcion[]>(environment.apiUrl + '/api/ORDEN_COMPRA_RECEPCION_RESUMEN', { params });
  }
  getDetalleLadosTarima (operacion: any, IdPlanta: any, IdTarima: any, OrdenCompraRecepcion: any): Observable<DetalleLadosTarimaModel[]>{
    const params = new HttpParams()
    .set('pOperacion', operacion)
    .set('pPlanta_id', IdPlanta)
    .set('pTarima_id', IdTarima)
    .set('pOrden_Compra_Recepcion_id', OrdenCompraRecepcion)
    .set('access-control-allow-origin',environment.apiUrl);
    return this.http.get<DetalleLadosTarimaModel[]>(environment.apiUrl + '/api/ORDEN_COMPRA_RECEPCION', { params });
  }
  getDetalleProductoPorTarima (operacion: any, IdPlanta: any,  IdTarima: any, OrdenCompraRecepcion: any): Observable<DetalleProductoTarima[]> {
    const params = new HttpParams()
      .set('pOperacion', operacion)
      .set('pPlanta_id', IdPlanta)
      .set('pTarima_id', IdTarima)
      .set('pOrden_Compra_Recepcion_id', OrdenCompraRecepcion)
      .set('access-control-allow-origin',environment.apiUrl);
    return this.http.get<DetalleProductoTarima[]>(environment.apiUrl + '/api/ORDEN_COMPRA_RECEPCION_RESUMEN', { params });
  }
  getTarimaAbierta(operacion: any, IdPlanta: any, OrdenCompraRecepcion: any, usuarioId: any): Observable<TarimaAbierta[]> {
    const params = new HttpParams()
    .set('pOperacion', operacion)
    .set('pPlanta_id', IdPlanta)
    .set('pOrden_Compra_Recepcion_id', OrdenCompraRecepcion)
    .set('pUsusarioId', usuarioId)
    .set('access-control-allow-origin',environment.apiUrl);
    return this.http.get<TarimaAbierta[]>(environment.apiUrl + '/api/ORDEN_COMPRA_RECEPCION', { params })
  }
  postCodigoBarras(IdPlanta: any,  IdTarima: any, ordenCompraRecepcion: any, ladoTarima: any, codigoBarras: any, macAddress: any, usuarioModifica: any, material: any, cantidadMenor: any): Observable<CodigoBarras> {
    const params = new HttpParams()
      .set('pPlanta_id', IdPlanta)
      .set('pTarima_id', IdTarima)
      .set('pOrden_Compra_Recepcion_id', ordenCompraRecepcion)
      .set('pLado_Tarima', ladoTarima)
      .set('pCodigo_Barras', codigoBarras)
      .set('pMacAddress', macAddress)
      .set('pusuario_modifica_id', usuarioModifica)
      .set('pMaterial', material)
      .set('pCantidad_Menor', cantidadMenor)
      .set('access-control-allow-origin',environment.apiUrl);
      return this.http.post<CodigoBarras>(environment.apiUrl + '/api/CODIGOBARRAS', { params });
  }
  putEstatusTarima(IdPlanta: any, ordenCompraRecepcion: any,  IdTarima: any, usuarioId: any, estatus: any): Observable<EstatusTarima> {
    const params = new HttpParams()
    .set('pPlanta_id', IdPlanta)
    .set('pOrden_Compra_Recepcion_id', ordenCompraRecepcion)
    .set('pTarima_id', IdTarima)
    .set('pusuario_id', usuarioId)
    .set('Estatus', estatus)
    .set('access-control-allow-origin',environment.apiUrl);
    return this.http.put<EstatusTarima>(environment.apiUrl + '/api/OCR_MATERIAL', { params });
  }
}

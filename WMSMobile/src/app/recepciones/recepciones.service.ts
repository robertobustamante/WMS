import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { TarimasPorRecepcion } from '../Models/TarimasPorRecepcion.model';
import { DetalleLadosTarimaModel } from '../Models/DetalleLadosTarima.model';
import { DetalleProductoTarima } from '../Models/DetalleProductoTarima.model';
import { TarimaAbierta } from '../Models/TarimaAbierta.model';
import { EstatusTarima } from '../Models/EstatusTarima.model';
import { CodigoBarras } from '../Models/CodigoBarras.model';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RecepcionesService {
  private apiUrl = '/Api/recepciones/';

  constructor(private http: HttpClient) {
  }

  getTarimaAbierta(ip: string, IdPlanta: any, OrdenCompraRecepcion: any, usuarioId: any): Observable<TarimaAbierta[]> {
    const params = new HttpParams()
    .set('idPlanta', IdPlanta)
    .set('idOrdenCompraRecepcion', OrdenCompraRecepcion)
    .set('idUsuario', usuarioId)
    .set('access-control-allow-origin', ip + this.apiUrl);
    return this.http.get<TarimaAbierta[]>(ip + this.apiUrl + 'GetTablaRecepcionAsignacionTarima', { params }).pipe(retry(1), catchError(this.handleError));
  }

  getTarimasPorRecepcion (ip: string, IdPlanta: any, OrdenCompraRecepcion: any): Observable<TarimasPorRecepcion[]> {
    const params = new HttpParams()
      .set('idPlanta', IdPlanta)
      .set('idOrdenCompraRecepcion', OrdenCompraRecepcion)
      .set('access-control-allow-origin', ip + this.apiUrl);
    return this.http.get<TarimasPorRecepcion[]>(ip + this.apiUrl + 'GetTablaTarimaRecepcion', { params }).pipe(retry(1), catchError(this.handleError));
  }
  getDetalleLadosTarima (ip: string, IdPlanta: any, IdTarima: any, OrdenCompraRecepcion: any): Observable<DetalleLadosTarimaModel[]>{
    const params = new HttpParams()
    .set('idPlanta', IdPlanta)
    .set('idTarima', IdTarima)
    .set('idOrdenCompraRecepcion', OrdenCompraRecepcion)
    .set('access-control-allow-origin',ip + this.apiUrl);
    return this.http.get<DetalleLadosTarimaModel[]>(ip + this.apiUrl + 'GetTablaLadosTarima', { params }).pipe(retry(1), catchError(this.handleError));
  }
  getDetalleProductoPorTarima (ip: string, IdPlanta: any,  IdTarima: any, OrdenCompraRecepcion: any): Observable<DetalleProductoTarima[]> {
    const params = new HttpParams()
      .set('idPlanta', IdPlanta)
      .set('idTarima', IdTarima)
      .set('idOrdenCompraRecepcion', OrdenCompraRecepcion)
      .set('access-control-allow-origin',ip + this.apiUrl);
    return this.http.get<DetalleProductoTarima[]>(ip + this.apiUrl + 'GetTablaDetalleRecepcionMaterial', { params }).pipe(retry(1), catchError(this.handleError));
  }

  postCodigoBarras(ip: string, IdPlanta: any,  IdTarima: any, ordenCompraRecepcion: any, ladoTarima: any, codigoBarras: any, macAddress: any, usuarioModifica: any, material: any, cantidadMenor: any): Observable<CodigoBarras> {
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
      .set('access-control-allow-origin',ip + this.apiUrl);
      return this.http.post<CodigoBarras>(ip + this.apiUrl + 'PostCodigoBarras', { params }).pipe(retry(1), catchError(this.handleError));
  }
  putEstatusTarima(ip: string, IdPlanta: any, ordenCompraRecepcion: any,  IdTarima: any, usuarioId: any, estatus: any): Observable<EstatusTarima> {
    const params = new HttpParams()
    .set('idPlanta', IdPlanta)
    .set('idOrdenCompraRecepcion', ordenCompraRecepcion)
    .set('idTarima', IdTarima)
    .set('idUsuario', usuarioId)
    .set('idEstatus', estatus)
    .set('access-control-allow-origin',ip + this.apiUrl);
    return this.http.put<EstatusTarima>(ip + this.apiUrl + 'PutAsignaTarima', { params }).pipe(retry(1), catchError(this.handleError));
  }
  handleError(error: any) {
    debugger;
    window.alert(error.message);
    return throwError(error.message);
  }
}

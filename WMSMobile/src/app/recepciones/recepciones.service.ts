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
  getTablaRecepcionMaterial(ip: string, IdPlanta: any, IdOrdenCompra): Observable<any> {
    const params = new HttpParams()
      .set('idPlanta', IdPlanta)
      .set('idOrdenCompraRecepcion', IdOrdenCompra)
      .set('access-control-allow-origin',ip + this.apiUrl);
    return this.http.get<any>(ip+this.apiUrl+'GetTablaRecepcionMaterial', { params });
  }
  getCodigoBarras(ip: string, IdPlanta: any,  IdTarima: any, ordenCompraRecepcion: any, ladoTarima: any, codigoBarras: any, macAddress: any, usuarioModifica: any, material: any, cantidadMenor: any): Observable<CodigoBarras> {
    const params = new HttpParams()
      .set('idPlanta', IdPlanta)
      .set('idOrdenCompraRecepcion', ordenCompraRecepcion)
      .set('idTarima', IdTarima)
      .set('idLado', ladoTarima)
      .set('idCodigoBarras', codigoBarras)
      .set('idMacAddress', macAddress)
      .set('idUsuario', usuarioModifica)
      .set('idMaterial', material)
      .set('CantidadMenor', cantidadMenor)
      .set('access-control-allow-origin',ip + this.apiUrl);
    return this.http.get<CodigoBarras>(ip + this.apiUrl + 'GetCodigoBarras', { params });//.pipe(retry(1), catchError(this.handleError));
  }
  deleteCodigoBarras(ip: string, IdPlanta: any,  IdTarima: any, ordenCompraRecepcion: any, ladoTarima: any, codigoBarras: any, macAddress: any, usuarioModifica: any): Observable<CodigoBarras> {
    const params = new HttpParams()
      .set('idPlanta', IdPlanta)
      .set('idOrdenCompraRecepcion', ordenCompraRecepcion)
      .set('idTarima', IdTarima)
      .set('idLado', ladoTarima)
      .set('idCodigoBarras', codigoBarras)
      .set('idMacAddress', macAddress)
      .set('idUsuario', usuarioModifica)
      .set('access-control-allow-origin',ip + this.apiUrl);
    return this.http.delete<CodigoBarras>(ip + this.apiUrl + 'DeleteCodigoBarras', { params });//.pipe(retry(1), catchError(this.handleError));
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

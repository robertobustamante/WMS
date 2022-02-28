import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { MaterialModel } from '../Models/Material.model';
import { retry, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MaterialesService {
  private apiUrl = '/Api/recepciones/';

  constructor(private http: HttpClient) {
  }
  getTarimaAbierta(ip: string, IdPlanta: any, OrdenCompraRecepcion: any): Observable<MaterialModel[]> {
    const params = new HttpParams()
    .set('idPlanta', IdPlanta)
    .set('idOrdenCompraRecepcion', OrdenCompraRecepcion)
    .set('access-control-allow-origin', ip + this.apiUrl);
    return this.http.get<MaterialModel[]>(ip + this.apiUrl + 'GetTablaRecepcionMaterial', { params }).pipe(retry(1), catchError(this.handleError));
  }
  postAgregarContenedor(ip: string, IdPlanta: any,  IdTarima: any, ordenCompraRecepcion: any, ladoTarima: any, macAddress: any, usuarioModifica: any): Observable<any> {
    const params = new HttpParams()
      .set('idPlanta', IdPlanta)
      .set('idOrdenCompraRecepcion', ordenCompraRecepcion)
      .set('idTarima', IdTarima)
      .set('idLado', ladoTarima)
      .set('idMacAddress', macAddress)
      .set('idUsuario', usuarioModifica)
      .set('access-control-allow-origin',ip + this.apiUrl);
    return this.http.post<any>(ip + this.apiUrl+'PostAgregarContenedor', {params});
  }
  handleError(error: any) {
    debugger;
    window.alert(error.message);
    return throwError(error.message);
  }
}

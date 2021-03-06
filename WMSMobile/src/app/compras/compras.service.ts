import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { CompraModel } from 'src/app/Models/Compra.model';
import { RecepcionModel } from 'src/app/Models/Recepcion.model';
import { environment } from 'src/environments/environment';
import { retry, catchError } from 'rxjs/operators';

import { Http, HttpResponse } from '@capacitor-community/http';

@Injectable({
  providedIn: 'root'
})
export class ComprasService {
  private apiUrl = '/Api/compras/';

  constructor(private http: HttpClient) {
  }

  getOrdenCompra(ip: string, IdPlanta: any): Observable<CompraModel[]>{
    let params = new HttpParams()
    .set('access-control-allow-origin',ip + this.apiUrl)
    .set('idPlanta', IdPlanta);

    return this.http.get<CompraModel[]>(ip + this.apiUrl + 'GetTablaOrdenCompra', { params }).pipe(retry(1), catchError(this.handleError));
  }
  getRecepcion(ip: string, IdPlanta: any, folio: any): Observable<RecepcionModel[]> {
    var params = new HttpParams()
      .set('access-control-allow-origin', ip + this.apiUrl)
      .set('idPlanta', IdPlanta)
      .set('folioMicrosip', folio);

    return this.http.get<RecepcionModel[]>(ip + this.apiUrl + 'GetTablaRecepcion', { params }).pipe(retry(1), catchError(this.handleError));
  }

  getNewOrdenCompra(ip: string, IdPlanta: any) {
    Http.request({ url: `${ip}${this.apiUrl}GetTablaOrdenCompra?idPlanta=${IdPlanta}`, method: 'GET' })
      .then(async response => {
        if (response.status === 200) {
          return await response.data;
        }
      })
      .catch(e => {
        console.log(e)
      })
  }

  handleError(error: any) {
    debugger;
    window.alert(error.message);
    return throwError(error.message);
  }
}

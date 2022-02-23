import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ComprasService } from './compras.service';
import { CompraModel } from 'src/app/Models/Compra.model';
import { RecepcionModel } from 'src/app/Models/Recepcion.model';
import { environment } from 'src/environments/environment';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-compras',
  templateUrl: './compras.page.html',
  styleUrls: ['./compras.page.scss'],
})
export class ComprasPage implements OnInit, OnDestroy {

  comprasData: CompraModel[];
  recepcionData: RecepcionModel[];
  loading: boolean;
  hostIp: string;
  enableCors: boolean = true;
  enableEncode: boolean = false;
  btnDisabled = true;
  currentComprasSelected = 0;
  currentRecepcionSelected = -1;
  selectedIdRecepcion = 0;

  private subscription: Subscription = new Subscription();
  constructor(private comprasService: ComprasService, private alertController: AlertController) { }

  ngOnInit(): void {
    this.hostIp = environment.apiUrl;
    this.buscar();
  }

  async configuracionIp() {
    const alert = await this.alertController.create({
      cssClass: 'my-custom-class',
      header: 'Configuracion IP',
      inputs: [
        {
          name: 'apiUrl',
          type: 'text',
          placeholder: 'api Url',
          value: this.hostIp
        },
        {
          name: 'enableCors',
          type: 'checkbox',
          label: 'Habilitar Cors',
          checked: this.enableCors
        },
        {
          name: 'enableEncode',
          type: 'checkbox',
          label: 'Habilitar Encode',
          checked: this.enableEncode
        }
      ],
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          cssClass: 'secondary',
          handler: () => {
            console.log('Confirm Cancel');
          }
        }, {
          text: 'Ok',
          handler: data => {
            this.hostIp = data.apiUrl;
            this.buscar()
          }
        }
      ]
    });

    await alert.present();
  }

  buscar() {
    try {
      this.loading = true;
      this.subscription.add(this.comprasService.getOrdenCompra(this.hostIp, 6).subscribe(data => {
        this.comprasData = data;
        this.loading = false;
      }));
    } catch (error) {
      this.loading = false;
      this.mostrarMensaje(error);
    }
  }

  cambiarCompra(folio: any, indx: any) {
    this.currentComprasSelected = indx;
    this.currentRecepcionSelected = -1;
    this.btnDisabled = true;
    try {
      this.subscription.add(this.comprasService.getRecepcion(this.hostIp, 1, folio).subscribe(resp => {
        this.recepcionData = resp;
      }));
    } catch(error) {
      debugger;
      this.mostrarMensaje(error);
    }
  }

  recepcionSelected(indx: any) {
    this.currentRecepcionSelected = indx;
    this.selectedIdRecepcion = this.recepcionData[indx].recepcion;
    if (this.recepcionData[indx]) {
      this.btnDisabled = false;
    } else {
      this.btnDisabled = true;
    }
  }

  ngOnDestroy(): void {
    if(this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  async mostrarMensaje(error) {
    const alert = await this.alertController.create({
      cssClass: 'my-custom-class',
      header: 'Error',
      message: error,
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          cssClass: 'secondary',
          handler: () => {
            console.log('Confirm Cancel');
          }
        }, {
          text: 'Ok',
          handler: () => {
            console.log('Confirm Ok');
          }
        }
      ]
    });

    await alert.present();
  }

}

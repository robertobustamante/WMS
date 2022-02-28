import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { AlertController } from '@ionic/angular';
import { RecepcionesService } from './recepciones.service';
import { TarimasPorRecepcion } from '../Models/TarimasPorRecepcion.model';
import { DetalleLadosTarimaModel } from '../Models/DetalleLadosTarima.model';
import { DetalleProductoTarima } from '../Models/DetalleProductoTarima.model';
import { CodigoBarras } from '../Models/CodigoBarras.model';
import { ModalController } from '@ionic/angular';
import { MaterialesPage } from '../materiales/materiales.page';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-recepciones',
  templateUrl: './recepciones.page.html',
  styleUrls: ['./recepciones.page.scss'],
})
export class RecepcionesPage implements OnInit {
  public folder = 'Recepciones';
  public entrada = 'Entrada-25';
  public tarima = 'Tarima #1A0001 (1)';
  public lockState = 'lock-open';

  public ladoSeleccionado = 'A';

  public buttonA = 'success';
  public buttonB = 'primary';
  public buttonC = 'primary';
  public buttonD = 'primary';

  public classLadoA = 'selectedHeader';
  public classLadoB = 'normalHeader';
  public classLadoC = 'normalHeader';
  public classLadoD = 'normalHeader';

  idOrdenRecepcion: any;
  private selectedTarima: string = '';

  tarimasPorRecepcionData: TarimasPorRecepcion[];
  detalleLadosTarimaData: DetalleLadosTarimaModel[];
  detalleProductosTarimaData: DetalleProductoTarima[];
  buscarCodigoResponse: CodigoBarras;
  loading: boolean;
  showModalAgregar = false;
  tipoOperacionCodigoBarras = 'agregar';
  hostIp: string;

  private subscription: Subscription = new Subscription();
  constructor(private activatedRoute: ActivatedRoute, private recepcionesService: RecepcionesService, private modalController: ModalController, private alertController: AlertController) {
  }

  ngOnInit() {
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
    this.idOrdenRecepcion = this.activatedRoute.snapshot.paramMap.get('id');
    if(!this.idOrdenRecepcion) {
      this.idOrdenRecepcion = 1;
    }
    this.loading = true;
    this.subscription.add(this.recepcionesService.getTarimaAbierta(this.hostIp, 1, this.idOrdenRecepcion, 1).subscribe(dtTA =>
      {
        this.selectedTarima = dtTA[0].tarima_id;
        this.tarima = 'Tarima #'+ this.selectedTarima + '(1)';
        if(dtTA[0].estatus == 0) {
          this.lockState = 'lock-open';
        } else if(dtTA[0].estatus == 1) {
          this.lockState = 'lock-closed';
        }

        this.subscription.add(this.recepcionesService.getTarimasPorRecepcion(this.hostIp, 1,this.idOrdenRecepcion).subscribe(dtTR => {
          this.tarimasPorRecepcionData = dtTR;
        }));
        setTimeout(() => {
          this.subscription.add(this.recepcionesService.getDetalleLadosTarima(this.hostIp, 1,this.selectedTarima, this.idOrdenRecepcion).subscribe(dtDLT => {
            this.detalleLadosTarimaData = dtDLT;
          }));
          this.subscription.add(this.recepcionesService.getDetalleProductoPorTarima(this.hostIp,1,this.selectedTarima, this.idOrdenRecepcion).subscribe(dtDPT => {
            this.detalleProductosTarimaData = dtDPT;
          }));
        }, 200);
      }));

    this.loading = false;
  }
  public buscarCodigo(codigo: any) {
    if(this.tipoOperacionCodigoBarras == 'agregar'){
      this.subscription.add(this.recepcionesService.getCodigoBarras(this.hostIp, 1, this.selectedTarima.trim(), this.idOrdenRecepcion, this.ladoSeleccionado, codigo.value, '1456398', 1, 0, 0 ).subscribe(data => {
        this.buscarCodigoResponse = data;
        if(this.buscarCodigoResponse.hayError || this.buscarCodigoResponse.mensajeRespuesta == "EL PROVEEDOR NO TIENE CONFIGURADO UN MATERIAL") {
          this.presentModalMateriales();
        } else {
          this.subscription.add(this.recepcionesService.getDetalleLadosTarima(this.hostIp, 1,this.selectedTarima, this.idOrdenRecepcion).subscribe(dtDLT => {
            this.detalleLadosTarimaData = dtDLT;
          }));
          this.subscription.add(this.recepcionesService.getDetalleProductoPorTarima(this.hostIp,1,this.selectedTarima, this.idOrdenRecepcion).subscribe(dtDPT => {
            this.detalleProductosTarimaData = dtDPT;
          }));
        }
      }));
    } else {
      this.subscription.add(this.recepcionesService.deleteCodigoBarras(this.hostIp, 1, this.selectedTarima, this.idOrdenRecepcion, this.ladoSeleccionado, codigo.value, '1456398', 1).subscribe(data => {
        if(data.hayError){
          this.mensaje('Error', data.mensajeError);
        } else {
          this.subscription.add(this.recepcionesService.getDetalleLadosTarima(this.hostIp, 1,this.selectedTarima, this.idOrdenRecepcion).subscribe(dtDLT => {
            this.detalleLadosTarimaData = dtDLT;
          }));
          this.subscription.add(this.recepcionesService.getDetalleProductoPorTarima(this.hostIp,1,this.selectedTarima, this.idOrdenRecepcion).subscribe(dtDPT => {
            this.detalleProductosTarimaData = dtDPT;
          }));
        }
      }));
    }
  }

  public cambiarLock() {
    if(this.lockState === 'lock-closed') {
      this.lockState = 'lock-open';
    } else {
      this.lockState = 'lock-closed';
    }
    this.subscription.add(this.recepcionesService.putEstatusTarima(this.hostIp, 1, this.idOrdenRecepcion, this.selectedTarima.trim(), 1, this.lockState === 'lock-closed' ? 1 : 0).subscribe(data => {

    }));
  }
  async cambiarFocoBoton(id) {
    this.ladoSeleccionado = id;
    if(id === 'A') {
      this.buttonA = 'success';
      this.buttonB = 'primary';
      this.buttonC = 'primary';
      this.buttonD = 'primary';
      this.classLadoA = 'selectedHeader';
      this.classLadoB = 'normalHeader';
      this.classLadoC = 'normalHeader';
      this.classLadoD = 'normalHeader';
    } else if(id === 'B') {
      this.buttonA = 'primary';
      this.buttonB = 'success';
      this.buttonC = 'primary';
      this.buttonD = 'primary';
      this.classLadoA = 'normalHeader';
      this.classLadoB = 'selectedHeader';
      this.classLadoC = 'normalHeader';
      this.classLadoD = 'normalHeader';
    } else if(id === 'C') {
      this.buttonA = 'primary';
      this.buttonB = 'primary';
      this.buttonC = 'success';
      this.buttonD = 'primary';
      this.classLadoA = 'normalHeader';
      this.classLadoB = 'normalHeader';
      this.classLadoC = 'selectedHeader';
      this.classLadoD = 'normalHeader';
    } else if(id === 'D') {
      this.buttonA = 'primary';
      this.buttonB = 'primary';
      this.buttonC = 'primary';
      this.buttonD = 'success';
      this.classLadoA = 'normalHeader';
      this.classLadoB = 'normalHeader';
      this.classLadoC = 'normalHeader';
      this.classLadoD = 'selectedHeader';
    }
  }
  async presentModalMateriales() {
    const modal = await this.modalController.create({
      component: MaterialesPage,
      cssClass: 'my-custom-class',
      componentProps: {
        'idPlanta': 1,
        'idOrdenCompra': this.idOrdenRecepcion,
        'ip': this.hostIp
      }
    });
    return await modal.present();
  }
  async mensaje(header: string, message: string) {
    const alert = await this.alertController.create({
      cssClass: 'my-custom-class',
      header: header,
      message: message,
      buttons: [
        {
          text: 'OK',
          cssClass: 'secondary',
          handler: () => {
            console.log('Confirm Okay');
          }
        }
      ]
    });
    await alert.present();
  }

  async presentAlertPrompt(id = null) {
    const headerCapt = (id == null ? 'Agregar Cantidad' : 'Editar');
    const valSec = (id == null ? '' : '40');
    const valCant = (id == null ? '' : '20');

    const alert = await this.alertController.create({
      cssClass: 'my-custom-class',
      header: headerCapt,
      inputs: [
        {
          name: 'name1',
          type: 'text',
          placeholder: 'Sec',
          value: valSec
        },
        {
          name: 'name2',
          type: 'text',
          id: 'name2-id',
          placeholder: 'Cant Menor',
          value: valCant
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
          handler: () => {
            console.log('Confirm Ok');
          }
        }
      ]
    });

    await alert.present();
  }
}

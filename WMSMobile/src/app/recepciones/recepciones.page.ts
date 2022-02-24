import { ActivatedRoute } from '@angular/router';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Subscription } from 'rxjs';
import { AlertController } from '@ionic/angular';
import { RecepcionesService } from './recepciones.service';
import { TarimasPorRecepcion } from '../Models/TarimasPorRecepcion.model';
import { DetalleLadosTarimaModel } from '../Models/DetalleLadosTarima.model';
import { DetalleProductoTarima } from '../Models/DetalleProductoTarima.model';
import { CodigoBarras } from '../Models/CodigoBarras.model';

@Component({
  selector: 'app-recepciones',
  templateUrl: './recepciones.page.html',
  styleUrls: ['./recepciones.page.scss'],
})
export class RecepcionesPage implements OnInit {
  public folder = 'Recepciones';
  public tarima = 'Entrada-25 / Tarima #1A0001 (1)';
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

  private subscription: Subscription = new Subscription();
  constructor(private activatedRoute: ActivatedRoute, private recepcionesService: RecepcionesService,private alertController: AlertController) {
  }

  ngOnInit() {
    this.idOrdenRecepcion = this.activatedRoute.snapshot.paramMap.get('id');
    if(!this.idOrdenRecepcion) {
      this.idOrdenRecepcion = 1;
    }
    this.loading = true;
    debugger;
    this.subscription.add(this.recepcionesService.getTarimaAbierta(6, 1, this.idOrdenRecepcion, 1).subscribe(dtTA =>
      {
        this.selectedTarima = dtTA[0].TARIMA_ID;
        if(dtTA[0].ESTATUS == 0) {
          this.lockState = 'lock-open';
        } else if(dtTA[0].ESTATUS == 1) {
          this.lockState = 'lock-closed';
        }

        this.subscription.add(this.recepcionesService.getTarimasPorRecepcion(8,1,this.idOrdenRecepcion).subscribe(dtTR => {
          this.tarimasPorRecepcionData = dtTR;
        }));
        this.subscription.add(this.recepcionesService.getDetalleLadosTarima(7,1,this.selectedTarima, this.idOrdenRecepcion).subscribe(dtDLT => {
          this.detalleLadosTarimaData = dtDLT;
        }));
        this.subscription.add(this.recepcionesService.getDetalleProductoPorTarima(9,1,this.selectedTarima, this.idOrdenRecepcion).subscribe(dtDPT => {
          this.detalleProductosTarimaData = dtDPT;
        }));
      }));

    this.loading = false;
  }

  public buscarCodigo(codigo: any) {
    this.subscription.add(this.recepcionesService.postCodigoBarras(1, this.selectedTarima, this.idOrdenRecepcion, this.ladoSeleccionado, codigo.value, '1456398', 1, 0, 0 ).subscribe(data => {
      this.buscarCodigoResponse = data;
      if(this.buscarCodigoResponse.HayError) {
        this.presentAlertPrompt();
      }
    }));
  }

  public cambiarLock() {
    if(this.lockState === 'lock-closed') {
      this.lockState = 'lock-open';
    } else {
      this.lockState = 'lock-closed';
    }
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
  async presentAlertConfirm() {
    const alert = await this.alertController.create({
      cssClass: 'my-custom-class',
      header: 'Confirmar eliminacion',
      message: '¿Desea eliminar el elemento seleccionado?',
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          cssClass: 'secondary',
          handler: (blah) => {
            console.log('Confirm Cancel: blah');
          }
        }, {
          text: 'OK',
          cssClass: 'danger',
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

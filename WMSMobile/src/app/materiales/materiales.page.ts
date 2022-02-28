import { Component, OnInit, Input } from '@angular/core';
import { MaterialesService } from './materiales.service';
import { Subscription } from 'rxjs';
import { MaterialModel } from '../Models/Material.model';

@Component({
  selector: 'app-materiales',
  templateUrl: './materiales.page.html',
  styleUrls: ['./materiales.page.scss'],
})
export class MaterialesPage implements OnInit {

  @Input() idPlanta: string;
  @Input() idOrdenCompra: string;
  @Input() ip: string;
  materiales: MaterialModel[];

  private subscription: Subscription = new Subscription();
  constructor(private materialesService: MaterialesService) { }

  ngOnInit() {
    this.subscription.add(this.materialesService.getTarimaAbierta(this.ip, this.idPlanta, this.idOrdenCompra).subscribe(data => {
      this.materiales = data;
    }));
  }

}

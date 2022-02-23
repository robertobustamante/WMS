import { Component } from '@angular/core';
@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss'],
})
export class AppComponent {
  public appPages = [
    {
      title: 'Compras',
      url: '/compras',
      icon: 'document',
      subPages:[{
        title: 'Recepciones', url: '/recepciones'
      }] },
  ];

  constructor() {}
}

import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'compras',
    pathMatch: 'full'
  },
  {
    path: 'recepciones/',
    loadChildren: () => import('./recepciones/recepciones.module').then( m => m.RecepcionesPageModule)
  },
  {
    path: 'recepciones/:id',
    loadChildren: () => import('./recepciones/recepciones.module').then( m => m.RecepcionesPageModule)
  },
  {
    path: 'compras',
    loadChildren: () => import('./compras/compras.module').then( m => m.ComprasPageModule)
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}

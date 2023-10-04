import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ItemsListComponent } from './components/items/items-list/items-list.component';
import { AppComponent } from './app.component';
import { AddItemComponent } from './components/items/add-item/add-item.component';
import { UpdateItemComponent } from './components/items/update-item/update-item.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guards/auth-guard.service';

const routes: Routes = [
  
  {
    path:'',
    component:LoginComponent
  },
  {
    path:'items',
    component:ItemsListComponent,
    canActivate:[
      AuthGuard
    ]
  },
  {
    path:'items/add',
    component:AddItemComponent,
    canActivate:[
      AuthGuard
    ]
  },
  {
    path:'items/edit/:id',
    component:UpdateItemComponent,
    canActivate:[
      AuthGuard
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwtHelperService, JWT_OPTIONS  } from '@auth0/angular-jwt';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ItemsListComponent } from './components/items/items-list/items-list.component';
import { HttpClientModule } from '@angular/common/http';
import { AddItemComponent } from './components/items/add-item/add-item.component';
import { FormsModule } from '@angular/forms';
import { UpdateItemComponent } from './components/items/update-item/update-item.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './guards/auth-guard.service';

@NgModule({
  declarations: [
    AppComponent,
    ItemsListComponent,
    AddItemComponent,
    UpdateItemComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    AuthGuard,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

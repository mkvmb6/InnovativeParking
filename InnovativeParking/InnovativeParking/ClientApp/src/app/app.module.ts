import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RequestComponent } from './componets/request/request.component';
import { DashbaordComponent } from './componets/dashbaord/dashbaord.component';
import { ReleaseComponent } from './componets/release/release.component';
import { AdminComponent } from './componets/admin/admin.component';
import { LoginComponent } from './componets/login/login.component';
import { CommonComponent } from './componets/common/common.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    RequestComponent,
    DashbaordComponent,
    ReleaseComponent,
    AdminComponent,
    LoginComponent,
    CommonComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: DashbaordComponent, pathMatch: 'full' },
      { path: 'dashboard', component: DashbaordComponent },
      { path: 'request', component: RequestComponent },
      { path: 'release', component: ReleaseComponent },
      { path: 'admin', component: AdminComponent },
      { path: 'login', component: LoginComponent },
      { path: 'common', component: CommonComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

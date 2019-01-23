import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtModule } from '@auth0/angular-jwt';
import { ToastrModule } from 'ngx-toastr';

import { CoreModule } from './core/core.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { IngredientsModule } from './ingredients/ingredients.module';
import { AuthModule } from './auth/auth.module';
import { AppRountingModule } from './app-routing.module';
import { ShoppingListModule } from './shopping-list/shopping-list.module';

export function tokenGetter() {
  return localStorage.getItem('jwt');
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    // RecipesModule, - eager loading
    IngredientsModule,
    ShoppingListModule,
    AuthModule,
    SharedModule,
    CoreModule,
    AppRountingModule,
    ToastrModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ['localhost:44373'], // TODO: this is for development only
        blacklistedRoutes: ['example.com/examplebadroute/']
      }
    })
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

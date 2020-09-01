import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { AppComponent } from './app.component';
import { AppRoutesModule } from './app.routes';
import { AuthGuard } from '@core/guards/auth.guard';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { LayoutModule } from './modules/layout/layout.module';
import { NgModule } from '@angular/core';
import { NzNotificationModule } from 'ng-zorro-antd/notification';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { interceptorProvider } from '@core/interceptors/interceptor-provider';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutesModule,
    BrowserAnimationsModule,
    HttpClientModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
    }),
    NzNotificationModule,
    LayoutModule,
  ],
  providers: [interceptorProvider, AuthGuard],
  bootstrap: [AppComponent],
})
export class AppModule {}

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

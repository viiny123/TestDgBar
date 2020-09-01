import { NzI18nService, pt_BR } from 'ng-zorro-antd/i18n';

import { Component } from '@angular/core';
import { Language } from '@core/constants/language/language.enum';
import { TranslateService } from '@ngx-translate/core';
import pt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';

@Component({
  selector: 'pj-root',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent {
  constructor(translate: TranslateService, antI18n: NzI18nService) {
    translate.setDefaultLang(Language.Portuguese);
    antI18n.setLocale(pt_BR);
    registerLocaleData(pt);
  }
}

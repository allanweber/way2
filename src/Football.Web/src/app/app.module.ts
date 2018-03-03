import { BrowserModule } from '@angular/platform-browser';
import { NgModule, APP_INITIALIZER } from '@angular/core';
import { HttpModule } from '@angular/http';
import { routing } from './app.routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CompetitionComponent } from './competition/competition.component';
import { AppConfig, AppConfigFactory } from './app-config.service';
import { CompetitionService } from './competition/shared/service/competition.service';
import { LeagueTableComponent } from './league-table/league-table.component';
import { LeagueTableService } from './league-table/shared/service/league-table.service';

@NgModule({
  declarations: [AppComponent, NavbarComponent, CompetitionComponent, LeagueTableComponent],
  imports: [BrowserModule, HttpModule, routing],
  providers: [
    AppConfig,
    {
      provide: APP_INITIALIZER,
      useFactory: AppConfigFactory,
      deps: [AppConfig],
      multi: true,
    },
    CompetitionService,
    LeagueTableService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}

import { Injectable } from '@angular/core';
import { AppConfig } from '../../../app-config.service';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { BaseRequests } from '../../../base-requests';
import { LeagueTable } from '../model/league-table.model';

@Injectable()
export class LeagueTableService  extends BaseRequests {
  constructor(private appConfig: AppConfig, private http: Http) {
    super();
  }

  getTeams(competitionId: number): Observable<LeagueTable[]> {
    return this.http
      .get(
        `${this.appConfig.footballApi}/api/v1/LeagueTable/${competitionId}`,
        this.getOptionsHeader()
      )
      .map(result => result.json())
      .catch(this.handleError);
  }

}

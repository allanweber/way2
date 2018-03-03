import { Injectable } from '@angular/core';
import { AppConfig } from '../../../app-config.service';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { BaseRequests } from '../../../base-requests';
import { Competition } from '../model/competition.model';

@Injectable()
export class CompetitionService extends BaseRequests {
  constructor(private appConfig: AppConfig, private http: Http) {
    super();
  }

  getCompetitions(): Observable<Competition[]> {
    return this.http
      .get(
        `${this.appConfig.footballApi}/api/v1/Competition`,
        this.getOptionsHeader()
      )
      .map(result => result.json())
      .catch(this.handleError);
  }
}

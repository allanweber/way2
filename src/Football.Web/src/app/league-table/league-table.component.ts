import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { LeagueTableService } from './shared/service/league-table.service';
import { LeagueTable } from './shared/model/league-table.model';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-league-table',
  templateUrl: './league-table.component.html',
  styleUrls: ['./league-table.component.css']
})
export class LeagueTableComponent implements OnInit, OnDestroy {
  private competitionId: number;
  public teams: LeagueTable[];
  private serviceSubscription: Subscription;

  constructor(private leagueTableService: LeagueTableService) {}

  ngOnInit() {
    this.loadTeams();
  }

  loadTeams() {
    if (this.teams) {
      this.teams.splice(0, this.teams.length);
    }

    this.serviceSubscription = this.leagueTableService
      .getTeams(this.competitionId)
      .subscribe(teamsResp => {
        this.teams = teamsResp;
      });
  }

  @Input()
  set competition(id: number) {
    this.competitionId = id;
    this.loadTeams();
  }

  ngOnDestroy(): void {
    this.serviceSubscription.unsubscribe();
  }
}

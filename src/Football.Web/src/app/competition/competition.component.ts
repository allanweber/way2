import { Component, OnInit, OnDestroy } from '@angular/core';
import { CompetitionService } from './shared/service/competition.service';
import { Competition } from './shared/model/competition.model';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-competition',
  templateUrl: './competition.component.html',
  styleUrls: ['./competition.component.css']
})
export class CompetitionComponent implements OnInit, OnDestroy {
  public competitions: Competition[];
  public competitionId: number;
  private serviceSubscription: Subscription;

  constructor(private competitionService: CompetitionService) {}

  ngOnInit() {
    this.serviceSubscription = this.competitionService.getCompetitions().subscribe(comps => {
      this.competitions = comps;
      this.competitionId = 444;
    });
  }

  onChange(newValue) {
    this.competitionId = newValue;
  }

  ngOnDestroy(): void {
    this.serviceSubscription.unsubscribe();
  }
}

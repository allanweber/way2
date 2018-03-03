import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from '@angular/router';
import { CompetitionComponent } from './competition/competition.component';

const appRoutes: Routes = [
  {
    path: 'competition',
    component: CompetitionComponent
  },
  { path: '', redirectTo: '/competition', pathMatch: 'full' }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes, {
  useHash: true
});

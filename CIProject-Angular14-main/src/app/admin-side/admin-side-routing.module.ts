import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UserComponent } from './user/user.component';
import { CMSListComponent } from './CMS/cmslist/cmslist.component';
import { CMSAddComponent } from './CMS/cmsadd/cmsadd.component';
import { CMSEditComponent } from './CMS/cmsedit/cmsedit.component';
import { MissionComponent } from './mission/mission.component';
import { MissionApplicationComponent } from './mission-application/mission-application.component';
import { MissionthemeComponent } from './missiontheme/missiontheme.component';
import { MissionskillComponent } from './missionskill/missionskill.component';
import { StoryComponent } from './story/story.component';
import { BannerManagementComponent } from './banner-management/banner-management.component';
import { LoginComponent } from '../LoginRegister/login/login.component';
import { UpdateMissionComponent } from './mission/update-mission/update-mission.component';
import { AddMissionComponent } from './mission/add-mission/add-mission.component';
import { UserTypeGuard } from '../service/user-type.guard';
import { AddMissionThemeComponent } from './missiontheme/add-mission-theme/add-mission-theme.component';
import { AddMissionSkillComponent } from './missionskill/add-mission-skill/add-mission-skill.component';


const routes: Routes = [
  {path:'',component:LoginComponent},
 // {path:'login',component:LoginComponent},
  {path:'dashboard',component:DashboardComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'} },
  {path:'userPage',component:UserComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'cms',component:CMSListComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'addCMS',component:CMSAddComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'editCMS/:Id',component:CMSEditComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'mission',component:MissionComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'addMission',component:AddMissionComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'editMission/:Id',component:UpdateMissionComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'missionTheme',component:MissionthemeComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'addMissionTheme',component:AddMissionThemeComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'updateMissionTheme/:Id',component:AddMissionThemeComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'missionSkill',component:MissionskillComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'addMissionSkill',component:AddMissionSkillComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'updateMissionSkill/:Id',component:AddMissionSkillComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'missionApplication',component:MissionApplicationComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'story',component:StoryComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'bannerManagement',component:BannerManagementComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}},
  {path:'**',component:LoginComponent,canActivate:[UserTypeGuard],data: {expectedUserType: 'admin'}}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminSideRoutingModule { }

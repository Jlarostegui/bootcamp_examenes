import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlogComponent } from './components/blog/blog.component';
import { FormComponent } from './components/form/form.component';
import { ViewPostComponent } from './components/view-post/view-post.component';

const routes: Routes = [
  {path:'', pathMatch:'full', redirectTo:'/home'},
  {path:'home', component:BlogComponent},
  {path:'post/:id', component:ViewPostComponent},
  {path:'category/:categoryTitle', component:BlogComponent},
  {path:'new', component:FormComponent},
  {path:'**', redirectTo:'/home'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

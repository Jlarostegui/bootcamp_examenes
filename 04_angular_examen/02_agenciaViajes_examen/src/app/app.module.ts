import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BlogComponent } from './components/blog/blog.component';
import { FormComponent } from './components/form/form.component';
import { ViewPostComponent } from './components/view-post/view-post.component';
import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';
import { SliceStringPipe } from './pipes/slice-string.pipe'

@NgModule({
  declarations: [
    AppComponent,
    BlogComponent,
    FormComponent,
    ViewPostComponent,
    SliceStringPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { Component } from '@angular/core';
import { Category } from './interfaces/category.interface';
import { CategoriesService } from './services/categories.service';
import { PostsService } from './services/posts.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  
  arrCategories:Category[];


  constructor(
    private categoriesService:CategoriesService,
    ){
    this.arrCategories = this.categoriesService.getCategories()
  } 

  filterByCategory($event:any){
    
  }

  



}

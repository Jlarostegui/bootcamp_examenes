import { Injectable } from '@angular/core';
import { Category } from '../interfaces/category.interface';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  arrCategories:Category[];

  constructor() {
    this.arrCategories = new Array(
      {title:'Playa'},
      {title:'Ciudad'},
      {title:'Rural'},
      {title:'Festivales'},
      {title:'Montaña'},
    )
  }

  getCategories():Category[]{
    return this.arrCategories
  }

}





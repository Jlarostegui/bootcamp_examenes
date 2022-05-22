import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from 'src/app/interfaces/category.interface';
import { CategoriesService } from 'src/app/services/categories.service';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  fecha = new Date();
  arrCategories:Category[] | undefined
  formularioNewPost:FormGroup
  


  constructor(
    private categoriesService:CategoriesService,
    private postService:PostsService,
    private router:Router
    ) { 
    
      this.formularioNewPost = new FormGroup({
      title: new FormControl('',[Validators.required,Validators.minLength(4)]),
      date: new FormControl('',[Validators.required, Validators.pattern(/^\d{2}\/\d{2}\/\d{4}/)]),
      category: new FormControl('',[]),
      img: new FormControl('',[Validators.required, Validators.pattern(/(http|https):\/\/\S+\.\S/ )]),
      text: new FormControl('',[Validators.required, Validators.minLength(10)]),
    })

  }

  ngOnInit(): void {
    this.arrCategories = this.categoriesService.getCategories()

  }
  
  checkRequired(controlName:string, errorName:string):boolean{
    if(this.formularioNewPost.get(controlName)?.hasError(errorName) &&this.formularioNewPost.get(controlName)?.touched){
      return true
    }else{
      return false
    }
  }

  saveDataForm(){
    let id:number = Math.floor(Math.random()*(100-9+1)+9)
    let data = {id:id, ...this.formularioNewPost.value}
    this.postService.saveDataPost(data)
   
    this.router.navigate(['/home'])
    this.formularioNewPost.reset()
  }
}

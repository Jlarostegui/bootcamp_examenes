import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/interfaces/category.interface';
import { Post } from 'src/app/interfaces/post.interface';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {


  arrCategories:Category[] = new Array();
  arrFilter:Category[] = new Array();

  arrPost:Post[] = new Array();
  category:string = "";
  

  constructor(
    private postsService:PostsService,
    private activatedRoute:ActivatedRoute) {
      this.arrPost = this.postsService.getPosts()
      console.log(this.arrPost);
      
     }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.category =  params['categoryTitle']
      console.log(this.category);
      
      if(this.category){  
      this.arrPost =  this.postsService.getByCategory(this.category)
      }else {
        this.arrPost = this.postsService.getPosts()
      }
    })
    
  }

}

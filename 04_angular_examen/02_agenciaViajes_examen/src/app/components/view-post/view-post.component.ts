import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from 'src/app/interfaces/post.interface';
import { PostsService } from 'src/app/services/posts.service';

@Component({
  selector: 'app-view-post',
  templateUrl: './view-post.component.html',
  styleUrls: ['./view-post.component.css']
})
export class ViewPostComponent implements OnInit {

  id:number;
  post:Post[]| undefined;
  category:string |undefined
  constructor(
    private postService:PostsService,
    private activatedRoute:ActivatedRoute) 
    {this.id= 0;}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe( params => {
      this.id = Number(params['id'])
    })    
    this.post= this.postService.getSinglePost(this.id);
    
  }

}

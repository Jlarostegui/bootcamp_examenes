import { NgIf } from '@angular/common';
import { ThisReceiver } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { Post } from '../interfaces/post.interface';


@Injectable({
  providedIn: 'root'
})
export class PostsService {


  arrPost:Post[];
  arrFilter:Post[]|undefined
  post:Post []|undefined
  
  
  constructor() { 
    this.arrPost = new Array (
      {id:1,title:'Viaje a la playa 1',text:' Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque at tempore, perspiciatis maiores, distinctio enim ad voluptatum sapiente accusantium dolore molestiae obcaecati laboriosam ducimus ab esse ullam ipsum rem. Molestiae? ',author:'web1',img:'https://picsum.photos/id/21/200/300',date:'12/02/22', category:{title:'Playa'}},
      {id:2,title:'Visita la ciudad 1',text:' Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque at tempore, perspiciatis maiores, distinctio enim ad voluptatum sapiente accusantium dolore molestiae obcaecati laboriosam ducimus ab esse ullam ipsum rem. Molestiae? ',author:'web1',img:'https://picsum.photos/id/22/200/300',date:'12/02/22', category:{title:'Ciudad'}},
      {id:3,title:'Visita un pueblo 1',text:' Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque at tempore, perspiciatis maiores, distinctio enim ad voluptatum sapiente accusantium dolore molestiae obcaecati laboriosam ducimus ab esse ullam ipsum rem. Molestiae? ',author:'web1',img:'https://picsum.photos/id/23/200/300',date:'12/02/22', category:{title:'Rural'}},
      {id:4,title:'Viaje a la playa 2',text:' Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque at tempore, perspiciatis maiores, distinctio enim ad voluptatum sapiente accusantium dolore molestiae obcaecati laboriosam ducimus ab esse ullam ipsum rem. Molestiae? ',author:'web1',img:'https://picsum.photos/id/24/200/300',date:'12/02/22', category:{title:'Playa'}},
      {id:5,title:'Festival de verano',text:' Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque at tempore, perspiciatis maiores, distinctio enim ad voluptatum sapiente accusantium dolore molestiae obcaecati laboriosam ducimus ab esse ullam ipsum rem. Molestiae? ',author:'web1',img:'https://picsum.photos/id/25/200/300',date:'12/02/22', category:{title:'Festivales'}},
      {id:6,title:'Fin de semna Rural',text:' Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque at tempore, perspiciatis maiores, distinctio enim ad voluptatum sapiente accusantium dolore molestiae obcaecati laboriosam ducimus ab esse ullam ipsum rem. Molestiae? ',author:'web1',img:'https://picsum.photos/id/26/200/300',date:'12/02/22', category:{title:'Montaña'}},
      {id:7,title:'Relax en la ciudad',text:' Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque at tempore, perspiciatis maiores, distinctio enim ad voluptatum sapiente accusantium dolore molestiae obcaecati laboriosam ducimus ab esse ullam ipsum rem. Molestiae? ',author:'web1',img:'https://picsum.photos/id/27/200/300',date:'12/02/22', category:{title:'Ciudad'}},
      {id:8,title:'festivales de inv',text:'  Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque at tempore, perspiciatis maiores, distinctio enim ad voluptatum sapiente accusantium dolore molestiae obcaecati laboriosam ducimus ab esse ullam ipsum rem. Molestiae?',author:'web1',img:'https://picsum.photos/id/28/200/300',date:'12/02/22', category:{title:'Festivales'}},
      {id:9,title:'casas',text:'Lorem ipsum dolor sit amet consectetur adipisicing elit. Atque at tempore, perspiciatis maiores, distinctio enim ad voluptatum sapiente accusantium dolore molestiae obcaecati laboriosam ducimus ab esse ullam ipsum rem. Molestiae?  ',author:'web1',img:'https://picsum.photos/id/29/200/300',date:'12/02/22', category:{title:'Rural'}},
    )
  }

  saveDataPost(dForm:Post):void{
    this.arrPost.push(dForm)
  }

  getPosts():Post[]{
    return this.arrPost;
  }
  
  getSinglePost(pId:number):Post[]{
    return this.arrPost.filter(post => post.id === pId)
    
  }

  getByCategory(pCategory:string):Post[]{
    this.arrFilter = this.arrPost.filter( post => post.category.title === pCategory)
    return this.arrFilter
  }

  
}

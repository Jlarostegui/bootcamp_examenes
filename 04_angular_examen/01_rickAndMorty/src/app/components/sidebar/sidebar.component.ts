import { Component, OnInit } from '@angular/core';
import { CharactersService } from 'src/app/services/characters.service';
import { Character } from 'src/app/interfaces/character.interface';
import { ThisReceiver } from '@angular/compiler';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  arrCharacters:Character[];
  next:string = "";
  prev:string = "";

  constructor(
    private characterService:CharactersService, 
    private activatesRoute:ActivatedRoute) { 
    this.arrCharacters = new Array()
  }

  async ngOnInit():Promise<void>{

    const response = await this.characterService.getbyPage();
    this.repartirDatos(response)
  }

  async prevPage(){
    if(this.prev !== null){
      const response = await this.characterService.getbyPage(this.prev)
      this.repartirDatos(response)
    }

  }

  async nextPage(){
    if(this.next !== null){
      const response = await this.characterService.getbyPage(this.next)
      this.repartirDatos(response)
    } 
  }

  repartirDatos(pResponse: any):void{
    this.next = pResponse.info.next;
    this.prev = pResponse.info.prev
    this.arrCharacters = pResponse.results
  }

 
    
  
}

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Character } from 'src/app/interfaces/character.interface';
import { CharactersService } from 'src/app/services/characters.service';

@Component({
  selector: 'app-info-character',
  templateUrl: './info-character.component.html',
  styleUrls: ['./info-character.component.scss']
})
export class InfoCharacterComponent implements OnInit {

  personaje: Character | undefined;

  constructor(
    private characterService:CharactersService,
    private activatedRoute:ActivatedRoute) 
    {

    }

  
   ngOnInit():void{
      this.activatedRoute.params.subscribe(async  params =>{
        let id = Number(params['idcharacter'])
        this.personaje = await this.characterService.getByID(id)
        console.log(this.personaje.episode);
        
      })





  }
}

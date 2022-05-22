import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Episodes } from 'src/app/interfaces/episodes.interface';
import { CharactersService } from 'src/app/services/characters.service';
import { EpisodesService } from 'src/app/services/episodes.service';

@Component({
  selector: 'app-episodes',
  templateUrl: './episodes.component.html',
  styleUrls: ['./episodes.component.scss']
})
export class EpisodesComponent implements OnInit {


  arrEpisodios:string[] = new Array();

  episodes:Episodes[] |undefined;

  constructor(
    private episodesService:EpisodesService,
    private activatedRoute:ActivatedRoute,
    private characterService:CharactersService) { }

  ngOnInit(): void {

   let character =  this.activatedRoute.parent?.params.subscribe( async  params => {
     let id = params['idcharacter']
     const character = await  this.characterService.getByID(id)
     this.arrEpisodios = character.episode
   })

   


  }

}

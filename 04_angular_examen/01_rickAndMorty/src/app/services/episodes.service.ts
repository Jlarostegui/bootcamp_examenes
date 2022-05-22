import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { Episodes } from '../interfaces/episodes.interface';
import { Character } from '../interfaces/character.interface';

@Injectable({
  providedIn: 'root'
})
export class EpisodesService {


  baseUrl = "https://rickandmortyapi.com/api/episode";
  allEpisodes:Episodes[] | undefined;


  constructor(
    private httpClient:HttpClient) { }


    getByUrl(pUrl:string):Promise<Episodes>{
     return lastValueFrom(this.httpClient.get<Episodes>(pUrl))
    }


 

    






}

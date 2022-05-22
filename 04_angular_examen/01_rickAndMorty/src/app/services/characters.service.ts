import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom } from 'rxjs';
import { Character } from '../interfaces/character.interface';

@Injectable({
  providedIn: 'root'
})
export class CharactersService {

  baseUrl:string = 'https://rickandmortyapi.com/api/character'

  constructor(private httpclient:HttpClient) { }


  getbyPage(url:string = this.baseUrl):Promise<any>{

    let response = lastValueFrom(this.httpclient.get<any>(url))
    console.log(response);  
    return response   
  }

  getByID(pId:number): Promise<Character>{
    return  lastValueFrom(this.httpclient.get<Character>(this.baseUrl+'/'+ pId))
  }
}

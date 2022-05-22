import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CharactersService } from 'src/app/services/characters.service';
import { LocationsService } from 'src/app/services/locations.service';

@Component({
  selector: 'app-locations',
  templateUrl: './locations.component.html',
  styleUrls: ['./locations.component.scss']
})
export class LocationsComponent implements OnInit {

  arrLocation:any[] = new Array();

  constructor(
    private actvatedroute:ActivatedRoute,
    private characterService:CharactersService,
    private locationsService:LocationsService
  ) { }

  ngOnInit(): void {
    this.actvatedroute.parent?.params.subscribe( async params => {
      let id = Number(params['idcharacter'])
      const character = await this.characterService.getByID(id)
      this.arrLocation.push(character.location)
    })
  }

}

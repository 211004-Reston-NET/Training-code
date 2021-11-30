import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PokemonService } from '../services/pokemon.service';

@Component({
  selector: 'app-pokemon',
  templateUrl: './pokemon.component.html',
  styleUrls: ['./pokemon.component.css']
})
export class PokemonComponent implements OnInit {

  pokeGroup:FormGroup = new FormGroup({
    id: new FormControl(""),
    name: new FormControl("", [Validators.required])
  });

  get name() {return this.pokeGroup.get("name");}
  
  currentPokemon:string = "No Pokemon";

  imageSource1:string = "";
  imageSource2:string = "";

  constructor(private pokeService:PokemonService) { }

  ngOnInit(): void {
  }

  getPokemon(poke:FormGroup)
  {
    let pokeId:string = poke.get("id")?.value;
    let pokeName:string = poke.get("name")?.value;

    //A blank string evaluates to false
    if (pokeId) {
      this.pokeService.getPokemon(pokeId).subscribe(
        (response) =>{
          this.currentPokemon = `Name:${response.name} Id:${response.id}`;
        },
        (error:HttpErrorResponse) =>
        {
          this.currentPokemon = "No pokemon was found";
        }
      );
    } else if(pokeName){
      this.pokeService.getPokemon(pokeName).subscribe(
        (response) =>{
          this.currentPokemon = `Name:${response.name} Id:${response.id}`;
        },
        (error:HttpErrorResponse) =>
        {
          this.currentPokemon = "No pokemon was found";
        }
      );
    }
    
    else {
      this.currentPokemon = "You haven't inputted anything";
    }
    


  }

}
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pokemon } from '../models/pokemon';

@Injectable({
  providedIn: 'root'
})
export class PokemonService {

  private endpoint:string = "https://pokeapi.co/api/v2/pokemon/";

  constructor(private http:HttpClient) { }

  getPokemon(poke:string)
  {
    return this.http.get<Pokemon>(this.endpoint + poke);
  }
}

import { Schema, MapSchema, type } from "@colyseus/schema";
import { Player } from "./Player";
  
export class State extends Schema {
    @type({ map: Player }) players = new MapSchema<Player>();
}
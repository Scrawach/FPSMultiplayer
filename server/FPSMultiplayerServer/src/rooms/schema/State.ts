import { Schema, MapSchema, type } from "@colyseus/schema";
import { Position } from "./Position";
  
export class State extends Schema {
    @type({ map: Position }) players = new MapSchema<Position>();
}
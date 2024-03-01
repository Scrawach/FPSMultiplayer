import { Schema, MapSchema, type } from "@colyseus/schema";
import { Player } from "./Player";
import { Position } from "./Position"
  
export class State extends Schema {
    @type({ map: Player }) players = new MapSchema<Player>();

    setPlayerPosition(sessionId: string, position: Position) {
        if (position) {
            this.players.get(sessionId).position = position;
        }
    }
}
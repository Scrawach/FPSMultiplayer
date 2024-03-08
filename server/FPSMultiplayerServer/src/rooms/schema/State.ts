import { Schema, MapSchema, type } from "@colyseus/schema";
import { Player } from "./Player";
import { Vector3Data } from "./Vector3Data"
import { Movement } from "./Movement"
  
export class State extends Schema {
    @type({ map: Player }) players = new MapSchema<Player>();

    addPlayer(sessionId: string, player: Player) {
        this.players.set(sessionId, player);
    }

    removePlayer(sessionId: string) {
        this.players.delete(sessionId);
    }

    setPlayerMovement(sessionId: string, movement: Movement) {
        this.players.get(sessionId).movement = movement;
    }
}
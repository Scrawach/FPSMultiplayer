import { Schema, MapSchema, type } from "@colyseus/schema";
import { Player } from "./Player";
import { Vector3Data } from "./Vector3Data"
  
export class State extends Schema {
    @type({ map: Player }) players = new MapSchema<Player>();

    addPlayer(sessionId: string, player: Player) {
        this.players.set(sessionId, player);
    }

    removePlayer(sessionId: string) {
        this.players.delete(sessionId);
    }

    setPlayerPosition(sessionId: string, position: Vector3Data) {
        if (position) {
            this.players.get(sessionId).position = position;
        }
    }
}
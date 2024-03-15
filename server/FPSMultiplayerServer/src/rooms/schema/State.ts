import { Schema, MapSchema, type } from "@colyseus/schema";
import { Player } from "./Player";
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
        const player = this.players.get(sessionId);
        player.movement = movement;
    }

    equipGun(sessionId: string, gunId: number) {
        const player = this.players.get(sessionId);
        player.equippedGun = gunId;
    }
}
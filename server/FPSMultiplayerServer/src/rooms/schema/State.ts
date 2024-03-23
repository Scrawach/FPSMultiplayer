import { Schema, MapSchema, type } from "@colyseus/schema";
import { Player } from "./Player";
import { Movement } from "./Movement"
import { ScoreData } from "./ScoreData";
import { LevelData } from "../../data/LevelData";
  
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

    playerKillSomeone(attackerId: string, targetId: string) {
        const targetPlayer = this.players.get(targetId);
        const attackerPlayer = this.players.get(attackerId);
        attackerPlayer.score = new ScoreData(attackerPlayer.score.kills + 1, attackerPlayer.score.deaths);
        targetPlayer.score = new ScoreData(targetPlayer.score.kills, targetPlayer.score.deaths + 1);
        console.log(`${attackerId} kill ${targetId}`);
    }
}
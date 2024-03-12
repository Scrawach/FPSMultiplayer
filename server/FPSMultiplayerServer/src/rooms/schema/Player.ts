import { Schema, type } from "@colyseus/schema"
import { Movement } from "./Movement"
import { PlayerSettings } from "./PlayerSettings";

export class Player extends Schema {
    @type(Movement) movement: Movement = new Movement();
    @type(PlayerSettings) settings: PlayerSettings = new PlayerSettings();

    public toString = () : string => {
        return `Player: ${this.movement};`
    }
}
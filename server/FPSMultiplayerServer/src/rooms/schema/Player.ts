import { Schema, type } from "@colyseus/schema"
import { Movement } from "./Movement"
import { CharacterStatsData } from "./CharacterStatsData";

export class Player extends Schema {
    @type(Movement) movement: Movement = new Movement();
    @type(CharacterStatsData) stats: CharacterStatsData = new CharacterStatsData();

    public toString = () : string => {
        return `Player: ${this.movement};`
    }
}
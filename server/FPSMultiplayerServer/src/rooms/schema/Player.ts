import { Schema, type } from "@colyseus/schema"
import { Movement } from "./Movement"
import { CharacterStatsData } from "./CharacterStatsData";
import { ScoreData } from "./ScoreData";

export class Player extends Schema {
    @type(Movement) movement: Movement = new Movement();
    @type(CharacterStatsData) stats: CharacterStatsData = new CharacterStatsData();
    @type(ScoreData) score: ScoreData = new ScoreData();

    public toString = () : string => {
        return `Player: ${this.movement};`
    }
}
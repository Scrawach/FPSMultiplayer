import { Schema, type } from "@colyseus/schema"
import { Movement } from "./Movement"
import { CharacterStatsData } from "./CharacterStatsData";
import { ScoreData } from "./ScoreData";
import { HealthData } from "./HealthData";

export class Player extends Schema {
    @type(Movement) movement: Movement = new Movement();
    @type(CharacterStatsData) stats: CharacterStatsData = new CharacterStatsData();
    @type(ScoreData) score: ScoreData = new ScoreData(0, 0);
    @type(HealthData) health: HealthData = new HealthData(0, 0);
    @type("uint8") equippedGun: number = 0;
    @type("uint8") skin: number = 0;

    public toString = () : string => {
        return `Player: ${this.movement};`
    }
}
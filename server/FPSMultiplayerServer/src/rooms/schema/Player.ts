import { Schema, type } from "@colyseus/schema"
import { Movement } from "./Movement"
import { CharacterSettingsData } from "./CharacterSettingsData";

export class Player extends Schema {
    @type(Movement) movement: Movement = new Movement();
    @type(CharacterSettingsData) settings: CharacterSettingsData = new CharacterSettingsData();

    public toString = () : string => {
        return `Player: ${this.movement};`
    }
}
import { Schema, type } from "@colyseus/schema"

export class CharacterStatsData extends Schema {
    @type("uint8") totalHealth: number;
    @type("uint8") currentHealth: number;
    @type("uint8") speed: number;
    @type("uint8") jumpHeight: number;
}
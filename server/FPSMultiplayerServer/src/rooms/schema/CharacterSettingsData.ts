import { Schema, type } from "@colyseus/schema"

export class CharacterSettingsData extends Schema {
    @type("uint8") speed: number;
    @type("uint8") totalHealth: number;
    @type("uint8") jumpHeight: number;
}
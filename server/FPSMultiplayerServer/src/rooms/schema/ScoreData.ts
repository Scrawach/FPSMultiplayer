import { Schema, type } from "@colyseus/schema"

export class ScoreData extends Schema {
    @type("uint8") kills: number;
    @type("uint8") deaths: number;
}
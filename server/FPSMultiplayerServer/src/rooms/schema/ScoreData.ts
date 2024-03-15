import { Schema, type } from "@colyseus/schema"

export class ScoreData extends Schema {
    @type("uint8") kills: number;
    @type("uint8") deaths: number;

    constructor(kills: number, death: number) {
        super();
        this.kills = kills;
        this.deaths = death;
    }
}
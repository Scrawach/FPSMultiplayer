import { Schema, type } from "@colyseus/schema"

export class Vector2Data extends Schema {
    @type("number") x: number;
    @type("number") y: number;

    constructor(x: number, y: number) {
        super();
        this.x = x;
        this.y = y;
    }

    public toString = () : string => {
        return `(${this.x},${this.y})`
    }
}
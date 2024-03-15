import { Schema, type } from "@colyseus/schema"

export class HealthData extends Schema {
    @type("uint8") current: number = 0;
    @type("uint8") total: number = 0;

    constructor(current: number, total: number) {
        super();
        this.current = current;
        this.total = total;
    }

    public toString = () : string => {
        return `health = ${this.current} / ${this.total}`;
    }
}
import { Schema, type } from "@colyseus/schema"
import { Position } from "./Position"

export class Player extends Schema {
    @type(Position) position: Position

    public toString = () : string => {
        return `Player ${this.position};`
    }
}
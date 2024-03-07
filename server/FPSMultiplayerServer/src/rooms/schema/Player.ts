import { Schema, type } from "@colyseus/schema"
import { Movement } from "./Movement"

export class Player extends Schema {
    @type(Movement) movement: Movement

    public toString = () : string => {
        return `Player: ${this.movement};`
    }
}
import { Schema, type } from "@colyseus/schema"
import { Vector3Data } from "./Vector3Data"

export class Movement extends Schema {
    @type(Vector3Data) position: Vector3Data
    @type(Vector3Data) velocity: Vector3Data

    public toString = () : string => {
        return `position = ${this.position}, velocity = ${this.velocity};`
    }
}

export class Player extends Schema {
    @type(Movement) movement: Movement

    public toString = () : string => {
        return `Player: ${this.movement};`
    }
}
import { Schema, type } from "@colyseus/schema"
import { Vector3Data } from "./Vector3Data"
import { Vector2Data } from "./Vector2Data"

export class Movement extends Schema {
    @type(Vector3Data) position: Vector3Data
    @type(Vector3Data) velocity: Vector3Data
    @type(Vector2Data) rotation: Vector2Data
    @type("boolean") isSitting: boolean

    public toString = () : string => {
        return `position = ${this.position}, velocity = ${this.velocity};`
    }
}
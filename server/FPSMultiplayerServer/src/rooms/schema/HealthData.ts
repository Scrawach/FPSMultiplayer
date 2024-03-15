import { Schema, type } from "@colyseus/schema"

export class HealthData extends Schema {
    @type("uint8") current: number = 0
    @type("uint8") total: number = 0
}
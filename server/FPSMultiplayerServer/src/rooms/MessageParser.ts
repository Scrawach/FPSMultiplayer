import { Movement } from "./schema/Movement";
import { CharacterSettingsData } from "./schema/CharacterSettingsData";
import { Vector2Data } from "./schema/Vector2Data";
import { Vector3Data } from "./schema/Vector3Data";

export class MessageParser {
    parseMovement(message: any) : Movement {
        var movement = new Movement()
        movement.position = this.parsePosition(message);
        movement.velocity = this.parseVelocity(message);
        movement.rotation = this.parseRotation(message);
        movement.angles = this.parseAngles(message);
        movement.isSitting = message.isSitting;
        return movement;
    }

    parsePlayerSettings(message: any) : CharacterSettingsData {
        let settings = new CharacterSettingsData();
        settings.speed = message.Speed;
        settings.totalHealth = message.TotalHealth;
        settings.jumpHeight = message.JumpHeight;
        return settings;
    }

    parsePosition(message: any) : Vector3Data {
        const pos = message.position;
        return new Vector3Data(pos.x, pos.y, pos.z);
    }
    
    parseVelocity(message: any) : Vector3Data {
        const vel = message.velocity
        return new Vector3Data(vel.x, vel.y, vel.z);
    }
    
    parseRotation(message: any) : Vector2Data {
        const vel = message.rotation;
        return new Vector2Data(vel.x, vel.y);
    }
    
    parseAngles(message: any) : Vector2Data {
        const angles = message.angles;
        return new Vector2Data(angles.x, angles.y);
    }
}
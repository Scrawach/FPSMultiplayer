import { Movement } from "../rooms/schema/Movement";
import { CharacterStatsData } from "../rooms/schema/CharacterStatsData";
import { Vector2Data } from "../rooms/schema/Vector2Data";
import { Vector3Data } from "../rooms/schema/Vector3Data";

export class MessageParser {
    parseMovement(message: any) : Movement {
        const movement = new Movement()
        movement.position = this.parsePosition(message);
        movement.velocity = this.parseVelocity(message);
        movement.rotation = this.parseRotation(message);
        movement.angles = this.parseAngles(message);
        movement.isSitting = message.isSitting;
        return movement;
    }

    parseCharacterStats(message: any) : CharacterStatsData {
        const stats = new CharacterStatsData();
        stats.speed = message.Speed;
        stats.totalHealth = message.TotalHealth;
        stats.currentHealth = message.CurrentHealth;
        stats.jumpHeight = message.JumpHeight;
        return stats;
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
import { Movement } from "../rooms/schema/Movement";
import { CharacterStatsData } from "../rooms/schema/CharacterStatsData";
import { Vector2Data } from "../rooms/schema/Vector2Data";
import { Vector3Data } from "../rooms/schema/Vector3Data";
import { HealthData } from "../rooms/schema/HealthData";

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
        stats.speed = message.speed;
        stats.jumpHeight = message.jumpHeight;
        return stats;
    }

    parseHealthStats(message: any) : HealthData {
        const health = new HealthData(message.currentHealth, message.totalHealth);
        return health;
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
import { Player } from "./schema/Player";
import { CharacterStatsData } from "./schema/CharacterStatsData";
import { Vector2Data } from "./schema/Vector2Data";
import { Vector3Data } from "./schema/Vector3Data";

export class Environment {
    worldSize: number;

    constructor(worldSize: number) {
        this.worldSize = worldSize;
    }
    
    createNewPlayer(settings: CharacterStatsData) : Player {
        const player = new Player();
        const position = this.getSpawnPosition();
        player.movement.position = position;
        player.movement.velocity = new Vector3Data(0, 0, 0)
        player.movement.rotation = new Vector2Data(0, 0)
        player.movement.angles = new Vector2Data(0, 0);
        player.movement.isSitting = false;
        player.stats = settings;
        return player;
    }

    getSpawnPosition() : Vector3Data {
        const x = Math.random() * this.worldSize;
        const y = Math.random() * this.worldSize;
        return new Vector3Data(x, 0, y)
    }
}
import { Player } from "../rooms/schema/Player";
import { CharacterStatsData } from "../rooms/schema/CharacterStatsData";
import { Vector2Data } from "../rooms/schema/Vector2Data";
import { Vector3Data } from "../rooms/schema/Vector3Data";
import { LevelData } from "../data/LevelData";
import { HealthData } from "../rooms/schema/HealthData";

export class Environment {
    worldSize: number;

    constructor(worldSize: number) {
        this.worldSize = worldSize;
    }
    
    createNewPlayer(settings: CharacterStatsData, health: HealthData, levelData: LevelData) : Player {
        const player = new Player();
        const position = levelData.getRandomSpawnPoint();
        console.log(`${position}`)
        player.movement.position = position;
        player.movement.velocity = new Vector3Data(0, 0, 0)
        player.movement.rotation = new Vector2Data(0, 0)
        player.movement.angles = new Vector2Data(0, 0);
        player.movement.isSitting = false;
        player.stats = settings;
        player.health = health;
        return player;
    }

    getSpawnPosition() : Vector3Data {
        const x = Math.random() * this.worldSize;
        const y = Math.random() * this.worldSize;
        return new Vector3Data(x, 0, y)
    }
}
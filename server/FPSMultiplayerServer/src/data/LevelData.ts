import { Vector3Data } from "../rooms/schema/Vector3Data";

export class LevelData {
    sceneName: string;
    spawnPoints: Vector3Data[];

    constructor(object: any) {
        this.sceneName = object.SceneName;
        this.spawnPoints = object.SpawnPoints;
    }

    getRandomSpawnPoint() : Vector3Data {
        const index = this.getRandomIndex(this.spawnPoints.length);
        return this.spawnPoints[length];
    }

    getRandomIndex(max: number) : number {
        return Math.floor(Math.random() * max);
    }
}
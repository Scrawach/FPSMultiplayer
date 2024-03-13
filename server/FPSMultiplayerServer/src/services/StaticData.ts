import { LevelData } from "../data/LevelData";
import * as fs from 'fs';

export class StaticData {
    private readonly pathToStaticData: string = "./src/staticData/levels"

    private levels: Map<string, LevelData> = new Map()

    initialize() : void {
        const files = fs.readdirSync(this.pathToStaticData);
        files.forEach(file => {
            const jsonLevelData = fs.readFileSync(`${this.pathToStaticData}/${file}`, "utf-8");
            const levelData = new LevelData(JSON.parse(jsonLevelData));
            this.levels.set(levelData.sceneName, levelData);
        });
    }

    hasLevelData(sceneName: string) : boolean {
        return this.levels.has(sceneName);
    }

    getLevelData(sceneName: string) : LevelData {
        return this.levels.get(sceneName);
    }
}
import { Room, Client } from "@colyseus/core";
import { State } from "./schema/State";
import { Environment } from "../services/Environment";
import { MessageParser } from "../services/MessageParser";
import { StaticData } from "../services/StaticData";
import { HealthData } from "./schema/HealthData";
import { ScoreData } from "./schema/ScoreData";

export class GameRoom extends Room<State> {
  maxClients = 4;

  environment: Environment;
  messageParser: MessageParser;
  staticData: StaticData

  onCreate (options: any) {
    this.environment = new Environment(10);
    this.messageParser = new MessageParser();
    this.staticData = new StaticData();

    this.staticData.initialize();
    this.setState(new State());

    this.onMessage("move", (client, message) => {
      this.state.setPlayerMovement(client.sessionId, this.messageParser.parseMovement(message));
    });

    this.onMessage("shoot", (client, message) => {
      this.broadcast("shoot", message);
    });

    this.onMessage("takeDamage", (client, message) => {
      const targetId = message.targetId;
      const attackedId = message.attackedId;
      const currentHealth = message.currentHealth;

      const targetPlayer = this.state.players.get(targetId);
      const totalHealth = targetPlayer.health.total;

      targetPlayer.health = new HealthData(currentHealth, totalHealth);

      if (targetPlayer.health.current <= 0){
        console.log(`${attackedId} kill ${targetId}`);
        const attackerPlayer = this.state.players.get(attackedId);
        attackerPlayer.score = new ScoreData(attackerPlayer.score.kills + 1, attackerPlayer.score.deaths);
        targetPlayer.score = new ScoreData(targetPlayer.score.kills, targetPlayer.score.deaths + 1);
      }
    })

    this.onMessage("equipGun", (client, message) => {
      this.state.equipGun(client.sessionId, message);
    })
  }

  onJoin (client: Client, options: any) {
    const levelData = this.staticData.getLevelData(options.SceneName);
    const playerSettings = this.messageParser.parseCharacterStats(options.CharacterStats);
    const health = this.messageParser.parseHealthStats(options);
    const newPlayer = this.environment.createNewPlayer(playerSettings, health, levelData);
    this.state.addPlayer(client.sessionId, newPlayer);
  }

  onLeave (client: Client, consented: boolean) {
    console.log(client.sessionId, "left!");
    this.state.removePlayer(client.sessionId);
  }

  onDispose() {
    console.log("room", this.roomId, "disposing...");
  }
}

import { Room, Client } from "@colyseus/core";
import { State } from "./schema/State";
import { Environment } from "../services/Environment";
import { MessageParser } from "../services/MessageParser";
import { StaticData } from "../services/StaticData";

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

    this.onMessage("changeHealth", (client, message) => {
      this.state.changeHealth(client.sessionId, message.current, message.total);
    })
  }

  onJoin (client: Client, options: any) {
    const levelData = this.staticData.getLevelData(options.SceneName);
    const playerSettings = this.messageParser.parseCharacterStats(options.CharacterStats);
    const newPlayer = this.environment.createNewPlayer(playerSettings, levelData);
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

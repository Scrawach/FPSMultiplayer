import { Room, Client } from "@colyseus/core";
import { State } from "./schema/State";
import { Environment } from "./Environment";
import { MessageParser } from "./MessageParser";

export class GameRoom extends Room<State> {
  maxClients = 4;

  environment: Environment;
  messageParser: MessageParser;

  onCreate (options: any) {
    this.environment = new Environment(10);
    this.messageParser = new MessageParser();

    this.setState(new State());

    this.onMessage("move", (client, message) => {
      this.state.setPlayerMovement(client.sessionId, this.messageParser.parseMovement(message));
    })

    this.onMessage("shoot", (client, message) => {
      this.broadcast("shoot", message);
    })
  }

  onJoin (client: Client, options: any) {
    const playerSettings = this.messageParser.parsePlayerSettings(options);
    const newPlayer = this.environment.createNewPlayer(playerSettings);
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

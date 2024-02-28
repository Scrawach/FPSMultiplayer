import { Room, Client } from "@colyseus/core";
import { State } from "./schema/State";
import { Position } from "./schema/Position";

export class GameRoom extends Room<State> {
  maxClients = 4;

  onCreate (options: any) {
    this.setState(new State());

    this.onMessage("type", (client, message) => {
      //
      // handle "type" message
      //
    });
  }

  onJoin (client: Client, options: any) {
    const position = this.generateRandomPosition(10);

    console.log(client.sessionId, "joined!");
    console.log(client.sessionId, `spawned position: ${position}`);

    this.state.players.set(client.sessionId, position)
  }

  onLeave (client: Client, consented: boolean) {
    console.log(client.sessionId, "left!");
  }

  onDispose() {
    console.log("room", this.roomId, "disposing...");
  }

  generateRandomPosition(size: number) : Position {
    const x = Math.random() * size;
    const y = Math.random() * size;
    return new Position(x, y)
  }

}

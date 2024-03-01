import { Room, Client } from "@colyseus/core";
import { State } from "./schema/State";
import { Position } from "./schema/Position";
import { Player } from "./schema/Player";

export class GameRoom extends Room<State> {
  maxClients = 4;

  onCreate (options: any) {
    this.setState(new State());

    this.onMessage("move", (client, message) => {
      
    });

    this.onMessage("setPosition", (client, message) => {
      const desiredPosition = this.convertToPosition(message);
      this.state.setPlayerPosition(client.sessionId, desiredPosition);
    })
  }

  onJoin (client: Client, options: any) {
    const newPlayer = this.createNewPlayer();
    console.log(client.sessionId, `${newPlayer}`);
    this.state.addPlayer(client.sessionId, newPlayer);
  }

  onLeave (client: Client, consented: boolean) {
    console.log(client.sessionId, "left!");
    this.state.removePlayer(client.sessionId);
  }

  onDispose() {
    console.log("room", this.roomId, "disposing...");
  }

  convertToPosition(message: any) : Position {
    return new Position(message.x, message.y);
  }

  createNewPlayer() : Player {
    const player = new Player();
    const position = this.generateRandomPosition(10);
    player.position = position;
    return player;
  }

  generateRandomPosition(size: number) : Position {
    const x = Math.random() * size;
    const y = Math.random() * size;
    return new Position(x, y)
  }

}

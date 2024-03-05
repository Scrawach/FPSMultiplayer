import { Room, Client } from "@colyseus/core";
import { State } from "./schema/State";
import { Player } from "./schema/Player";
import { Vector3Data } from "./schema/Vector3Data";

export class GameRoom extends Room<State> {
  maxClients = 4;

  onCreate (options: any) {
    this.setState(new State());

    this.onMessage("setPosition", (client, message) => {
      const desiredPosition = this.getPosition(message);
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

  getPosition(message: any) : Vector3Data {
    const pos = message.position;
    return new Vector3Data(pos.x, pos.y, pos.z);
  }

  createNewPlayer() : Player {
    const player = new Player();
    const position = this.generateRandomPosition(10);
    player.position = position;
    return player;
  }

  generateRandomPosition(size: number) : Vector3Data {
    const x = Math.random() * size;
    const y = Math.random() * size;
    return new Vector3Data(x, 0, y)
  }

}

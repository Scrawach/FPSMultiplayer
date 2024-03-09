import { Room, Client } from "@colyseus/core";
import { State } from "./schema/State";
import { Player } from "./schema/Player";
import { Vector3Data } from "./schema/Vector3Data";
import { Vector2Data } from "./schema/Vector2Data";
import { Movement } from "./schema/Movement";

export class GameRoom extends Room<State> {
  maxClients = 4;

  onCreate (options: any) {
    this.setState(new State());

    this.onMessage("move", (client, message) => {
      this.state.setPlayerMovement(client.sessionId, this.getMovement(message));
    })

    this.onMessage("shoot", (client, message) => {
      this.broadcast("shoot", message);
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

  getVelocity(message: any) : Vector3Data {
    const vel = message.velocity
    return new Vector3Data(vel.x, vel.y, vel.z);
  }

  getRotation(message: any) : Vector2Data {
    const vel = message.rotation;
    return new Vector2Data(vel.x, vel.y);
  }

  getRotationAngles(message: any) : Vector2Data {
    const angles = message.angles;
    return new Vector2Data(angles.x, angles.y);
  }

  getMovement(message: any) : Movement {
    var movement = new Movement()
    movement.position = this.getPosition(message);
    movement.velocity = this.getVelocity(message);
    movement.rotation = this.getRotation(message);
    movement.angles = this.getRotationAngles(message);
    movement.isSitting = message.isSitting;
    console.log(message);
    return movement;
  }

  createNewPlayer() : Player {
    const player = new Player();
    const position = this.generateRandomPosition(10);
    player.movement.position = position;
    player.movement.velocity = new Vector3Data(0, 0, 0)
    player.movement.rotation = new Vector2Data(0, 0)
    player.movement.angles = new Vector2Data(0, 0);
    player.movement.isSitting = false;
    return player;
  }

  generateRandomPosition(size: number) : Vector3Data {
    const x = Math.random() * size;
    const y = Math.random() * size;
    return new Vector3Data(x, 0, y)
  }

}

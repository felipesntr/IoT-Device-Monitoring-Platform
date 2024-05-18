import { Parameter } from "./parameter";

export class Command {
  command: string;
  parameters: Parameter[];

  constructor(command: string, parameters: Parameter[]) {
    this.command = command;
    this.parameters = parameters;
  }
}

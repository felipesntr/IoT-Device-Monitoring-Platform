import { Command } from "./command";

export class
  CommandDescription {
  constructor(
    public operation: string,
    public description: string,
    public command: Command,
    public result: string,
    public format: string
  ) { }
}

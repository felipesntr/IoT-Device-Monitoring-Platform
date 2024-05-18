import { CommandDescription } from "./command-description";

export class Device {
  constructor(
    public identifier: string,
    public description: string,
    public manufacturer: string,
    public url: string,
    public commands: CommandDescription[]
  ) { }
}

namespace Challenges

open System

module Day2 =

  type Cube =
    | Red
    | Blue
    | Green
    | Other

  type Configuration = Map<Cube, byte>

  type Game =
    { Id: uint16; Revealed: Map<Cube, byte> list}
    member this.IsImpossible(configuration: Configuration): bool =
      this.Revealed
        |> List.exists (fun revelated ->
          revelated |> Map.exists (fun cube amount ->
            configuration |> Map.exists (fun configCube configAmount -> configCube = cube && amount > configAmount)))

    member this.IsPossible(configuration: Configuration) =
      not (this.IsImpossible configuration)

  let private getId (line: string) =
    line.Substring(5) |> System.UInt16.Parse

  let private mapColor (color: string) =
    match color with
    | "red" -> Red
    | "blue" -> Blue
    | "green" -> Green
    | _ -> Other

  let private mapFromString (line: string) =
    let parts = line.Trim().Split(
      ' ')
    let count = System.Byte.Parse(parts.[0])
    let color = mapColor parts.[1]
    (color, count)

  let private getSetRevealed (line: string): Map<Cube, byte> =
    line.Split(',')
    |> Array.map mapFromString
    |> Map.ofArray

  let private mapSet (line: string) =
    line.Split(';')
    |> Array.map getSetRevealed
    |> List.ofArray

  let parseGame (lineGame: string): Game =
    let parts = lineGame.Split(':')
    let sets = parts.[1] |> mapSet
    {Id = getId parts.[0]; Revealed = sets}

  let sumOfPossibleGames(games: string list, config: Configuration) : uint16 =
    games
    |> List.map parseGame
    |> List.filter (fun g -> g.IsPossible(config))
    |> List.sumBy (fun g -> g.Id)

  let readFromFile =
    let games = File.ReadAllLines("Files/day2_input.txt")
              |> List.ofArray
    let config = Configuration [( Red, 12uy); ( Green, 13uy); ( Blue, 14uy) ]
    sumOfPossibleGames(games, config)

namespace Challenges

open System

module Day2 =

  type Cube =
    | Red
    | Blue
    | Green
    | Other

  type Set = {
    Revealed: Map<Cube, byte>
  }

  type Game = {
    Id: uint16
    Sets: Set list
  }

  let private getId (line: string) =
    line.Substring(5,1) |> System.UInt16.Parse

  let private mapColor (color: string) =
    match color with
    | "red" -> Red
    | "blue" -> Blue
    | "green" -> Green
    | _ -> Other

  let private mapFromString (line: string) =
    let parts = line.Trim().Split(' ')
    let count = System.Byte.Parse(parts.[0])
    let color = mapColor parts.[1]
    (color, count)

  let private getSetRevealed (line: string): Set =
    line.Split(',')
    |> Array.map mapFromString
    |> Map.ofArray
    |> fun arr -> {Revealed = arr}

  let private mapSet (line: string) =
    line.Split(';')
    |> Array.map getSetRevealed
    |> List.ofArray

  let parseGame (lineGame: string): Game =
    let parts = lineGame.Split(':')
    let sets = parts.[1] |> mapSet
    {Id = getId parts.[0]; Sets = sets}


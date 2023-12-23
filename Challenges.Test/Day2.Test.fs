module Day2.Test

open Xunit
open Challenges
open Day2

[<Fact>]
let ``Day2: Parse line to a Game object`` () =
  let gameLine: string = "Game 100: 13 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
  let game = parseGame gameLine

  let parsedGame: Game = {
    Id = 100us
    Revealed = [
      Map [(Blue, 13uy); (Red, 4uy)]
      Map [(Red, 1uy); (Green, 2uy); (Blue, 6uy)]
      Map [(Green, 2uy)]
    ]
  }


  Assert.Equal(parsedGame, game)

[<Fact>]
let ``Day2: The game should be possible`` () =
  let game:  Game = {
    Id = 2us
    Revealed = [
      Map [( Blue, 3uy); ( Red, 4uy)]
      Map [( Red, 1uy); ( Green, 2uy); ( Blue, 6uy)]
      Map [( Green, 2uy)]
    ]
  }

  let config = Configuration [( Red, 12uy); ( Green, 13uy); ( Blue, 14uy) ]

  Assert.True(game.IsPossible(config))

[<Fact>]
let ``Day2: The game should be impossible`` () =
  let game:  Game = {
    Id = 3us
    Revealed = [
      Map [(Green, 8uy); (Blue, 6uy); (Red, 20uy)]
      Map [(Blue, 5uy); (Red, 4uy); (Green, 13uy)]
      Map [(Green, 5uy); (Red, 1uy)]
    ]
  }

  let config = Configuration [( Red, 12uy); ( Green, 13uy); ( Blue, 14uy) ]

  Assert.True(game.IsImpossible(config))

[<Fact>]
let ``Day2: Sum game ids among possible and impossible games`` () =
  let config = Configuration [( Red, 12uy); ( Green, 13uy); ( Blue, 14uy) ]
  let games = [
    "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
    "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue"
    "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red"
    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red"
    "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
  ]

  let possibleGamesSum = sumOfPossibleGames (games, config)

  Assert.Equal(8us, possibleGamesSum)

[<Fact>]
let ``Day2: Final`` () =
  readFromFile
  |> printfn "The total is %d"



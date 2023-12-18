module Day2.Test

open Xunit
open Challenges

[<Fact>]
let ``Day2: Parse line to a Game object`` () =
  let gameLine: string = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
  let game = Day2.parseGame gameLine

  let parsedGame: Day2.Game = {
    Id = 1us
    Sets = [
      {Revealed =  Map [(Day2.Blue, 3uy); (Day2.Red, 4uy)]  }
      {Revealed =  Map [(Day2.Red, 1uy); (Day2.Green, 2uy); (Day2.Blue, 6uy)]  }
      {Revealed =  Map [(Day2.Green, 2uy)]  }
    ]
  }

  Assert.Equal(parsedGame, game)

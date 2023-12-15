module Tests

open Xunit
open Challenges

[<Theory>]
[<InlineData("1abc2", "12")>]
[<InlineData("a1b2c3d4e5f", "15")>]
[<InlineData("treb7uchet", "77")>]
let ``Should get the calibration with only two numbers`` (line: string, expected: string) =
    let calibration = Day1.GetCalibrationValues line

    Assert.Equal( expected, calibration)


[<Fact>]
let ``Should sum all calibration values`` () =
    let calibrations = ["1abc2";"pqr3stu8vwx";"a1b2c3d4e5f";"treb7uchet"]
    let sum = Day1.SumCalibrations calibrations

    Assert.Equal( 142, sum)


[<Theory>]
[<InlineData("two1nine", "29")>]
[<InlineData("abcone2threexyz", "13")>]
[<InlineData("eightwothree", "83")>]
[<InlineData("xtwone3four", "24")>]
[<InlineData("4nineeightseven2", "42")>]
[<InlineData("zoneight234", "14")>]
[<InlineData("7pqrstsixteen", "76")>]
let ``Should read spelled number as a digit`` (line:string, expect: string) =
    let calibration = Day1.GetCalibrationValues line

    Assert.Equal( expect, calibration)


[<Fact>]
let ``Should sum all calibration values with spelled digits`` () =
    let calibrations = ["two1nine";"eightwothree";"abcone2threexyz";"xtwone3four";"4nineeightseven2";"zoneight234";"7pqrstsixteen"]
    let sum = Day1.SumCalibrations calibrations

    Assert.Equal( 281, sum)


[<Fact>]
let ``Should sum for real test`` () =
    Day1.ReadFromFile



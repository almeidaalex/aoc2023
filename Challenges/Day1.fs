namespace Challenges

open System
open System.IO

module Day1 =

    let private firstAndLast(n: char array ) =
        [|n.[0];n.[n.Length - 1]|]

    let private combineDigits(digits: char array) =
        $"{digits[0]}{digits[1]}"

    let private spelledToDigit(line: string) =
      // I declared array with spelled numbers, then I can take advantage of the index
      let num = ["zero"; "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine"]

      let replaceAll (input: string) (oldValue: string) (newValue: string) =
          printfn "Replacing %s with %s" oldValue newValue
          input.Replace(oldValue, newValue)

      let matches =
          num
          |> List.mapi (fun i v -> (line.IndexOf(v), v, i.ToString()))
          |> List.filter (fun (rank, sp, vl) -> rank >= 0)
          |> List.sort

      matches
      |> List.fold (fun acc (rank, sp, vl) -> replaceAll acc sp vl) line

    let GetCalibrationValues(line: string ) =
        line
        |> spelledToDigit
        |> Seq.filter Char.IsDigit
        |> Array.ofSeq
        |> firstAndLast
        |> combineDigits

    let SumCalibrations(lines: string seq) : int =
        lines
        |> Seq.map GetCalibrationValues
        |> Seq.sumBy int //sumBy applies a function, int is a function, then covert byte to int 😲

    let ReadFromFile =
        File.ReadAllLines("Files/day1_input2.txt")
        |> SumCalibrations
        |> printfn "The sum is %d"

namespace Challenges

open System
open System.IO

module Day1 =

    let private firstAndLast(n: char array ) =
        [|n.[0];n.[n.Length - 1]|]

    let private combineDigits(digits: char array) =
        $"{digits[0]}{digits[1]}"

    let private spelledToDigit(line: string) =
        let num = ["zero";"one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight";"nine"]
        let matches =
            num
            |> List.mapi (fun i v -> (line.IndexOf(v), num[i], i.ToString()))
            |> List.filter (fun (rank, sp, vl) -> rank >= 0 )
            |> List.sort

        let mutable newLine = line
        for mat in matches do
            let (_, sp, vl) = mat
            newLine <- newLine.Replace(sp, vl)
        newLine

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

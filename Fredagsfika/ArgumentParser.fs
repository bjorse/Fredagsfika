module ArgumentParser

open System

type ParsedArguments = { date : DateTime; user : string; resultCount : int }

let tryParseArguments (args : string array) =
    try
        let date = DateTime.Parse args.[0]
        let user = args.[1]
        let count = int args.[2]

        Some({ date = date; user = user; resultCount = count })
    with
    | :? IndexOutOfRangeException -> None
    | :? FormatException -> None
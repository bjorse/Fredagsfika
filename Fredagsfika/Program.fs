module Program

open System
open ArgumentParser
open UserData
open DataAggregator
open ResultFormatter

let parseArguments (args : string array) =
    match ArgumentParser.tryParseArguments args with
    | Some result -> result
    | None -> failwith "Invalid arguments (invalid formatting or wrong number of arguments)"

let getUserIndex (users : string list, username : string) =
    match UserData.getUserIndex (username, users) with
    | Some index -> index
    | None -> failwith (sprintf "Invalid username: %s" username)

[<EntryPoint>]
let main argv = 
    try
        let parsedArgs = parseArguments argv
        let users = UserData.getUsers UserData.defaultFilename |> Seq.toList
        let userIndex = getUserIndex (users, parsedArgs.user)
        let result = DataAggregator.generateData (parsedArgs.date, userIndex, users.Length, parsedArgs.resultCount)
        let parsedResult = result |> List.map (fun x -> ResultFormatter.formatResultItem (users, x))

        printf "%A" parsedResult
        0
    with
    | Failure msg -> printf "Could not execute due to an error: %s" msg; 0
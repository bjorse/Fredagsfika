module Program

open System
open ArgumentParser
open UserData
open DataGenerator
open ResultFormatter

let parseArguments (args : string array) =
    match ArgumentParser.tryParseArguments args with
    | Some result -> result
    | None -> failwith "invalid arguments (invalid formatting or wrong number of arguments)"

let getUserIndex (users : string list) username =
    match UserData.getUserIndex username users with
    | Some index -> index
    | None -> failwith (sprintf "invalid username: %s" username)

let parseUserFile filename =
    match UserData.getUsersFromFile filename with
    | Some users -> users 
    | None -> failwith (sprintf "file not found or contained no elements: %s" filename)

[<EntryPoint>]
let main argv =
    try
        let parsedArgs = parseArguments argv
        let users = parseUserFile UserData.defaultFilename
        let userIndex = getUserIndex users parsedArgs.user
        
        DataGenerator.generateOccurrences parsedArgs.date userIndex users.Length parsedArgs.resultCount
        |> ResultFormatter.formatResult users
        |> printf "%s"

        0
    with
    | Failure msg -> printf "Could not execute due to an error: %s" msg; -1
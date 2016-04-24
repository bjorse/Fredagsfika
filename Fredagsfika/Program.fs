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

let getUserIndex (users : string list, username : string) =
    match UserData.getUserIndex (username, users) with
    | Some index -> index
    | None -> failwith (sprintf "invalid username: %s" username)

let parseUserFile filename =
    match UserData.getUsers filename with
    | Some users -> users 
    | None -> failwith (sprintf "file not found or contained no elements: %s" filename)

[<EntryPoint>]
let main argv = 
    try
        let parsedArgs = parseArguments argv
        let users = parseUserFile UserData.defaultFilename
        let userIndex = getUserIndex (users, parsedArgs.user)
        
        (parsedArgs.date, userIndex, users.Length, parsedArgs.resultCount)
        |> DataGenerator.generateOccurrences 
        |> (fun x -> ResultFormatter.formatResult (users, x))
        |> printf "%s"

        0
    with
    | Failure msg -> printf "Could not execute due to an error: %s" msg; -1
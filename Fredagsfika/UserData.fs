module UserData

open System
open System.IO

let defaultFilename = "users.txt"

let readFile filename =
    try
        Some(File.ReadAllLines filename |> Array.toList)
    with
    | :? FileNotFoundException -> None

let parseFileContents (fileContents : string list) =
    fileContents
    |> List.filter (fun x -> x <> null)
    |> List.map (fun x -> x.Trim()) 
    |> List.filter (fun x -> x.Length > 0)

let getUsers filename =
    match readFile filename with
    | Some result -> match parseFileContents result with
                     | users when users.Length = 0 -> None
                     | users -> Some(users)
    | None -> None

let getUserIndex (username : string, users : string list) =
    List.tryFindIndex (fun x -> x = username) users
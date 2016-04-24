module DataAggregator

open System
open DateGenerator

let getNextUserIndex (previousIndex : int, userCount : int) =
    match previousIndex with
    | x when x + 1 > userCount - 1 -> 0
    | x -> x + 1

let getNextData ((date : DateTime, userIndex : int), userCount : int) =
    DateGenerator.getNextDate date, getNextUserIndex (userIndex, userCount)

let generateData (date : DateTime, userIndex : int, userCount : int, resultCount : int) =
    let rec loop result = 
        match result with
        | [] -> match resultCount with
                | x when x <= 0 -> []
                | _ -> loop [getNextData ((date, userIndex), userCount)]
        | _ -> match result.Length with
               | x when x = resultCount -> List.rev result 
               | _ -> loop ((List.head result |> (fun x -> getNextData (x, userCount))) :: result)
    loop []
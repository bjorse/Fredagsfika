module DataGenerator

open System

let validDays = [DayOfWeek.Monday; DayOfWeek.Tuesday; DayOfWeek.Wednesday; DayOfWeek.Thursday]

let getDaysToAdd dayOfWeek =
    match dayOfWeek with
    | dow when dow = DayOfWeek.Monday -> 3 
    | dow when List.exists ((=) dow) validDays -> -1
    | dow -> (int)DayOfWeek.Thursday - (int)dow

let getNextDate (previousDate : DateTime) =
    let nextWeekDate = previousDate.AddDays 7.0
    nextWeekDate.DayOfWeek |> getDaysToAdd |> float |> nextWeekDate.AddDays

let getNextUserIndex previousIndex userCount =
    match previousIndex with
    | x when x + 1 > userCount - 1 -> 0
    | x -> x + 1

let getNextOccurrence userCount (date, userIndex)  =
    getNextDate date, getNextUserIndex userIndex userCount

let generateOccurrences date userIndex userCount resultCount =
    let rec loop result = 
        match result with
        | [] -> match resultCount with
                | x when x < 1 -> []
                | _ -> loop [getNextOccurrence userCount (date, userIndex)]
        | _ -> match result.Length with
               | x when x = resultCount -> List.rev result 
               | _ -> List.head result |> getNextOccurrence userCount |> (fun x -> x :: result) |> loop
    loop []
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

let getNextUserIndex (previousIndex : int, userCount : int) =
    match previousIndex with
    | x when x + 1 > userCount - 1 -> 0
    | x -> x + 1

let getNextOccurrence ((date : DateTime, userIndex : int), userCount : int) =
    getNextDate date, getNextUserIndex (userIndex, userCount)

let generateOccurrences (date : DateTime, userIndex : int, userCount : int, resultCount : int) =
    let rec loop result = 
        match result with
        | [] -> match resultCount with
                | x when x <= 0 -> []
                | _ -> loop [getNextOccurrence ((date, userIndex), userCount)]
        | _ -> match result.Length with
               | x when x = resultCount -> List.rev result 
               | _ -> loop ((List.head result |> (fun x -> getNextOccurrence (x, userCount))) :: result)
    loop []
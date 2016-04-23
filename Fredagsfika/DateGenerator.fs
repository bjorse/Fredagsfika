module DateGenerator

open System;

let validDays = [DayOfWeek.Monday; DayOfWeek.Tuesday; DayOfWeek.Wednesday; DayOfWeek.Thursday]

let getDaysToAdd dayOfWeek =
    match dayOfWeek with
    | dow when dow = DayOfWeek.Monday -> 3 
    | dow when List.exists ((=) dow) validDays -> -1
    | dow -> (int)DayOfWeek.Thursday - (int)dow

let getNextDate (previousDate : DateTime) =
    let nextWeekDate = previousDate.AddDays 7.0
    nextWeekDate.DayOfWeek |> getDaysToAdd |> float |> nextWeekDate.AddDays
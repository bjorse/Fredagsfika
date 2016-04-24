module ResultFormatter

open System

let formatResultItem users item =
    let date = fst item : DateTime
    let weekDay = date.DayOfWeek.ToString().ToLower()
    let formattedDate = date.ToShortDateString()
    let username = List.nth users (snd item)

    sprintf "Fredagsfika %s %s is provided by %s" weekDay formattedDate username

let formatResult users result =
    result 
    |> List.map (fun x -> formatResultItem users x) 
    |> String.concat Environment.NewLine
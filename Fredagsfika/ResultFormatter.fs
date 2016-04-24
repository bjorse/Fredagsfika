module ResultFormatter

open System

let formatResultItem (users, item) =
    let date = fst item : DateTime
    let userId = int (snd item)
    let weekDay = date.DayOfWeek.ToString().ToLower()
    let formattedDate = date.ToShortDateString()
    let personName = List.nth users userId

    sprintf "Fredagsfika %s %s is provided by %s" weekDay formattedDate personName

let formatResult (users, result) =
    result 
    |> List.map (fun x -> formatResultItem (users, x)) 
    |> String.concat Environment.NewLine
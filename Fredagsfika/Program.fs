module Program

open System
open UserData
open DataAggregator

let parseResultItem (users, item) =
    let date = fst item : DateTime
    let userId = int (snd item)
    let weekDay = date.DayOfWeek.ToString().ToLower()
    let formattedDate = date.ToShortDateString()
    let personName = List.nth users userId

    sprintf "Fredagsfika %s %s is provided by %s" weekDay formattedDate personName

[<EntryPoint>]
let main argv = 
    let date = DateTime.Parse argv.[0]
    let user = argv.[1]
    let count = int argv.[2]
    let users = UserData.getUsers UserData.defaultFilename |> Seq.toList
    let result = DataAggregator.generateData (date, users, user, count)
    let parsedResult = result |> List.map (fun x -> parseResultItem (users, x))

    printf "%A" parsedResult
    0 // return an integer exit code
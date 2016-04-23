module UserData

open System
open System.IO

let defaultFilename = "users.txt"

let getUsers filename =
    File.ReadAllLines filename 
    |> Seq.filter (fun x -> x <> null)
    |> Seq.map (fun x -> x.Trim()) 
    |> Seq.filter (fun x -> x.Length > 0)
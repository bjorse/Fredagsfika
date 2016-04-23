# Fredagsfika
When is next fredagsfika? Find out by running this application :)

## How to run
Compile the solution like any other .NET application. Navigate to `Fredagsfika/bin/Debug` (or equal for your compilation setup) where you'll find the executable file `Fredagsfika.exe`.

## Arguments

There are three arguments needed for a successful result. Beware there are no error handling so any faulty parameters will crash the app. The first argument is the *date* of the last fredagsfika, written in the `YYYY-MM-DD` format. The second argument is the *user* that provided fredagsfika the last time. The user must be listed in the file `users.txt`. The third and last argument is how many occurrences that should be generated (observe there's no upper limit). An example: `Fredagsfika.exe 2016-04-20 Björn 10`. This will generate a result like this:

```
["Fredagsfika tuesday 2016-04-26 is provided by Jan";
 "Fredagsfika monday 2016-05-02 is provided by Jimmy";
 "Fredagsfika thursday 2016-05-12 is provided by Malin";
 "Fredagsfika wednesday 2016-05-18 is provided by Henrik";
 "Fredagsfika tuesday 2016-05-24 is provided by Lotta";
 "Fredagsfika monday 2016-05-30 is provided by Emil";
 "Fredagsfika thursday 2016-06-09 is provided by Elmedin";
 "Fredagsfika wednesday 2016-06-15 is provided by Johan";
 "Fredagsfika tuesday 2016-06-21 is provided by Björn";
 "Fredagsfika monday 2016-06-27 is provided by Jan"]
```

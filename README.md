# Fredagsfika
When is next fredagsfika? Find out by running this application :)

## Rules
To determine the next fredagsfika, there are some rules to follow:

- Fredagsfika should occur once every week

- Fredagsfika cannot occur on a friday

- Fredagsfika cannot occur on the same day two weeks in a row

- Fredagsfika cannot be hosted by the same person two weeks in a row (given there are more than one person participating in these events)

## Implementation

This implementation goes through all the allowed week days following a certain path, where next occurrence will be set on `plus 7 days from the previous occurrence, minus one day`. If the previous occurence was set during the weekend, on a friday, or on a monday, thursday will be selected in that week. Otherwise, the previous mentioned rule will be followed. The next host will be the next person in the user list (compared to the previous host). If the previous host is the last user in the list, the list will just restart from the beginning.

*No database is used. To calculate the next fredagsfika occurrence(s), data must be provided by the caller. The user list is extracted from the file `users.txt`*

## How to run
Compile the solution like any other .NET application. Navigate to `Fredagsfika/bin/Debug` (or equal for your compilation setup) where you'll find the executable file `Fredagsfika.exe`.

## Arguments

There are three mandatory arguments needed for a successful result. The first argument is the *date* of the last fredagsfika, written in the `YYYY-MM-DD` format. The second argument is the *user* that provided fredagsfika the last time (the user must be listed in the file `users.txt`). The third and last argument is how many occurrences that should be generated. `Fredagsfika.exe 2016-04-20 Björn 10` will generate a result like this:

```
Fredagsfika tuesday 2016-04-26 is provided by Jan
Fredagsfika monday 2016-05-02 is provided by Jimmy
Fredagsfika thursday 2016-05-12 is provided by Malin
Fredagsfika wednesday 2016-05-18 is provided by Henrik
Fredagsfika tuesday 2016-05-24 is provided by Lotta
Fredagsfika monday 2016-05-30 is provided by Emil
Fredagsfika thursday 2016-06-09 is provided by Elmedin
Fredagsfika wednesday 2016-06-15 is provided by Johan
Fredagsfika tuesday 2016-06-21 is provided by Björn
Fredagsfika monday 2016-06-27 is provided by Jan
```

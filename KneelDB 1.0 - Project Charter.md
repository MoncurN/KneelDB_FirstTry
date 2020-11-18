# Project Charter
Kneel DB, Version 1

## Description
Kneel DB is a dead-easy way to start storing and retrieving data.  It is not intended to be powerful or highly concurrent.  Also, although it borrows some SQL concepts, it is not intended to be SQL-compliant.  It is intended to be ridiculously easy to start using, with absolutely no setup required.

There are already many established, powerful, robust databases in the world (e.g. MSSQL, Oracle, MySQL, etc).  Kneel DB is not intended to compete with those heavy-hitters.  Also, there are many established, simple, low-barrier-to-entry databases in the world (e.g. SQLite, Derby, etc).  Kneel DB is not intended to compete with any of those.  But if you want to make it stupid-easy for your application to start storing and retrieving data (just include a library, and start making calls), then you could do worse than Kneel DB.  And over time as your application matures, you will probably want to switch to one of those established DBs anyway.

Additionally, Kneel DB is a way for me to learn.  I may change the database's architecture and technical approach over time.  Not because it is strictly necessary to improve the application, but because I want to learn new things.  I will try to respect backward compatibility whenever possible.

## Version 1.0 Requirements
* Dead easy to start using.  Just include it in your program, and start getting and setting data instantly
* Allow as many defaults and auto-settings as possible.  Make configuration assumptions, but allow the user to specify actual configurations if they want
* First priority is on simplest possible starting point for the user

## Version 1.0 Limitations
* Don't worry about data types or sorting.  Always return the entire table.  If the user wants to sort or filter, they can do Linq on the result set.
* Speed, concurrency, relationships are not a priority at this time

## Possible Future Improvements
* Proper SQL language parser
* Support data-types
* Try programming in different sorting algorithms, both for learning and for fun
* Provide an administrator

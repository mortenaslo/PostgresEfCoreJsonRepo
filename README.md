# Error with Postgres + EfCore + Multiple JsonDocuments

Reproduce of error with postgres + EF Core + multiple entities with JsonDocument properties.

First run seeds data and displays it, everything is OK. Data looks like this:
Skoda:
 - {"HP":94}
John Doe:
 - {"Title":"Senior"}

Second run and forward, the output look like this:
Skoda:
 - "Title": "
John Doe:
 - {"Title": "Senior"}

The data in the database are correct, it look like this:
SELECT * FROM public."Cars"
1	"Skoda"	"{"HP": 94}"

SELECT * FROM public."People"
1	"John Doe"	"{"Title": "Senior"}"

# visionhealthcare

Solution structure:
-  Web API project
-  BL project: Contains business logic, validation, communicates with DB project
-  DB project: Contains db entities and configures DbContext

There is a postman collection along with this demo that should be used to test the application, all HTTP calls are self describing and easy to understand.
The Import POST call contains the data of the json file for the exercise to be imported to the database, you may want to use it before anything to populate the database.

Notes:
-  In a real world project I would cover at least the BL project with unit tests, I didn't for this project assuming that is OK and because of time constraints.
-  I am using EF in memory database - which can have a *very* tricky and unpredictable behavior - if, while testing, you start seeing something very weird happen, such as while testing a clear error case (like attempt to import the json twice, which would collide with ProductId keys, the remain endpoints may start to malfunction), simply restart the application as it should be very fast. Microsoft advises against it, but I already used it in the past and found it alright for this demo.

To start the application, simply run it on VS, no further configuration needed.

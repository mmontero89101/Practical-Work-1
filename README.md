# Practical-Work-1
This repo contains the Practical Work 1 of Aitor de las Heras, Miguel Montero and Luis Rollán.

Luis - I've created the principal folder for the project called Practical-Work-1 in order to add the .csproj and the Program.cs file with the main included. Also I've divided the classes in different files in order to make the program easier to read. 

Luis - Today, 21st of April, I've created the Runway and Aircraft Status enums in separated files for better reading and also created the Runway class.

Luis- I've moved the project to the src file, created the class airport and defined a little bit with some methods, although is not complete"

Luis and Aitor - Expanded the Runway class with the Request Runway, Release Runway and GetRemainingTicks methods that show the request, status and time for the runway in order to be free.

Miguel- Coded the classes Aircraft and Runway, later divided and modified in some things by the members of the team.

Luis - Changed Runway and Aircraft classes  by introducing the enums in their main classes. Then Completed The ShowStatus method of the airport class in order to show the status of both aircrafts (their distance, fuel level and so on) and Runways(if there are free runways and the ticks left) and then completed the advancetick method, which update the state of the simulation by 15 minutes.

Luis - Made the main in  Program.cs whith the little interface to make the user choose between loading the files from the file or manually or if he wants to start the simulation Manually or automaticlly. Also modified the Aircraft class with a constructor because before that it was causing problems with the classes that inherit from it (private, commercial and Cargo). And Finally, finished the Airport Class with the LoadFlightsFromFile method in which the program automaticly puts some aircrafts previously created and also the LoadFlightManually methot in which the user has to create his own aircrafts with the data he chooses depending on what he wants.
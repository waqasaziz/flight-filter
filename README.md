# Flights
DotNet Standard Lib which implements filters for flights.

##### Development Enviroment
 - DotNet Standard  2.0
 - DotNet Core  3.1
 - XUnit
 - Visual Studio 2019

##### Projects
- Domain: Contains implementation of Filters, Services and abstracts
- Runner: A simple console app to show filters output. It uses default .Net logger to print output. AppSettings.json has Loglevel for domain set to Information 
- Tests: Contains basic test coverage of positive and negative scenarios

##### Running Solution and Tests
- Set Runner as startup project and hit F5 
- Right Click Tests projects and click Run Tests

##### Todo
- Use MOQ to write tests for verifying Filters call in Service classes
- Write tests for edge cases 

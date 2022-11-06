# MarsRoverApp
Solution to the Mars Rover problem using .NET core, WebApi and .NET 5.0

Mars Rover programming problem.

Follows SOLID principles.
Uses Command design pattern.
Uses Factory design pattern.
Xunit tested using MOQ.
WebApi using swagger

Sample Json input
-------------------

{
  "plateauModel": {
    "width": 3,
    "height": 4
  },
  "coordinateModel": {
    "xCoord": 1,
    "yCoord": 1
  },
  "messageCommand": "FFRFLFLF",
  "direction": "N"
}

Requirements
-----------------
You need to develop a robot that will navigate on Mars terrain.
The input of the app will be a series of commands to move the robot on the plateau. Mars plateau is a grid defined by the initial input of the app, such as 5x5, 3x4, etc.
The second input line will be a string containing multiple commands as described below:
L: Turn the robot left
R: Turn the robot right
F: Move forward on it's facing direction
Sample command string: LFLRFLFF
The robot will always start at X: 1, Y: 1 facing NORTH. If the robot reaches the limits of the plateau the command must be ignored.
Your goal is to navigate the robot and print the final position.
--------------
Example:
Input:
5x5
FFRFLFLF
Result:
1,4,West
There is no limit for the Plateau size
Inputs will always be valid, so there is no need to validate them
There is no 0,0 position


Build
dotnet restore
dotnet build
dotnet run --project MarsRoverApp/MarsRoverApp.csproj

Test
dotnet test MarsRoverApp/MarsRover.Domain.Test.csproj

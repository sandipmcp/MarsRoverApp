# MarsRoverApp
<b>Solution to the Mars Rover problem using .NET core, WebApi and .NET 5.0 </b>
 <br />
Mars Rover programming problem.
 <br />
Follows SOLID principles.
 <br />
Uses Command design pattern.
 <br />
Uses Factory design pattern.
 <br />
Xunit tested using MOQ.
 <br />
WebApi using swagger

<b>Sample Json input</b>
 <br />
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

<b>Requirements</b>
-----------------
You need to develop a robot that will navigate on Mars terrain.
 <br />
The input of the app will be a series of commands to move the robot on the plateau. Mars plateau is a grid defined by the initial input of the app, such as 5x5, 3x4, etc.
 <br />
The second input line will be a string containing multiple commands as described below:
 <br />
L: Turn the robot left
 <br />
R: Turn the robot right
 <br />
F: Move forward on it's facing direction
 <br />
Sample command string: LFLRFLFF
 <br />
The robot will always start at X: 1, Y: 1 facing NORTH. If the robot reaches the limits of the plateau the command must be ignored.
 <br />
Your goal is to navigate the robot and print the final position.
 <br />
--------------
Example:
 <br />
Input:
 <br />
5x5
 <br />
FFRFLFLF
 <br />
Result:
 <br />
1,4,West
 <br />
There is no limit for the Plateau size
 <br />
Inputs will always be valid, so there is no need to validate them
 <br />
There is no 0,0 position

-----------------
Build
 <br />
dotnet restore
 <br />
dotnet build
 <br />
dotnet run --project MarsRoverApp/MarsRoverApp.csproj
 <br />
-------------------
Test
 <br />
dotnet test MarsRoverApp/MarsRover.Domain.Test.csproj

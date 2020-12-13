<div align="center">Mars rover movement simulation</div>

# Table of Contents

* Execution
  * [Ubuntu/WSL](#linux)
  * [Visual Studio](#win)
  * [.zip](https://github.com/RyanDBurke/mars-rover/raw/main/zip/mars-rover.zip)
* [Dependencies](#dependencies)
* [Verbose Example](#verbose)

## Ubuntu/WSL <a name="linux"></a>
1. ```git clone https://github.com/RyanDBurke/mars-rover.git``` <br>
2. ```cd mars-rover/```<br>
3. ```./install.sh```<br>
4. ```cd src/```<br>
5. ```make```<br>
6. ```mono Main.exe input.txt``` or ```mono Main.exe input.txt --verbose```<br>
  ###### "--verbose" executes program with more stdout detail. Example [here](#verbose)
  
## Visual Studio <a name="win"></a>
1. Download Project/Solution .zip [here](https://github.com/RyanDBurke/mars-rover/raw/main/zip/mars-rover.zip) <br>
2. Unzip and open solution (mars-rover/mars-rover.sln) in Visual Studio <br>
3. add command-line args ```input.txt``` or ```input.txt --verbose``` <br>
4. run <br>
  ###### "--verbose" executes program with more stdout detail. Example [here](#verbose)
  
## Dependencies <a name="dependencies"></a>
* Make
* [Mono Compiler](https://www.mono-project.com/docs/about-mono/languages/csharp/)

## Verbose<a name="verbose"></a>
```
Parsing Input from input.txt

Deploying Rover [1]
Deploying Rover [2]

Rover [1]'s Completed Position: 1 2 N
Rover [2]'s Completed Position: 5 1 E

   Final Rover Positions:
        0 0 0 0 0
        0 0 0 0 0
        0 1 0 0 0
        0 0 0 0 0
North ^ 0 0 0 0 0
         East >

All Rover Coordinates:
Rover [1]: (1, 2)
Rover [2]: (5, 1) OFF GRID

You can find the results in: results.txt
```

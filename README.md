<div align="center">mars rover movement simulation for DealerOn</div>

# Table of Contents

* [Dependencies](#dependencies)
* Execution
  * [Ubuntu/WSL](#linux)
  * [Visual Studio](#win)

## Ubuntu/WSL <a name="linux"></a>
1. ```git clone https://github.com/RyanDBurke/mars-rover.git``` <br>
2. ```cd mars-rover/```<br>
3. ```./install.sh```<br>
4. ```cd src/```<br>
5. ```make```<br>
6. ```mono Main.exe input.txt``` or ```mono Main.exe input.txt --verbose```<br>
  ###### "--verbose" executes program with more stdout detail
  
## Visual Studio <a name="win"></a>
1. Download Project/Solution .zip [here](https://github.com/RyanDBurke/mars-rover/raw/main/zip/mars-rover.zip) <br>
2. Unzip and open solution (mars-rover/mars-rover.sln) in Visual Studio <br>
3. add command-line args ```input.txt``` or ```input.txt --verbose``` <br>
4. run <br>
  ###### "--verbose" executes program with more stdout detail
  
## Dependencies <a name="dependencies"></a>
* Make
* [Mono Compiler](https://www.mono-project.com/docs/about-mono/languages/csharp/)

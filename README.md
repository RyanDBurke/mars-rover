<div align="center">mars-rover</div>
<div align="center">mars rover movement simulation for DealerOn</div>

# Table of Contents

* [Dependencies](#dependencies)
* Execute
  * [Ubuntu/WSL](#linux)
  * [Windows PowerShell](#win)

## Ubuntu/WSL <a name="linux"></a>
1. ```git clone https://github.com/RyanDBurke/mars-rover.git``` <br>
2. ```cd mars-rover/```<br>
3. ```./install.sh```<br>
4. ```cd src/```<br>
5. ```make```<br>
6. ```mono Main.exe input.txt``` or ```mono Main.exe input.txt --verbose```<br>
  ###### "--verbose" executes program with more stdout detail
  
## Windows Powershell <a name="win"></a>
1. Install [Mono](https://www.mono-project.com/docs/getting-started/install/windows/) and [Make For Windows](https://sourceforge.net/projects/gnuwin32/files/make/3.81/make-3.81.exe/download?use_mirror=netactuate&download=)
1. ```git clone https://github.com/RyanDBurke/mars-rover.git``` <br>
2. ```cd mars-rover/```<br>
3. ```./install.sh```<br>
4. ```cd src/```<br>
5. ```make```<br>
6. ```mono Main.exe input.txt``` or ```mono Main.exe input.txt --verbose```<br>
  ###### "--verbose" executes program with more stdout detail
  
## Dependencies <a name="dependencies"></a>
* Make
* [Mono Compiler](https://www.mono-project.com/docs/about-mono/languages/csharp/)

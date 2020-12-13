all: Main.exe

Main.exe: Main.cs
	mcs Main.cs ./lib/* ./util/*

clean:
	$(RM) Main.exe
	$(RM) results.txt
@echo off 

:begin 
echo Please wait while we finish the update...
timout /t 2


:finishupdate
ren ..\Temp\OpenBot.exe OpenBot.old
cd Temp
xcopy /s OpenBot.exe ..\OpenBot.exe

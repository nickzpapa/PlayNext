dotnet publish -r linux-x64 -c Release /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true /p:PublishTrimmed=true
# cp "bin\Release\net8.0\linux-x64\publish\PlayNext.exe" "PlayNext.exe"
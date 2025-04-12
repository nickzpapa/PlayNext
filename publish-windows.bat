dotnet publish -r win-x64 -c Release /p:PublishSingleFile=true /p:IncludeAllContentForSelfExtract=true /p:PublishTrimmed=true
copy "bin\Release\net8.0\win-x64\publish\PlayNext.exe" "PlayNext.exe"
dotnet publish PlayNext.csproj -r linux-x64 -c Release --self-contained true /p:PublishSingleFile=true
cp "bin/Release/net8.0/linux-x64/publish/PlayNext" "PlayNext"
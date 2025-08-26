Write-Host "Running tests with coverage..."
dotnet test --collect:"XPlat Code Coverage"

Write-Host "Generating HTML report..."
[System.Net.ServicePointManager]::SecurityProtocol = [System.Net.SecurityProtocolType]::Tls12
dotnet tool restore
dotnet tool run reportgenerator -reports:"**/coverage*.xml" -targetdir:"coveragereport" -reporttypes:"Html;Cobertura;MarkdownSummary"

Write-Host "Done! Open coveragereport/index.html"
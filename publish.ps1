# 让用户手动输入 NuGet 密钥
$NugetApiKey = Read-Host "请输入 NuGet API Key"

# 清理 _packages 目录
if (Test-Path "_packages") {
    Remove-Item "_packages\*" -Force
    Write-Host "_packages 目录已清理"
}

# 编译项目
dotnet build

# 发布 nupkg 包
$nupkgFiles = Get-ChildItem -Path "_packages" -Filter "*.nupkg"
foreach ($pkg in $nupkgFiles) {
    Write-Host "正在发布 nupkg 包: $($pkg.FullName)"
    dotnet nuget push $pkg.FullName --api-key $NugetApiKey --source https://api.nuget.org/v3/index.json
}

# 发布 snupkg 包（符号包）
$snupkgFiles = Get-ChildItem -Path "_packages" -Filter "*.snupkg"
foreach ($spkg in $snupkgFiles) {
    Write-Host "正在发布 snupkg 包: $($spkg.FullName)"
    dotnet nuget push $spkg.FullName --api-key $NugetApiKey --source https://api.nuget.org/v3/index.json --symbol-source https://api.nuget.org/v3/index.json
}

# 运行结束后关闭窗口
Write-Host "发布完成，窗口即将关闭..."
Start-Sleep -
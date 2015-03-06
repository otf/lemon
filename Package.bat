set PATH=%PATH%;C:\Windows\Microsoft.NET\Framework\v4.0.30319
MSBuild.exe .\solution\Lemon\Lemon.fsproj /t:Rebuild /p:Configuration=Release;Platform=AnyCPU /p:TargetFrameworkVersion=v4.0 /p:OutputPath="..\..\bin\Release\v4.0" /p:VisualStudioVersion=11.0
MSBuild.exe .\solution\Lemon\Lemon.fsproj /t:Rebuild /p:Configuration=Release;Platform=AnyCPU /p:TargetFrameworkVersion=v4.5 /p:OutputPath="..\..\bin\Release\v4.5" /p:VisualStudioVersion=12.0

.\solution\.nuget\NuGet.exe pack .\solution\Lemon\Lemon.nuspec

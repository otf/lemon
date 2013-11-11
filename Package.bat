rem set PATH=%PATH%;C:\Windows\Microsoft.NET\Framework\v4.0.30319
rem msbuild solution\Lemon\Lemon.fsproj /p:TargetFramework=v4.0;Configuration=Release;Platform=AnyCPU /t:Rebuild
cd solution\Lemon
..\.nuget\NuGet.exe pack Lemon.fsproj -Symbols -Build

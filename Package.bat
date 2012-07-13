set PATH=%PATH%;C:\Windows\Microsoft.NET\Framework\v4.0.30319


msbuild solution\Lemon\Lemon.fsproj /p:TargetFramework=v4.0;Configuration=Release;Platform=AnyCPU /t:Rebuild
nuget pack Package.nuspec
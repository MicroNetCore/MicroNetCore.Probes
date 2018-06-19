# Push the NuGet packages
cd src

cd MicroNetCore.Probes
dotnet nuget push bin/Release/MicroNetCore.Probes.*.nupkg -k $NUGET_API_KEY -s $NUGET_SOURCE
cd ..

cd MicroNetCore.Probes.Core
dotnet nuget push bin/Release/MicroNetCore.Probes.Core.*.nupkg -k $NUGET_API_KEY -s $NUGET_SOURCE
cd ..

cd MicroNetCore.Probes.Kubernetes
dotnet nuget push bin/Release/MicroNetCore.Probes.Kubernetes.*.nupkg -k $NUGET_API_KEY -s $NUGET_SOURCE
cd ..

cd ..
# Execute Unit tests
cd test

cd MicroNetCore.Probes.Core.Tests
dotnet restore
dotnet test
cd ..

cd MicroNetCore.Probes.Kubernetes.Tests
dotnet restore
dotnet test
cd ..

cd ..
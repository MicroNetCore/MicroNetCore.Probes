#!/usr/bin/env bash

# Exit on any error
set -e

# Create the NuGet packages
cd src

cd MicroNetCore.Probes
dotnet pack -c Release
cd ..

cd MicroNetCore.Probes.Core
dotnet pack -c Release
cd ..

cd MicroNetCore.Probes.Kubernetes
dotnet pack -c Release
cd ..

cd ..
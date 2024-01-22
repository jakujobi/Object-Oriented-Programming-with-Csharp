#!/bin/bash

# Get the directory of the script file
DIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

# Change the current working directory to the directory of the script file
cd "$DIR"

# Now create the project
mkdir Norman1 && \
cd Norman1 && \
dotnet new sln -n Norman1 && \
dotnet new console -o Norman1 && \
dotnet sln add Norman1/Norman1.csproj

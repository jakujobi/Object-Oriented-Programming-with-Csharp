# Python script to create a shell script file

# Prompt for the project name
project_name = input("Enter the project name: ")

# Define the commands to be written to the shell script
commands = f"""
#!/bin/bash

mkdir {project_name} && \\
cd {project_name} && \\
dotnet new sln -n {project_name} && \\
dotnet new console -o {project_name} && \\
dotnet sln add {project_name}/{project_name}.csproj
"""

# Open the shell script file in write mode
with open('create_project.sh', 'w') as file:
    # Write the commands to the file
    file.write(commands)

print("Shell script created successfully.")
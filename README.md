**CHATBOT Project**

A C# backend chatbot application built with Angular frontend and Semantic Kernel framework for natural language processing.

# how to run this project

## requirements to run the project:
* Docker or Podman
* Dotnet SDK 9.0 (change version from 8 to 9)
* Nodejs 24+
* NPM
    * @angular/cli


 "dotnet workload restore " or "sudo dotnet workload restore"
 "cd src/Frontends/chatbotweb" and "npm i"
 "dotnet run --project src/AppHost/AppHost.csproj"

 **Pendings**

Inputs:
    - Text message (Ok)
    - Image (Pending)
    - Voice (Pending)
    - Video (Pending)

Chatbot project using AI technologies, to learn about integrations with semantic kernels

**Overview**

This project demonstrates a fully functional chatbot that can engage in conversations using a C# backend, Angular frontend, and Semantic Kernel framework for natural language processing. The chatbot is built using .Net Aspire as the orchestration layer.

**Features**

*   Visualizes the chat interface
*   Sends messages to the user
*   Receives responses from the bot
*   Utilizes OLAMA in local for models and Docker for containerization
*   New MCP server checkout http://localhost:port/openapi/v1.json

**Setup and Installation**

To set up this project, follow these steps:

1.  Clone the repository using Git: `git clone https://github.com/ojrojas/chatbot.git`
2.  Navigate to the cloned repository: `cd chatbot`
3.  Install the required packages:
    *   `npm install` for Angular frontend
    *   `dotnet restore` for C# backend
4.  Start the application using visual studio or run command dotnet run --project src/AppHost`

**Usage**

1.  Open a web browser and navigate to `http://localhost:4200`
2.  Interact with the chatbot by sending messages, which will be responded to accordingly

**API Documentation**

*   [C# Backend API] -- pending 
*   [Angular Frontend API] -- pending

**Commit Message Guidelines**

*   Follow the standard commit message format: `[type]([optional scope]): [short description]`
*   Example: `feat(chatbot): add chat interface visualizer`

**Contribution Guidelines**

*   Fork this repository to your own account
*   Create a new branch for your changes and submit a pull request
*   Ensure all contributions meet the project's code quality standards

**License**

This project is licensed under [MIT License].

## Prerequisites

- [Docker](https://www.docker.com/) installed
- [.NET 7.0.114](https://dotnet.microsoft.com/download/dotnet/7.0) installed

## Execution Instructions

1. Clone the repository to your local machine:

    ```bash
    git clone https://github.com/FelipeFreitas96/wardrobe-api.git
    ```

2. Navigate to the project directory:

    ```bash
    cd wardrobe-api
    ```

3. Run the following command to start the environment with Docker:

    ```bash
    docker-compose up -d
    ```

   This will initiate the necessary containers for the application backend.

4. Next, run the following command to run the .NET application:

    ```bash
    dotnet run
    ```

   This will start the .NET application using version 7.0.114.

Now, your application should be up and running.
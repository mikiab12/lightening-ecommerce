```markdown
# Lightening E-commerce Project

## Overview

This project is a comprehensive e-commerce application with a robust backend and a dynamic front end. Follow the steps below to set up the project on your local machine.

## Prerequisites

- SQL Server
- Node.js
- .NET Core SDK

## Database Setup

1. Download the AdventureWorks2019 database backup file from the following [URL](https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks).

2. Restore the `AdventureWorks2019.bak` file to your SQL Server instance. Ensure the database is named `AdventureWorks2019`.

## Front End Setup

1. Navigate to the `lightening.ecommerce.web` directory.

2. Create a `.env` file with the following content:

    ```env
    VITE_API_ENDPOINT="BACKEND_API_URL"
    VITE_OPEN_WEATHER_MAP_API_KEY="OPEN_WEATHER_MAP_API_KEY"
    ```

    Replace `BACKEND_API_URL` with the actual URL of your backend API, and `OPEN_WEATHER_MAP_API_KEY` with your Open Weather Map API key.

3. Install the necessary dependencies and start the development server:

    ```bash
    npm install
    npm run dev
    ```

## Back End Setup

1. Navigate to the `Lightening.Ecommerce.API` directory.

2. Open the `appsettings.json` file and update the connection string to point to your SQL Server instance:

    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=AdventureWorks2019;Trusted_Connection=True;"
    }
    ```

3. Ensure that your SQL Server instance is running and the `AdventureWorks2019` database is accessible.

4. Build and run the backend project:

    ```bash
    dotnet build
    dotnet run
    ```

```
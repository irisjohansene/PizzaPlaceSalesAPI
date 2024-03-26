# Pizza Place Sales API

This is the official repository for the Pizza Place Sales API, a .NET Core 6 web API designed to handle sales data for a pizza place. The API allows users to upload CSV files containing sales data and provides endpoints to retrieve and analyze this data.

## Getting Started

To get started with the Pizza Place Sales API, follow these steps:

1. **Clone the Repository**: Clone this repository to your local machine using the following command:

    ```bash
    git clone https://github.com/irisjohansene/PizzaPlaceSalesAPI.git
    ```

2. **Install .NET Core 6 SDK**: Ensure that you have the .NET Core 6 SDK installed on your machine. You can download it from the [official .NET website](https://dotnet.microsoft.com/download).

3. **Set Up Database**: The API uses Entity Framework Core to interact with a database. Make sure you have a compatible database (such as SQL Server) set up, and update the connection string in the `appsettings.json` file.

4. **Build and Run**: Navigate to the project directory and use the following commands to build and run the API:

    ```bash
    dotnet build
    dotnet run
    ```

5. **Explore Endpoints**: Once the API is running, you can explore the available endpoints using tools like Swagger UI. Access Swagger UI by navigating to `https://localhost:5001/swagger/index.html` in your web browser.

## Usage

The Pizza Place Sales API provides the following endpoints:

- **Upload CSV**: Allows users to upload CSV files containing sales data.
- **Retrieve Sales Data**: Provides endpoints to retrieve sales data in various formats.
- **Analyze Sales**: Offers endpoints to analyze sales data, such as calculating total sales or sales by date.

## Contributing

If you'd like to contribute to the Pizza Place Sales API, follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix: `git checkout -b feature-name`.
3. Make your changes and commit them: `git commit -m "Description of changes"`.
4. Push your changes to your fork: `git push origin feature-name`.
5. Submit a pull request to the main repository.

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgements

- This API was developed as part of a project for a fictional pizza place.
- Special thanks to the .NET community and the authors of the libraries and tools used in this project.

For more details on how to use the API or contribute to the project, please refer to the documentation in the repository.

# XPhone
XPhone is an innovative smartphone rental platform, developed in .NET, that offers a flexible and affordable solution for individuals and companies that require cutting-edge mobile devices without the commitment of a purchase.

## Technologies 
- .NET 8.0
- PostgreSQL
- Entity Framework
- CQRS
- GIT

## Getting Started
To get started, you need to have Visual Studio or any other IDE that supports .NET and PostgreSQL.

## Installation
1. Clone the repository:
    ```cmd
    git clone <url>
    ```
2. Restore NuGet packages:
    ```cmd
    dotnet restore
    ```

## Endpoints

### ClientController
- **GetAllClients**: Retrieves all clients.
    ```http
    GET /XPhone/Client/GetAllClients
    ```
- **GetClientById**: Retrieves a client by ID.
    ```http
    GET /XPhone/Client/GetClientById/{id}
    ```
- **AddClient**: Adds a new client.
    ```http
    POST /XPhone/Client/AddClient
    ```
- **UpdateClientById**: Updates a client by ID.
    ```http
    PUT /XPhone/Client/UpdateClientById/{id}
    ```
- **DeleteClientById**: Deletes a client by ID.
    ```http
    DELETE /XPhone/Client/DeleteClientById/{id}
    ```

### RentController
- **GetAllRents**: Retrieves all rents.
    ```http
    GET /XPhone/Rent/GetAllRents
    ```
- **GetRentById**: Retrieves a rent by ID.
    ```http
    GET /XPhone/Rent/GetRentBy{id}
    ```
- **AddRent**: Adds a new rent.
    ```http
    POST /XPhone/Rent/AddRent
    ```
- **UpdateRent**: Updates a rent by ID.
    ```http
    PUT /XPhone/Rent/UpdateRent{id}
    ```
- **DeleteRent**: Deletes a rent by ID.
    ```http
    DELETE /XPhone/Rent/DeleteRent{id}
    ```

### ReturnController
- **GetAllReturns**: Retrieves all returns.
    ```http
    GET /XPhone/Return/GetAllReturns
    ```
- **GetReturn**: Retrieves a return by ID.
    ```http
    GET /XPhone/Return/GetReturn{id}
    ```
- **AddReturn**: Adds a new return.
    ```http
    POST /XPhone/Return/AddReturn
    ```
- **UpdateReturn**: Updates a return by ID.
    ```http
    PUT /XPhone/Return/UpdateReturn{id}
    ```
- **DeleteReturn**: Deletes a return by ID.
    ```http
    DELETE /XPhone/Return/DeleteBy{id}
    ```

### SmartPhoneController
- **GetAllSmartPhones**: Retrieves all smartphones.
    ```http
    GET /XPhone/SmartPhone/GetAllSmartPhones
    ```
- **UpdateSmartPhone**: Updates a smartphone by ID.
    ```http
    PUT /XPhone/SmartPhone/UpdateSmartPhone{id}
    ```
- **DeleteSmartPhone**: Deletes a smartphone by ID.
    ```http
    DELETE /XPhone/SmartPhone/DeleteBy{id}
    ```
- **CheckAvailability**: Checks if a smartphone is available by ID.
    ```http
    GET /XPhone/SmartPhone/CheckIsAvailable/{id}
    ```

### StockController
- **GetAllStocks**: Retrieves all stocks.
    ```http
    GET /api/Stock/GetAllStock
    ```
- **GetStockById**: Retrieves a stock by ID.
    ```http
    GET /api/Stock/GetStockById/{id}
    ```
- **UpdateStock**: Updates a stock by ID.
    ```http
    PUT /api/Stock/UpdateStock/{id}
    ```
- **DeleteStock**: Deletes a stock by ID.
    ```http
    DELETE /api/Stock/DeleteStock/{id}
    ```
- **GetStockCount**: Retrieves the count of items in a stock by ID.
    ```http
    GET /api/Stock/GetStockCount/{id}
    ```
- **AddSmartPhoneToStock**: Adds a smartphone to a stock by stock ID.
    ```http
    POST /api/Stock/AddSmartPhoneToStock/{stockId}
    ```
- **CreateStock**: Creates a new stock.
    ```http
    POST /api/Stock/CreateStock
    ```

## Contributing

Contributions are welcome! Feel free to open issues and pull requests.

## License

This project is licensed under the MIT License.

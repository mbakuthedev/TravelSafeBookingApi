# TravelSafeBookingApi
TravelSafeAPI is a .NET-based API designed to handle road travel-related data. 
Whether you're building an application to help travelers plan their journeys, providing traffic updates, or creating a road trip planner,
this API serves as a robust foundation for your project. It enables you to manage information about Buses, routes, destinations, points of interest, Tourist centers in the states and more,
making road travel experiences smoother and more enjoyable.
## Features
- **Route Management:** Easily create, retrieve, update, and delete routes for different travel destinations.
- **User Authentication:** Secure user data and provide personalized experiences by implementing user authentication and authorization.
- **Point of Interest (POI) Integration:** Incorporate points of interest along routes, providing users with information about Tourist centers to visit.
- **Bus Management :** Easily manage bus information for different users

#### PS: This Project is still at it's early stages, more features will be added as time goes on


## Getting Started
These instructions will help you set up the project on your local machine for development and testing purposes.

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
- A code editor such as Visual Studio or Visual Studio Code.
  
### Installation
 ```bash
   git clone https://github.com/your-username/TravelSafeBookingApi.git
 ```

1. Navigate to the project directory:
```bash
 cd TravelSafeBookingApi
 ```
2. Build the solution
```bash
dotnet build
```
3. Configure the database connection string in ``` appsettings.json. ```
4. Apply the database migrations:
 ```bash
 dotnet ef database update
 ```
5. Run the application:
```bash
dotnet run
```
The API should now be running locally at ``` https://localhost:7055 ```

### Usage
Once the API is up and running, you can use tools like Postman or Swagger to interact with its endpoints. Refer to the API documentation for details on available routes and request formats.

### Documentation
For detailed information on the API endpoints, request and response formats, refer to the API Documentation.

### Contributing
Contributions are welcome! If you find any issues or want to add enhancements, please create a pull request. Make sure to follow the contributing guidelines.

### Acknowledgments
This project was inspired by the love for road trips and the desire to make road travels more exciting and convenient.
Special thanks to the .NET community for their continuous support and contributions.

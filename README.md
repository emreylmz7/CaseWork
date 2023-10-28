# Corporate Job Application Platform

This project aims to develop an online job application platform for a corporate company.

## Features

### Backend (C# .NET 7.0, Web API, Entity Framework, MSSQL, Swagger):

- **Database Model:** The job application model includes the applicant's name, last name, contact information, resume, position preference, and more. Applications are stored using an MSSQL database.

- **Web API:** It provides API endpoints for receiving, saving, updating, and deleting job applications. It includes necessary validation for processing and verifying application data.

- **Swagger Documentation:** Swagger is used to create API documentation, helping users better understand the API.

### Frontend (MVC):

- **User Interface:** The job application form includes personal information and a resume for the applicant. Users can select their position preference.

- **Application List:** A page that lists the job applications made by users, including a date for each application.

- **Job Application Submission:** Enables users to submit their job applications.

- **Extras:** Allows users to edit or delete their applications. It includes a system to track the status of job applications (pending, under review, accepted, rejected, etc.).

## Getting Started

To run the project locally or for development purposes, you can follow these steps:

1. Clone the project repository to your computer.

2. In the `Backend` folder, run `dotnet restore` to install the required dependencies.

3. Edit the `appsettings.json` file in the `Backend` folder to configure the MSSQL database connection settings.

4. Use Entity Framework Migration to create the database and tables (`dotnet ef migrations add InitialCreate` and `dotnet ef database update`).

5. Start the Web API using the `dotnet run` command.

6. In the `Frontend` folder, install the necessary dependencies using `npm install` or `yarn install`.

7. Start the user interface using `npm start` or `yarn start`.

8. Visit `http://localhost:3000` in your browser to see the project in action.

## Contributing

If you'd like to contribute to the project, please submit a pull request. We welcome your contributions.

## License

This project is licensed under the MIT License. For more information, refer to the [LICENSE](LICENSE) file.

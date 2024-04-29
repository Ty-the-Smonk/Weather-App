## Software Bill of Materials (SBOM)

This project utilizes the following NuGet packages:

| Package               | Requested Version | Resolved Version |
|-----------------------|-------------------|------------------|
| Moq                   | 4.20.70           | 4.20.70          |
| Newtonsoft.Json       | 13.0.3            | 13.0.3           |
| NUnit                 | 4.1.0             | 4.1.0            |
| NUnit3TestAdapter     | 4.5.0             | 4.5.0            |
| Serilog               | 3.1.1             | 3.1.1            |
| Serilog.Sinks.File    | 5.0.0             | 5.0.0            |
| Serilog.Sinks.RollingFile | 3.3.0         | 3.3.0            |

The versions listed above are the ones resolved at the last successful build of the project. These packages are part of the .NET ecosystem and are commonly used for unit testing, logging, and utility functions in .NET applications.

## Third-Party APIs

The application interacts with the following third-party APIs:

| API Name         | Version | Endpoint                                  | Purpose                               |
|------------------|---------|-------------------------------------------|---------------------------------------|
| OpenWeatherMap   | 3.0     | `https://api.openweathermap.org/data/2.5/`| To fetch weather data based on ZIP codes. |

*Note: The API versions and endpoints are subject to change according to the third-party provider's updates or changes in the application's requirements.*

## Static Application Security Testing (SAST)

### SAST Tool Used

**Semgrep**
- **Website**: [Semgrep](https://semgrep.dev/)
- **Version**: Specify the version used if relevant
- **Configuration**: Mention any specific rulesets or configurations employed. For example, "Used standard C# security ruleset."

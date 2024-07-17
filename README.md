# NUnitBrowserStackPoC

This project demonstrates how to set up and run SpecFlow tests with NUnit using BrowserStack for testing an iOS. The project includes a sample `.feature` file, step definitions, and necessary configuration to run tests on BrowserStack.


## Prerequisites

- [.NET SDK 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [SpecFlow for Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowforVisualStudio)
- [BrowserStack account](https://www.browserstack.com/users/sign_up)
- [Appium.WebDriver](https://www.nuget.org/packages/Appium.WebDriver/)
- [BrowserStackLocal](https://www.nuget.org/packages/BrowserStackLocal/)


## Setup

1. **Clone the Repository**

   ```zsh
   git clone https://github.com/your-repo/nunit-browserstack-poc.git
   cd nunit-browserstack-poc

   ```

2. run `dotnet restore` from the CLI or build the project using Visual Studio IDE GUI

3. Go to the .yml file and configure the file to your liking (instructions in the .yml file) 

4. run `dotnet build` then `dotnet build`, or clean and build the project from the Visual Studio IDE GUI

5. run `dotnet test` or run tests from the Visual Studio IDE test explorer panel to run your tests (you will of course need to write your tests and define steps, etc...) 


## Project Structure
Features: Contains the .feature files which define the test scenarios in Gherkin syntax.

StepDefinitions: Contains the step definition classes that implement the steps in the feature files.

Hooks: Contains the Hooks.cs file for setting up and tearing down the test environment.

browserstack.yml: Configuration file for BrowserStack credentials and capabilities.


## References

- [BrowserStack Appium Integration](https://www.browserstack.com/docs/app-automate/appium/getting-started)
- [SpecFlow Documentation](https://specflow.org/documentation/)
- [NUnit Documentation](https://nunit.org/)
- [Appium Documentation](https://appium.io/docs/en/latest/quickstart/test-dotnet/)
- [BrowserStack nunit-appium-app-browserstack GitHub Repository](https://github.com/browserstack/nunit-appium-app-browserstack)

This section includes links to the relevant documentation and resources for BrowserStack, SpecFlow, xUnit, and Appium.

## Getting Help
If you are running into any issues or have any queries, please check the Browserstack Support page.

## Author
This project was created by [Jacob McKenzie].

## License

Use it as you see fit.




# MoralisTaskAssignment

******* This repository contains a solution for testing both the UI and API functionalities of the Moralis platform. 
The project is divided into two parts: UI Tests for automating the admin login, creating node and retrieving API key, 
and API Tests for validating various API endpoints, including the retrieval of NFTs from wallet. *******

# Project Structure

MoralisTaskAssignment/
│
├── MoralisAPITest/
│   └── RpcAPITest.cs        # Contains API tests for Moralis APIs
│
├── MoralisUITest/
│   └── AdminUITest.cs       # Contains UI tests for Moralis UI functionality
│
├── .gitignore
├── .gitattributes
└── README.md				 # Project documentation (this file)

# Pre-requisites

Before running please ensure the following are installed on the system

1. Visual Studio (or any other C# IDE)
2. NET SDK (>=6.0)
3. Selenium WebDriver (for UI testing)
4. RestSharp (for API testing)
5. ChromeDriver (for browser automation)
6. NUnit (for unit testing)

# Installing dependencies

Install the following Nuget Packages for both projects

1. Moralis UI Test:

Add following packages using Nuget Package manager 

Selenium.WebDriver
Selenium.WebDriver.ChromeDriver
Selenium.Support
NUnit3TestAdapter
NUnit

2. Moralis API Test:

Add following packages using Nuget Package manager 

RestSharp
NUnit3TestAdapter
NUnit

# Testing Structure and Execution

1. Moralis UI Test:

AdminUITest.cs: Contains the test to login to the admin UI, create node and fetch the API key required for API testing.

Running UI Tests with Test Explorer:

1. Open the project in Visual Studio.
2. Open Test Explorer from the menu Test > Test Explorer.
3. Build the solution to ensure all tests are discovered.
4. In Test Explorer, you should see the tests listed. Run the UI test by right-clicking the test and selecting Run.

2. Moralis API Test:

RpcAPITest.cs: Contains API tests including GetBlockNumber, GetBlockByNumber, GetTransactionByHash and GetWalletNFTs using the Moralis API.

Running API Tests with Test Explorer:

1. Open the project in Visual Studio.
2. Ensure the apikey.json file exists (obtained from UI test - GetAPIKey)
3. Open Test Explorer from the menu Test > Test Explorer
4. Build the solution to ensure all tests are discovered.
5. In Test Explorer, locate the API tests and run them.


# Čorbová SiemensHealth Assignment

## Overview

This assignment focuses on creating a file and folder management system. It comprises classes that manage directory-related operations, serialize and deserialize folder information, and handle JSON files.

## Project Structure

The project includes the following key components:

- **Directory_management**: Manages directory-related operations and implements the `IManageable` interface.
- **File_info**: Represents file information and inherits from the `AbstractInformation` class.
- **Folder_info**: Represents folder information and also inherits from `AbstractInformation`.
- **AbstractInformation**: An abstract class that provides a common structure for file and folder information classes.
- **IManageable**: An interface that defines methods to be implemented by classes for managing directory operations.

## Functionality

The `Directory_management` class has several functions:

- **ImplementAll**: Checks the provided path and handles file/folder operations.
- **PrintAllExtensions**: Prints the extensions of files in a folder.
- **SerializeToJSON**: Serializes folder information to JSON format.
- **DeserializeJSON**: Deserializes folder information from JSON.
- **SaveJSONFile**: Prompts the user to save folder information to a JSON file.


## Getting Started

To get started with this project:

1. Ensure you have .NET Core installed on your system.
2. Clone this repository to your local machine.
3. Open the project in your IDE.
4. Explore the classes and their functionality.
5. Run the application and interact with the console prompts.


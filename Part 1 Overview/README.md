# Part 1 - .NET MAUI Overview

Lets start by getting a basic overview of .NET MAUI and how projects are structured.

## .NET MAUI what is it?

.NET MAUI or .NET Multi-platform application user interface is a cross-platform framework for creating native mobile and desktop applications with C# and XAML.

### What is C\#

C# is a modern, object-oriented and type-safe programming language. C# enables developers to build secure and robust applications that run on .NET. C# has its roots in the C family of languages and will be familiar to anyone that has used C, C++, Java or JavaScript.

### What is XAML

XAML stands for eXtensible Application Markup Language which is a declarative XML-based language developed by Microsoft. XAML simplifies creating a UI for a .NET application. When represented as text, XAML files are XML files that generally have the `.xaml` extension. The files can be encoded by an XML encoding, but encoding is UTF-8 typically.

Using .NET MAUI, you can develop applications that run on Android, iOS, macOS, and Windows from a single shared code-base.

![.NET MAUI Overview][1]

.NET MAUI is an evolution of Xamarin.Forms, bringing it from mobile to desktop scenarios, the UI controls have been rebuilt to improve performance and extensibility. If you have experience with Xamarin Forms, you will notice many similiarities with .NET MAUI. Although we do have differences as well. .NET MAUI allows us to create mulit-platform applications utilizing a single project, with the ability to add platform-specific source code and resources as necessary. The key aim of .NET MAUI is to allow as much application logic and UI layout as possible in a single code-base.

## Who should use .NET MAUI

.NET MAUI is for developers who want to:

- Write cross-platform applications in XAML adn C#, from a single code-base in Visual Studio.
- Share code, tests and business logic across platforms.
- Share UI layout and design across platforms.

## How does .NET MAUI Work

.NET MAUI brings together Android, iOS, macOS, and Windows APIs into a single API that allows a write-once run-anywhere developer experience, while allowing a deep access to every aspect of each native platform.

With .NET 6 and newer we have a series of platform-specific frameworks for creating applications:

- .NET for Android,
- .NET for iOS,
- .NET for macOS,
- Windows UI 3 (WinUI 3)

These framworks all access the same .NET Base Class Library (BCL). This library abstracts the details of the underlying framework away from your code. The BCL depends on the .NET Runtime to provide the execution environment for your code. For Android, iOS, and macOS the environment is implemented by Mono, and implementation of the .NET runtime. While on Windows, .NET CoreCLR provides the execution environment.

.NET MAUI provides a single framework for building the UIs for mobile and desktop applications. The following diagram shows a high-level view of the architecture of a .NET MAUI application

![.NET MAUI application architecture][2]

In a .NET MAUI application, you write code that interacts primarily with the .NET MAUI API which we see with the number 1. .NET MAUI then utilizes the native platform APIs as shown by number 3. Additionally your application code can directly access the platform APIs if it is required.

## Installation

In order to develop .NET MAUI applications we will need to install either Visual Studio 2022 or Visual Studio for Mac from [Visual Studio Site][3]

From this site we can download the community edition and we need to make sure that we select the MAUI workload in the installation screen so that we will have the necessary project types and files to work with.

[1]: ../Assets/Images/dotnet-maui-net-maui-7.jpg
[2]: ../Assets/Images/dotnet-maui-net-maui-7-frameworks.jpg
[3]: https://visualstudio.microsoft.com/ "Visual Studio site to download from"

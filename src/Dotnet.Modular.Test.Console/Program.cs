// See https://aka.ms/new-console-template for more information
using Dotnet.Modular.Test.Console;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.Start();

//services.sta

var serviceProvider = services.BuildServiceProvider();


Console.WriteLine("Hello, World!");




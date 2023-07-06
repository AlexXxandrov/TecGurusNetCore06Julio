// See https://aka.ms/new-console-template for more information
using ConsoleInjection.DependenciaDebil;

Console.WriteLine("Hello, World!");


Console.WriteLine("Ejercicio Debilmente Acoplado!!!");
SoldadoDI soldadoInyector =
    new SoldadoDI(new AvionDI());
Console.WriteLine(soldadoInyector.Acelerar());

//Mostrar la aceleracion de un tanque y el disparo de una pistola

Console.ReadLine();
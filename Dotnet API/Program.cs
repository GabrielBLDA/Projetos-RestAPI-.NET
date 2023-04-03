using Dotnet_API.Metods;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World2!");
app.MapGet("/user", () => "Gabriel Abreu"); 
app.MapPost("/user", () => new {Name = "Matheus", Id = 1 });
app.MapGet("/AddHeader", (HttpResponse response) => response.Headers.Add("Teste", "Joao dom victor"));


app.MapPost("/product", (Products product) => {
    ProductRepository.Add(product);
}); 

app.MapGet("/product/{code}", ([FromRoute] string code) =>
{
    var product = ProductRepository.GetBy(code);
    return product;
});

app.MapPut("/product", (Products product) =>
{
    var productSaved = ProductRepository.GetBy(product.Code);
    productSaved.Name = product.Name;
});

app.MapDelete("/product/{code}", ([FromRoute] string code) =>
{
    var productDeleted = ProductRepository.GetBy(code);
    ProductRepository.DeleteBy(productDeleted);
});

app.Run();


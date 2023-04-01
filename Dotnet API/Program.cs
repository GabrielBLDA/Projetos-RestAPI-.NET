using Dotnet_API.Metods;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World2!");
app.MapGet("/user", () => "Gabriel Abreu"); 
app.MapPost("/user", () => new {Name = "Matheus", Id = 1 });
app.MapGet("/AddHeader", (HttpResponse response) => response.Headers.Add("Teste", "Joao dom victor"));

app.MapPost("/saveproduct", (Products product) => {
    return product.Code + " - " +  product.Name;
});

//api.app.com/users?datastart={date}&dateend={date}
//exemplo: (https://localhost:7236/getproduct?dateStart=2023/04/01&dateEnd=2023/04/05) -> get
app.MapGet("/getproduct", ([FromQuery]string dateStart, [FromQuery]string dateEnd) =>
{
    return dateStart + " - " + dateEnd;
});

//api.app.com/user/{code}
//exemplo: (https://localhost:7236/getproduct/teste); -> get
app.MapGet("/getproduct/{code}", ([FromRoute] string code) =>
{
    return code;
});

app.MapGet("/getProductbyheader", (HttpRequest request) =>
{
    return request.Headers["product-code"].ToString();
});


app.Run();


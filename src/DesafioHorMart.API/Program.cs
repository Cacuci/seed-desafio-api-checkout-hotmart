using DesafioHormart.Payment.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(setup =>
{
    setup.CustomSchemaIds(s => s.ToString());

    var path = AppContext.BaseDirectory;

    foreach (var name in Directory.GetFiles(path, "*.xml"))
    {
        setup.IncludeXmlComments(filePath: name);
    }
});

builder.Services.AddDbContext<PaymentContext>(options => options.UseInMemoryDatabase("Payment"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/payment", () =>
{
    return string.Empty;
})
.WithName("PostPayment")
.WithOpenApi();

app.Run();
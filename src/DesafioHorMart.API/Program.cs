using DesafioHormart.Payment.Data;
using DesafioHortmart.Core.DomainObjects.DTOs;
using DesafioHotmart.Payment.AntiCorruption;
using DesafioHotmart.Payment.AntiCurruption;
using DesafioHotmart.Payment.Business;
using Microsoft.AspNetCore.Mvc;
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

builder.Services.AddScoped<IPaymentService, >

builder.Services.AddScoped<IPaymentFacade, PaymentFacade>();
builder.Services.AddScoped<IPaymentGateway, PaymentGateway>();

builder.Services.AddDbContext<PaymentContext>(options => options.UseInMemoryDatabase("Payment"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/payment/credit-card", ([FromBody] PaymentCreditCardRequest request, IPaymentService service) =>
{
    return string.Empty;
})
.WithName("PostPaymentCreditCard")
.WithOpenApi();

app.MapPost("/payment/boleto-cpf", ([FromBody] PaymentBoletoCPFRequest request, IPaymentService service) =>
{
    return string.Empty;
})
.WithName("PostPaymentBoletoCPF")
.WithOpenApi();

app.MapPost("/payment/boleto-cnpj", ([FromBody] PaymentBoletoCPFRequest request, IPaymentService service) =>
{
    return string.Empty;
})
.WithName("PostPaymentBoletoCNPJ")
.WithOpenApi();

app.MapPost("/payment/pix", () =>
{
    return string.Empty;
})
.WithName("PostPaymentPix")
.WithOpenApi();

app.MapPost("/payment/pay-pal", () =>
{
    return string.Empty;
})
.WithName("PostPaymentPayPal")
.WithOpenApi();

app.MapPost("/payment/credit-card-caixa", ([FromBody] PaymentCreditCardRequest request, IPaymentService service) =>
{
    return string.Empty;
})
.WithName("PostPaymentCreditCardCaixa")
.WithOpenApi();

app.MapPost("/payment/two-credit-card", ([FromBody] IEnumerable<PaymentCreditCardRequest> request, IPaymentService service) =>
{
    return string.Empty;
})
.WithName("PostPaymentTwoCreditCard")
.WithOpenApi();

app.Run();
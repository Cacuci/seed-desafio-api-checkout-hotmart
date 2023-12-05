using DesafioHormart.Payment.Data;
using DesafioHortmart.Core.DomainObjects.DTOs;
using DesafioHotmart.Payment.AntiCorruption;
using DesafioHotmart.Payment.AntiCurruption;
using DesafioHotmart.Payment.Business;
using Microsoft.AspNetCore.Http.HttpResults;
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

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
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

app.MapPost("/payment/credit-card", async Task<Results<Created, BadRequest>> ([FromBody] PaymentCreditCardRequest request, IPaymentService service) =>
{
    await service.AddPaymentOrder(request);

    return TypedResults.Created();
})
.WithName("PostPaymentCreditCard")
.WithOpenApi(option => new(option)
{
    Summary = "Realiza o pagamento via cart�o de cr�dito",
    Description = "Use esta API para realizar o pagamento via cart�o de cr�dito. Todos os detalhes devem ser passados no corpo da requisi��o.",
});

app.MapPost("/payment/boleto-cpf", async Task<Results<Created, BadRequest>> ([FromBody] PaymentBoletoCPFRequest request, IPaymentService service) =>
{
    await service.AddPaymentOrder(request);

    return TypedResults.Created();
})
.WithName("PostPaymentBoletoCPF")
.WithOpenApi(option => new(option)
{
    Summary = "Realiza o pagamento via boleto onde o pagador � pessoa f�sica",
    Description = "Use esta API para realizar o pagamento via boleto, onde o pagador � pessoa f�sica. Todos os detalhes devem ser passados no corpo da requisi��o.",
});

app.MapPost("/payment/boleto-cnpj", async Task<Results<Created, BadRequest>> ([FromBody] PaymentBoletoCNPJRequest request, IPaymentService service) =>
{
    await service.AddPaymentOrder(request);

    return TypedResults.Created();
})
.WithName("PostPaymentBoletoCNPJ")
.WithOpenApi(option => new(option)
{
    Summary = "Realiza o pagamento via boleto onde o pagador � pessoa jur�dica",
    Description = "Use esta API para realizar o pagamento via boleto, onde o pagador � pessoa jur�dica. Todos os detalhes devem ser passados no corpo da requisi��o.",
});

app.MapPost("/payment/pix", async Task<Results<Created, BadRequest>> (IPaymentService service) =>
{
    await service.AddPaymentOrder(ETypePayment.Pix);

    return TypedResults.Created();
})
.WithName("PostPaymentPix")
.WithOpenApi(option => new(option)
{
    Summary = "Realiza o pagamento via pix",
    Description = "Use esta API para realizar o pagamento via Pix. N�o h� par�metros obrigat�rios para esta API.",
});

app.MapPost("/payment/pay-pal", async Task<Results<Created, BadRequest>> (IPaymentService service) =>
{
    await service.AddPaymentOrder(ETypePayment.Paypal);

    return TypedResults.Created();
})
.WithName("PostPaymentPayPal")
.WithOpenApi(option => new(option)
{
    Summary = "Realiza o pagamento via PayPal",
    Description = "Use esta API para realizar o pagamento via PayPal. N�o h� par�metros obrigat�rios para esta API.",
});

app.MapPost("/payment/credit-card-caixa", async Task<Results<Created, BadRequest>> ([FromBody] PaymentCreditCardRequest request, IPaymentService service) =>
{
    await service.AddPaymentOrder(request);

    return TypedResults.Created();
})
.WithName("PostPaymentCreditCardCaixa")
.WithOpenApi(option => new(option)
{
    Summary = "Realiza o pagamento via cart�o de cr�dito Caixa (Virtual)",
    Description = "Use esta API para realizar o pagamento via cart�o de cr�dito Caixa (Virtual). Todos os detalhes devem ser passados no corpo da requisi��o.",
});

app.MapPost("/payment/two-credit-card", async Task<Results<Created, BadRequest>> ([FromBody] IEnumerable<PaymentCreditCardRequest> request, IPaymentService service) =>
{
    await service.AddPaymentOrder(request);

    return TypedResults.Created();
})
.WithName("PostPaymentTwoCreditCard")
.WithOpenApi(option => new(option)
{
    Summary = "Realiza o pagamento via m�ltiplos cart�es de cr�dito",
    Description = "Use esta API para realizar o pagamento via m�ltiplos cart�es de cr�dito. Todos os detalhes devem ser passados no corpo da requisi��o.",
});

app.Run();
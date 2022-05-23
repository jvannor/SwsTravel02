using Azure.Messaging.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductContext"), sqlOptions =>
        sqlOptions.EnableRetryOnFailure()));

builder.Services.AddAzureClients(b => b.AddServiceBusClient(builder.Configuration.GetConnectionString("ProductMessage"))
    .WithName("ProductMessage")
    .ConfigureOptions(options => 
    {
        options.RetryOptions.Mode = ServiceBusRetryMode.Exponential;
        options.RetryOptions.MaxRetries = 5;
        options.RetryOptions.Delay = TimeSpan.FromSeconds(5);
    }));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

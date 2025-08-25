using BookstoreGraphQL.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.AddBookstoreServices();

builder.Services.AddBookstoreDatabase();

builder.Services.AddGraphQLServices(builder.Environment.IsDevelopment());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseGraphQL();
app.UseGraphQLAltair();

app.MapControllers();

app.Run();
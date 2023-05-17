using Biss.DailyCashFlow.App.Api.Balance;
using Biss.DailyCashFlow.App.Api.Entry;
using Biss.DailyCashFlow.Data;
using Biss.DailyCashFlow.Data.Interface;
using Biss.DailyCashFlow.Data.Repository;
using Biss.DailyCashFlow.Service;
using Biss.DailyCashFlow.Service.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<DataContext>(builder.Configuration.GetConnectionString("Default"));

builder.Services.AddScoped<IBalanceService, BalanceService>();
builder.Services.AddScoped<IEntryService, EntryService>();
builder.Services.AddScoped<IEntryRepository, EntryRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Api is On");
app.MapMethods(EntryPost.Template, EntryPost.Methods, EntryPost.Handle);
app.MapMethods(BalanceGet.Template, BalanceGet.Methods, BalanceGet.Handle);


app.Run();


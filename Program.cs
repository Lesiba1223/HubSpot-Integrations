using HubSpot_Integrations.Repositories;
using HubSpot_Integrations.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<HubSpotService>(provider =>
{
	var config = provider.GetRequiredService<IConfiguration>();
	string token = config["HubSpotSettings:Token"];
	return new HubSpotService(token);
});

// Add services to the container.
builder.Services.AddScoped<ICompanyRepository, CompanyService>();
builder.Services.AddScoped<IContactsRepository, ContactsService>();
builder.Services.AddScoped<IAssociationRepository, AssociationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

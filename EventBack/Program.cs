using EventBack;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<IEventService>(s =>
{
    var eventService = new EventService();

    eventService.AddTags("Tout public", "Durable", "Caritatif");
    eventService.AddEvent(new EventEntity() {
        Start = new DateTime(2022, 1, 24),
        Title = "Anniversaire",
        Description = "Grosse tuf sans alcool",
        Rating = 5.0,
        Tags = eventService.TagsFromTitles("Tout public".Split(","))
    });
    eventService.AddEvent(new EventEntity()
    {
        Start = DateTime.Parse("1/4/2022"),
        Title = "Poisson d'avril",
        Description = "On s'amuse",
        Rating = 2.0,
        Tags = eventService.TagsFromTitles("Durable,Tout public".Split(","))
    });
    return eventService;
});


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

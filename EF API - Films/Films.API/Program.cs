var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FilmContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("FilmConnection")));

ConfigureAutoMapper(builder.Services);
ConfigureDbService(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
// Funktionalitet som systemet kan behöva, små kodsnuttar som kan behövas för att programmet ska kunna köras
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

// Config-metoder
void ConfigureAutoMapper(IServiceCollection services)
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<Film, FilmDTO>().ReverseMap(); // ReverseMap spegelvänder konfigurationen
        //cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
        //cfg.CreateMap<Producer, ProducerDTO()>.ReverseMap();        
    });
    var mapper = config.CreateMapper();
    services.AddSingleton(mapper);
}

void ConfigureDbService(IServiceCollection services)
{
    services.AddScoped<IDbService, DbService>();
}

//void ConfigureDbService(IServiceCollection services)
//{
//    services.AddScoped<IDbService, TestDbService>();
//}
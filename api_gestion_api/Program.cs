using dao_library;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<StudentDAO>();
builder.Services.AddScoped<CourseDAO>();
builder.Services.AddScoped<ActivityDAO>();
builder.Services.AddScoped<TeamDAO>();
builder.Services.AddScoped<PlayerDAO>();
builder.Services.AddScoped<TrainerDAO>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("/api", (string slack_name, string track) =>
{
    var today = DateTime.Now;
    return Results.Ok(
        new
        {
            slack_name = slack_name,
            current_day = today.ToString("dddd"),
            utc_time = today.ToUniversalTime(),
            track = track,
            github_file_url = "https://github.com/username/repo/blob/main/file_name.ext",
            github_repo_url = "https://github.com/username/repo",
            status_code = 200
        });
})
.WithOpenApi();

app.Run();
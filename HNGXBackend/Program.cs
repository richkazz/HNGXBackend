using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/api", (string slack_name, string track) =>
{
    var today = DateTime.UtcNow;
    return Results.Ok(
        new
        {
            slack_name = slack_name,
            current_day = today.ToString("dddd"),
            utc_time = today.ToString("yyyy-MM-ddTHH:mm:ssZ"),
            track = track,
            github_file_url = "https://github.com/richkazz/HNGXBackend/blob/master/HNGXBackend/Program.cs",
            github_repo_url = "https://github.com/richkazz/HNGXBackend",
            status_code = 200
        });
})
.WithOpenApi();

app.Run();
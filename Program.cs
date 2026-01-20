var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger UI - для проверки API
app.UseSwagger();
app.UseSwaggerUI();

// DTO - контейнер
app.MapPost("/distance", (DistanceRequest req) =>
{
    var dx = req.X2 - req.X1;
    var dy = req.Y2 - req.Y1;

    var distance = Math.Sqrt(dx * dx + dy * dy);

    return Results.Ok(new DistanceResponse(distance));
});

app.Run();

public record DistanceRequest(double X1, double Y1, double X2, double Y2);
public record DistanceResponse(double Distance);
using AspNetcoreLearning.Dto;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int i = 0;
Dto _data = new(i); 

app.MapGet("/", () => "Hello World!");

app.MapGet("heartbeat", () =>
{
    if (i > 9999)
        i = 0;
    else
        i += 1;
    Dto dto = new(i);
    _data = dto;

    return _data;


 });

app.Run();

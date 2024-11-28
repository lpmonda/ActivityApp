using AspNetcore1.Dto;
using AspNetcore1.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Security.Policy;
using MFC = AspNetcore1.Dto.MFC;


var builder = WebApplication.CreateBuilder(args);


#region Database Configure

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<ValveContext>(options => options.UseMySql( connectionString,  ));
builder.Services.AddDbContext<ValveContext> (options => options.UseMySql("server=localhost;database=sakila;user=admin;password=valco;port=3306;Connect Timeout=5;",
              new MySqlServerVersion(new Version(8, 0, 11))));

#endregion

var app = builder.Build();

int i = 0;
Dto _data = new(i);

List<MFC> mfclist = [

        new(
            1,
            "Column Flow",
            100,
            50,
            "HE"
        ),
    new(
            2,
            "Column2 Mix",
            500,
            400,
            "H2"
        ),
    new(
            3,
            "Oven",
            100,
            100,
            "CO"
        )
];

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

app.MapGet("MFC/{id}", (int id) => {
    return mfclist.Find(mfc => mfc.MFCId == id);
}).WithName("GetMFC");

app.MapPost("AddMFC", (MFC mfc) => {
    int id = mfclist.Count + 1;
    MFC mfc2 = new(id, mfc.Name, mfc.Setpoint, mfc.Measure, mfc.GasId);

    mfclist.Add(mfc2);

    return Results.CreatedAtRoute("GetMFC", new { id = id }, mfc2);
});

app.MapPut("list/{id}", (int id, MFC updatedmfc) => {
    MFC? currmfc = mfclist.Find(mfc => mfc.MFCId == id);
    if (currmfc == null)
    {
        return Results.NotFound();
    }
    MFC newmfc = new(
        id,
        updatedmfc.Name,
        updatedmfc.Setpoint,
        updatedmfc.Measure,
        updatedmfc.GasId

    );
    mfclist[id - 1] = newmfc;
    return Results.Ok();
});

app.MapPost("AddEntityMAN", (Manufacturer m) => {
    using (var context = new ValveContext())
    {
        // Creates the database if not exists
        context.Database.EnsureCreated();

        // Adds a manufacturer
        var m1 = new Manufacturer
        {
            ID = m.ID,
            Name = m.Name                
        };
        context.Manufacturer.Add(m1);
        context.SaveChanges();

    }

});

app.Run();

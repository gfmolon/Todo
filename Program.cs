using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

// [Configuration]
// add support for controllers
builder.Services.AddControllers();
// add addContext
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// mao controllers created
app.MapControllers();


app.Run();


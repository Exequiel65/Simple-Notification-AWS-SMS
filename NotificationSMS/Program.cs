using NotificationSMS.Service.AWSSMS;
using NotificationSMS.Service.AWSSMS.Configure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<AwssmsMessageOptions>(builder.Configuration.GetSection("AwssmsMessageOptions"));

builder.Services.AddSingleton<ISmsDispatcher, SmsDispatcher>();
builder.Services.AddScoped<ISmsService, SmsService>();
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

using BizsolETask_Api.Interface;
using BizsolETask_Api.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(options =>
options.SerializerSettings.ContractResolver = new DefaultContractResolver());

JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    DateTimeZoneHandling = DateTimeZoneHandling.Local
};

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddTransient<IUserModuleMaster, UserModuleMasterService>();
builder.Services.AddTransient<IEmployeeMaster, EmployeeMasterService>();
builder.Services.AddTransient<IStatusMaster, StatusMasterService>();
builder.Services.AddTransient<IWorkTypeMaster, WorkTypeMasterService>();
builder.Services.AddTransient<IEmployeeRatePerHourDetails, EmployeeRatePerHourDetailsService>();
builder.Services.AddTransient<IClientMaster, ClientMasterService>();
builder.Services.AddTransient<ITimeSheet, TimeSheetService>();
builder.Services.AddTransient<IReport, ReportServices>();
builder.Services.AddTransient<IGenerateTask, GenerateTaskService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

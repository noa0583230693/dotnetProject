
using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Repositories;
using Clean.CORE.Services;
using Clean.DATA.Data;
using Clean.DATA.Repositories;
using Clean.SERVICE;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeService, EmployeeService>();//עבור הקונטרולרים
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IProjectAssignmentService, ProjectAssignmentService>();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<IemployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectAssignmentRepository, ProjectAssignmentRepository>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));//כרגע לא בשימוש כי אין מחלקה שרק ממשת את rrepository בלימהוספת פונקציה משלה

//builder.Services.AddSingleton<IDataContext, DataContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty; // Swagger יהיה בדף הראשי
});

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

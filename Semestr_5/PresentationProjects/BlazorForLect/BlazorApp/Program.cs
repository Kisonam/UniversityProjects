using BlazorApp.Components;
using BlazorApp.Components.Models;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Реєструємо HttpClient
builder.Services.AddScoped(sp =>
{
    // Реєструємо HttpClient з базовою адресою через NavigationManager
    var navigationManager = sp.GetRequiredService<Microsoft.AspNetCore.Components.NavigationManager>();
    return new HttpClient { BaseAddress = new Uri(navigationManager.BaseUri) };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

var students = new List<Student>();

app.MapGet("/api/students", () => students);
app.MapPost("/api/students", (Student student) =>
{
    student.Id = students.Count + 1;
    students.Add(student);
});
app.MapPut("/api/students/{id}", (int id, Student updatedStudent) =>
{
    var student = students.FirstOrDefault(s => s.Id == id);
    if (student != null)
    {
        student.FirstName = updatedStudent.FirstName;
        student.LastName = updatedStudent.LastName;
        student.StudentNumber = updatedStudent.StudentNumber;
    }
});
app.MapDelete("/api/students/{id}", (int id) =>
{
    var student = students.FirstOrDefault(s => s.Id == id);
    if (student != null)
        students.Remove(student);
});

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

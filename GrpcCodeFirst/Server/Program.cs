using System;
using Grpc.AspNetCore.Server;
using GrpcCodeFirst.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args); 

// Registers a provider that can recognize and handle code-first services
builder.Services.AddCodeFirstGrpc((Action<GrpcServiceOptions>)(config =>
        {
            config.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal;
            if (builder.Environment.IsDevelopment())
            {
                config.EnableDetailedErrors = true;
            }
        }
    )
);

// Adds gRPC reflection services
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCodeFirstGrpcReflection();
}


builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

// Must be added after UseRouting and before UseEndpoints 
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

app.MapGrpcService<UserServices>();
app.MapRazorPages();
app.MapFallbackToFile("index.html");

app.MapCodeFirstGrpcReflectionService();
app.Run();

public partial class Program { }
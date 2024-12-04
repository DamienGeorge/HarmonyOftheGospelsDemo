var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.HarmonyWebApp>("harmonywebapp");

builder.Build().Run();

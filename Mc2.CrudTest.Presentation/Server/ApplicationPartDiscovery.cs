using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;

namespace Mc2.CrudTest.Presentation.Server
{
    public static class ApplicationPartDiscovery
    {
        public static Assembly[] FindAssemblies()
        {
            return Directory
                .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories)
                .Select(f =>
                {
                    // catch bad image exception for native libraries
                    try
                    {
                        return Assembly.LoadFile(f);
                    }
                    catch
                    {
                        return null;
                    }
                })
            .Where(a => a is not null)
                .Where(a => a.GetTypes().Any(t => t.IsAssignableTo(typeof(IApplicationPart))))
                .ToArray();
        }
    }
}

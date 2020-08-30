using System;
using System.Collections.Generic;

namespace UserMicroService.Configuration
{
    public static class EnvironmentSettings
    {
        public const string MicroServiceConnectionString="MICRO_SERVICE_CONNECTION_STRING";

        public static IEnumerable<(string, string)> GetFileProcessorEnvironmentValues()
        {
            yield return (MicroServiceConnectionString,Environment.GetEnvironmentVariable(MicroServiceConnectionString) ?? throw new ArgumentException($"environment variable {MicroServiceConnectionString} is needed"));
        }
    }
}
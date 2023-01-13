using Microsoft.Extensions.Hosting;

namespace Karami.Common.ClassExtensions;

public static class ExceptionExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Exception"></param>
    /// <param name="Environment"></param>
    public static void FileLogger(this Exception Exception, IHostEnvironment Environment)
    {
        string LogsPath = $"{Environment.ContentRootPath}\\CoreLogs\\Logs.txt";

        if (!File.Exists(LogsPath))
            File.Create(LogsPath);
        
        using StreamWriter StreamWriter = new(LogsPath, append: true);

        StreamWriter.WriteLine($"\n Message: {Exception.Message} | Source: {Exception.ToString()} \n");
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Exception"></param>
    /// <param name="Environment"></param>
    public static async Task FileLoggerAsync(this Exception Exception, IHostEnvironment Environment)
    {
        string LogsPath = $"{Environment.ContentRootPath}\\CoreLogs\\Logs.txt";

        if (!File.Exists(LogsPath))
            File.Create(LogsPath);
        
        await using StreamWriter StreamWriter = new(LogsPath, append: true);

        await StreamWriter.WriteLineAsync($"\n Message: {Exception.Message} | Source: {Exception.ToString()} \n");
    }
}
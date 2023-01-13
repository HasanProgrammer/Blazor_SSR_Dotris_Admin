using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Karami.Common.ClassExtensions;

public static class StringExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="phone"></param>
    /// <returns></returns>
    public static bool IsValidMobileNumber(this string phone)
    {
        const string pattern = @"^09[0|1|2|3][0-9]{8}$";
        return new Regex(pattern).IsMatch(phone);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public static bool IsValidEmail(this string email)
    {
        const string pattern = @"[\w-\.]+@([\w-]+\.)+[\w-]{2,4}";
        return new Regex(pattern).IsMatch(email);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Input"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T DeSerialize<T>(this string Input) => JsonConvert.DeserializeObject<T>(Input);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Input"></param>
    /// <returns></returns>
    public static async Task<string> HashAsync(this string Input)
    {
        await using MemoryStream Stream = new(Encoding.ASCII.GetBytes(Input));
        
        #pragma warning disable CS0618
        byte[] Result = await new SHA512CryptoServiceProvider().ComputeHashAsync(Stream);
        #pragma warning restore CS0618

        StringBuilder Builder = new();
        foreach (byte item in Result)
            Builder.Append(item.ToString("X2"));
        return Builder.ToString();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="Environment"></param>
    public static async Task EventLoggerAsync(this string text, IHostEnvironment Environment)
    {
        string LogsPath = $"{Environment.ContentRootPath}\\CoreLogs\\EventLogs.txt";

        if (!File.Exists(LogsPath))
            File.Create(LogsPath);
        
        await using StreamWriter StreamWriter = new(LogsPath, append: true);

        await StreamWriter.WriteLineAsync($"\n {text} \n");
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    /// <param name="Environment"></param>
    public static void EventLogger(this string text, IHostEnvironment Environment)
    {
        string LogsPath = $"{Environment.ContentRootPath}\\CoreLogs\\EventLogs.txt";

        if (!File.Exists(LogsPath))
            File.Create(LogsPath);
        
        using StreamWriter StreamWriter = new(LogsPath, append: true);

        StreamWriter.WriteLine($"\n {text} \n");
    }
}
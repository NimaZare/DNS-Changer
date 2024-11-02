using System.Diagnostics;

namespace ChangeDNS.App;

public static class Tools
{
    public static string GetInterfaceIndex(string networkType)
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = $"Get-DnsClientServerAddress | Where-Object -Property \"InterfaceAlias\" -EQ -Value \"{networkType}\" | Where-Object -Property \"AddressFamily\" -EQ -Value \"2\" | Select-Object \"InterfaceIndex\"",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();

        var output = process.StandardOutput.ReadToEnd();

        var interfaceIndex = output
            .Replace("InterfaceIndex", string.Empty)
            .Replace("-", string.Empty)
            .Replace(Environment.NewLine, string.Empty)
            .Replace(" ", string.Empty);

        return interfaceIndex;
    }

    public static string GetConnectedNetworkType()
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = "Get-NetAdapter | Where-Object { $_.Status -eq 'Up' } | Select-Object -ExpandProperty Name",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();

        var output = process.StandardOutput.ReadToEnd().Trim();

        if (output.Contains("Wi-Fi"))
            return "Wi-Fi";
        if (output.Contains("Ethernet"))
            return "Ethernet";

        return string.Empty;
    }

    public static bool SetDNS(string dnsServer)
    {
        var networkType = GetConnectedNetworkType();
        if (string.IsNullOrEmpty(networkType))
        {
            Console.WriteLine("No active network connection found.");
            return false;
        }

        var interfaceIndex = GetInterfaceIndex(networkType);

        if (string.IsNullOrEmpty(interfaceIndex))
        {
            Console.WriteLine($"Could not find interface index for {networkType}.");
            return false;
        }

        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            Arguments = $"Set-DnsClientServerAddress -InterfaceIndex {interfaceIndex} -ServerAddresses {dnsServer}",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();

        Console.WriteLine($"{networkType} DNS updated to {dnsServer}");
        return true;
    }

    public static void ResetDNS(string interfaceAlias)
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = $"Set-DnsClientServerAddress -InterfaceAlias \"{interfaceAlias}\" -ResetServerAddresses",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();
    }

    public static void EnableNetworkAdapter(string networkType)
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = $"Enable-NetAdapter -Name \"{networkType}\" -Confirm:$false",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();
    }

    public static void DisableNetworkAdapter(string networkType)
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = $"Disable-NetAdapter -Name \"{networkType}\" -Confirm:$false",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();
    }
}

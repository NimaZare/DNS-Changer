using System.Diagnostics;

namespace ChangeDNS.App;

public static class Tools
{
    private static string GetAdapterName()
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
        var adapterNames = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

        if (adapterNames.Length == 1)
            return adapterNames[0];
        
        foreach (var name in adapterNames)
        {
            if (name.Contains("Ethernet") || name.Contains("Wi-Fi"))
                return name;
        }

        return adapterNames.FirstOrDefault() ?? string.Empty;
    }

    private static string GetInterfaceIndex()
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = "Get-NetAdapter | Where-Object { $_.Status -eq 'Up' -and $_.ifIndex -ne $null } | Select-Object -ExpandProperty ifIndex"
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();

        var output = process.StandardOutput.ReadToEnd().Trim();
        return output;
    }

    public static bool SetDNS(string dnsServer)
    {
        var interfaceIndex = GetInterfaceIndex();
        if (string.IsNullOrEmpty(interfaceIndex))
        {
            Console.WriteLine($"Could not find interface index.");
            return false;
        }

        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            Arguments = $"Set-DnsClientServerAddress -InterfaceIndex \"{interfaceIndex}\" -ServerAddresses {dnsServer}",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();

        Console.WriteLine($"DNS updated to {dnsServer}");
        return true;
    }

    public static void ResetDNS()
    {
        var interfaceIndex = GetInterfaceIndex();
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = $"Set-DnsClientServerAddress -InterfaceIndex {interfaceIndex} -ResetServerAddresses",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();
    }

    public static void EnableNetworkAdapter()
    {
        var networkType = GetAdapterName();
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

    public static void DisableNetworkAdapter()
    {
        var networkType = GetAdapterName();
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

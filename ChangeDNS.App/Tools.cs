using System.Diagnostics;

namespace ChangeDNS.App;

public static class Tools
{
    public static string GetInterfaceIndex()
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = "Get-DnsClientServerAddress | Where-Object -Property \"InterfaceAlias\" -EQ -Value \"Wi-Fi\" | Where-Object -Property \"AddressFamily\" -EQ -Value \"2\" | Select-Object \"InterfaceIndex\"",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();

        var output = process.StandardOutput.ReadToEnd();

        var interfaceIndex = output
            .Replace(oldValue: "InterfaceIndex", newValue: string.Empty)
            .Replace(oldValue: "-", newValue: string.Empty)
            .Replace(oldValue: Environment.NewLine, newValue: string.Empty)
            .Replace(oldValue: " ", newValue: string.Empty);

        return interfaceIndex;
    }

    public static void EnableNetworkAdapter()
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = "Enable-NetAdapter -Name Wi-Fi -Confirm:$false",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();
    }

    public static void DisableNetworkAdapter()
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            Arguments = "Disable-NetAdapter -Name Wi-Fi -Confirm:$false",
        };

        using var process = new Process();
        process.StartInfo = processInfo;
        process.Start();
        process.WaitForExit();
    }
}

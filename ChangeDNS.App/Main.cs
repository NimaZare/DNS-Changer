using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ChangeDNS.App;

public partial class Main : Form
{
    [DllImport("user32.dll")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    public Main()
    {
        InitializeComponent();
        ComboBoxDNS.SelectedIndex = 0;
    }

    private void Main_Load(object sender, EventArgs e)
    {
        IntPtr taskbarHandle = FindWindow("Shell_TrayWnd", null!);
        if (taskbarHandle != IntPtr.Zero)
        {
            GetWindowRect(taskbarHandle, out RECT taskbarRect);

            int taskbarY = taskbarRect.Top;
            int taskbarWidth = taskbarRect.Right - taskbarRect.Left;

            this.Location = new Point(taskbarWidth - 390, taskbarY - 400);
        }
    }

    private void BtnExit_Click(object sender, EventArgs e)
    {
        this.Hide();
    }

    private void ToolMenuShowApp_Click(object sender, EventArgs e)
    {
        this.Show();
    }

    private void ToolMenuExit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void BtnChangeDns_Click(object sender, EventArgs e)
    {
        SetDNS();
        ComboBoxDNS.Enabled = false;
    }

    private void BtnResetDns_Click(object sender, EventArgs e)
    {
        ResetDNS();
    }

    private void BtnRestartAdapter_Click(object sender, EventArgs e)
    {
        DisableControls();
        lblStatus.ForeColor = Color.White;
        lblStatus.Text = "Restarting...";

        try
        {
            Tools.DisableNetworkAdapter();
            lblStatus.Text = "Restart SuccessFull";
            Thread.Sleep(millisecondsTimeout: 5000);
            Tools.EnableNetworkAdapter();
        }
        catch (Exception ex)
        {
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = ex.Message;
        }

        EnableControls();
        lblStatus.ForeColor = Color.FromArgb(255, 255, 128);
        lblStatus.Text = "Disconnected";
    }


    ///  Methods
    private void EnableControls()
    {
        ComboBoxDNS.Enabled = true;
        BtnChangeDns.Enabled = true;
        BtnResetDns.Enabled = true;
        BtnRestartAdapter.Enabled = true;
    }

    private void DisableControls()
    {
        ComboBoxDNS.Enabled = false;
        BtnChangeDns.Enabled = false;
        BtnResetDns.Enabled = false;
        BtnRestartAdapter.Enabled = false;
    }

    private void SetDNS()
    {
        DisableControls();
        lblStatus.ForeColor = Color.White;
        lblStatus.Text = "Connecting...";

        try
        {
            var interfaceIndex = Tools.GetInterfaceIndex();

            var processInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
            };

            if (ComboBoxDNS.SelectedIndex == 0)
            {
                processInfo.Arguments = $"Set-DnsClientServerAddress -InterfaceIndex {interfaceIndex} -ServerAddresses ('10.202.10.202','10.202.10.102')";
            }
            else
            {
                processInfo.Arguments = $"Set-DnsClientServerAddress -InterfaceIndex {interfaceIndex} -ServerAddresses ('178.22.122.100','185.51.200.2')";
            }

            using var process = new Process();

            process.StartInfo = processInfo;
            process.Start();
            process.WaitForExit();

            var output = process.StandardOutput.ReadToEnd();

            if (output == string.Empty)
            {
                lblStatus.ForeColor = Color.Green;
                lblStatus.Text = "Connected";
            }
            else
            {
                lblStatus.ForeColor = Color.Yellow;
                lblStatus.Text = output;
            }
        }
        catch (Exception ex)
        {
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = ex.Message;
        }

        EnableControls();
    }

    private void ResetDNS()
    {
        DisableControls();
        lblStatus.ForeColor = Color.White;
        lblStatus.Text = "Disconnecting...";

        try
        {
            var interfaceIndex = Tools.GetInterfaceIndex();

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

            var output = process.StandardOutput.ReadToEnd();

            if (output == string.Empty)
            {
                lblStatus.ForeColor = Color.FromArgb(255, 255, 128);
                lblStatus.Text = "Disconnected";
            }
            else
            {
                lblStatus.ForeColor = Color.Yellow;
                lblStatus.Text = output;
            }
        }
        catch (Exception ex)
        {
            lblStatus.ForeColor = Color.Red;
            lblStatus.Text = ex.Message;
        }

        EnableControls();
    }
}

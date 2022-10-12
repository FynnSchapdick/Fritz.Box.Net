using FritzBox.Net.Console.Handlers;
using FritzBox.Net.Fritz;
using FritzBox.Net.Fritz.Clients.Base;

namespace FritzBox.Net.Console;

public class Program
{
    static Dictionary<string, ClientHandler> _clientHandlers = new();

    static void Main(string[] args)
    {
        RunAsync(args).Wait();
    }

    static async Task RunAsync(string[] args)
    {
        System.Console.WriteLine("Searching for devices...");
        IEnumerable<FritzDevice> devices = await FritzDevice.LocateDevicesAsync();

        if (devices.Count() > 0)
        {
            System.Console.WriteLine($"Found {devices.Count()} devices.");
            string input = string.Empty;
            int deviceIndex = -1;
            do
            {
                int counter = 0;
                foreach (FritzDevice device in devices)
                {
                    System.Console.WriteLine($"{counter} - {device.ModelName}");
                }

                counter++;

                input = System.Console.ReadLine();
            } while (!Int32.TryParse(input, out deviceIndex) && (deviceIndex < 0 || deviceIndex >= devices.Count()));

            FritzDevice selected = devices.Skip(deviceIndex).First();
            Configure(selected);

            do
            {
                System.Console.Clear();
                System.Console.WriteLine(" 1 - DeviceInfo");
                System.Console.WriteLine(" 2 - DeviceConfig");
                System.Console.WriteLine(" 3 - LanConfigSecurity");
                System.Console.WriteLine(" 4 - LanEthernetInterface");
                System.Console.WriteLine(" 5 - LanHostConfigManagement");
                System.Console.WriteLine(" 6 . WanCommonInterfaceConfig");
                System.Console.WriteLine(" 7 - WanIpConnection");
                System.Console.WriteLine(" 8 - WanPppConnection");
                System.Console.WriteLine(" 9 - AppSetup");
                System.Console.WriteLine("10 - Layer3Forwarding");
                System.Console.WriteLine("11 - UserInterface");
                System.Console.WriteLine("12 - WlanConfiguration");
                System.Console.WriteLine("13 - WlanConfiguration2");
                System.Console.WriteLine("14 - WlanConfiguration3");
                System.Console.WriteLine("15 - WanDslInterfaceConfig");
                System.Console.WriteLine("16 - WanEthernetLinkConfig");
                System.Console.WriteLine("17 - WanDslLinkConfig");
                System.Console.WriteLine("18 - Speedtest");

                System.Console.WriteLine("r - Reinitialize");
                System.Console.WriteLine("q - Exit");

                input = System.Console.ReadLine();
                if (_clientHandlers.ContainsKey(input))
                    await _clientHandlers[input].Handle();
                else if (input.ToLower() == "r")
                    Configure(selected);
                else if (input.ToLower() != "q")
                    System.Console.WriteLine("invalid choice");
            } while (input.ToLower() != "q");
        }
        else
        {
            System.Console.WriteLine("No devices found");
            System.Console.ReadLine();
        }
    }

    static void Configure(FritzDevice device)
    {
        ConnectionSettings settings = GetConnectionSettings();
        device.Credentials = new System.Net.NetworkCredential(settings.UserName, settings.Password);
        //device.GetServiceClient<DeviceInfoClient>(settings);
        InitClientHandler(device);
    }

    static ConnectionSettings GetConnectionSettings()
    {
        ConnectionSettings settings = new ConnectionSettings();
        System.Console.Write("User: ");
        settings.UserName = System.Console.ReadLine();
        System.Console.Write("Password: ");
        settings.Password = System.Console.ReadLine();

        return settings;
    }

    static void InitClientHandler(FritzDevice device)
    {
        _clientHandlers.Clear();
        Action clearOutput = () => System.Console.Clear();
        Action wait = () => System.Console.ReadKey();
        Action<string> printOutput = (output) => System.Console.WriteLine(output);
        Func<string> getInput = () => System.Console.ReadLine();

        _clientHandlers.Add("1", new DeviceInfoClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("2", new DeviceConfigClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("3", new LanConfigSecurityHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("4",
            new LANEthernetInterfaceClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("5",
            new LANHostConfigManagementClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("6",
            new WANCommonInterfaceConfigClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("7", new WANIPConnectonClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("8", new WANPPPConnectionClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("9", new AppSetupClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("10", new Layer3ForwardingClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("11", new UserInterfaceClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("12", new WLANConfigurationClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("13",
            new WLANConfigurationClientHandler2(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("14",
            new WLANConfigurationClientHandler3(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("15",
            new WANDSLInterfaceConfigClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("16",
            new WANEthernetLinkConfigClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("17", new WANDSLLinkConfigClientHandler(device, printOutput, getInput, wait, clearOutput));
        _clientHandlers.Add("18", new SpeedtestClientHandler(device, printOutput, getInput, wait, clearOutput));
    }
}
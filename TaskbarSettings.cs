using Microsoft.Win32;
using System.Diagnostics;

namespace TBToggler
{
    class TaskbarSettings
    {

        public static bool ToggleTaskbarAutoHide()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\StuckRects3";
            object registryData = (byte[])Registry.GetValue(keyName, "Settings", null);

            if (registryData != null)
            {
                byte[] data = (byte[])registryData;
                if (data.Length >= 12)
                {
                    // Read current auto-hide status from the registry data
                    byte currentAutoHideValue = data[8];
                    bool isCurrentlyAutoHide = currentAutoHideValue == 0x7B;

                    // Toggle the auto-hide status
                    if (isCurrentlyAutoHide)
                    {
                        data[8] = 0x7A;  // Set auto-hide off
                        Debug.WriteLine("Auto-hide disabled.");
                    }
                    else
                    {
                        data[8] = 0x7B;  // Set auto-hide on
                        Debug.WriteLine("Auto-hide enabled.");
                    }

                    // Save the updated settings back to the registry
                    Registry.SetValue(keyName, "Settings", data, RegistryValueKind.Binary);

                    ExplorerManager.RestartExplorer();

                    // Return true if auto-hide is now enabled, false otherwise
                    return data[8] == 0x7B;
                }
                else
                {
                    Debug.WriteLine("Failed to retrieve or modify taskbar settings.");
                    return false;  // Return false if unable to read or write the settings
                }
            } else
            {
                Debug.WriteLine("Failed to retrieve registry data.");
                return false;  // Return false if unable to read or write the settings
            }

        }

        public static void ToggleTaskbarAutoHideRegistry()
        {
            const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\StuckRects3";
            byte[] data = (byte[])Registry.GetValue(keyName, "Settings", null);
            if (data != null)
            {
                Debug.WriteLine("There is data");
                int currentValue = data[8];
                ExplorerManager.RestartExplorer();

            } else
            {
                Debug.WriteLine("There is no data.");
            }
        }

    //    public static void ToggleTaskbarAutoHide()
    //    {
    //        const string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\StuckRects3";
    //        byte[] data = (byte[])Registry.GetValue(keyName, "Settings", null);
    //        if (data != null && data.Length >= 12)
    //        {
    //            data[8] = (byte)(data[8] == 2 ? 3 : 2); // Toggle between 2 (auto-hide off) and 3 (auto-hide on)
    //            Registry.SetValue(keyName, "Settings", data, RegistryValueKind.Binary);
    //        }
    //        // You may need to broadcast a message that settings have changed, but this requires additional API calls.
    //    }
    }
}

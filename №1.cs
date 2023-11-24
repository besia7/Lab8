using System;
using System.Collections.Generic;

public class ConfigurationManager
{
    private static ConfigurationManager _instance;
    private Dictionary<string, string> _settings;

    private ConfigurationManager()
    {
        _settings = new Dictionary<string, string>();
    }

    public static ConfigurationManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ConfigurationManager();
            }
            return _instance;
        }
    }

    public void SetSetting(string key, string value)
    {
        _settings[key] = value;
    }

    public string GetSetting(string key)
    {
        if (_settings.ContainsKey(key))
        {
            return _settings[key];
        }
        return null;
    }

    public void DisplaySettings()
    {
        Console.WriteLine("Current Configuration Settings:");
        foreach (var setting in _settings)
        {
            Console.WriteLine($"{setting.Key}: {setting.Value}");
        }
    }
}

class Program
{
    static void Main()
    {
        ConfigurationManager configManager = ConfigurationManager.Instance;

        while (true)
        {
            Console.WriteLine("1. Set Configuration Setting");
            Console.WriteLine("2. Display Configuration Settings");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter setting key: ");
                    string key = Console.ReadLine();
                    Console.Write("Enter setting value: ");
                    string value = Console.ReadLine();
                    configManager.SetSetting(key, value);
                    Console.WriteLine("Setting updated successfully!");
                    break;

                case "2":
                    configManager.DisplaySettings();
                    break;

                case "3":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

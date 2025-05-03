using ElevenLabsApp.Main;
using System;
using System.Threading.Tasks;

namespace ElevenLabsApp
{
    class Program
    {
        static async Task Main()
        {
            AppContext.SetSwitch("EPPlus.ExcelPackage.NonCommercialLicenseAccepted", true);

            Console.Title = "🎙️ Excel to Speech Generator";
            Console.WriteLine("===========================================");
            Console.WriteLine("       ElevenLabs Excel-to-Audio Tool       ");
            Console.WriteLine("===========================================");
            Console.WriteLine("1. Generate Audio from Excel File");
            Console.WriteLine("2. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("\n📄 Enter full path to Excel file (.xlsx): ");
                    var excelPath = Console.ReadLine()?.Trim();

                    Console.Write("📁 Enter output folder path for audio files: ");
                    var outputPath = Console.ReadLine()?.Trim();

                    Console.WriteLine("\n⚙️ Processing... Please wait.\n");

                    try
                    {
                        await AudioGenerationService.GenerateFromExcelAsync(excelPath, outputPath);
                        Console.WriteLine("\n✅ Audio generation complete.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"\n❌ An error occurred: {ex.Message}");
                    }

                    break;

                case "2":
                    Console.WriteLine("\n👋 Farewell, noble user.");
                    return;

                default:
                    Console.WriteLine("\n⚠️ Invalid selection. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

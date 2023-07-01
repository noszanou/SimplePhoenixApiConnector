using Bot;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shared;
using Shared.DatEntity.Manager;
using System.Text;

namespace MainForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            var xd = ServiceProvider.GetService<IItemManager>();
            Console.WriteLine(xd.Items[1].Name);
            Application.Run(ServiceProvider.GetRequiredService<MainTab>());
            //Application.Run(new MainTab());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    services.AddSingleton<IBotConfiguration, BotConfiguration>();
                    services.AddSingleton<IItemManager, ItemManager>();
                    services.AddSingleton<BotForm>();
                    services.AddSingleton<MainTab>();
                });
        }
    }
}
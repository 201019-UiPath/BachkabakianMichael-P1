using JCUI.Menus;
using JCDB;
using Serilog;
using System;

namespace JCUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "JERKY CENTRAL - Your One Stop Shop For All Your Jerky Needs :3";
            string title = @"                             _____                 __                  
                            /\___ \               /\ \                 
                            \/__/\ \     __   _ __\ \ \/'\   __  __    
                               _\ \ \  /'__`\/\`'__\ \ , <  /\ \/\ \   
                              /\ \_\ \/\  __/\ \ \/ \ \ \\`\\ \ \_\ \  
                              \ \____/\ \____\\ \_\  \ \_\ \_\/`____ \ 
                               \/___/  \/____/ \/_/   \/_/\/_/`/___/> \
                                                                 /\___/
                                                                 \/__/ 
                             ____                   __                   ___      
                            /\  _`\                /\ \__               /\_ \     
                            \ \ \ \_\     __    ___\ \ ,_\  _ __    __  \//\ \    
                             \ \ \   _  /'__`\/' _ `\ \ \/ /\`'__\/'__`\  \ \ \   
                              \ \ \_\ \/\  __//\ \/\ \ \ \_\ \ \//\ \L\.\_ \_\ \_ 
                               \ \____/\ \____\ \_\ \_\ \__\\ \_\\ \__/.\_\/\____\
                                \/___/  \/____/\/_/\/_/\/__/ \/_/ \/__/\/_/\/____/";
            Console.WriteLine();
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine(title);
            Console.WriteLine("=======================================================================================================================");
            Console.WriteLine();

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/log.txt",
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();


            JCContext context = new JCContext();
            DBRepo dBRepo = new DBRepo(context);

            IMenu LoginMenu = new LoginMenu(dBRepo);
            LoginMenu.Start();       
           
        }
    }
}

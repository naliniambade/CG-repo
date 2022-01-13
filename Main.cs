using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class MainClass
    {
        public static void Main(string[] args)
        {
           UserInterface desc = new ScreenDescription();
        try
        {
            while (true)
            {
                desc.showFirstScreen();
            }
        }
        catch(Exception e) {
            Console.WriteLine(e.StackTrace);
        }
        }
    }
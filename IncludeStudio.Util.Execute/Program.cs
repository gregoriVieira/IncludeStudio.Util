using IncludeStudio.Util.Radar;
using System;
using System.Collections.Generic;

namespace IncludeStudio.Util.Execute
{
    class Program
    {
        static void Main(string[] args)
        {
            ExecuteRadar();
        }

        static void ExecuteRadar()
        {
            Logger.StartRadar(
                "PajtVNGP4ufV7MlkGfaZKwocbwF3kQ1z6jpdCRbP",
                "https://fir-includestudio-radar.firebaseio.com",
                "details.json",
                "Execute"
                );

            int numberInt = 14;
            string text = "TEST string value";
            double numberDouble = 17;
            float numberFloat = 15;
            List<string> lstString = new List<string>();
            lstString.Add("TEST 1");
            lstString.Add("TEST 2");

            numberInt.Track("numberInt");
            text.Track("text");
            numberDouble.Track("numberDouble");
            numberFloat.Track("numberFloat");
            lstString.Track("numberFloat");

            Logger.Information("Information method");

            var ex = new Exception("Exception test");
            ex.Error("Exception test description");

        }
    }
}

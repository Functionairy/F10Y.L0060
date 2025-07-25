using System;
using System.Threading.Tasks;


namespace F10Y.L0060.Construction
{
    class Program
    {
        static async Task Main()
        {
            //await Program.Demonstrations_();
            await Program.Demonstrations_Json();
        }

        #region Demonstrations

        static Task Demonstrations_()
        {
            throw new NotImplementedException();
        }

        static async Task Demonstrations_Json()
        {
            await Instances.JsonDemonstrations.RoundTrip_ExampleJsonFile();
        }

        #endregion
    }
}
using System;
using System.Threading.Tasks;
using GrainLibraryProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans.Serialization;
using Orleans.TestingHost;
using SerializationBug;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1 : TestingSiloHost
    {
        public UnitTest1() : base(new TestingSiloOptions() { StartSecondary = true }) { }

        [ClassInitialize]
        public static void ClassInitialize(TestContext param)
        {
            SerializationManager.InitializeForTesting();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            StopAllSilosIfRunning();
        }
        [TestMethod]
        public async Task TestMethod1()
        {
            var secondarySiloGrain = GrainFactory.GetGrain<IGenericGrain<CustomObject>>(Guid.NewGuid());
            var matchingSilo = await secondarySiloGrain.GetSiloIdentity();
            if (matchingSilo == this.Secondary.Silo.SiloAddress.ToLongString())
            {
                Console.WriteLine("Lucky Initialization");

                // This call fails on the primary silo during deserialization.
                try
                {
                    await secondarySiloGrain.Get();
                }
                catch (System.TimeoutException)
                {
                    Console.WriteLine("Call 1 failed");
                }

                // Fails again
                try
                {
                    await secondarySiloGrain.Get();
                }
                catch (System.TimeoutException)
                {
                    Console.WriteLine("Call 2 failed");
                }

                IGenericGrain<CustomObject> primarySiloGrain = null;
                do
                {
                    var grain = GrainFactory.GetGrain<IGenericGrain<CustomObject>>(Guid.NewGuid());
                    var grainSilo = await grain.GetSiloIdentity();
                    if (grainSilo == this.Primary.Silo.SiloAddress.ToLongString())
                        primarySiloGrain = grain;
                    else
                    {
                        try
                        {
                            await secondarySiloGrain.Get();
                            Console.WriteLine("Call X succeeded unexpectedly");
                        }
                        catch (System.TimeoutException)
                        {
                            Console.WriteLine("Call X failed");
                        }
                    }
                } while (primarySiloGrain == null);

                // Fails not anymore
                await secondarySiloGrain.Get();
                return;
            }

        }
    }
}

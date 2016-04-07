using System;
using System.Threading.Tasks;
using GrainLibraryProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans.TestingHost;
using SerializationBug;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1 : TestingSiloHost
    {
        //public UnitTest1() : base(new TestingSiloOptions() { StartSecondary = true, StartPrimary = false}) { }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            StopAllSilos();
        }
        [TestMethod]
        public async Task TestMethod1()
        {
            var grain = GrainFactory.GetGrain<IGenericGrain<CustomObject>>(Guid.NewGuid());
            var x = await grain.Get();
        }
        [TestMethod]
        public async Task TestMethod2()
        {
            var grain = GrainFactory.GetGrain<IGenericGrain<CustomObject>>(Guid.NewGuid());
            var x = await grain.Get();
        }

        [TestMethod]
        public async Task TestMethod3()
        {
            var grain = GrainFactory.GetGrain<IGenericGrain<CustomObject>>(Guid.NewGuid());
            var x = await grain.Get();
        }

        [TestMethod]
        public async Task TestMethod4()
        {
            var grain = GrainFactory.GetGrain<IGenericGrain<CustomObject>>(Guid.NewGuid());
            var x = await grain.Get();
        }

        [TestMethod]
        public async Task TestMethod5()
        {
            var grain = GrainFactory.GetGrain<IGenericGrain<CustomObject>>(Guid.NewGuid());
            var x = await grain.Get();
        }
    }
}

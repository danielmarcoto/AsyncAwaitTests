using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Demo04ValueTask
{
    [MemoryDiagnoser()]
    public class TaskBenchmarks
    {
        private static readonly GeoService GeoService = new();

        [Benchmark]
        public async Task<StateModel> GetStateNameAsyncWithTask()
        {
            return await GeoService.GetStateNameAsync("PE");
        }

        [Benchmark]
        public async Task<StateModel> GetStateNameValueAsync()
        {
            return await GeoService.GetStateNameValueAsync("PE");
        }
    }
}

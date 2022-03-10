using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Demo04ValueTask
{
    public class GeoService
    {
        private readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());

        private static readonly HttpClient HttpClient = new()
        {
            // Sorry for the Portuguese words, it was the fastest open service that I've found ;(
            BaseAddress = new Uri("https://servicodados.ibge.gov.br")
        };

        public async Task<StateModel> GetStateNameAsync(string acronym)
        {
            StateModel stateName = _memoryCache.Get<StateModel>(acronym);
            if (stateName is null)
            {
                // Think of this requestURI as /locations/states
                stateName = await HttpClient.GetFromJsonAsync<StateModel>($"/api/v1/localidades/estados/{acronym}");
                _memoryCache.Set(acronym, stateName, TimeSpan.FromHours(1));
            }
            return stateName;
        }

        public async ValueTask<StateModel> GetStateNameValueAsync(string acronym)
        {
            StateModel stateName = _memoryCache.Get<StateModel>(acronym);
            if (stateName is null)
            {
                // Think of this requestURI as /locations/states
                stateName = await HttpClient.GetFromJsonAsync<StateModel>($"/api/v1/localidades/estados/{acronym}");
                _memoryCache.Set(acronym, stateName, TimeSpan.FromHours(1));
            }
            return stateName;
        }
    }
}

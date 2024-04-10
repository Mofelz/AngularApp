using Microsoft.Extensions.Caching.Memory;

namespace AngularApp2.Server
{
    public class MemoryCacheService
    {
        readonly IMemoryCache? objMemCash;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            objMemCash = memoryCache;
        }
        //readonly IMemoryCache? objMemCash;

        //public MemoryCacheService(IMemoryCache objMemoryCache) // ???
        //{
        //    this.objMemCash = (IMemoryCache?)objMemoryCache; // ???
        //}

        public void FnSetMappingAccountsInMemCash()
        {
            IDictionary<string, long?> dctMappingAcs = new Dictionary<string, long?>();
            dctMappingAcs["PROFIT_ACCOUNT"] = 15;
            dctMappingAcs["DISCOUNT_ACCOUNT"] = 23;

            this.objMemCash.Set("MAPPING_ACCOUNTS", dctMappingAcs);
        }

        public IDictionary<string, long?> FnGetMappingAccountsInMemCash()
        {
            IDictionary<string, long?> dctMappingAcs = new Dictionary<string, long?>();

            if (!this.objMemCash.TryGetValue("MAPPING_ACCOUNTS", out dctMappingAcs))
            {
                this.FnSetMappingAccountsInMemCash();
            }

            dctMappingAcs = (IDictionary<string, long?>)this.objMemCash.Get("MAPPING_ACCOUNTS");

            return dctMappingAcs;
        }

        public void FnRemoveMappingAccountsInMemCash()
        {
            this.objMemCash.Remove("MAPPING_ACCOUNTS");
        }
    }
}

using TradeCaptureWebAPI.Controllers;
using TradeCaptureWebAPI.Models;

namespace TradeCaptureWebAPI
{
    public class QueryCompile
    {
        private readonly IList<SecurityFilter> filters;
        public QueryCompile(IList<SecurityFilter> filters)
        {
            this.filters = filters;
        }

        public Func<Security, bool> Compile()
        {
            return x =>
            {
                bool resoult = true;

                foreach (var f in filters)
                {
                    resoult = resoult && f.ApplyFilter(x);
                    if (resoult == false) {
                        return false;
                    }
                }
                return resoult;
            };
        }
    }
}

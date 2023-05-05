using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TradeCaptureWebAPI.Models;

namespace TradeCaptureWebAPI.Controllers
{
    public interface ISecurityFilter
    {
        bool ApplyFilter(Security a);
    }
    public enum FilterOperation
    {
        Equals,
        StartsWith,
        Contains
    }
    [EnableCors]
    public class SecurityFilter : ISecurityFilter
    {
        public string SecurityFilterValue { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; } 
        public FilterOperation Operation { get; set; }
        public bool ApplyFilter(Security a)
        {
            if (PropertyType == "string")
            {
                switch (Operation)
                {
                    case FilterOperation.Equals:
                        return (GetPropValue(a) as string) == (SecurityFilterValue);

                    case FilterOperation.StartsWith: //null check
                        return (GetPropValue(a) as string).StartsWith(SecurityFilterValue);

                    case FilterOperation.Contains:
                        return (GetPropValue(a) as string).Contains(SecurityFilterValue);
                }
            }
            else if (PropertyType=="int")
            {
                var value = ( int.Parse(SecurityFilterValue));
                return (GetPropValue(a) as int?) == value;
            }
            return false;
        }
        private object GetPropValue(Security a)
        {
            return a.GetType().GetProperty(PropertyName).GetValue(a, null);
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SecurityFilterController : ControllerBase
    {
        private readonly TradeCaptureContext _context;

        public SecurityFilterController(TradeCaptureContext context)
        {
            _context = context;
        }

        [HttpPost(Name = "SearchBy")]
        public IEnumerable<Security> Search(IList<SecurityFilter> filters)
        {
            var comp = new QueryCompile(filters);
            return _context.Security.Where(comp.Compile());
        }
    }
}

namespace Globomatics.Web.PracticeClasses
{
    public class RegionConstraint : IRouteConstraint
    {
        private static readonly HashSet<string> ValidRegions = new() { "eu", "us", "asia" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out var value))
                return ValidRegions.Contains(value?.ToString()?.ToLower());
            return false;
        }
    }

}

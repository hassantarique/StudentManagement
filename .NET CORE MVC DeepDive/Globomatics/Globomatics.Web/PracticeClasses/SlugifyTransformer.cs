using System.Text.RegularExpressions;

namespace Globomatics.Web.PracticeClasses
{
    public class SlugifyTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            if (value == null) return null;
            return Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }

}

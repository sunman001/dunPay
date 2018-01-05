using System;
using System.Linq;

namespace DunxPay.Core
{
    public class StringHelper
    {
        public string CamleCase(string input)
        {
            return input.Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries).Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }
    }
}

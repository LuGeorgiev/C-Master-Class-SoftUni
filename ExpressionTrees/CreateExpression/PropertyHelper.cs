using System;
using System.Collections.Generic;
using System.Text;

namespace CreateExpression
{
    public class PropertyHelper
    {
        public string Name { get; set; }

        public Func<object, object> Getter { get; set; }

        public static PropertyHelper[] Get<T>(T obj)
        {
            return null;
        }
    }
}

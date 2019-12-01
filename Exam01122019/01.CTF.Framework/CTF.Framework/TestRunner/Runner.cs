namespace CTF.Framework.TestRunner
{
    using System;
    using System.Text;
    using System.Reflection;
    using System.Linq;
    using CTF.Framework.Attributes;
    using System.Collections.Generic;
    using CTF.Framework.Exceptions;

    public class Runner
    {
        private readonly StringBuilder stringBuilder;

        public Runner()
        {
            this.stringBuilder = new StringBuilder();
        }

        public string Run(string assemblyPath)
        {
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            var classes = assembly.GetTypes()
                .Where(x => x.GetCustomAttributes(typeof(CTFTestClassAttribute)).Any());

            foreach (var current in classes)
            {
                var methods = current.GetMethods()
                    .Where(x => x.GetCustomAttributes(typeof(CTFTestMethodAttribute)).Any());
                var instance = Activator.CreateInstance(current);
                foreach (var method in methods)
                {
                    try
                    {
                        var parameters = method.GetParameters();
                        var parametesToInvoke = new List<object>();
                        foreach (var parameter in parameters)
                        {
                            parametesToInvoke.Add(parameter);
                        }

                        try
                        {
                            method.Invoke(instance, parametesToInvoke.ToArray());
                            this.stringBuilder.AppendLine($"Class: {current.Name} Method: {method.Name} - passed!");
                        }
                        catch (TestException e)
                        {
                            this.stringBuilder.AppendLine($"Class: {current.Name} Method: {method.Name} - failed!");
                        }

                    }
                    catch (Exception ex)
                    {
                        this.stringBuilder.AppendLine($"Unexpected error occurred in {method.Name}!");
                    }
                }

            }


            return this.stringBuilder.ToString();
        }
    }
}

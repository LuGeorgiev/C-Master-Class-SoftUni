using Demo;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ParsingExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            var someInteger = 42;
            //Expression<Func<object>> constant = () => 42;
            //Expression<Func<Dog, string>> constant = (dog) => dog.SayBau(42);
            Expression<Func<Dog, string>> constant = (dog) => dog.SayBau(someInteger);
            Expression<Func<Dog, string>> property = (dog) => dog.Owner.FullName;
            Expression<Func<int, int, long>> sum = (x, y) => x + y;
            Expression<Func<string, string, Dog>> dogFactory = (dogName, ownerName) => new Dog(dogName)
            { 
                Owner = new Owner {FullName = ownerName.ToLower() }
            };

            //if Compiled variable value will be parsed
            var func = constant.Compile();

            ParseExpression(dogFactory, String.Empty);


        }

        private static void ParseExpression(Expression expression, string level)
        {
            level += "- ";

            if (expression.NodeType == ExpressionType.Lambda)
            {
                Console.WriteLine($"{level}Extracting lambda..");
                var lambdaExpression = (LambdaExpression)expression;

                Console.WriteLine($"{level}Extracting body..");
                var body = lambdaExpression.Body;
                ParseExpression(body, level);

                Console.WriteLine($"{level}Extracting parameterS..");
                foreach (var parameterExpression in lambdaExpression.Parameters)
                {
                    ParseExpression(parameterExpression, level);
                }
            }
            else if (expression.NodeType == ExpressionType.Constant)
            {
                Console.WriteLine($"{level}Extracting constant..");
                var constantExpression = (ConstantExpression)expression;
                var value = constantExpression.Value;

                Console.WriteLine($"{level}Constant - {value}");
            }
            else if (expression.NodeType == ExpressionType.Convert)
            {
                Console.WriteLine($"{level}Converting..");
                var unaryExpression = (UnaryExpression)expression;

                ParseExpression(unaryExpression.Operand, level);
            }
            else if (expression.NodeType == ExpressionType.Call)
            {
                Console.WriteLine($"{level}Extracting method..");
                var methodCallExpresion = (MethodCallExpression)expression;

                Console.WriteLine($"{level}Method Name: {methodCallExpresion.Method.Name}");
                if (methodCallExpresion.Object == null)
                {
                    Console.WriteLine($"{level}Method is static");
                }
                else
                {
                    ParseExpression(methodCallExpresion.Object, level);
                }

                Console.WriteLine($"{level}Extracting method arguments");
                foreach (var argument in methodCallExpresion.Arguments)
                {
                    ParseExpression(argument, level);
                }
            }
            else if (expression.NodeType == ExpressionType.Parameter)
            {
                Console.WriteLine($"{level}Extracting parameter..");
                var parameterExpression = (ParameterExpression)expression;

                Console.WriteLine($"{level}Parameter: {parameterExpression.Name} - {parameterExpression.Type.Name}");
            }
            else if (expression.NodeType == ExpressionType.MemberAccess)
            {
                Console.WriteLine($"{level}Extracting member..");
                var memberExpression = (MemberExpression)expression;

                if (memberExpression.Member is PropertyInfo property)
                {
                    Console.WriteLine($"{level}Property: {property.Name} - {property.PropertyType.Name}");
                }

                if (memberExpression.Member is FieldInfo field)
                {
                    // instance of the closure class which is hidden
                    var classInstance = (ConstantExpression)memberExpression.Expression;
                    var variableValue = field.GetValue(classInstance.Value);

                    Console.WriteLine($"{level}Variable: {variableValue}");
                }
                ParseExpression(memberExpression.Expression, level);
            }
            else if (expression.NodeType == ExpressionType.Add)
            {
                Console.WriteLine($"{level}Extracting binary expression..");
                var binaryExpression = (BinaryExpression)expression;

                ParseExpression(binaryExpression.Left, level);
                ParseExpression(binaryExpression.Right, level);
            }
            else if (expression.NodeType == ExpressionType.New)
            {
                Console.WriteLine($"{level}Object creation..");
                var newExpression = (NewExpression)expression;

                Console.WriteLine($"{level}Constructor: {newExpression.Constructor.DeclaringType.Name}");
                Console.WriteLine($"{level}Extraccting constructor arguments..");
                foreach (var argument in newExpression.Arguments)
                {
                    ParseExpression(argument, level);
                }
            }
            else if (expression.NodeType == ExpressionType.MemberInit)
            {
                Console.WriteLine($"{level}Extracting object creation wilth members..");
                var memberInit = (MemberInitExpression)expression;

                ParseExpression(memberInit.NewExpression, level);

                foreach (var memberBinding in memberInit.Bindings)
                {
                    Console.WriteLine($"{level}Extracting members..");
                    Console.WriteLine($"{level}Members: {memberBinding.Member.Name}");
                    var memberAssignment = (MemberAssignment)memberBinding;

                    ParseExpression(memberAssignment.Expression, level);
                }
            }
            else
            {
                //todo variable
                //TODO extract not supported compilation
            }
        }
    }
}

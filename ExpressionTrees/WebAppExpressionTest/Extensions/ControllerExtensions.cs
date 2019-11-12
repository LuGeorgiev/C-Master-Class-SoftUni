using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace WebAppExpressionTest.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult RedirectToAction<TController>(this Controller controller, Expression<Action<TController>> redirectExpression)
        {
            if (redirectExpression.Body is MethodCallExpression methodCall)
            {
                var actionName = methodCall.Method.Name;
                var controllerNme = typeof(TController).Name.Replace(nameof(Controller), String.Empty);

                var routeValueDictionary = new RouteValueDictionary();

                var parameters = methodCall
                    .Method
                    .GetParameters()
                    .Select(x => x.Name)
                    .ToArray();

                var values = methodCall
                    .Arguments
                    .Select(arg =>
                    {
                        var constant = (ConstantExpression)arg;

                        return constant.Value;
                    })
                    .ToArray();
                for (int i = 0; i < parameters.Length; i++)
                {
                    routeValueDictionary.Add(parameters[i], values[i]);
                }

                return controller.RedirectToAction(actionName, controllerNme, routeValueDictionary);
            }
            else
            {
                throw new InvalidOperationException("Expression i snot valid");
            }
        }
    }
}

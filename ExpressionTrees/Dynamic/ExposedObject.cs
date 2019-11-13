using System;
using System.Dynamic;
using System.Reflection;

namespace Dynamic
{
    public class ExposedObject : DynamicObject
    {
        private readonly object obj;
        private readonly Type type;

        public ExposedObject(object obj)
        { 
            this.obj = obj;
            this.type = obj.GetType();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {

            var name = binder.Name;
            var property = this.type
                .GetProperty(name, BindingFlags.Instance | BindingFlags.NonPublic);

            if (property == null)
            {
                //Check for filed

                return base.TryGetMember(binder, out result);
            }

            result = property.GetValue(this.obj);

            return true;
        }


        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var name = binder.Name;
            Console.WriteLine(name);
            result = null;

            return true;
            //return base.TryInvokeMember(binder, args, out result);
        }
    }
}

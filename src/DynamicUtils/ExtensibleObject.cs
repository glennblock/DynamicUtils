using System;
using System.Collections.Generic;
using System.Dynamic;

namespace DynamicUtils
{
    public abstract class ExtensibleObject : DynamicObject
    {
        protected ExtensibleObject()
        {
            Members = new Dictionary<string, object>(StringComparer.CurrentCultureIgnoreCase);
        }
        
        protected IDictionary<string, object> Members { get; private set; }
 
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var name = binder.Name;
            var found = Members.TryGetValue(name, out result);
            
            if (result == null)
                return false;

            return found;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Members[binder.Name] = value;
            return true;
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            foreach (var entry in Members)
            {
                if (entry.Value != null)
                    yield return entry.Key;
            }
        }

        public T GetValue<T>(string key)
        {
            object val;
            var found = Members.TryGetValue(key, out val);

            if (found)
                return (T) val;

            return default(T);
        }

        public void SetValue(string key, object value)
        {
            Members[key] = value;
        }
       
        public dynamic Extensions()
        {
            return this;
        }
    }
}

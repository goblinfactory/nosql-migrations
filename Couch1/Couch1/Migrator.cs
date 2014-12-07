using System;
using Newtonsoft.Json;

namespace Couch1
{
    public static class Migrator
    {
        public static T Create<T>(string json) where T : Migratable
        {
            var verFrom = JsonConvert.DeserializeObject<Couch1.MigratableTypeInfo>(json);
            var verTo = MigratableHelper.ConfirmCompatible<T>(verFrom);
            
            if (verFrom.Equals(verTo))
                return JsonConvert.DeserializeObject<T>(json);
            else
                Activator.CreateInstance(typeof(T), json);
            //NOTE: hack!
            return default(T);
        }

    }
}
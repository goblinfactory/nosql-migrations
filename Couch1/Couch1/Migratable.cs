using System;
using Newtonsoft.Json;

namespace Couch1
{

    public  class Migratable
    {
        public Migratable()
        {
            TypeInfo = GetVersion();
        }

        private TypeInfo GetVersion()
        {
            return MigratableHelper.ReadVersion(GetType());
        }

        public TypeInfo TypeInfo { get; set; }

        public string ToJson()
        {
            return this.ToString();
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
using Newtonsoft.Json;

namespace Couch1
{
    public abstract class Migratable
    {
        protected Migratable()
        {
            TypeInfo = MigratableHelper.ReadVersion(GetType());
        }

        public abstract string Id { get; set; }

        public MigratableTypeInfo TypeInfo { get; set; }

        [JsonIgnore]
        public string Key
        {
            get
            {
                return string.Format("{0}.{1}:{2}",TypeInfo.Namespace, TypeInfo.ClassName, Id);    
            }
        }

    }
}
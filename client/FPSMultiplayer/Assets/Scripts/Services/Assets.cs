using UnityEngine;

namespace Services
{
    public class Assets
    {
        private readonly Injector _injector;

        public Assets(Injector injector) => 
            _injector = injector;

        public TAsset Instantiate<TAsset>(string path) 
            where TAsset : Object => 
            Instantiate<TAsset>(path, Vector3.zero);

        public TAsset Instantiate<TAsset>(string path, Vector3 position)
            where TAsset : Object =>
            Instantiate<TAsset>(path, position, Quaternion.identity);

        public TAsset Instantiate<TAsset>(string path, Vector3 position, Quaternion rotation)
            where TAsset : Object
        {
            var resource = Resources.Load<TAsset>(path);
            var instance = Object.Instantiate(resource, position, rotation);
            _injector.Inject(instance);
            return instance;
        }
    }
}
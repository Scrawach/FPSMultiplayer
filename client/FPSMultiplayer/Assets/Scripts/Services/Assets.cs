using UnityEngine;

namespace Services
{
    public class Assets
    {
        private readonly Injector _injector;

        public Assets(Injector injector) => 
            _injector = injector;

        public TAsset Load<TAsset>(string path)
            where TAsset : Object =>
            Resources.Load<TAsset>(path);

        public TAsset[] LoadAll<TAsset>(string path)
            where TAsset : Object =>
            Resources.LoadAll<TAsset>(path);
        
        public TAsset Instantiate<TAsset>(string path) 
            where TAsset : Object => 
            Instantiate<TAsset>(path, Vector3.zero);

        public TAsset Instantiate<TAsset>(string path, Vector3 position)
            where TAsset : Object =>
            Instantiate<TAsset>(path, position, Quaternion.identity);

        public TAsset Instantiate<TAsset>(string path, Vector3 position, Quaternion rotation)
            where TAsset : Object
        {
            var instance = Object.Instantiate(Load<TAsset>(path), position, rotation);
            _injector.Inject(instance);
            return instance;
        }
    }
}
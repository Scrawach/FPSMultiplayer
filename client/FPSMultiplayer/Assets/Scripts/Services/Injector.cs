using Reflex.Core;
using Reflex.Injectors;
using UnityEngine;

namespace Services
{
    public class Injector
    {
        private readonly Container _container;

        public Injector(Container container) => 
            _container = container;
    
        public GameObject Inject(GameObject gameObject)
        {
            GameObjectInjector.InjectRecursive(gameObject, _container);
            return gameObject;
        }
    }
}
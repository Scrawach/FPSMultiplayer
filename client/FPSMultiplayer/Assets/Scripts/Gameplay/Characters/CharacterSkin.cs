using UnityEngine;

namespace Gameplay.Characters
{
    public class CharacterSkin : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] _elements;
        
        public void ChangeTo(Material targetMaterial)
        {
            foreach (var element in _elements) 
                element.material = targetMaterial;
        }
    }
}
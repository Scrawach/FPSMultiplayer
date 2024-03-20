using Services;
using StaticData.Data;
using StaticData.ScriptableObjects;
using UnityEngine;

namespace StaticData
{
    public class StaticDataService
    {
        private const string CharacterDataPath = "StaticData/Character Settings";

        private readonly Assets _assets;
        
        private CharacterStaticData _characterData;

        public StaticDataService(Assets assets) => 
            _assets = assets;

        public void Load()
        {
            _characterData = LoadCharacterData();
        }
        
        public CharacterStats ForCharacter() => 
            _characterData.Stats;

        public Material[] ForSkins() =>
            _characterData.Skins;

        private CharacterStaticData LoadCharacterData() => 
            _assets.Load<CharacterStaticData>(CharacterDataPath);
    }
}
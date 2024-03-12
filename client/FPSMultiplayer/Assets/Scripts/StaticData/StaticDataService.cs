using System.Collections.Generic;
using System.Linq;
using Services;
using StaticData.Data;
using StaticData.ScriptableObjects;
using UnityEngine;

namespace StaticData
{
    public class StaticDataService
    {
        private const string CharacterDataPath = "StaticData/Character Settings";
        private const string GunDataPath = "StaticData/Guns Settings";

        private readonly Assets _assets;
        
        private CharacterSettings _characterData;
        private Dictionary<GunType, GunSettings> _gunData;

        public StaticDataService(Assets assets) => 
            _assets = assets;

        public void Load()
        {
            _characterData = LoadCharacterData();
            _gunData = LoadGunsData();
        }

        public CharacterSettings ForCharacter() => 
            _characterData;

        public GunSettings ForGun(GunType type) =>
            _gunData[type];

        private CharacterSettings LoadCharacterData() => 
            _assets.Load<CharacterStaticData>(CharacterDataPath).Settings;

        private Dictionary<GunType, GunSettings> LoadGunsData()
        {
            var guns = _assets.Load<GunStaticData>(GunDataPath).Settings;
            return guns.ToDictionary(key => key.Type, value => value);
        }
    }
}
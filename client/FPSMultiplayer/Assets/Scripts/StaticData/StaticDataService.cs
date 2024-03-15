using Services;
using StaticData.Data;
using StaticData.ScriptableObjects;

namespace StaticData
{
    public class StaticDataService
    {
        private const string CharacterDataPath = "StaticData/Character Settings";

        private readonly Assets _assets;
        
        private CharacterStats _characterData;

        public StaticDataService(Assets assets) => 
            _assets = assets;

        public void Load()
        {
            _characterData = LoadCharacterData();
        }
        
        public CharacterStats ForCharacter() => 
            _characterData;

        private CharacterStats LoadCharacterData() => 
            _assets.Load<CharacterStaticData>(CharacterDataPath).Stats;
    }
}
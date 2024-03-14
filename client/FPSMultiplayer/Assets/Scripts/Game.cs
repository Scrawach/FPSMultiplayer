using Cysharp.Threading.Tasks;
using Network.Services;
using StaticData;
using UnityEngine.SceneManagement;

public class Game
{
    private readonly NetworkConnection _network;
    private readonly StaticDataService _staticData;

    public Game(NetworkConnection network, StaticDataService staticData)
    {
        _network = network;
        _staticData = staticData;
    }

    public async UniTask Run()
    {
        _staticData.Load();
        var characterStats = _staticData.ForCharacter();
        var sceneName = SceneManager.GetActiveScene().name;
        await _network.Connect(sceneName, characterStats);
    }

    public async UniTask Stop() => 
        await _network.Disconnect();
}
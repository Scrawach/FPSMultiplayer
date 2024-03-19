using Cysharp.Threading.Tasks;
using Network.Services;
using Services;
using StaticData;
using UnityEngine.SceneManagement;

public class Game
{
    private readonly NetworkConnection _network;
    private readonly StaticDataService _staticData;
    private readonly CursorService _cursorService;

    public Game(NetworkConnection network, StaticDataService staticData, CursorService cursorService)
    {
        _network = network;
        _staticData = staticData;
        _cursorService = cursorService;
    }

    public async UniTask Run()
    {
        _staticData.Load();
        var characterStats = _staticData.ForCharacter();
        var sceneName = SceneManager.GetActiveScene().name;
        await _network.Connect(sceneName, characterStats);
        _cursorService.HideCursor();
    }

    public async UniTask Stop() => 
        await _network.Disconnect();
}
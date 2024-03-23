using Cysharp.Threading.Tasks;
using Network.Services;
using Services;
using StaticData;
using UnityEngine;
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
        var selectedSkin = GetRandomSkinIndex();
        await _network.Connect(sceneName, characterStats, selectedSkin);
        _cursorService.HideCursor();
    }

    public async UniTask Stop() => 
        await _network.Disconnect();

    private int GetRandomSkinIndex()
    {
        var availableSkins = _staticData.ForSkins();
        var randomIndex = Random.Range(0, availableSkins.Length);
        return randomIndex;
    }
}
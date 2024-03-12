using Cysharp.Threading.Tasks;
using Network.Services;
using StaticData;

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
        var characterSettings = _staticData.ForCharacter();
        await _network.Connect(characterSettings);
    }

    public async UniTask Stop() => 
        await _network.Disconnect();
}
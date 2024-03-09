using Cysharp.Threading.Tasks;
using Network.Services;

public class Game
{
    private readonly NetworkManager _network;

    public Game(NetworkManager network) => 
        _network = network;

    public async UniTask Run() => 
        await _network.Connect();

    public async UniTask Stop() => 
        await _network.Disconnect();
}
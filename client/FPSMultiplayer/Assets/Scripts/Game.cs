using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Network.Schemas;
using Network.Services;
using Network.Services.Initializers;

public class Game
{
    private readonly NetworkManager _network;
    private readonly IEnumerable<INetworkStateInitializer> _initializers;

    public Game(NetworkManager network, IEnumerable<INetworkStateInitializer> initializers)
    {
        _network = network;
        _initializers = initializers;
    }
    
    public async UniTask Run()
    {
        await _network.Connect();
        _network.StateChanged += OnStateChanged;
    }

    public async UniTask Stop()
    {
        await _network.Disconnect();
        _network.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(State state, bool isFirstState)
    {
        if (isFirstState)
            Initialize(state);
    }

    private void Initialize(State state)
    {
        foreach (var initializer in _initializers) 
            initializer.Initialize(state);
    }
}
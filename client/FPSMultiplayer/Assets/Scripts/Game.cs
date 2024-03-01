using System.Collections.Generic;
using System.Threading.Tasks;
using Network.Services;
using Network.Services.StateListeners;
using Schemas;
using Services;

public class Game
{
    private readonly NetworkManager _network;
    private readonly IEnumerable<INetworkStateListener> _listeners;

    public Game(NetworkManager network, IEnumerable<INetworkStateListener> listeners)
    {
        _network = network;
        _listeners = listeners;
    }
    
    public async Task Run()
    {
        await _network.Connect();
        _network.StateChanged += OnStateChanged;
    }

    public async Task Stop()
    {
        await _network.Disconnect();
        _network.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(State state, bool isFirstState)
    {
        foreach (var listener in _listeners) 
            listener.ChangeState(state, isFirstState);
    }
}
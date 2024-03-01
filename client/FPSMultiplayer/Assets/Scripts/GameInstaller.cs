using Colyseus;
using Network.Services;
using Network.Services.StateListeners;
using Reflex.Core;
using Services;
using UnityEngine;

public class GameInstaller : MonoBehaviour, IInstaller
{
    public ColyseusSettings Settings;
    
    public void InstallBindings(ContainerBuilder builder)
    {
        builder.AddSingleton(container => new ColyseusClient(container.Resolve<ColyseusSettings>()));
        builder.AddSingleton(Settings);
        builder.AddSingleton(typeof(Injector));
        builder.AddSingleton(typeof(NetworkFactory));
        builder.AddSingleton(typeof(NetworkManager));
        builder.AddSingleton(typeof(Game));
        builder.AddSingleton(typeof(PlayerBuilder), typeof(INetworkStateListener));
        // builder.AddSingleton(typeof(DebugChangeState), typeof(INetworkStateListener));
    }
}
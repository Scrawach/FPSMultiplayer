using Colyseus;
using Extensions;
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
        builder.AddSingleton(Settings);
        builder.AddSingleton(container => new ColyseusClient(container.Resolve<ColyseusSettings>()));

        builder.AddSingleton<Injector>();
        builder.AddSingleton<NetworkFactory>();
        builder.AddSingleton<NetworkManager>();
        builder.AddSingleton<Game>();
        builder.AddSingleton<INetworkStateListener, PlayerBuilder>();
        //builder.AddSingleton<INetworkStateListener, DebugChangeState>();
    }
}
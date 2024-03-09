using Colyseus;
using Extensions;
using Network.Services;
using Network.Services.Characters;
using Network.Services.Listeners;
using Network.Services.Logic;
using Network.Services.Messages;
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
        builder.AddSingleton<InputService>();
        builder.AddSingleton<CameraProvider>();
        builder.AddSingleton<Assets>();
        builder.AddSingleton<BulletFactory>();
        builder.AddSingleton<GameFactory>();
        
        builder.AddSingleton<NetworkCharactersProvider>();
        builder.AddSingleton<NetworkGameFactory>();
        builder.AddSingleton<NetworkManager>();
        
        builder.AddSingleton<Game>();

        builder.AddSingleton<NetworkPlayersInitializer>();
        builder.AddSingletonWithInterfacesAndSelf<NetworkTransmitter>();
        builder.AddSingleton<INetworkRoomListener, NetworkStateInitializer>();
        builder.AddSingleton<INetworkRoomListener, ShootMessageListener>();
        
        builder.AddTransient<NetworkMovementPrediction>();
    }
}
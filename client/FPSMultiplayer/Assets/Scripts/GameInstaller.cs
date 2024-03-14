using Colyseus;
using Extensions;
using Network.Services;
using Network.Services.Characters;
using Network.Services.Listeners;
using Network.Services.Listeners.Players;
using Network.Services.Logic;
using Network.Services.Messages;
using Reflex.Core;
using Services;
using StaticData;
using UI.Score;
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
        builder.AddSingleton<StaticDataService>();
        builder.AddSingleton<BulletFactory>();
        builder.AddSingleton<GameFactory>();
        builder.AddSingleton<UIFactory>();
        
        builder.AddSingleton<NetworkCharactersProvider>();
        builder.AddSingleton<NetworkGameFactory>();
        builder.AddSingleton<NetworkConnection>();
        
        builder.AddSingleton<Game>();

        builder.AddSingleton<IPlayersChangeHandler, PlayersInitializer>();
        builder.AddSingleton<IPlayersChangeHandler, UIPlayerInitializer>();
        builder.AddSingleton<NetworkPlayersListener>();
        
        builder.AddSingletonWithInterfacesAndSelf<NetworkTransmitter>();
        builder.AddSingleton<INetworkRoomHandler, NetworkStateInitializer>();
        builder.AddSingleton<INetworkRoomHandler, ShootMessageHandler>();
        
        builder.AddTransient<NetworkMovementPrediction>();
    }
}
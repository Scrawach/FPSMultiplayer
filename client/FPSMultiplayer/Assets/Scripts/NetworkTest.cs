using Colyseus;
using Extensions;
using Network;
using Schemas;
using UnityEngine;

public class NetworkTest : MonoBehaviour
{
    [SerializeField] private ColyseusSettings _settings;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private GameObject _enemyPrefab;

    private ColyseusRoom<State> _room;
    
    private async void Start()
    {
        const string roomName = "my_room";
        var client = new ColyseusClient(_settings.WebSocketEndpoint);
        _room = await client.JoinOrCreate<State>(roomName);
        _room.OnStateChange += OnStateChanged;
    }

    public void SendPosition(Vector3 vector3) => 
        _room.Send("setPosition", vector3.AsPosition());

    private void OnStateChanged(State state, bool isFirstState)
    {
        if (!isFirstState)
            return;

        state.players.ForEach((key, player) =>
        {
            if (_room.SessionId == key)
                CreatePlayer(key, player);
            else
                CreateEnemy(key, player);
        });

        state.players.OnAdd(CreateEnemy);
        state.players.OnRemove(null);
    }

    private void CreatePlayer(string sessionId, Player player)
    {
        var instance = Instantiate(_playerPrefab, player.position.ToVector3(), Quaternion.identity);
        instance.GetComponent<NetworkPositionSync>().Construct(this);
    }

    private void CreateEnemy(string sessionId, Player player)
    {
        var instance = Instantiate(_enemyPrefab, player.position.ToVector3(), Quaternion.identity);
        var positionSync = instance.GetComponent<NetworkPositionSync>();
        positionSync.Construct(this);
        player.OnPositionChange(positionSync.OnPositionChanged);
    }

    private void OnDestroy() => 
        _room.Leave();
}
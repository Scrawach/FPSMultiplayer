using Colyseus;
using Extensions;
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

        var sessionId = _room.SessionId;

        CreatePlayer(sessionId, state.players[sessionId]);
        Debug.Log($"{sessionId}, position {state.players[sessionId]}");
    }

    private void CreatePlayer(string sessionId, Player player)
    {
        var instance = Instantiate(_playerPrefab, player.position.ToVector3(), Quaternion.identity);
    }

    private void CreateEnemy(string sessionId, Player player)
    {
        var instance = Instantiate(_enemyPrefab, player.position.ToVector3(), Quaternion.identity);
    }

    private void OnDestroy() => 
        _room.Leave();
}
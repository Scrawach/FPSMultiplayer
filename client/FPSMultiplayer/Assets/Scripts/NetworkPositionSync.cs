using UnityEngine;

public class NetworkPositionSync : MonoBehaviour
{
    private NetworkTest _network;

    public void Construct(NetworkTest network) => 
        _network = network;

    private void Update() => 
        _network.SendPosition(transform.position);
}
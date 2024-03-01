using Reflex.Attributes;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private Game _game;
    
    [Inject]
    public void Construct(Game game) => 
        _game = game;

    private async void Start()
    {
        await _game.Run();
        DontDestroyOnLoad(gameObject);
    }
    
    private async void OnDestroy() => 
        await _game.Stop();
}
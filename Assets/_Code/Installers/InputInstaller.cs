using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InputActions input = new InputActions(); 
        
        Container
            .Bind<InputActions>()
            .FromInstance(input)
            .AsSingle();

        input.Enable();
    }
}
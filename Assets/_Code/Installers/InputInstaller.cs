using Zenject;

public class InputInstaller : MonoInstaller
{
    private InputActions _input;

    public override void InstallBindings()
    {
        _input = new InputActions();
        _input.Enable();

        Container
            .Bind<InputActions>()
            .FromInstance(_input)
            .AsSingle();
    }
}
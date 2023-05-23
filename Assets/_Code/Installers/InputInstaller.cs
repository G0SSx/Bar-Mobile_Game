using UnityEngine;
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

        Container
            .Bind<InputService>()
            .FromInstance(RegisterInputService())
            .AsSingle();
    }

    private InputService RegisterInputService()
    {
        if (Application.isEditor)
            return new StandaloneInput();
        else
            return new MobileInput();
    }
}
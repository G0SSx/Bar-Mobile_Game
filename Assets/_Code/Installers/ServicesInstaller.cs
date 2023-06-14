using _Code.Counters.Services;
using _Code.Data;
using _Code.Infrastructure.AssetManagement;
using _Code.Infrastructure.Services.Factory;
using _Code.Infrastructure.Services.Input;
using _Code.Infrastructure.Services.SaveLoad;
using _Code.Infrastructure.Services.StaticData;
using _Code.KitchenObjects.Factory;
using _Code.UI.Services.Factory;
using Zenject;
using UnityEngine;

namespace _Code.Installers
{
    public class ServicesInstaller : MonoInstaller
    {
        [Inject]
        private DiContainer _container;

        public override void InstallBindings()
        {
            RegisterInput();
            IAssets assets = RegisterAssetProvider();
            IStaticDataService staticData = RegisterStaticDataProvider();
            IPersistentProgressService progress = RegisterPersistentProgressService();

            RegisterUIFactory(assets);
            IGameFactory gameFactory = RegisterGameFactory(assets, progress);
            RegisterSaveLoadService(progress, gameFactory);
            RegisterKitchenObjectFactory(assets, staticData);
            RegisterCountersFactory(assets);
        }

        private void RegisterSaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            Container
                .Bind<ISaveLoadService>()
                .FromInstance(new SaveLoadService(progressService, gameFactory))
                .AsSingle();
        }

        private void RegisterInput()
        {
            Container
                .Bind<IInputService>()
                .FromInstance(RegisterInputService())
                .AsSingle();
        }

        private IPersistentProgressService RegisterPersistentProgressService()
        {
            IPersistentProgressService progressService = new PersistentProgressService();

            Container
                .Bind<IPersistentProgressService>()
                .FromInstance(progressService)
                .AsSingle();

            return progressService;
        }

        private IStaticDataService RegisterStaticDataProvider()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadConfigs();

            Container
                .Bind<IStaticDataService>()
                .FromInstance(staticData)
                .AsSingle();

            return staticData;
        }

        private IAssets RegisterAssetProvider()
        {
            IAssets assets = new AssetProvider(_container);
        
            Container
                .Bind<IAssets>()
                .FromInstance(assets)
                .AsSingle();

            return assets;
        }

        private InputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInput();
            else
                return new MobileInput();
        }

        private void RegisterCountersFactory(IAssets assets)
        {
            Container.
                Bind<ICountersFactory>()
                .FromInstance(new CountersFactory(assets))
                .AsSingle();
        }

        private void RegisterUIFactory(IAssets assets)
        {
            Container
                .Bind<IUIFactory>()
                .FromInstance(new UIFactory(assets))
                .AsSingle();
        }

        private IKitchenObjectsFactory RegisterKitchenObjectFactory(IAssets assets, IStaticDataService staticData)
        {
            IKitchenObjectsFactory factory = new KitchenObjectsFactory(assets, staticData);

            Container
                .Bind<IKitchenObjectsFactory>()
                .FromInstance(factory)
                .AsSingle();

            return factory;
        }

        private IGameFactory RegisterGameFactory(IAssets assets, IPersistentProgressService progress)
        {
            IGameFactory gameFactory = new GameFactory(assets, progress);

            Container
                .Bind<IGameFactory>()
                .FromInstance(gameFactory)
                .AsSingle();

            return gameFactory;
        }
    }
}
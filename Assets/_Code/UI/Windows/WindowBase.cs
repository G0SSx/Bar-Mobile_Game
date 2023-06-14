using _Code.Data;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Code.UI.Windows
{
    public abstract class WindowBase : MonoBehaviour
    {
        protected IPersistentProgressService progressService;
    
        protected PlayerProgress Progress => progressService.Progress;

        [SerializeField] private Button _closeButton;

        [Inject]
        private void Construct(IPersistentProgressService progressService) => 
            this.progressService = progressService;

        private void Awake() => 
            OnAwake();

        private void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        private void OnDestroy() => 
            CleanUp();

        protected virtual void OnAwake() => 
            _closeButton.onClick.AddListener(() => Destroy(gameObject));

        protected virtual void Initialize() { }
        protected virtual void SubscribeUpdates() { }
        protected virtual void CleanUp() { }
    }
}
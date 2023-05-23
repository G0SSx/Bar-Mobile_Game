public interface IPersistentProgressService : IService
{
    PlayerProgress Progress { get; set; }
}
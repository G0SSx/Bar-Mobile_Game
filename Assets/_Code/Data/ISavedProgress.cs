public interface ISavedProgress : ISavedProgressReader
{
    void UpdateProgress(PlayerProgress progress);
}
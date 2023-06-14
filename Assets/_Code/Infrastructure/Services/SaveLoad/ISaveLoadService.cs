using _Code.Data;

namespace _Code.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}
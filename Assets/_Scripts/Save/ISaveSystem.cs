namespace _Scripts.Save
{
    public interface ISaveSystem
    {
        void Save(SaveData saveData);

        void Load();
    }
}

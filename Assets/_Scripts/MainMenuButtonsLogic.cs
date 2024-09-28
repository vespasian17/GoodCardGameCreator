using UnityEngine;

namespace _Scripts
{
    public class MainMenuButtonsLogic : MonoBehaviour
    {
        private void DeleteMainDataFile()
        {
            DataManager.Instance.DataSaveService.DeleteData<SaveData>("/player-stats.json");
        }

        public void ContinueButton()                                                  // Continue button
        {
            DataManager.Instance.LoadSavedStatsFromFile();
            DataManager.Instance.LoadSavedCard();
        }

        public void NewGameButton()                                                          // New Game button
        {
            DeleteMainDataFile();               //not necessary
            DataManager.Instance.ResetStats();           
            DataManager.Instance.ResetCard();
        }
    }
}

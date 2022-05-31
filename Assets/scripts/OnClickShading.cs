using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickShading : MonoBehaviour
{
    public void OnClickWin()
    {
        StatusSystem.DispelAll();
        SceneManager.LoadScene("Map");
    }

    public void AbandonBattle()
    {
        NodeScript.currentNodeNumber = 0;
        StatusSystem.DispelAll();
        Units.ResetUnits();
        BattleResultsSingleton.ResetResults();
        GameState.isGame = false;
        SceneManager.LoadScene("MainMenu");
    }
}

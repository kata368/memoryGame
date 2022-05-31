using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehaviour : MonoBehaviour
{
    public void TriggerMenuBehaviour(int i){
        switch (i)
        {
            case(0):
                SceneManager.LoadScene("LevelSceene");
                break;
            case(1):
                Application.Quit();
                break;
        }
    }
}

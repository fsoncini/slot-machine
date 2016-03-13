using UnityEngine;
using UnityEngine.SceneManagement;



public class LevelManager : MonoBehaviour {

    //Create function for loading level when Start button is pressed
    //const int max_count = 5;
    //int count = 0;
    //bool still_trying = true;

    public void LoadLevel(string name){
        //Debug.Log("Level load requested for " + name);
        SceneManager.LoadScene(name);
    }

    public void QuitRequest() {
        
        Application.Quit();
    }

    //public void OnGui()
    //{
    //    Application.Quit;
    //}
 
}

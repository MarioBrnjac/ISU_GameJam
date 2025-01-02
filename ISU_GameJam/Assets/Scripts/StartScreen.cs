using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScreenManager : MonoBehaviour {
    void Update() {
        if (Input.anyKeyDown) {
            LoadNextScene();
        } 
    } 
    void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
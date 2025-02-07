using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
        public void ChangeScenes(string ExitPlane)
    {
        SceneManager.LoadScene(ExitPlane);
    }
}
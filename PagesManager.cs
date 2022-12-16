using UnityEngine;
using UnityEngine.SceneManagement;

public class PagesManager : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

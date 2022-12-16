using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToTitle : MonoBehaviour
{

    public bool mouseOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnMouseDown()
    {
        SceneManager.LoadScene("1-Title");
    }
}

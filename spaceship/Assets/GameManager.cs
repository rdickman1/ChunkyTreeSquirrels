using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ReconstructScene()
    {
	    SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);	
    }

    public void ResetScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void Update()
    {
        if(Input.GetKey("r"))
		{
			ReconstructScene();	//Calls the function to reset the scene
		}
    }

    void FixedUpdate()
    {
        if(Input.GetKey("z"))
        {
            ResetScene();
        }
    }
}

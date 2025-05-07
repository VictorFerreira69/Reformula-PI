using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
    [SerializeField] string scene;
    [SerializeField] float time;
    void Start()
    {

       StartCoroutine(CCh());    

    }
    IEnumerator CCh()
    {


        yield return new WaitForSeconds(time);
 
       SceneManager.LoadScene(scene);
       
    }

    
}

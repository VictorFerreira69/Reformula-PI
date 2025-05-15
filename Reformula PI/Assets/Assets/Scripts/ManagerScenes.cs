using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
     [Header("Nome da cena")]
    [SerializeField] string scene; 
 [Header("Tempo para carregar a cena")]
    [SerializeField] float time;
    void Start()
    {
        // Inicia a coroutina
        StartCoroutine(ChangeSceneAfterDelay());
    }

    // Espera o tempo definido e carrega a cena
    private IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(time); // Espera o tempo acabar
        SceneManager.LoadScene(scene); // Troca para a cena 
    }
}


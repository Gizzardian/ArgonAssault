using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSource : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadLevel", 5f);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

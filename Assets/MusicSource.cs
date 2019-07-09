using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSource : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);  // keeps music playing, small g means instance of an object
    }
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

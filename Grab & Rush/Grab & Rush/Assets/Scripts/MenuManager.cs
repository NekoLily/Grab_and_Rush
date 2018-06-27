using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

    public GameObject Canvas;
    public GameObject Camera;
    bool Paused = false;

    void Start()
    {
        Canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMethod();
        }
    }
        public void PauseMethod()
        {
            if (Canvas.gameObject.activeInHierarchy == false)
            {
                Canvas.gameObject.SetActive(true);
            }
            else
            {
                Canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
    
  
}
    


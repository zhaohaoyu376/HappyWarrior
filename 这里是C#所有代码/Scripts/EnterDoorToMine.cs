using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterDoorToMine : MonoBehaviour
{



    void Update()
    {
        print("检测是否按下E");
        if (Input.GetKey(KeyCode.E))
        {
            print("按下E");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}

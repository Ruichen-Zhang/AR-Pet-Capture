using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login_UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Btn_GoMapScn()
    {
        Login_Au.Instance.BtnAudioPlay();
        SceneManager.LoadScene("Map_Scn");
    }
}

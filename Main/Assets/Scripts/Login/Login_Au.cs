using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login_Au : MonoBehaviour
{
    private AudioSource AuS;
    public static Login_Au Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        AuS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnAudioPlay()
    {
        AuS.Play();
    }
}

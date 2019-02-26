using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSet : MonoBehaviour
{
    VideoPlayer videoplayer;
    GameController gamecontroller;
    int ok=1;
    [SerializeField] string file_name;
    

    private void Start()
    {
        videoplayer = GetComponent<VideoPlayer>();
        gamecontroller= gamecontroller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    private void Update()
    {
        if (transform.localScale.x >= 0.9f&&ok==1)
        {
            OnVideo();
        }
        else
        {
            OffVideo();
        }
    }

    public void OnVideo()
    {
        videoplayer.enabled = true;
    }

    public void OffVideo()
    {
        videoplayer.enabled = false;
    }

    public void Kurikku()
    {
        if(transform.localScale.x >= 0.9f)
        {
            ok = 0;
            Invoke("GameStart", 5);
            gamecontroller.StartScreen(file_name);
        }
    }

    void GameStart()
    {
        ok = 1;
    }
}

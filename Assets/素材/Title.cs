using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] AudioSource kanon;
    [SerializeField] AudioSource doon;
    [SerializeField] Animator title;
    [SerializeField] GameObject 曲選択キャンバス;

    // Start is called before the first frame update
    void Start()
    {
        曲選択キャンバス.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            曲選択キャンバス.SetActive(true);
            doon.enabled = true;
            title.SetBool("susumu", true);
        }
    }
}

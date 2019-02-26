using UnityEngine;
using System.Collections;
using System.IO;
using System;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] notes;
    private float[] _timing;
    private int[] _lineNum;

    string filePass;
    private int _notesCount = 0;

    private float _startTime = 0;

    public float timeOffset =0;

    private bool _isPlaying = false;

    [SerializeField] Text scoreText,comboText;
    int score,combo;

    [SerializeField] Slider slider;
    [SerializeField] GameObject excellent;
    [SerializeField] GameObject good;
    [SerializeField] GameObject miss;
    [SerializeField] Animator sentakupanel;
    [SerializeField] AudioSource key_sound;

    public float line;
    float x_1;
    float x_2;
    [SerializeField] GameObject yon;
    [SerializeField] GameObject go;
    [SerializeField] GameObject roku;

    void Start()
    {
        _timing = new float[4096];
        _lineNum = new int[4096];
    }

    void Update()
    {
        scoreText.text = score.ToString();
        comboText.text = combo.ToString();
        if (_isPlaying)
        {
            CheckNextNotes();
        }

        if (Input.anyKeyDown)
        {
            key_sound.enabled=false;
            key_sound.enabled=true;
        }
    }

    public void StartScreen(string file_name)
    {
        sentakupanel.SetBool("UP", true);
        line = slider.value;
        filePass = "CSV/" + line.ToString() + "/" + file_name;
        LoadCSV();
        Invoke("StartGame", 5);
        if (line == 4)
        {
            yon.SetActive(true);
            go.SetActive(false);
            roku.SetActive(false);
        }

        if (line == 5)
        {
            yon.SetActive(false);
            go.SetActive(true);
            roku.SetActive(false);
        }

        if (line == 6)
        {
            yon.SetActive(false);
            go.SetActive(false);
            roku.SetActive(true);
        }
    }

    public void StartGame()
    {
        _startTime = Time.time;
        _isPlaying = true;
    }

    void CheckNextNotes()
    {
        while (_timing[_notesCount] + timeOffset < GetMusicTime() && _timing[_notesCount] != 0)
        {
            SpawnNotes(_lineNum[_notesCount]);
            _notesCount++;
        }
    }

    void SpawnNotes(int num)
    {
        if (line == 4)
        {
            x_1 = -10.5f;
            x_2 = 7f;
        }

        if (line == 5)
        {
            x_1 = -11.2f;
            x_2 = 5.6f;
        }

        if (line == 6)
        {
            x_1 = -11.65f;
            x_2 = 4.65f;
        }
        Instantiate(notes[num],
            new Vector3(x_1 + (x_2 * num), 10.5f, 0),
            Quaternion.identity);
    }

    void LoadCSV()
    {
        int i = 0, j;
        TextAsset csv = Resources.Load(filePass) as TextAsset;
        StringReader reader = new StringReader(csv.text);
        while (reader.Peek() > -1)
        {

            string line = reader.ReadLine();
            string[] values = line.Split(',');
            for (j = 0; j < values.Length; j++)
            {
                _timing[i] = float.Parse(values[0]);
                _lineNum[i] = int.Parse(values[1]);
            }
            i++;
        }
    }

    float GetMusicTime()
    {
        return Time.time - _startTime;
    }


    //0=使ったら戻す,1=グット,2=エクセレント,3=ミス
    public void Decision(int decision)
    {
        if (decision == 1)
        {
            score += 100+combo*10;
            combo++;
            good.SetActive(false);
            good.SetActive(true);
        }
        if (decision == 2)
        {
            score += 300+combo*10;
            combo++;
            excellent.SetActive(false);
            excellent.SetActive(true);
        }
        if (decision == 3)
        {
            combo=0;
            miss.SetActive(false);
            miss.SetActive(true);
        }
    }
}
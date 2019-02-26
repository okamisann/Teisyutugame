using System.Collections;
using UnityEngine;
using System.IO;

public class MusicGameCreate : MonoBehaviour
{
    //ノーツが振り分けられる範囲を指定
    [SerializeField, Tooltip("レーンの数"), Range(4, 6)] int line_quantity = 4;

    //曲を読み込む
    AudioSource source;

    //テンポの管理
    float[] spectrum = new float[1024];
    float key_create_time, wait_time = 0, start_time = 0;

    //ノーツ管理
    bool first=false, second=false, third=false, fourth=false, fifth=false, sixth=false,normal=false;
    int notes_amount;
    int notes_Random;

    //書き込み
    string fileName;
    bool write_name = false;


    void Start()
    {
        source = GetComponent<AudioSource>();
        int bpm = UniBpmAnalyzer.AnalyzeBpm(source.clip);
        key_create_time = 30.0f / bpm;
        start_time = Time.time;

        //保存ファイルの名付け
        fileName = "Resources/CSV/" + line_quantity.ToString() + "/" + source.clip.ToString();

        Debug.Log(source.clip.name+"--------------------" +"BPM" + bpm);
    }
    
    void Update()
    {
        wait_time += Time.deltaTime;
        if (wait_time >= key_create_time)
        {
            wait_time = 0;
            StartCoroutine(CubeScale());
        }
        if (!source.isPlaying) Application.Quit();
    }

    //キューブを音に合わせて拡大、縮小する処理
    IEnumerator CubeScale()
    {
        yield return null;
        source.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        float max = 0;
        int min = 0;
        int maximum = 1024;
        for (int i = min; i < maximum; i++)
        {
            if (spectrum[i] >= max)
            {
                max = spectrum[i];
            }
        }
        float y = max * 200;
        transform.localScale = new Vector3(1, y, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Quadruple")
        {
            Notes_Installation(4);
            return;
        }
        if(other.tag== "Triple")
        {
            Notes_Installation(3);
            return;
        }
        if(other.tag== "Double")
        {
            Notes_Installation(2);
            return;
        }
        if (normal == false)
        {
            normal = true;
            Invoke("Normal_Notes", key_create_time);
        }
    }

    //この文でノーマルノーツが同一の時間に複数生成されるのを防ぐ
    void Normal_Notes()
    {
        normal = false;
        Notes_Installation(1);
    }

    //ノーツをランダムに振り分ける処理
    void Notes_Installation(int notes)
    {
        for (notes_amount = 0; notes_amount < notes;)
        {
            if (first == false && notes_amount < notes)
            {
                notes_Random = Random.Range(0, 6);
                if (notes_Random == 1)
                {
                    first = true;
                    notes_amount++;
                }
            }

            if (second == false && notes_amount < notes)
            {
                notes_Random = Random.Range(0, 6);
                if (notes_Random == 1)
                {
                    second = true;
                    notes_amount++;
                }
            }

            if (third == false && notes_amount < notes)
            {
                notes_Random = Random.Range(0, 6);
                if (notes_Random == 1)
                {
                    third = true;
                    notes_amount++;
                }
            }

            if (fourth == false && notes_amount < notes)
            {
                notes_Random = Random.Range(0, 6);
                if (notes_Random == 1)
                {
                    fourth = true;
                    notes_amount++;
                }
            }

            if (fifth == false && notes_amount < notes && line_quantity >= 5)
            {
                notes_Random = Random.Range(0, 6);
                if (notes_Random == 1)
                {
                    fifth = true;
                    notes_amount++;
                }
            }

            if (sixth == false && notes_amount < notes && line_quantity >= 6)
            {
                notes_Random = Random.Range(0, 6);
                if (notes_Random == 1)
                {
                    sixth = true;
                    notes_amount++;
                }
            }
        }
        InputNotes();
    }
    
    //実際のゲームで流れるレーンを設定
    void InputNotes()
    {
        if (first == true)
        {
            first = false;
            WriteNotesTiming(0);
        }
        if (second == true)
        {
            second = false;
            WriteNotesTiming(1);
        }
        if (third == true)
        {
            third = false;
            WriteNotesTiming(2);
        }
        if (fourth == true)
        {
            fourth = false;
            WriteNotesTiming(3);
        }
        if (fifth == true)
        {
            fifth = false;
            WriteNotesTiming(4);
        }
        if (sixth == true)
        {
            sixth = false;
            WriteNotesTiming(5);
        }
    }

    //キューブが反応した瞬間の時間を所得
    float GetTiming()
    {
        return Time.time - start_time;
    }

    void WriteNotesTiming(int notes_line)
    {
        WriteCSV(GetTiming().ToString() + "," + notes_line.ToString());
        Debug.Log(GetTiming()+"----------"+notes_line);
    }

    //書き込み処理
    public void WriteCSV(string txt)
    {
        StreamWriter streamWriter;
        FileInfo fileInfo;
        fileInfo = new FileInfo(Application.dataPath + "/" + fileName + ".csv");
        streamWriter = fileInfo.AppendText();
        streamWriter.WriteLine(txt);
        streamWriter.Flush();
        streamWriter.Close();
    }


}

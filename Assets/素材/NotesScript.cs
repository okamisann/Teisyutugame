using UnityEngine;

public class NotesScript : MonoBehaviour
{
    GameController _gameController;
    [SerializeField] int lineNum;
    bool isInLine = false;
    int decision;

    private void Start()
    {
        _gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }


    void Update()
    {
        transform.position += Vector3.down * 10 * Time.deltaTime;

        if (transform.position.y < -6.0f)
        {
            _gameController.Decision(3);
            Destroy(gameObject);
        }
        if (isInLine == true)
        {
            CheckInput();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        isInLine = true;

        if (other.tag == "エクセレント")
        {
            decision = 2;
        }
        else
        {
            if(other.tag=="グッド")decision = 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "エクセレント")
        {
            decision = 1;
            return;
        }
        else
        {
            if(other.tag=="グッド")isInLine = false;
        }
    }

    void CheckInput()
    {
        if (_gameController.line == 6)
        {
            if (lineNum == 0)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 1)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 2)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 3)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 4)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 5)
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
        }
        if (_gameController.line == 5)
        {
            if (lineNum == 0)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 1)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 2)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 3)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 4)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
        }
        if (_gameController.line == 4)
        {
            if (lineNum == 0)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 1)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 2)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
            if (lineNum == 3)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    _gameController.Decision(decision);
                    Destroy(gameObject);
                }
            }
        }
    }
}
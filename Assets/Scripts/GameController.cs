using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject slime;
    [SerializeField] private InputActionReference pauseInput;

    public int slimeCount = 50;
    public Image pauseMenu;
    public Image hud;
    public Text timerTxt;
    public Text progressTxt;

    public int min = 15;
    public int sec = 0;
    
    private float interval;

    void Start()
    {
        for(int i = 0; i < slimeCount; i++)
        {
            float rx = Random.Range(-50, 51);
            float rz = Random.Range(-50, 51);
            GameObject s = Instantiate(slime);
            s.transform.position = new Vector3(rx, -0.5f, rz);
        }

        if (sec < 10)
        {
            timerTxt.text = min.ToString() + ":" + sec.ToString() + "0";
        }
        else
        {
            timerTxt.text = min.ToString() + ":" + sec.ToString();
        }

        interval = 1;
    }

    void Update()
    {
        progressTxt.text = "Population: " + slimeCount.ToString();
        if (slimeCount <= 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        interval -= Time.deltaTime;
        if(interval <= 0)
        {
            CountDown();
            if (sec == 0 && min == 0)
            {
                GameOver();
            }
            interval = 1;
        }

        if(pauseInput.action.triggered)
        {
            TogglePause();
        }
    }

    void CountDown()
    {
        if(sec == 0)
        {
            sec = 59;
            min--;
        }
        else
        {
            sec--;
        }

        if(sec < 10)
        {
            timerTxt.text = min.ToString() + ":" + sec.ToString() + "0";
        }
        else
        {
            timerTxt.text = min.ToString() + ":" + sec.ToString();
        }
    }

    public void TogglePause()
    {
        if (pauseMenu.IsActive())
        {
            pauseMenu.gameObject.SetActive(false);
        }
        else if(!pauseMenu.IsActive())
        {
            pauseMenu.gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}

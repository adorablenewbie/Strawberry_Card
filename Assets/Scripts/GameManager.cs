using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;

    AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;
    float time = 30f;

    public bool isGameOver = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1.0f; //Ω√¿€
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            time -= Time.deltaTime;
            timeTxt.text = time.ToString("N2");
            if (time <= 0)
            {
                time = 0;
                timeTxt.text = time.ToString("N2");
                isGameOver = true;
            }
        }
        else
        {
            Time.timeScale = 0.0f;
            endTxt.SetActive(true);
        }

    }

    public void Matched()
    {
        if(firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                Time.timeScale = 0.0f;
                endTxt.SetActive(true);
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        firstCard = null;
        secondCard = null;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Sounds
{
    public float helsPoint;
    public float maxHealsPoint;
    private Rigidbody2D rb;
    public Image healsImage;
    public AudioSource qAudio;
    

    private bool top;

    public GameObject PausePanel;

    public void PauseButtonPressed()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;

    }
    public void RestartButtonPresed()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void ChangeScene(int scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }
    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        helsPoint = maxHealsPoint;
    }
    private void Update()
    {
        healsImage.fillAmount = helsPoint / maxHealsPoint;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            qAudio.Play();
            rb.gravityScale *= -1;
            Rotation();
        }
        if (helsPoint <= 0)
        {
          
            PausePanel.SetActive(true);
            Time.timeScale = 0f;
        }

    }

    void Rotation()
    {
        if (top)
        {
            transform.eulerAngles = new Vector3(0, 180, 180);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
        top = !top;
    }



}

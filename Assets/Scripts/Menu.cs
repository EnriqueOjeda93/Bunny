using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject panelCredits;

    private float velTransition = 8000f;

    private bool credits = false;

    private Vector3 posPanelCredit;

    [SerializeField]
    private AudioClip S_ClickPocho;
    [SerializeField]
    private AudioClip S_Click;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        posPanelCredit = panelCredits.transform.position;
        Time.timeScale = 1;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (credits)
        {

            panelCredits.transform.position = Vector3.MoveTowards(panelCredits.transform.position, transform.position, Time.deltaTime * velTransition);

        }

        if (!credits)
        {

            panelCredits.transform.position = Vector3.MoveTowards(panelCredits.transform.position, posPanelCredit, Time.deltaTime * velTransition);

        }
    }

    public void Play()
    {
        
        audio.clip = S_Click;
        audio.Play();
        SceneManager.LoadScene("Map 2");

    }

    public void Settings()
    {

        audio.clip = S_ClickPocho;
        audio.Play();

    }

    public void Credits()
    {

        audio.clip = S_Click;
        audio.Play();
        credits = true;

    }

    public void Back()
    {

        audio.clip = S_Click;
        audio.Play();
        credits = false;

    }

    public void Exit()
    {

        audio.clip = S_Click;
        audio.Play();
        Application.Quit();

    }


}

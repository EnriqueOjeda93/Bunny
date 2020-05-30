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

    // Start is called before the first frame update
    void Start()
    {
        posPanelCredit = panelCredits.transform.position;
        Time.timeScale = 1;
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

        SceneManager.LoadScene("Map");

    }

    public void Credits()
    {

        credits = true;

    }

    public void Back()
    {

        credits = false;

    }

    public void Exit()
    {

        Application.Quit();

    }


}

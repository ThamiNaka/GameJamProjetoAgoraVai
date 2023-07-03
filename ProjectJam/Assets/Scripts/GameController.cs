using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOver;
    public GameObject portalLevel;

    public int totalMineral;
    public Text mineralText;

    /*
    public GameObject mineral1;
    public GameObject mineral2;
    public GameObject mineral3;
    public GameObject mineral4;
    public GameObject mineral5;
    */

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        //UpdateMineral();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);

    }

    
    public void UpdateMineralText()
    {
        mineralText.text = totalMineral.ToString();
    }




    public void Portal()
    {
        UpdateMineral();
        if (totalMineral > 4)
        {
            portalLevel.SetActive(true);
        }
    }
   /*
    
    public void UpdateMineral()
    {
        if (totalMineral > 0)
        {
            mineral1.SetActive(true);
        }
        else
        {
            mineral1.SetActive(false);
        }
        if (totalMineral > 1)
        {
            mineral2.SetActive(true);
        }
        else
        {
            mineral2.SetActive(false);
        }
        if (totalMineral > 2)
        {
            mineral3.SetActive(true);
        }
        else
        {
            mineral3.SetActive(false);
        }if (totalMineral > 3)
        {
            mineral4.SetActive(true);
        }
        else
        {
            mineral4.SetActive(false);
        }if (totalMineral > 4)
        {
            mineral5.SetActive(true);
        }
        else
        {
            mineral5.SetActive(false);
        }
        PlayerPrefs.SetInt("totalMineral", totalMineral);
    }

*/
}

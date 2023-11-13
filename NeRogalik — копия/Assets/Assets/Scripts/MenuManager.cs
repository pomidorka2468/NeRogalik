using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject InGameUIWindow;
    [SerializeField] private GameObject DeathWindow;
    [SerializeField] private GameObject GameOnPauseWindow;
    [SerializeField] private GameObject HelpWindow;
    [SerializeField] private GameObject AuthorWindow;
    [SerializeField] public GameObject HalfShield;
    [SerializeField] public GameObject FullShield;

    [SerializeField] public Image fullShieldImage;

    [Header("Texts")]
    [SerializeField] private Text hpText;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text keysText;

    [Header("Scripts")]
    [SerializeField] private PlayerScript ps;
    [HideInInspector] private GunScript gs;
    
    public void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        gs = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunScript>();
    }

    public void OpenWindow(string windowName)
    {
        switch (windowName)
        {
            case "inGameUI":
            CloseWindow();
            InGameUIWindow.SetActive(true);
            break;

            case "deathWindow":
            CloseWindow();
            DeathWindow.SetActive(true);
            break;            

            case "gameOnPauseWindow":
            CloseWindow();
            GameOnPauseWindow.SetActive(true);
            break;

            case "helpWindow":
            CloseWindow();
            HelpWindow.SetActive(true);
            break;

            case "authorWindow":
            CloseWindow();
            AuthorWindow.SetActive(true);
            break;

            default:
            break;
        }
    }

    public void CloseWindow()
    {
        GameOnPauseWindow.SetActive(false);
        InGameUIWindow.SetActive(false);
        HelpWindow.SetActive(false);
        AuthorWindow.SetActive(false);
        DeathWindow.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Update()
    {
        hpText.text = "HP: " + ps.health;
        keysText.text = "X" + ps.keys;
        coinsText.text = "" + ps.coins;
        //ammoText.text = "Ammo: " + gs.curAmmo;

        /*if (Normal gun is active)
        {
            gs = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunScript>();
        }
        else
        {
            gs = GameObject.FindGameObjectWithTag("fastGun").GetComponent<GunScript>();
        }*/
    }

    public void Continue()
    {
        CloseWindow();
        OpenWindow("");
        Time.timeScale = 1f;
    }

    public void NewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}


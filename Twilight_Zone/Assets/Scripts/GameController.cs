using UnityEngine;
using  UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard,
        GodLike
        
    };

    public DifficultyLevel Difficulty = DifficultyLevel.Easy;

    public bool IsMenuDisplayed = false;

    public bool IsLaunchingGame = false;

    public bool IsShopping = false;

    public bool PlayerWon = false;

    public bool PlayerDied = false;

    public GameObject Menu;

    public GameObject Shop;

    private EnemyController enemyController;

    private crowdManager crowdController;

    private Player_Behaviour player;

    private GameObject startButton;

    private GameObject resumeButton;

    private GameObject difficultySelector;

    public GameObject UICanvas;

    public void StartGame()
    {
        Debug.Log("plop");
        difficultySelector.SetActive(true);
        startButton.SetActive(false);
        resumeButton.SetActive(true);
        
    }

    public void ResumeGame()
    {
        IsLaunchingGame = true;
    }

    public void SetEasy()
    {
        Difficulty = DifficultyLevel.Easy;

        difficultySelector.SetActive(false);
        IsLaunchingGame = true;
        UICanvas.SetActive(true);
    }

    public void SetMedium()
    {
        Difficulty = DifficultyLevel.Medium;

        difficultySelector.SetActive(false);
        IsLaunchingGame = true;
        UICanvas.SetActive(true);
    }

    public void SetHard()
    {
        Difficulty = DifficultyLevel.Hard;

        difficultySelector.SetActive(false);
        IsLaunchingGame = true;
        UICanvas.SetActive(true);
    }

    public void SetGodLike()
    {
        Difficulty = DifficultyLevel.GodLike;

        difficultySelector.SetActive(false);
        IsLaunchingGame = true;
        UICanvas.SetActive(true);
    }

    private void Start() {
        
    }

    private void Awake() {
        enemyController = GameObject.FindWithTag("EnemyController").GetComponent<EnemyController>();
        crowdController = GameObject.FindWithTag("CrowdController").GetComponent<crowdManager>();
        player = GameObject.FindWithTag("Player").GetComponent<Player_Behaviour>();

        startButton = GameObject.Find("Start");
        resumeButton = GameObject.Find("Resume");
        difficultySelector = GameObject.Find("DifficultySelector");

        resumeButton.SetActive(false);
        difficultySelector.SetActive(false);

    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsMenuDisplayed = !IsMenuDisplayed;
            IsLaunchingGame = !IsMenuDisplayed;
        }
        
        if(IsMenuDisplayed || IsShopping)
        {
            enemyController.ActivateEnnemies(false);
            enemyController.gameObject.SetActive(false);
            crowdController.gameObject.SetActive(false);
            player.gameObject.SetActive(false);
        }
        
        if(IsLaunchingGame)
        {
            enemyController.ActivateEnnemies(true);
            enemyController.gameObject.SetActive(true);
            crowdController.gameObject.SetActive(true);
            player.gameObject.SetActive(true);

            changeDifficulty();

            IsLaunchingGame = false;
            IsMenuDisplayed = false;
            Debug.Log("pouet");
        }

        Menu.SetActive(IsMenuDisplayed);
        Shop.SetActive(IsShopping);

        PlayerDied = player.hp <= 0;
        PlayerWon = enemyController.HasNoMoreWaves;

        if(PlayerDied)
        {
            SceneManager.LoadScene("DeathScene");
        }
        else if(PlayerWon)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    private void changeDifficulty()
    {
        switch(Difficulty)
        {
            case DifficultyLevel.GodLike:
            enemyController.MaxSpawRate = 1;
            enemyController.MaxNbWaves = 15;
            enemyController.MaxNbEnemies = 250;
            enemyController.MaximalHealth = 150;
            break;

            case DifficultyLevel.Hard:
            enemyController.MaxSpawRate = 2;
            enemyController.MaxNbWaves = 10;
            enemyController.MaxNbEnemies = 15;
            enemyController.MaximalHealth = 200;
            break;
            
            case DifficultyLevel.Medium:
            enemyController.MaxSpawRate = 1;
            enemyController.MaxNbWaves = 8;
            enemyController.MaxNbEnemies = 12;  
            enemyController.MaximalHealth = 150;
            break;

            case DifficultyLevel.Easy:
            default:
            enemyController.MaxSpawRate = 1;
            enemyController.MaxNbWaves = 5;
            enemyController.MaxNbEnemies = 10;
            enemyController.MaximalHealth = 150;
            break;
        }

        enemyController.InitWaves();
    }
}
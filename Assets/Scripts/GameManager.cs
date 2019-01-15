using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject player, heartOne, heartTwo, heartThree, textBox, deathScreen, winScreen;
    public GameObject enemyOne, enemyTwo, enemyThree, enemyFour, enemyFive, enemySix, enemySeven, enemyEight, enemyNine, enemyTen, enemyEleven, enemyTwelve, enemyThirteen,
        enemyFourteen, enemyFifteen, enemySixteen, enemySeventeen, enemyEighteen, enemyNineteen, enemyTwenty, enemyTwentyone, enemyTwentytwo, enemyTwentythree,
        enemyTwentyfour, enemyTwentyfive, enemyTwentysix, enemyTwentyseven, enemyTwentyeight, enemyTwentynine, enemyThirty, enemyThirtyone, enemyThirtytwo, enemyThirtythree;
    public int livesLeft, currentLine;
    public string[] dialogue;
    public Text theText;
    public TextAsset textfile;
    public bool ringCollide = false, timerStart = false;
    private int enemyNum;
    private bool constrict = false, allClear = false, clearOne = false, clearTwo = false;
    private Sprite initial;
    public float time, elapsedTime;
    private GameObject instructionImage;

    void Start () {     //This method executes once game has started.
        livesLeft = 3;
        initial = player.GetComponent<SpriteRenderer>().sprite;
        instructionImage = GameObject.Find("InstructionImage");
        instructionImage.SetActive(true);
        if (textfile != null)
            dialogue = (textfile.text.Split('\n'));
    }

    void Update () {    // This method executes once every frame.
        OpeningImage();
        DialogueOne(3);
        if (timerStart == false)
            elapsedTime = Time.time;

        if (player.transform.position.x >= 29.75 && enemyThree != null)
        {
            StopMovement();
            if (currentLine <= 4)
                DialogueTwo(5);
            if (textBox.activeSelf == false)
                LevelOne();
        }
        if (enemyThree == null && clearOne == false)
        {
            if (currentLine <= 5)
                DialogueTwo(6);
            if (textBox.activeSelf == false)
            {
                player.GetComponent<PlayerMovement>().enabled = true;
                timerStart = false;
                clearOne = true;
            }
        }
        if (player.transform.position.x >= 47.25 && enemyThirteen != null)
        {
            StopMovement();
            if (currentLine <= 8)
                DialogueTwo(9);
            if (textBox.activeSelf == false)
                LevelTwo();
        }
        if (enemyThirteen == null && enemyTwelve == null && clearTwo == false)
        {
            if (currentLine <= 9)
                DialogueTwo(10);
            if (textBox.activeSelf == false)
                player.GetComponent<PlayerMovement>().enabled = true;
                timerStart = false;
                clearTwo = true;
        }
        if (player.transform.position.x >= 65 && enemyThirtythree != null)
        {
            StopMovement();
            if (currentLine <= 11)
                DialogueTwo(12);
            if (textBox.activeSelf == false)
                LevelThree();
        }
        if (enemyThirtythree == null && enemyThirtytwo == null && enemyThirtyone == null && enemyThirty == null)
        {
            if (currentLine <= 13)
                DialogueTwo(14);
            if (textBox.activeSelf == false)
                player.GetComponent<PlayerMovement>().enabled = true;
                timerStart = false;
        }
        if (player.transform.position.x >= 82.75 && allClear == false)
        {
            StopMovement();
            if (currentLine <= 15)
                DialogueTwo(16);
            if (textBox.activeSelf == false)
                player.GetComponent<PlayerMovement>().enabled = true;
                allClear = true;
        }
        switch (livesLeft)
        {
            case 0:
                Destroy(heartOne);
                StopMovement();
                deathScreen.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Z))
                    Application.Quit();
                break;
            case 1:
                if (heartTwo != null)
                    Destroy(heartTwo);
                break;
            case 2:
                if (heartThree != null)
                    Destroy(heartThree);
                break;
            default:
                break;
        }
        if (ringCollide == true)
        {
            StopMovement();
            winScreen.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Z))
                Application.Quit();
        }
    }

    void OpeningImage() //This method displays the instruction screen and allows the player to proceed after 2 seconds from the start of the game.
    {
        if (instructionImage.activeSelf)
        {
            StopMovement();
            if (Input.GetKeyDown(KeyCode.Z) && Time.time > 2f)
            {
                instructionImage.SetActive(false);
                textBox.SetActive(true);
            }
        }
    }

    void DialogueOne(int endLine) //This method handles the first instance of dialogue before the game begins.
    {
        if (textBox.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && currentLine == endLine - 1)
            {
                currentLine++;
                textBox.SetActive(false);
                player.GetComponent<PlayerMovement>().enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && currentLine <= endLine - 1)
            {
                currentLine++;
            }
            theText.text = dialogue[currentLine];
        }
    }

    void DialogueTwo(int endLineTwo) //This method handles all remaining dialogue throughout the game.
    {
        textBox.SetActive(true);
        if (Input.GetKeyDown(KeyCode.DownArrow) && currentLine == endLineTwo - 1)
        {
            currentLine++;
            textBox.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && currentLine <= endLineTwo)
        {
            currentLine++;
        }
        theText.text = dialogue[currentLine];
    }

    void StopMovement() //This method prevents the player from moving around in the map.
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        if (constrict == false)
        {
            player.GetComponent<SpriteRenderer>().sprite = initial;
            constrict = true;
        }
    }

    void LevelOne() //This method handles all events in Level 1 including enemy generation, enemy elimination and enemy collision.
    {
        time = Time.time - elapsedTime;
        timerStart = true;
        if (time >= 1 && enemyNum == 0)
        {
            enemyOne.GetComponent<CreateEnemyOne>().enabled = true;
            enemyNum++;
        }
        else if (time >= 4 && enemyNum == 1)
        {
            enemyTwo.GetComponent<CreateEnemyOne>().enabled = true;
            enemyNum++;
        }
        else if (time >= 7 && enemyNum == 2)
        {
            enemyThree.GetComponent<CreateEnemyOne>().enabled = true;
            enemyNum++;
        }
    }

    void LevelTwo() //This method handles all events in Level 2 including enemy generation, enemy elimination and enemy collision.
    {
        time = Time.time - elapsedTime;
        timerStart = true;
        if (time >= 1 && enemyNum == 3)
        {
            enemyFour.GetComponent<CreateEnemyTwo>().enabled = true;
            enemyFive.GetComponent<CreateEnemyTwo>().enabled = true;
            enemyNum++;
        }
        else if (time >= 4 && enemyNum == 4)
        {
            enemySix.GetComponent<CreateEnemyTwo>().enabled = true;
            enemySeven.GetComponent<CreateEnemyTwo>().enabled = true;
            enemyNum++;
        }
        else if (time >= 7 && enemyNum == 5)
        {
            enemyEight.GetComponent<CreateEnemyTwo>().enabled = true;
            enemyNine.GetComponent<CreateEnemyTwo>().enabled = true;
            enemyNum++;
        }
        else if (time >= 10 && enemyNum == 6)
        {
            enemyTen.GetComponent<CreateEnemyTwo>().enabled = true;
            enemyEleven.GetComponent<CreateEnemyTwo>().enabled = true;
            enemyNum++;
        }
        else if (time >= 13 && enemyNum == 7)
        {
            enemyTwelve.GetComponent<CreateEnemyTwo>().enabled = true;
            enemyThirteen.GetComponent<CreateEnemyTwo>().enabled = true;
            enemyNum++;
        }
    }

    void LevelThree() //This method handles all events in Level 3 including enemy generation, enemy elimination and enemy collision.
    {
        time = Time.time - elapsedTime;
        timerStart = true;
        if (time >= 1 && enemyNum == 8)
        {
            enemyFourteen.GetComponent<CreateEnemyThree>().enabled = true;
            enemyFifteen.GetComponent<CreateEnemyThree>().enabled = true;
            enemySixteen.GetComponent<CreateEnemyThree>().enabled = true;
            enemySeventeen.GetComponent<CreateEnemyThree>().enabled = true;
            enemyNum++;
        }
        else if (time >= 4 && enemyNum == 9)
        {
            enemyEighteen.GetComponent<CreateEnemyThree>().enabled = true;
            enemyNineteen.GetComponent<CreateEnemyThree>().enabled = true;
            enemyTwenty.GetComponent<CreateEnemyThree>().enabled = true;
            enemyTwentyone.GetComponent<CreateEnemyThree>().enabled = true;
            enemyNum++;
        }
        else if (time >= 7 && enemyNum == 10)
        {
            enemyTwentytwo.GetComponent<CreateEnemyThree>().enabled = true;
            enemyTwentythree.GetComponent<CreateEnemyThree>().enabled = true;
            enemyTwentyfour.GetComponent<CreateEnemyThree>().enabled = true;
            enemyTwentyfive.GetComponent<CreateEnemyThree>().enabled = true;
            enemyNum++;
        }
        else if (time >= 10 && enemyNum == 11)
        {
            enemyTwentysix.GetComponent<CreateEnemyThree>().enabled = true;
            enemyTwentyseven.GetComponent<CreateEnemyThree>().enabled = true;
            enemyTwentyeight.GetComponent<CreateEnemyThree>().enabled = true;
            enemyTwentynine.GetComponent<CreateEnemyThree>().enabled = true;
            enemyNum++;
        }
        else if (time >= 13 && enemyNum == 12)
        {
            enemyThirty.GetComponent<CreateEnemyThree>().enabled = true;
            enemyThirtyone.GetComponent<CreateEnemyThree>().enabled = true;
            enemyThirtytwo.GetComponent<CreateEnemyThree>().enabled = true;
            enemyThirtythree.GetComponent<CreateEnemyThree>().enabled = true;
            enemyNum++;
        }
    }
}
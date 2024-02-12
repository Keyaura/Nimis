using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathscript : MonoBehaviour
{
    public PlayerEat _playerEatScript;
    public TMP_Text killcount;
    public TMP_Text survivaltime;
    public playertimer _playerTimerScript;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerEatScript = UnityEngine.Object.FindFirstObjectByType<PlayerEat>();
        _playerTimerScript = UnityEngine.Object.FindFirstObjectByType<playertimer>();

    }
    private void Start()
    {
        killcount.SetText($"{_playerEatScript.legitkills}");
        survivaltime.SetText($"{_playerTimerScript.currentTime}");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
}

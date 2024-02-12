using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertimer : MonoBehaviour
{
    [SerializeField] private bool timerActive;
    public float currentTime;
    public PlayerMovement _playerMovementScript;
    // Start is called before the first frame update
    private void Awake()
    {
        _playerMovementScript = UnityEngine.Object.FindFirstObjectByType<PlayerMovement>();
    }
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMovementScript.playerhealth > 0)
        {
            currentTime += Time.deltaTime;
        }
    }
}

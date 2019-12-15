using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float playerHealth;

    public float GetPlayerHealthAmount ()
    {
        return playerHealth;
    }
    
    void Start()
    {
        playerHealth = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            playerHealth -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            playerHealth += 0.1f;
        }

        playerHealth = Mathf.Clamp(playerHealth, 0f, 1f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverChecker : MonoBehaviour
{

    [SerializeField] licourBox[] boxes;
    int hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (countHp() <= 0)
        {
            // Play GameOver sound!
            Invoke("loadEndScene", 2f);
        }
    }

    void loadEndScene()
    {
        SceneManager.LoadScene("end");
    }

    int countHp()
    {
        hp = 0;
        foreach (licourBox l in boxes)
        {
            if (l != null)
            {
                hp += l.hp;
            }
        }
        return hp;
    }
}

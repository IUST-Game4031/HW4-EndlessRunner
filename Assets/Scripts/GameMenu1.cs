using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    //public GameObject T;
    public GameObject I;
    public GameObject[] B;
    public Animator animator;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("Menu") == true)
        {
            I.SetActive(true);
            B[0].SetActive(true);
            B[1].SetActive(true);
            B[2].SetActive(true);
            count = 1;
        }
        else if (animator.GetBool("Menu") == false)
        {
            I.SetActive(false);
            B[0].SetActive(false);
            B[1].SetActive(false);
            B[2].SetActive(false);
            count = 0;
        }
    }
    void FixedUpdate()
    {

    }
    public void Reset()
    {
        PL.Player.BS = false;
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        PL.Player.BS = false;
        SceneManager.LoadScene("Menu");
    }
}

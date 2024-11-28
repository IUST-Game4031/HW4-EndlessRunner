using UnityEngine;
using UnityEngine.SceneManagement;

namespace FMen
{
    public class FirstMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
        public void ExitGame()
        {
            Application.Quit();
        }
        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}

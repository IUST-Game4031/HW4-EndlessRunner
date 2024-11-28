using UnityEngine;
using UnityEngine.SceneManagement;

namespace PL
{
    public class Player : MonoBehaviour
    {
        public static bool BS = false;
        public Animator animator;
        public BoxCollider bx;
        private int counter = 0;
        private bool menu;
        int lefttime = 0;
        int righttime = 0;
        int extrajumptime = 0;
        int loc = 0;
        int fallLR = 0;
        int forceflag = 0;
        int camforce1 = 0;
        int camforce2 = 0;
        int resetcounter = 0;
        float jumpflag = -1;
        bool flagwall = false;
        bool menuflag = false;
        public static bool ext = false, rest = false;
        public void Resume()
        {
            if (menu == false)
            {
                animator.SetBool("Run", false);
                animator.SetBool("Menu", true);
            }
            else if (menuflag == false)
            {
                animator.SetBool("Menu", false);
            }
            else
            {
                if (animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
                {
                    animator.SetBool("Run", true);
                }
                animator.SetBool("Menu", false);
            }
        }
        static void Reset()
        {
            SceneManager.LoadScene("Game");
        }
        // Start is called before the first frame update
        void Start()
        {
        }
        // Update is called once per frame
        void Update()
        {
            if ((loc > 1 || loc < -1) && flagwall == false)
            {
                flagwall = true;
                camforce2 = 25;
                animator.SetBool("Fall3", true);
            }
            menu = animator.GetBool("Menu");
            if (Input.GetKeyDown(KeyCode.A) && lefttime == 0 && menu == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                loc++;
                lefttime = 15 - righttime;
                righttime = 0;
            }
            if (Input.GetKeyDown(KeyCode.D) && righttime == 0 && menu == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                loc--;
                righttime = 15 - lefttime;
                lefttime = 0;
            }
            if (((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && menu == false && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
                && animator.GetBool("Run") == false)
            {
                animator.SetBool("Run", true);
                menuflag = true;
                extrajumptime = 22 + ((int)(Mathf.Sqrt(Time.deltaTime) * 25));
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menu == false)
                {
                    animator.SetBool("Run", false);
                    animator.SetBool("Menu", true);
                }
                else if (menuflag == false)
                {
                    animator.SetBool("Menu", false);
                }
                else
                {
                    if (animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
                    {
                        animator.SetBool("Run", true);
                    }
                    animator.SetBool("Menu", false);
                }
            }
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.tag == "BART1" && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                forceflag = 15;
                if (extrajumptime > 0)
                {
                    jumpflag = 0.6f;
                }
                else
                {
                    jumpflag = -1;
                }
                animator.SetBool("Fall1", true);
                animator.SetBool("Run", false);
            }
            if (collider.gameObject.tag == "BART2" && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                camforce1 = 20;
                animator.SetBool("Fall2", true);
                animator.SetBool("Run", false);

            }
            if (((collider.gameObject.tag == "BART3") || (collider.gameObject.tag == "BART4")) && animator.GetBool("Fall1") == false && animator.GetBool("Fall2") == false && animator.GetBool("Fall3") == false && animator.GetBool("Fall4") == false)
            {
                camforce2 = 25;
                animator.SetBool("Fall3", true);
                animator.SetBool("Run", false);
            }
        }
        void FixedUpdate()
        {
            if (menu == false)
            {
                if (animator.GetBool("Fall1") == true || animator.GetBool("Fall2") == true || animator.GetBool("Fall3") == true || animator.GetBool("Fall4") == true)
                {
                    resetcounter++;
                }
                if (resetcounter == 150)
                {
                    Reset();
                }
                counter++;
                if (forceflag > 0)
                {
                    forceflag--;
                    this.transform.Translate(0f, 0f, 0.3f * jumpflag);
                }
                if (camforce1 > 0)
                {
                    camforce1--;
                    GameObject.Find("Main Camera").transform.Translate(0.0025f, -0.06375f, -0.25f);
                }
                if (camforce2 > 0)
                {
                    camforce2--;
                    GameObject.Find("Main Camera").transform.Translate(0.002f, 0.051f, 0.2f);
                }
                if (lefttime > 0 && (fallLR == 0 || fallLR == 1))
                {
                    if (animator.GetBool("Fall3") == true && lefttime > 10)
                    {
                        transform.Translate(-0.20466f, 0, 0);
                        lefttime--;
                    }
                    else if (animator.GetBool("Fall3") == true)
                    {
                        fallLR += 2;
                        animator.SetBool("Run", false);
                        righttime = 15;
                    }
                    else if (animator.GetBool("Run") == true)
                    {
                        transform.Translate(-0.20466f, 0, 0);
                        lefttime--;
                    }
                }
                if (righttime > 0 && (fallLR == 0 || fallLR == 2))
                {
                    if (animator.GetBool("Fall3") == true && righttime > 10)
                    {
                        transform.Translate(0.20466f, 0, 0);
                        righttime--;
                    }
                    else if (animator.GetBool("Fall3") == true)
                    {
                        fallLR += 1;
                        animator.SetBool("Run", false);
                        lefttime = 15;
                    }
                    else if (animator.GetBool("Run") == true)
                    {
                        transform.Translate(0.20466f, 0, 0);
                        righttime--;
                    }
                }
            }
        }
    }
}

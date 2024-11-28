using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class Score : MonoBehaviour
{
    public static void SetFileReadAccess(string FileName, bool SetReadOnly)
    {
        // Create a new FileInfo object.
        FileInfo fInfo = new FileInfo(FileName);

        // Set the IsReadOnly property.
        fInfo.IsReadOnly = SetReadOnly;
    }
    private int score;
    public Animator animator;
    public Text  T;
    private int highscore;
    public string Name;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (File.Exists(@"HighScore.json"))
        {
            highscore = int.Parse(File.ReadAllText(@"HighScore.json"));
        }
        else 
        {
            highscore = 0;
            File.WriteAllText(@"HighScore.json", "0");
            SetFileReadAccess(@"HighScore.json", true);
        };
        if (score > highscore)
        {

            SetFileReadAccess(@"HighScore.json", false);
            File.WriteAllText(@"HighScore.json", score.ToString());
            SetFileReadAccess(@"HighScore.json", true);
        }
        if (Name == "Score : ")
        {
            T.text = Name + score;
        }
        else if (Name == "High Score : ")
        {
            T.text = Name + highscore;
        }
    }
    void FixedUpdate()
    {
        if (score % 1000 == 0 && animator.GetBool("Run") == true && Time.timeScale <= 2.5f)
        {
            Time.timeScale += 0.005f;
        }
        if (animator.GetBool("Run") == true)
        {
            score++;
        }
    }
}

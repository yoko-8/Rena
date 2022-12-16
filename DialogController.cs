using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogController : MonoBehaviour
{
    public TextMeshPro textbox;
    public SpriteRenderer rena;
    public SpriteRenderer erin;
    public SpriteRenderer stella;
    public SpriteRenderer progressStar;

    private class Dialog
    {
        private readonly string name;
        private readonly string text;

        public string Name { get { return name; } }
        public string Text { get { return text; } }
        public Dialog(string name, string text)
        {
            this.name = name;
            this.text = text;
        }
    }
    private readonly Dialog[] scene3 = new Dialog[]
    {
        new Dialog("rena", "Almost done… settling all this paperwork for clients in group 4A… and then there’s 5A, and 6A…"),
        new Dialog("rena", "*sighs*"),
        new Dialog("rena", "At this rate, I’ll never be done…"),
        new Dialog("rena", "Is this all my life is? Just endless paperwork?"),
        new Dialog("action", "A soft jingle plays. A star appears before Rena."),
        new Dialog("stella", "... Rena? Are you ok?"),
        new Dialog("rena", "... I’ve been working too much overtime, I must be hearing things-"),
        new Dialog("stella", "No, you’re not! I’m right here! Rena? Earth to Rena!"),
        new Dialog("action", "Rena sees Stella, a glowing, floating star."),
        new Dialog("rena", "... oh my, who are you?"),
        new Dialog("stella", "Don’t be shocked, it’s me! Consider me the Spirit of Art Past! And I’ve brought something just for you."),
        new Dialog("stella", "It’s a scrapbook of all your memories! I’ve filled it with the essence of your past and present, hopes and dreams. Let’s take a look together!")
    };
    private readonly Dialog[] scene7 = new Dialog[]
    {
        new Dialog("rena", "That was a lot of fun. I don’t think I’ve done anything artistic like that in a long time."),
        new Dialog("stella", "That's great!"),
        new Dialog("rena", "... If only I could share my art with someone…"),
        new Dialog("stella", "What about your friends? I know one of your music-loving friends really misses you!"),
        new Dialog("action", "Stella whistles a tune."),
        new Dialog("rena", "Friends? I’m too busy for friends now, unfortunately-"),
        new Dialog("action", "Stella whistles the tune again."),
        new Dialog("rena", "... Erin?"),
        new Dialog("stella", "Yeah, your childhood friend, Erin!"),
        new Dialog("action", "Rena starts typing on her laptop. She finds Erin on social media."),
        new Dialog("rena", "Wow, Erin pursued music for her career after all! I’ll have to connect with her!")
    };
    private readonly Dialog[] scene11 = new Dialog[]
    {
        new Dialog("erin", "Wow Rena! You’re still just as amazing at art as you were when we were kids!"),
        new Dialog("rena", "Thanks Erin. I’m so glad I was able to return to making art!"),
        new Dialog("stella", "* Looks like my work here is done! Rena has found her passion for art again! *")
    };

    private int line = 0;
    private Dialog[] currentScene;
    private bool printing = false;
    private void Start()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                currentScene = scene3;
                break;
            case 6:
                currentScene = scene7;
                break;
            default:
            case 10:
                currentScene = scene11;
                break;
        }

        StartCoroutine(PrintLine(currentScene[line]));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (printing)
            {
                StopAllCoroutines();
                textbox.text = currentScene[line].Text;
                progressStar.color = Color.white;
                printing = false;
            } else
            {
                if (++line == currentScene.Length)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                } else
                {
                    StartCoroutine(PrintLine(currentScene[line]));
                }
            }
        }
    }

    private IEnumerator PrintLine(Dialog line)
    {
        textbox.text = "";
        progressStar.color = Color.clear;

        if (line.Name == "rena")
        {
            rena.color = Color.white;
            stella.color = Color.clear;
            erin.color = Color.clear;
        } else if (line.Name == "stella")
        {
            stella.color = Color.white;
            rena.color = Color.clear;
            erin.color = Color.clear;
        } else if (line.Name == "erin")
        {
            erin.color = Color.white;
            rena.color = Color.clear;
            stella.color = Color.clear;
        } else
        {
            rena.color = Color.clear;
            stella.color = Color.clear;
            erin.color = Color.clear;
        }
        
        textbox.color = line.Name == "action" ? new Color(.8f, .8f, .8f, 1) : Color.white;

        printing = true;
        foreach (char i in line.Text)
        {
            textbox.text += i;
            yield return new WaitForSeconds(0.05f);
        }
        progressStar.color = Color.white;
        printing = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Sprite[] cardFace;

    public Sprite cardBack;

    public GameObject[] cards;

    public Text matchText;

    private bool _init = false;
    private int _mathces = 0;


    // Update is called once per frame
    void Update()
    {
        if (!_init)
            initializeCards();
        if (Input.GetMouseButtonUp(0))
            checkCards();

    }

    void initializeCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 1; i < 14; i++)
            {
                bool test = false;
                int choise = 0;
                while (!test)
                {
                    choise = Random.Range(0, cards.Length);
                    test = !(cards[choise].GetComponent<Card>().initialized);
                }

                cards[choise].GetComponent<Card>().cardValue = i;
                cards[choise].GetComponent<Card>().initialized = true;
            }
        }

        foreach (GameObject c in cards)

            c.GetComponent<Card>().setuprGraphics();
        if (!_init)
            _init = true;
    }
    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFace[i-1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state==1)
                c.Add(i);
        }

        if (c.Count == 2)
            cardComparison(c);
    }

    void cardComparison(List<int> c)
    {
        Card.DO_NOT = true;
        int x = 0;
        if (cards[c[0]].GetComponent<Card>().cardValue == cards[c[1]].GetComponent<Card>().cardValue)
        {
            x = 2;
            _mathces++;
            matchText.text = "Points: " + _mathces;
            if (_mathces == 0)
            {
                SceneManager.LoadScene("MenuSceene");
            }
        }
            for (int i=0; i< c.Count; i++)
                {
                    cards[c[i]].GetComponent<Card>().state = x;
                    cards[c[i]].GetComponent<Card>().falseCheck();
                }
    }
}





    


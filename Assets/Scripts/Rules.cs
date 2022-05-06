using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    public int betCoins;
    private float coinSpawnOffsetX = -4f;
    private float coinSpawnOffsetY = 5.25f;
    private GameObject[] allCards;

    public GameObject draw;
    public GameObject hold;
    public GameObject coin;

    void Start()
    {
        allCards = GameObject.FindGameObjectsWithTag("Card");
        draw = GameObject.FindGameObjectWithTag("Draw");
        hold = GameObject.FindGameObjectWithTag("Hold");
        NewRound();
    }

    void NewRound()
    {
        //finds player's coins
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        int playerCoins = player.GetComponent<Player>().playerCoins;

        //setting the betting coins
        if (betCoins == 0 && playerCoins != 0)
        {
            //minimum one betting coin
            Player sn = player.GetComponent<Player>();
            sn.NewPlayerCoins(-1);
            betCoins += 1;

            //visual coin and button
            Instantiate(coin, new Vector2(coinSpawnOffsetX, coinSpawnOffsetY), Quaternion.identity);
            hold.transform.position = new Vector3(4, -1.64f, 0);
        }
        else if (betCoins == 0 && playerCoins == 0)
        {
            ExtraFreshStart();
        }
    }

    void Update()
    {
        int counter = 0;

        for (int i = 0; i < allCards.Length; i++)
        {
            //checks for see if any cards are selected
            bool b = allCards[i].GetComponent<Cards>().selectedCard;
            if (b)
            {
                counter++;
            }
        }

        //if any cards are selected
        if (counter != 0)
        {
            hold.transform.position = new Vector3(14.45f, -1.64f, 0);
            draw.transform.position = new Vector3(4, -1.64f, 0);
        }
        else
        {
            hold.transform.position = new Vector3(4, -1.64f, 0);
            draw.transform.position = new Vector3(14.45f, -1.64f, 0);
        }
        counter = 0;
    }

    public void ComputerAightBet()
    {
        //bye bye buttons
        //computer changes cards (check scoring and other cards get changed)
        //call scoring
        //cards are shown
    }

    public GameObject RandomCard()
    {
        //finds a random card
        int index = Random.Range(0, allCards.Length);
        GameObject randomCard = allCards[index];
        GameObject test = TestingRandomCard(randomCard);
        return test;
    }

    public GameObject TestingRandomCard(GameObject t)
    {
        bool testingCard = t.GetComponent<Cards>().takenCard;
        if (testingCard)
        {
            //loop time
            GameObject rerun = RandomCard();
            return rerun;
        }
        else
        {
            //sets randomCard as taken before sending back
            GameObject rc = t;
            Cards sn = rc.GetComponent<Cards>();
            sn.SetCardTaken();
            return t;
        }
    }

    public void SetBetCoins(int bc)
    {
        betCoins += bc;
    }

    void FinalScoringTime()
    {
        ///if player's handValue > computer's handValue
        ///check handValue and multiply betCoins
        ///give betCoins to playerCoins
        ///call method fresh start

        ///if player's handValue < computer's handValue
        ///betCoins = zero
        ///call method fresh start

        ///if player's handValue = computer's handValue
        ///playerCoins += betCoins
        ///call method fresh start
    }

    void HighestCard()
    {
        ///check value of all givenCards
        ///pick highest one
    }

    void FreshStart()
    {
        ///givenCards are null
        ///cardTaken = false
        ///call first cards method
        ///if playerCoins && betCoins = 0, call extra fresh start
    }

    void ExtraFreshStart()
    {
        ///gameover menu with restart button
        ///everything is gone and back to the VERY beginning
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsArticle
{
    string message;
    int score;

    public NewsArticle(string message, int score)
    {
        this.message = message;
        this.score = score;
    }

    public string getMessage()
    {
        return message;
    }

    public int getScore()
    {
        return score;
    }
}

public class Score
{
    int score;
    string message;

    public Score(int score, string message)
    {
        this.score = score;
        this.message = message;
    }

    public int getScore()
    {
        return score;
    }

    public string getMessage()
    {
        return message;
    }
}

public class newsGen : MonoBehaviour
{
    public Dictionary<int, string> Companies()
    {
        Dictionary<int, string> companies = new Dictionary<int, string>();
        companies.Add(1, "Peach");
        companies.Add(2, "Bean Corp");
        companies.Add(3, "Crying Inc");
        companies.Add(4, "Zoinkies");
        companies.Add(5, "COOKSQUFF");
        companies.Add(6, "funBorn");
        companies.Add(7, "fatcha");
        return companies;
    }

    public Dictionary<int, Score> Actions()
    {
        Dictionary<int, Score> act_dict = new Dictionary<int, Score>();

        List<Score> scores()
        {
            List<Score> actionsList = new List<Score>();
            actionsList.Add(new Score(-1, "boss eats"));
            actionsList.Add(new Score(-8, "pays"));
            actionsList.Add(new Score(-5, "fires"));
            actionsList.Add(new Score(-2, "pays off"));
            actionsList.Add(new Score(4, "donates"));
            actionsList.Add(new Score(-3, "steals"));
            actionsList.Add(new Score(7, "eliminates"));
            actionsList.Add(new Score(5, "openes"));
            actionsList.Add(new Score(-2, "closes"));
            actionsList.Add(new Score(6, "overthrows"));
            actionsList.Add(new Score(4, "develops"));
            actionsList.Add(new Score(1, "releases"));
            actionsList.Add(new Score(3, "murders"));
            actionsList.Add(new Score(-4, "opress"));
            actionsList.Add(new Score(5, "Bazingas"));
            return actionsList;
        }

        List<Score> actions = scores();
        int id = 1;
        foreach (Score score in actions)
        {
            act_dict.Add(id, score);
            id++;
        }
        return act_dict;
    }

    public Dictionary<int, string> Things()
    {
        Dictionary<int, string> companies = new Dictionary<int, string>();
        companies.Add(1, "cats");
        companies.Add(2, "taxes");
        companies.Add(3, "babies");
        companies.Add(4, "staff");
        companies.Add(5, "shops");
        companies.Add(6, "goverment");
        companies.Add(7, "prison");
        companies.Add(8, "John Cena");
        companies.Add(9, "beans");
        companies.Add(10, "aliens");
        companies.Add(11, "gamers");
        companies.Add(12, "birbs");
        companies.Add(13, "countries");
        companies.Add(14, "spoons");
        companies.Add(15, "noods");
        companies.Add(16, "stonks");
        companies.Add(17, "honks");
        companies.Add(18, "prawns");
        companies.Add(19, "flower");
        companies.Add(20, "bazinga");
        return companies;
    }

    public NewsArticle createNews()
    {
        Dictionary<int, string> companies = Companies();
        Dictionary<int, Score> actions = Actions();
        Dictionary<int, string> objects = Things();

        System.Random rnd = new System.Random();
        int randCompIndex = rnd.Next(1, companies.Count + 1);
        int randActIndex = rnd.Next(1, actions.Count + 1);
        int randObjIndex = rnd.Next(1, objects.Count + 1);

        string company = companies[randCompIndex];
        Score action = actions[randActIndex];
        string obj = objects[randObjIndex];

        string newsArticle = company + " " + action.getMessage() + " " + obj + ".";
        Debug.Log(newsArticle);
        return new NewsArticle(newsArticle, action.getScore());
    }

    private void Start()
    {
        NewsArticle test = createNews();
    }
}
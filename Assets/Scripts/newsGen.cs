using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class NewsArticle
{
    string message;
    int score;
    Company company;
    int hourCreated;

    public NewsArticle(string message, int score, Company company, int hourCreated)
    {
        this.message = message;
        this.score = score;
        this.company = company;
        this.hourCreated = hourCreated;
    }

    public string getMessage()
    {
        return message;
    }

    public int getScore()
    {
        return score;
    }

    public Company getCompany()
    {
        return company;
    }

    public int getHourCreated()
    {
        return hourCreated;
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
            actionsList.Add(new Score(7, "slaps"));
            actionsList.Add(new Score(-10, "discombobulates"));
            actionsList.Add(new Score(2, "rotates"));
            actionsList.Add(new Score(1, "finds"));
            actionsList.Add(new Score(-4, "exploits"));
            actionsList.Add(new Score(1, "beaned"));
            actionsList.Add(new Score(-3, "bombs"));
            actionsList.Add(new Score(1, "cooks"));
            actionsList.Add(new Score(-3, "kicks"));
            actionsList.Add(new Score(2, "votes for"));
            actionsList.Add(new Score(-4, "bullies"));
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
        companies.Add(21, "anime");
        companies.Add(22, "hentai");
        companies.Add(23, "Hitler");
        companies.Add(24, "Rasputin");
        companies.Add(25, "racists");
        companies.Add(26, "charities");

        return companies;
    }

    public NewsArticle createNews(int hour)
    {
        Dictionary<int, Score> actions = Actions();
        Dictionary<int, string> objects = Things();

        System.Random rnd = new System.Random();
        int randCompIndex = rnd.Next(1, Globals.companies.Count);
        int randActIndex = rnd.Next(1, actions.Count);
        int randObjIndex = rnd.Next(1, objects.Count);

        Company company = Globals.companies[randCompIndex];
        Score action = actions[randActIndex];
        string obj = objects[randObjIndex];

        string newsArticle = company.getName() + " " + action.getMessage() + " " + obj + ".";
        Debug.Log(newsArticle);
        return new NewsArticle(newsArticle, action.getScore(), company, hour);
    }

    public void updateCompanyData(NewsArticle article)
    {
        foreach (Company company in Globals.companies)
        {
            if (company.getName() == article.getCompany().getName())
            {
                Debug.Log(company.getStonkValue());
                float onePercent = company.getStonkValue() / 100;
                float totalPercent = onePercent * article.getScore();

                if ((float)company.getStonkValue() + totalPercent < 0)
                {
                    company.setStonkValue(1);
                } else
                {
                    company.setStonkValue(Mathf.RoundToInt((float)company.getStonkValue() + totalPercent));
                }

                company.updateStonkHistory(article.getHourCreated(), company.getStonkValue());
                Debug.Log(company.getStonkValue());
            }
        }
    }

    int previousHour = 80000;
    public static string newsHeadline;

    private void Update()
    {
        if (Time_Handler.currentHour != previousHour)
        {
            if (Time_Handler.currentHour >= 9 && Time_Handler.currentHour <= 20)
            {
                NewsArticle currNews = createNews(Time_Handler.currentHour);
                updateCompanyData(currNews);
                newsHeadline = currNews.getMessage();
            }
        }

        previousHour = Time_Handler.currentHour;
    }
}
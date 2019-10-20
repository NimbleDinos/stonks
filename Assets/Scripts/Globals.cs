using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static List<Company> createCompanies()
    {
        List<Company> companyList = new List<Company>();
        companyList.Add(new Company("Peach", 10));
        companyList.Add(new Company("Bean Corp", 6000));
        companyList.Add(new Company("Crying Inc", 50));
        companyList.Add(new Company("Zoinkies", 4500));
        companyList.Add(new Company("COOKSQUFF", 300));
        companyList.Add(new Company("funBorn", 1000));
        companyList.Add(new Company("fatcha", 2150));
        return companyList;
    }

    public static List<Company> companies = createCompanies();
}

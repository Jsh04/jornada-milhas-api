using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasTest.InterfacesTest.PageObjects;

public class RegisterDestinyPO
{
    private IWebDriver driver;
    private By InputFiles;
    private By NameDestiny;
    private By SubtitleDestiny;
    private By PriceDestiny;
    private By DescriptionPortuguese;
    private By DestinationEnglish;


    public RegisterDestinyPO(IWebDriver driver)
    {
        this.driver = driver; 
    }
}

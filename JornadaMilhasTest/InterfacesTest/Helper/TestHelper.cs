using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace JornadaMilhasTest.InterfacesTest.Helper;

public class TestHelper
{
    public static string PastaDoExecutavel => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    public static bool ReturnValidationOfTimeWait(Func<IWebDriver, bool> expression, IWebDriver driver, int time = 5)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
        return wait.Until(expression);
    }
}

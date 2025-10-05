using Microsoft.Playwright;
using TechTalk.SpecFlow;
using NUnit.Framework;
namespace MySpecFlowProject.LoginSteps;
[Binding]
public class Loginsteps
{
    private IBrowser _browser = null!;
    private IPage _page = null!;

    [Given("I navigate to the login page")]
    public async Task GivenINavigateToTheLoginPage()
    {
        var playwright = await Playwright.CreateAsync();
        _browser= await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions{Headless = true});
        var context = await _browser.NewContextAsync();
        _page = await context.NewPageAsync();
        await _page.GotoAsync("http://localhost:5003/Home");


    }
    [When("I click signin button")]
    public async Task WhenIClickSignInButton()
    {
        await _page.ClickAsync("//a[text()='Sign In']");

    }

    [When("I enter valid credentials")]
    public async Task WhenIEnterValidCredentials()
    {
        await _page.FillAsync("//input[@placeholder='Email address']", "ragulasweet6@gmail.com");
        await _page.FillAsync("//input[@placeholder='Password']","Ragula12345@");
        await _page.ClickAsync("//button[text()='Login']");
    }

    [Then("I should see the homepage")]
    public async Task ThenIShouldSeeTheHomepage()
    {
        var text = await _page.TextContentAsync("//a[text()='Mars Logo']");
        Assert.That(text, Does.Contain("Mars Logo"));
        await _browser.CloseAsync();
    }

}
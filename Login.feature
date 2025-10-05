Feature: Login
As a user
I want to log in to the application
So that I can access my account

    Scenario: Successful login
        Given I navigate to the login page
        When I click signin button
        When I enter valid credentials
        Then I should see the homepage
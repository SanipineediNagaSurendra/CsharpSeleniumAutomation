Feature: Forms

A short summary of the feature
Background: 
 Given User launches the website "https://demoqa.com/"
 And User selects the "Forms" feature from the homepage

@tag1
Scenario: Fill out the Practice Form with valid details
     When User selects the "Practice Form" link
     And the user enters the form details
      | FirstName | LastName   | Email              | Gender | Mobile     | DOB          | Subject     | Hobbies | Address              | State     | City   |
      | Surendra  | Sanipineedi| surendra@gmail.com | Male   | 9876543210 | 27 July 2025 | Chemistry   | Music   | Hyderabad, Telangana | Haryana   | Karnal |
    And the user "Submit" the form
    Then the submitted details "Thanks for submitting the form" should be displayed in the popup window 
    And The user "Close" the form
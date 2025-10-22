Feature: Alerts

A short summary of the feature

Background: 
 Given User launches the website "https://demoqa.com/"
 And User selects the "Alerts, Frame & Windows" feature from the homepage
@tag1
Scenario: Verify new tab opens correctly
	When User selects the "Browser Windows" link
	And User selects the "New Tab" button
	Then a new tab should open with message "This is a sample page"

@tag2
Scenario: Verify new window opens correctly
   When User selects the "Browser Windows" link
    When I click on the "New Window" button
    Then a new window should open with message "This is a sample page"

@tag3
Scenario: Verify new window message opens correctly
    When User selects the "Browser Windows" link
    When I click on the "New Window Message" button
    Then a message window should open with some text

@tag4
Scenario: Validating Alert window feature
    When User selects the "Alerts" link
    And User select the Click me button based on text "alertButton"
    Then User should see the text "You clicked a button" in popup window 

@tag5
Scenario: Verify Frame1 text
   When User selects the "Frames" link
    Then I verify text in frame is 'This is a sample page'

@tag6 
Scenario: Verify Frame2 text
    When User selects the "Frames" link
    Then I verify text in the frame is 'This is a sample page'

@tag7
Scenario: Validate nested frames content
    When User selects the "Nested Frames" link
    And I switch to the parent frame
    Then I should see "Parent frame" text
    When I switch to the child frame
    Then I should see "Child Iframe" text
    And I switch back to the main page

@tag8
 Scenario: Open and close small modal
    When User selects the "Modal Dialogs" link
    When I click on "Small modal" button
    Then The modal title should be "Small Modal"
    And The modal body should contain "This is a small modal. It has very less content"
    When I click on "Close" button in the modal
    Then The modal window should be closed

@tag9
  Scenario: Open and close large modal
  When User selects the "Modal Dialogs" link
    When I click on "Large modal" button
    Then The modal title should be "Large Modal"
    And The modal body should contains "Lorem Ipsum"
    When I click on "Close" button in the modal
    Then The modal window should be closed
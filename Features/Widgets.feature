Feature: Widgets

A short summary of the feature

Background: 
Given User launches the website "https://demoqa.com/"
 And User selects the "Widgets" feature from the homepage

@tag1
Scenario: Validating Accordian fearture
	 When User selects the "Accordian" link
	 Then User should see the text of "Accordian"

@tag2
 Scenario: Verify content of Section 1
  When User selects the "Accordian" link
  Then body should contain "Lorem Ipsum is simply dummy text"	
	
@tag3
 Scenario: Verify content of Section 2
 When User selects the "Accordian" link
    And I click on "Where does it come from?" header
    Then  body should contain "Contrary to popular belief"

@tag4
Scenario: Verify content of Section 3
When User selects the "Accordian" link
    When I click on "Why do we use it?" header
    Then body should contain "It is a long established fact"

@tag5
Scenario: Validating the Multiple Colours
 When User selects the "Auto Complete" link
  And User shouls selects the multiple colours 
     | Colours |
     | Red     |
     | Green   |
     | Yellow  |
     | White   |
 Then "Yellow" should be displayed in the input box

 @tag6
 Scenario: Validating Single colour section
  When User selects the "Auto Complete" link
  And User selects the "Green" Colour
 Then "Green" should be displayed in the input box

 @tag7
 Scenario: Validating DatePicker using given date
 When User selects the "Date Picker" link
 And User selects the select date input field
 And User should enter the date "28 Sep 2029"
 Then User should verify given date "09/28/2029" is displayed or not

 @tag8
 Scenario: Validating Date and Time section   
 When User selects the "Date Picker" link
 And User selects the Date and Time input field 
 And User should enter the date of "28 Sep 2029" and time "11:30 PM"
 Then User should verify the given date can be displayed 

 @tag9
 Scenario: Verify default slider value
     When User selects the "Slider" link 
    Then the slider value should be "25"

@tag10
Scenario: Move slider to minimum value
    When User selects the "Slider" link 
    When I move the slider to "75"
    Then the slider value should be "75"

@tag11
Scenario: Start and complete the progress bar
    When User selects the "Progress Bar" link 
    And I click the "Start" button
    Then the progress bar should reach "100"

@tag12
Scenario: Validating What tab list in Tabs section
When User selects the "Tabs" link 
Then the "Lorem Ipsum is simply dummy text" tab content should be visible

@tag13
Scenario: Validating Tab list  in Tabs section
When User selects the "Tabs" link 
And user selects the "Origin" tab
Then the "Contrary to popular belief, Lorem Ipsum" tab content should be visible

@tag14
Scenario: Validating Menu item in widgets feature
When User selects the "Menu" link
And User should mouse hover the "Main Item 2"
Then should display "Sub Item" under given menutab

@tag15
 Scenario: Verify tooltip on hover over the button
   When User selects the "Tool Tips" link
    When I hover over the "Hover me to see"
    Then I should see a tooltip with text "You hovered over the Button"

@tag16
  Scenario: Verify tooltip on hover over the text field
    When User selects the "Tool Tips" link
    When I hover over the "Hover me to see" in the input feild
    Then I should see a tooltip with text "You hovered over the text field"

@tag17
  Scenario: Verify tooltip on hover over the Contrary link
    When User selects the "Tool Tips" link
    When I hover over the "Contrary" link
    Then I should see a tooltip with text "You hovered over the Contrary"

      
 


	
	

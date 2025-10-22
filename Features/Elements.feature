Feature: Elements

A short summary of the elements feature

Background: 
 Given User launches the website "https://demoqa.com/"
 And User selects the "Elements" feature from the homepage

@TextBoxvalid
Scenario: Submit valid data in the Text Box form
  When User selects the "Text Box" link
  And User enters the name "Surendra Sanipineedi" in the Full Name field
  And User enters the email "surendra@gmail.com" in the Email field
  And User enters a address in the Current Address field
  And User enters a address in the Permanent Address field
  And User clicks on the "submit" button
  Then The displayed content should match the entered values

@TextBoxInvalid
Scenario: Submit invalid data in the Text Box form
  When User selects the "Text Box" link
  And User enters the name "surendra Sanipineedi" in the Full Name field
  And User enters the email "surendragmail.com" in the Email field
  And User enters a address in the Current Address field
  And User enters a address in the Permanent Address field
  And User clicks on the "submit" button
  Then The Email field should be highlighted with a red border


@CheckBoxValid
Scenario: select a parent checkbox and verify all child checkboxes are selected 
  When User selects the "Check Box" link
  And User expands the "Toggle" node
  And User selects the "Home" checkbox
  Then All child checkboxes should be selected

@CheckBoxpartialstate1
Scenario: select a child checkbox and verify all parent checkboxes are partially selected
  When User selects the "Check Box" link
  And User expands the "Toggle" node
  And User expandes the "Desktop" node
  And User selects the "Notes" checkbox
  Then The "Desktop" checkbox should be in a partially selected state

@CheckBoxInvalidstate
Scenario: Uncheck all children and verify parent becomes unselected
  When User selects the "Check Box" link
  And User expands the "Toggle" node
  And User expandes the "Documents" node
  And User selects all checkboxes under "Documents"
  And User unchecks the "Office" checkbox
  Then The "Documents" checkbox should be in a partially selected state

@RadioButton
Scenario: Select "Yes" RadioButton option
  When User selects the "Radio Button" link
  And User select the 'Yes' RadioButton
  Then The message 'You have selected 'and 'Yes' should be displayed

@RadioButton1
Scenario:Verify "No" radio button is disabled
 When User selects the "Radio Button" link
 Then The "No" radio button should be disabled and not selectable

@WebTablesAdd
Scenario: Add new user record in the web table
  When User navigates to the "Web Tables" section
  And User click on the "Add" button
  And User enters "Surendra" in the First Name field
  And User enters "Sanipineedi" in the Last Name field
  And User enters "30" in the Age field
  And User enters "surendra@gmail.com" in the Email field
  And User should add salary "30000" in the Salary field
  And User enters the "Finance" in the department field
  And User clicks on the "submit" button
  Then The new record with name "Sanipineedi" should appear in the table

@WebTablesDelete
Scenario: Delete a user record from the web table
  When User is on the "Web Tables" page
  And User clicks on the "Delete" button for the record with email "cierra@example.com"
  Then The record with email "cierra@example.com" should be removed from the table

@Buttons
Scenario: Perform a double click option
  When User selects the "Buttons" link
  And user double click on the "Double Click Me" button
  Then verify the message 'You have done a double click' should be displayed

@Links
Scenario: select the link redirect to the new tab
  When User selects the "Links" link
  And User clicks on the "Home" link 
  Then A new browser tab should open with the DemoQA home page 



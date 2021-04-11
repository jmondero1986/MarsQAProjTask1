Feature: Profile 
		Seller can add details in the profile feature
		So that people can look into the sellers details
		

@mytag
Scenario: Testing the Description feature
	Given I input text in the description box
	And I click the save button
	Then I will be able to see the description information


Scenario: Testing Languages feature

	Given I am logged in at profile page
	When I click language tabs
	Then I should see languages label
	And a list of languages seller can speak
	And an instruction of maximum of selections
	And I should see the languages list
	
	

Scenario: Adding, Updating and Deleting Language

	Given I am at the language page
	When I add language
	Then I see the added language in the grid
	And I update the language
	Then I will see the updated language
	When I delete the added language
	Then I should not see the added language


Scenario: Testing Skills feature

	Given I am at the profile page
	When I click skills tab
	Then I will go to skill feature page

Scenario: Adding Skills

	Given I am at the skills page
	When I add skills
	Then I see the added skills 

Scenario: Update Skills

	Given I am at the skills feature page
	When I edit the skills
	Then I see the updated skills

Scenario: Delete Skills

	Given I am at the skills feature page
	When I delete the skills
	Then I see the deleted language


Scenario: Testing Education feature

	Given I am at the profile page
	When I click Education tab
	Then I will go to Education feature page

Scenario: Adding Education 

	Given I am at the  education page
	When I add education information
	Then I see the added education information

Scenario: Update Education

	Given I am at the education feature page
	When I edit the education information
	Then I see the updated education information

Scenario: Delete Education

	Given I am at the language feature page
	When I delete the education information
	Then I see the deleted education information

Scenario: Testing Certification feature

	Given I am at the profile page
	When I click certification tab
	Then I will go to certifcation feature

Scenario: Adding Certification details

	Given I am at the education page
	When I add certification details
	Then I see the added certification details

Scenario: Update Certification details

	Given I am at the language feature page
	When I edit the certification details
	Then I see the updated certification details

Scenario: Delete Certification details

	Given I am at the language feature page
	When I delete the certification details
	Then I see the deleted certification details

Scenario: Edit Name feature

	Given I am at the profile  page
	When I click the name tab
	And I input new name
	When I click Save
	Then I see the updated/edited name

Scenario: Testing the Availability feature

	Given I am at the profile page
	When I click the availability feature
	And I select the availability type
	Then I see the availability result

Scenario: Testing the Hours feature

	Given I am at the profile page
	When I click the hours feature
	And I select the hours type
	Then I see the hours result

Scenario: Testing the Earn Target feature

	Given I am at the profile page
	When I click the Earn Target feature 
	And I select the Earn Target type
	Then I see the Earn Target result







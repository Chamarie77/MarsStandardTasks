Feature: ProfilePage

As a learner I want to add a Language, Edit the language and Delete the language.
So I can manage profile page successfully.

@automation
Scenario: 01 I am happy to enter the description
	Given i enter the description
	Then i can see the description
	

@automation
Scenario: 02 I am happy to enter a language
	Given i clicked on the language tab under the profile page
	When i entered a language
	Then i can see the language on my list

@automation
Scenario Outline: 03 I am happy to edit the language
	Given i clicked on the language tab under the profile page
	When i edited the '<Language>', '<Level>'
	Then i can see the edited '<Language>' and '<Level>' on my list

	Examples: 
	| Language | Level           |
	| Sinhalese| Native/Bilingual|


Scenario:04  I am happy to delete the language
	Given i clicked on the language tab under the profile page
	When i delete the language
	Then i can not see the delete language on my list


@automation
Scenario: 05 I am happy to enter a certification
	Given i clicked on the certifications tab under the profile page
	When i entered a certification
	Then i can see the certification on my list


@automation
Scenario Outline: 06 I am happy to edit the certification
	Given i clicked on the certifications tab under the profile page
	When i updated the '<Certificate>', '<From>', '<Year>'
	Then i can see the updated '<Certificate>', '<From>', '<Year>' on my list

	Examples:
	| Certificate | From   | Year |
	| Java        | Oracle | 2004 |

@automation	
Scenario: 07 I am happy to delete the certification
	Given i clicked on the certifications tab under the profile page
	When i delete the certification
	Then i can not see the delete certification on my list




Feature: ShareSkill

As a learner I am happy to add a skill, edit the skill and delete the skill.
So I can manage the Share Skill successfully.

@automation
Scenario: 08 i am happy to share a skill
	Given i clicked on the share skill button on the profile page
	When i added a new skill
	Then i can see the new skill on listings


@automation
Scenario: 09 i am happy to edit the skill
	Given i clicked on the manage listungs link on the profile page
	When i updated '<Title>', '<Description>' of the skill
	Then i can see the updated '<Title>', '<Description>' skill on listings

	Examples: 
	| Title    | Description            |
	| Selenium | Happy to help with API |

@automation
Scenario: 10 i am happy to delete the skill
	Given i clicked on the manage listungs link on the profile page
	When i deleted '<Title>' record
	Then i can not see the '<Title>' record on listings

	Examples: 
	| Title    |
	| Selenium |


















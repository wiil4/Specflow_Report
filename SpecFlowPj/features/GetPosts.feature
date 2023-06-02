Feature: GetPosts

A short summary of the feature

@tag1 @smoke @regression
Scenario: GetbyId
	Given a valid API endpoint	
	And I have an id with value 1
	When I send a request
	Then I expect a valid code response


Feature: GetPosts
	Simple calculator for adding two numbers

@mytag
Scenario: Asserting on author first Get
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "1"
	Then I should see the "author" name as "typicode"

Scenario: Asserting on title first Get
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "1"
	Then I should see the "title" name as "json-server"

Scenario: Asserting on author third Get
	Given I perform GET operation for "posts/{postid}"
	And I perform operation for post "3"
	Then I should see the "author" name as "Viraj"
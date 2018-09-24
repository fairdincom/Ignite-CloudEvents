# Ignite CloudEvents Demo #

This is the sample repository for demo-ing at Ignite.


## Session Information ##

* URL: [https://myignite.techcommunity.microsoft.com/sessions/66370](https://myignite.techcommunity.microsoft.com/sessions/66370)
* Slide: TBA
* Video: TBA


## Getting Started ##

### ARM Templates Deployment ###

ARM template should be deployed in this order:

1. EventGridTopic.json
1. LogicApp.Converter.json
1. LogicApp.Handler.json
1. EventGridSubscription.json


### Web API Integration with Event Grid ###

In order to integrate Web API with Event Grid, the following information needs to be replaced at `Todo.ApiApp`:

* Subscription Id
* Resource Group Name
* Event Grid Topic Name
* Event Grid Endpoint URL
* Event Grid Topic Access Key


### GitHub API Integration ###

In order to integrate GitHub API, the following information needs to be replaced at `GitHub.ConsoleApp`:

* GitHub Username
* GitHub Password
* GitHub Repository Id in number format
* GitHub Issue number


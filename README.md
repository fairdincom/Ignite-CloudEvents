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


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work with corresponding tests, please send us a pull request onto our `master` branch for review.


## License ##

This is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2018 [fairdin.com](https://github.com/fairdincom)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

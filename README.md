# CMPE-363 Final Project

## The problem

We defined language barriers as our real-life problem. Since we are Erasmus Students, we met many people from other countries who also spend a semester here in Istanbul. We thought that a app which makes translating easy would be very helpful if students from other countries need to interact with each other. 

## Solution

We came up with the idea of translating in various languages and let the translated word/sentence play as a audio file for the correct pronunciation. Since many Erasmus students have to deal with documents, and some documents are solely written in Turkish, we provide a very handy solution for this problem. Users can upload any image files to let it translate in the desired language.


### Application

We used the ASP.NET framework for this solution. It makes building websites very easy for the user. Also, C# is a very easy to understand language, even for Java Programmers like us.

### App Service and Deployment

For the deployment we used the Azure App Service, since it meets our needs perfectly. We configured the deployment-centre so it takes the code from our GitHub Repository, builds the application and releases on this app service. After the deployment the service is ready to use via https://webapp-dotnet-service.azurewebsites.net.

### Translate

The translation is the core of our web application. We used the Translator from the Cognitive Services. We connect our application with the translator via key and endpoint.

### Speech

To hear how the translated word/sentence sounds we added Speech from Cognitive Services to our app. We went with the REST-API option. First, we get the Authorization Token which includes the 64 Bytes Bearer code. This header is required in the request. In the body part we put our xml which defines the language and the voice of the speaker. We also add here the text we want to be spoken. As a response we get a .wav file, which we include in our basic audio player.

### Computer Vision

We also added the functionality to upload images and recognize the text in those images. The uploaded image gets converted to text via Computer Vision to which we also connect via endpoint and key. The converted text then gets translated in the desired language.

### Azure SQL

We used Azure SQL to save user information. It is possible for users to register on our application with username, password and the preferred language. The registration makes us set the language we want to translate from to the preferred language of the user. Also, the user can see how often the translation and speech services were used.

### Fault Tolerance
For fault tolerance, we used scale out in the app service plan, as load balancers are for VMs, and we do not have a VM. We chose custom auto scale, which has minimum 1 instance, maximum 10 and as default 3. In addition, we have created a rule that creates an instance when the CPU load is over 70%.

### Firewall
In addition, we have created a web application firewall (WAF). For the managed rules we used the Microsoft_DefaultRuleSet.

### Front Door
So that we can use the firewall, we have also created a front door.


# carter-cs
 Carter C# Package

# Documentation for V0.01

Requries For Baseline Newtonsoft.Json To Be installed

How to use CarterCS.

1. Download the source code and make sure you have the C# dependice (Newtonsoft.Json;) Installed.

To get started you need to create an agent on the user dashboard (https://dashboard.carterapi.com/) 

Go inside of your agent and get the api key.

Inside of your C# file ```CarterCS carter = new CarterCS();``` Add this line to your code to create a new carter service.

Once you have set that up you can call functions from it.

To check the api status call ```carter.CheckStatus();```

To send a message to your agent call ```carter.SendMessageToCarter();``` - Inside of this tag you have to call in this order the ApiKey, message, userID and optionally a scene.

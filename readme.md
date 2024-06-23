I have tried to keep things simple. I have chosen to create the following layers:
- Api
- Service
- Storage
- Storage.Json
- Web

# Api
The api layer is what is accessible from the outside world. It is the entry point to the application. It is responsible for handling requests and responses.

# Service
The service layer is responsible for the business logic. It is the layer that is responsible for the actual work that needs to be done. By separating the Api and Service layer, it is very easy to change the interface to the outside world. For instance, I created simple ASP.Net core Web api's, but should you want to use it in Azure like a Function App, it would be sufficient to remove the Api layer and add a new Function App project. From that point forward, it is not necessary (or, at least, shouldn't be) to make any other modifications to the code.

# Storage
The storage layer is meant to contain the contracts (interfaces) on how to store data. For instance, it is necessary to get the scratchboard for storage. That is common knowledge. But how the scratchboard is stored is not. It could be stored in a database, in a file, in memory, etc. The storage layer is meant to abstract that away. 

# Storage.Json
The storage.json layer actually implements persistence of the scratchboard in a json file. Of course, storing the scratchboard and all its actions in a json file is a very simple solution and is not meant to be used in a production environment. It is only meant to be used for testing purposes or, in this case, demonstrations.

The beauty is however, that should you want to store the scratchboard in a database, you can create a new project that implements the interfaces from the Storage layer and you are good to go. The rest of the code doesn't need to be changed.

# Web
The web laye merely contains the visualization of the scratchboard, so that it can be tested. I have almost entirely used AI to create it. I know that there is a lot that can be said about it (for instance, it is in a cshtml file rather than an html file!), but since this assessment is about the backend, I can perfectly well live with that.
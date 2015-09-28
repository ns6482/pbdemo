#backend

Should be able to compile and start the project, 3 apps will start. One is for the authorisation server, web api resources and ui. 

Before running, please make usre you have node installed and run grunt from the ui directory. See steps below.

#Other notes

Have used Micrsoft identity to register and login users. The authorisation choice is oauth2. 
For brevity only supplying access token for now, but in the real world you would also include a refresh token.
The ui is responsible for checking the state of the access token by the use of an interceptor. 

For local use, you will need to specify the database connection (see web.config files  in pbDemo.Authorisation).

make sure to run Update-database from package manager console.

# pb.ui

This project is generated with [yo angular generator](https://github.com/yeoman/generator-angular)
version 0.12.1.

## Build & development

Run `grunt` for building and `grunt serve` for preview.

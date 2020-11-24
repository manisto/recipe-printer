# Recipe-printer
## Settings
Unless otherwise specified, the application will store data in the `Recipes.Api/data` folder.
You can change this by specifying the environment variable "DataPath".
Please note that the specified path must be absolute, as in the following example.

```
dotnet run --project Recipes.Api --DataPath=c:\recipe-data
```

## Running the project
### Locally
In the root project folder, run the following commands:

```cmd
dotnet restore Recipes.Api
dotnet tool restore
```

Then, to setup the database, run the following command

```cmd
dotnet ef database update --project Recipes.Api
```

This will create and migrate the sqlite database located in `Recipes.Api/data/Recipes.sqlite`. Finally, you can start the backend by running the following command:

```cmd
dotnet run --project Recipes.Api
```

### Docker
First, build the Docker image from the root project folder:

```cmd
docker build --pull --rm -f "Dockerfile" -t recipeprinter:latest "."
```

You can now start the container with the following command:

#### Windows
```
docker run --rm -d -p 1337:80/tcp -v %cd%/Recipes.Api/data:/server/data --name recipe recipeprinter:latest
```

#### Linux
```
docker run --rm -d -p 1337:80/tcp -v "$(pwd)"/Recipes.Api/data:/server/data --name recipe recipeprinter:latest
```
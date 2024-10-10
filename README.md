# Docker names generator

Generate random names.\
The generation algorithm is the one used by docker to generate the names of their containers, see [names-generator.go from moby/moby](https://github.com/moby/moby/blob/39f7b2b6d0156811d9683c6cb0743118ae516a11/pkg/namesgenerator/names-generator.go).

## Quick start

### CLI

Start by installing the CLI tool, e.g. using dotnet:
```
dotnet tool install --global DockerNamesGenerator.CLI
```

Then run the `docker-name` command.
```
> docker-name
festive_meitner
```

<b>Features</b>
- Provide a seed
```
docker-name 123
zealous_thompson
```

<b>Usage</b>
```
docker-name 1.0.0
ismailbennani

  --help          Display this help screen.

  --version       Display version information.

  value pos. 0    Value that will be used as a seed for the random generation.

```

### Library

Start by installing the nuget, e.g. using dotnet:
```
dotnet add package DockerNamesGenerator
```

Then get an instance of the generator, and use it.
```csharp
DockerNameGenerator generator = DockerNameGenerator.Instance;
string name = generator.GenerateName();
```

The default instance of the generator uses `Random.Shared` as a random source. The `DockerNameGeneratorFactory` can be used to create a generator that uses another random source, or that uses the standard `Random` with a seed:
```csharp
Random customSource = ...;
DockerNameGenerator customSourceGenerator = DockerNameGeneratorFactory.Create(customSource);
```

```csharp
DockerNameGenerator intSeedGenerator = DockerNameGeneratorFactory.Create(123);
```

```csharp
Guid guid = ...;
DockerNameGenerator guidSeedGenerator = DockerNameGeneratorFactory.Create(guid);
```
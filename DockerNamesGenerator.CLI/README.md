# Docker names generator

Generate random names.\
The generation algorithm is the one used by docker to generate the names of their containers, see [names-generator.go from moby/moby](https://github.com/moby/moby/blob/39f7b2b6d0156811d9683c6cb0743118ae516a11/pkg/namesgenerator/names-generator.go).

## Quick start

Start by installing the CLI tool, e.g. using dotnet:
```
dotnet tool install --global DockerNamesGenerator.CLI
```

Then run the `docker-name` command.
```
> docker-name
festive_meitner
```

### Features
- Provide a seed
```
> docker-name 123
zealous_thompson
```

### Usage
```
> docker-name --help
docker-name 1.0.0
ismailbennani

  --help          Display this help screen.

  --version       Display version information.

  value pos. 0    Value that will be used as a seed for the random generation.

```
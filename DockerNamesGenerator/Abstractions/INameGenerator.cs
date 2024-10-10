namespace DockerNamesGenerator.Abstractions;

public interface INameGenerator
{
    public string GenerateName(Random random);
}

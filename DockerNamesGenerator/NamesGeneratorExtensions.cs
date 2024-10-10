using DockerNamesGenerator.Abstractions;

namespace DockerNamesGenerator;

public static class NamesGeneratorExtensions
{
    public static string GenerateName(this INameGenerator generator) => generator.GenerateName(Random.Shared);
    public static string GenerateName(this INameGenerator generator, int seed) => generator.GenerateName(new Random(seed));
    public static string GenerateName(this INameGenerator generator, Guid seed) => generator.GenerateName(new Random(Hash(seed)));

    static int Hash(Guid guid)
    {
        byte[] bytes = guid.ToByteArray();
        int result = 0;

        for (int i = 0; i < 4; i++)
        {
            result += BitConverter.ToInt32(bytes, i * 4);
        }

        return result;
    }
}

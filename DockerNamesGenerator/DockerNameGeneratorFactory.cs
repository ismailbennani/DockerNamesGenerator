namespace DockerNamesGenerator;

public static class DockerNameGeneratorFactory
{
    public static DockerNameGenerator Create() => new(Random.Shared);
    public static DockerNameGenerator Create(int seed) => new(new Random(seed));
    public static DockerNameGenerator Create(Guid seed) => new(new Random(Hash(seed)));
    public static DockerNameGenerator Create(Random random) => new(random);

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

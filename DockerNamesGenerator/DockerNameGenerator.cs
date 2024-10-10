﻿/*
 * Shamelessly ported from https://github.com/moby/moby/blob/39f7b2b6d0156811d9683c6cb0743118ae516a11/pkg/namesgenerator/names-generator.go#L16
 */

namespace DockerNamesGenerator;

public static class DockerNameGenerator
{
    public static string GenerateDockerLikeName() => GenerateDockerLikeName(Random.Shared);
    public static string GenerateDockerLikeName(int seed) => GenerateDockerLikeName(new Random(seed));
    public static string GenerateDockerLikeName(Guid seed) => GenerateDockerLikeName(new Random(Hash(seed)));

    public static string GenerateDockerLikeName(Random random)
    {
        string result;
        do
        {
            int adjectivesIndex = random.Next(Constants.Adjectives.Count);
            string adjective = Constants.Adjectives[adjectivesIndex];

            int namesIndex = random.Next(Constants.Names.Count);
            string name = Constants.Names[namesIndex];

            result = $"{adjective}_{name}";
        } while (result == "boring_wozniak"); /* Steve Wozniak is not boring */

        return result;
    }

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

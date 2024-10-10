/*
 * Shamelessly ported from https://github.com/moby/moby/blob/39f7b2b6d0156811d9683c6cb0743118ae516a11/pkg/namesgenerator/names-generator.go#L16
 */

using CommandLine;
using DockerNamesGenerator;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(
        opt =>
        {
            DockerNameGenerator generator = DockerNameGenerator.Instance;
            string name = opt.Seed.HasValue ? generator.GenerateName(opt.Seed.Value) : generator.GenerateName();
            Console.WriteLine(name);
        }
    );


class Options
{
    [Value(0, Required = false, HelpText = "Value that will be used as a seed for the random generation.")]
    public int? Seed { get; set; } = null;
}

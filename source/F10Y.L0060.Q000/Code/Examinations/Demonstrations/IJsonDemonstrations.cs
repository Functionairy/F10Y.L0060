using System;
using System.Threading.Tasks;

using F10Y.T0006;


namespace F10Y.L0060.Q000
{
    [DemonstrationsMarker]
    public partial interface IJsonDemonstrations
    {
        public async Task RoundTrip_ExampleJsonFile()
        {
            /// Inputs.
            var jsonFilePath = Instances.FilePaths.Example_JsonFilePath;
            var output_JsonFilePath = Instances.FilePaths.Output_JsonFilePath;

            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var jDocument = await Instances.JsonDocumentOperator.Deserialize_File(jsonFilePath);

            await Instances.JsonDocumentOperator.Serialize_ToFile(
                output_JsonFilePath,
                jDocument,
                Instances.JsonSerializerOptionsSet.Indented
            //Instances.JsonSerializerOptionsSet.Default
            );

            var files_AreEqual = await Instances.FileOperator.Files_AreEqual_ByteLevel(
                jsonFilePath,
                output_JsonFilePath);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{files_AreEqual}: files are equal");

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(
                jsonFilePath,
                output_JsonFilePath,
                output_TextFilePath);
        }
    }
}

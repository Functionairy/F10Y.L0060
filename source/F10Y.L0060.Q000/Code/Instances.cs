using System;


namespace F10Y.L0060.Q000
{
    public static class Instances
    {
        public static L0000.IEnumerableOperator EnumerableOperator => L0000.EnumerableOperator.Instance;
        public static L0000.IFileOperator FileOperator => L0000.FileOperator.Instance;
        public static IFilePaths FilePaths => Q000.FilePaths.Instance;
        public static IJsonDocumentOperator JsonDocumentOperator => L0060.JsonDocumentOperator.Instance;
        public static IJsonSerializerOptionsSet JsonSerializerOptionsSet => L0060.JsonSerializerOptionsSet.Instance;
        public static L0019.INotepadPlusPlusOperator NotepadPlusPlusOperator => L0019.NotepadPlusPlusOperator.Instance;
    }
}
using System;


namespace F10Y.L0060
{
    public static class Instances
    {
        public static L0000.IFileStreamOperator FileStreamOperator => L0000.FileStreamOperator.Instance;
        public static IJsonDocumentOperator JsonDocumentOperator => L0060.JsonDocumentOperator.Instance;
        public static IJsonElementOperator JsonElementOperator => L0060.JsonElementOperator.Instance;
        public static IJsonSerializerOptionsSet JsonSerializerOptionsSet => L0060.JsonSerializerOptionsSet.Instance;
        public static L0000.IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static L0000.ITypeOperator TypeOperator => L0000.TypeOperator.Instance;
    }
}
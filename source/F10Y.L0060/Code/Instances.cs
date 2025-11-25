using System;


namespace F10Y.L0060
{
    public static class Instances
    {
        public static L0000.IDateTimeFormats DateTimeFormats => L0000.DateTimeFormats.Instance;
        public static IDateOnlyOperator DateOnlyOperator => L0060.DateOnlyOperator.Instance;
        public static L0000.IDateTimeOffsetOperator DateTimeOffsetOperator => L0000.DateTimeOffsetOperator.Instance;
        public static IDateTimeOperator DateTimeOperator => L0060.DateTimeOperator.Instance;
        public static L0000.IDefaultOperator DefaultOperator => L0000.DefaultOperator.Instance;
        public static L0000.IFileOperator FileOperator => L0000.FileOperator.Instance;
        public static L0000.IFileStreamOperator FileStreamOperator => L0000.FileStreamOperator.Instance;
        public static IGarbageCollectorOperator GarbageCollectorOperator => L0060.GarbageCollectorOperator.Instance;
        public static IJsonDocumentOperator JsonDocumentOperator => L0060.JsonDocumentOperator.Instance;
        public static IJsonElementOperator JsonElementOperator => L0060.JsonElementOperator.Instance;
        public static IJsonSerializerOptionsSet JsonSerializerOptionsSet => L0060.JsonSerializerOptionsSet.Instance;
        public static L0000.IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static L0000.ITypeOperator TypeOperator => L0000.TypeOperator.Instance;
    }
}
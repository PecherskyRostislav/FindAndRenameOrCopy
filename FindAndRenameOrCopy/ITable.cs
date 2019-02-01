namespace FindAndRenameOrCopy
{
    public interface ITable
    {
        int ID { get; set; }
        int CopyFeature { get; set; }

        void SetProperties(params string[] arg);
        string[] GetProperties();
    }
}

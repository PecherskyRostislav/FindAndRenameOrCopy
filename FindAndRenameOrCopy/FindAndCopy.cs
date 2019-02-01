using System;

namespace FindAndRenameOrCopy
{
    class FindAndCopy : ITable
    {
        public int ID { get; set; }
        public int CopyFeature { get; set; }
        public string IN { get; set; }

        public string[] GetProperties()
        {
            return new string[] { ID.ToString(), IN, CopyFeature.ToString() };
        }

        public void SetProperties(params string[] arg)
        {
            ID = Convert.ToInt32(arg[0]);
            IN = arg[1];
            if (string.IsNullOrEmpty(arg[2]))
                CopyFeature = 0;
            else
                CopyFeature = Convert.ToInt32(arg[2]);
        }

        public FindAndCopy()
        {
            ID = 0;
            CopyFeature = 0;
            IN = "";
        }
    }
}

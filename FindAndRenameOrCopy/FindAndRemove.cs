using System;

namespace FindAndRenameOrCopy
{
    class FindAndRemove : ITable
    {
        public int ID { get; set; }
        public int CopyFeature { get; set; }
        public string PreviousName { get; set; }
        public string NewName { get; set; }


        public string[] GetProperties()
        {
            return new string[] { ID.ToString(), PreviousName, NewName, CopyFeature.ToString() };
        }

        public void SetProperties(params string[] arg)
        {
            ID = Convert.ToInt32(arg[0]);
            PreviousName = arg[1];
            NewName = arg[2];
            if (string.IsNullOrEmpty(arg[3]))
                CopyFeature = 0;
            else
                CopyFeature = Convert.ToInt32(arg[3]);
        }

        public FindAndRemove()
        {
            ID = 0;
            CopyFeature = 0;
            PreviousName = "";
            NewName = "";
        }
    }
}

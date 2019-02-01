using System.Windows.Forms;

namespace FindAndRenameOrCopy
{
    public class DefaultDialogService
    {
        public string SelectedPath { get; set; }

        public bool OpenFolderDialog()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = folderBrowserDialog.SelectedPath;
                return true;
            }
            return false;
        }
    }
}

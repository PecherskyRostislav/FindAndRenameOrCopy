using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Input;
using System.IO;
using System.Windows;
using System.Text;

namespace FindAndRenameOrCopy
{
    enum Mods
    {
        Move = 0,
        Copy
    }

    class MainVM : INotifyPropertyChanged
    {
        #region Variables
        private DefaultDialogService dialogService;
        private Mods _currentMode;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        private string _execBtnName;
        public string ExecBtnName
        {
            get { return _execBtnName; }
            set
            {
                _execBtnName = value;
                OnPropertyChanged("ExecBtnName");
            }
        }
        private string _dopLblName;
        public string DopLblName
        {
            get { return _dopLblName; }
            set
            {
                _dopLblName = value;
                OnPropertyChanged("DopLblName");
            }
        }
        public SolidColorBrush CurrentColor
        {
            get
            {
                SolidColorBrush brush = new SolidColorBrush();
                switch (_currentMode)
                {
                    case Mods.Move:
                        brush = new SolidColorBrush(Colors.ForestGreen);
                        break;
                    case Mods.Copy:
                        brush = new SolidColorBrush(Colors.Goldenrod);
                        break;
                }
                return brush;
            }
        }
        private string _selectFolderToFind;
        public string FolderToFind
        {
            get { return _selectFolderToFind; }
            set
            {
                _selectFolderToFind = value;
                OnPropertyChanged("FolderToFind");
            }
        }
        private string _selectFolderToMoveCopy;
        public string FolderToMoveCopy
        {
            get { return _selectFolderToMoveCopy; }
            set
            {
                _selectFolderToMoveCopy = value;
                OnPropertyChanged("FolderToMoveCopy");
            }
        }
        private int _coutnIter;
        public int CountItems
        {
            get { return _coutnIter; }
            set
            {
                _coutnIter = value;
                OnPropertyChanged("CountItems");
            }
        }
        private int _currPos;
        public int CurrentPosition
        {
            get { return _currPos; }
            set
            {
                _currPos = value;
                OnPropertyChanged("CurrentPosition");
            }
        }
        #endregion

        #region Commands
        public ICommand OpenDialgToFind
        {
            get => new RelayCommand((obj) => OpenDialog(true));
        }
        public ICommand OpenDialgToMoveCopy
        {
            get => new RelayCommand((obj) => OpenDialog(false));
        }
        public ICommand ActivateModeMove
        {
            get => new RelayCommand((obj) => ChangeMode(Mods.Move));
        }
        public ICommand ActivateModeCopy
        {
            get => new RelayCommand((obj) => ChangeMode(Mods.Copy));
        }
        public ICommand ExecuteCommand
        {
            get => new RelayCommand((obj) => Execute());

        }
        #endregion

        #region Methods
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void OpenDialog(bool toFind)
        {
            try
            {
                if (dialogService.OpenFolderDialog() == true)
                {
                    if (toFind)
                    {
                        FolderToFind = dialogService.SelectedPath;
                    }
                    else
                    {
                        FolderToMoveCopy = dialogService.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void ChangeMode(Mods mod)
        {
            _currentMode = mod;
            switch (_currentMode)
            {
                case Mods.Move:
                    ExecBtnName = "Переместить";
                    DopLblName = "перемещения";
                    break;
                case Mods.Copy:
                    ExecBtnName = "Копировать";
                    DopLblName = "копирования";
                    break;
            }
            OnPropertyChanged("CurrentColor");
        }

        private void Execute()
        {
            string catFind = @FolderToFind.Trim(),
                   catRemove = FolderToMoveCopy.Trim();

            if (ErrorСhecking(catFind, catRemove))
                return;

            switch (_currentMode)
            {
                case Mods.Move:
                    ExecuteMove(catFind, catRemove);
                    break;
                case Mods.Copy:
                    ExecuteCopy(catFind, catRemove);
                    break;
            }
            CurrentPosition = 0;
        }

        private void ExecuteMove(string catFind, string catRemove)
        {
            List<ITable> list = DBActions.Get<FindAndRemove>();
            CountItems = list.Count;
            int error = 0;
            for (int i = 0; i < CountItems; i++)
            {

                if (((FindAndRemove)list[i]).PreviousName == "" || ((FindAndRemove)list[i]).PreviousName == "нет, добавить")
                {
                    list[i].CopyFeature = 0;
                    CurrentPosition++;
                    error++;
                    continue;
                }
                List<string> result = new List<string>(Directory.EnumerateFiles(catFind, ((FindAndRemove)list[i]).PreviousName, SearchOption.AllDirectories));
                System.Windows.Forms.Application.DoEvents();
                if (result.Count == 0)
                {
                    list[i].CopyFeature = 0;
                    error++;
                }
                else
                {
                    File.Copy(result[0], catRemove + "\\" + ((FindAndRemove)list[i]).NewName);
                    list[i].CopyFeature = 1;
                }
                CurrentPosition++;
            }
            DBActions.Update<FindAndRemove>(list);
            if(error > 0)
            {
                CreateLogFileMove(list, catRemove);
            }
            string message = "Do you want open log file?";
            if (MessageBox.Show(message, "Info", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start(catRemove + "\\LogMove.txt");
            }
        }

        private void CreateLogFileMove(List<ITable> list, string catRemove)
        {
            using (StreamWriter sw = new StreamWriter(catRemove + "\\LogMove.txt", true, Encoding.Default))
            {
                sw.WriteLine(new string('-',5) + DateTime.Now.ToString() + new string('-', 5));
                sw.WriteLine("Файлы изображений, которые не были найдены:");
                for(int i = 0; i < list.Count; i++)
                {
                    if(list[i].CopyFeature == 0)
                    {
                        sw.WriteLine("     " + ((FindAndRemove)list[i]).PreviousName);
                    }
                }
                sw.WriteLine(new string('=', 29));
            }
        }

        private void ExecuteCopy(string catFind, string catRemove)
        {
            List<ITable> list = DBActions.Get<FindAndCopy>();
            CountItems = list.Count;
            int error = 0;
            for (int i = 0; i < CountItems; i++)
            {

                if (((FindAndCopy)list[i]).IN == "" || ((FindAndCopy)list[i]).IN == "нет, добавить")
                {
                    list[i].CopyFeature = 0;
                    CurrentPosition++;
                    error++;
                    continue;
                }
                List<string> result = new List<string>(Directory.EnumerateFiles(catFind, $"*{((FindAndCopy)list[i]).IN}*.jpg", SearchOption.AllDirectories));
                System.Windows.Forms.Application.DoEvents();
                if (result.Count == 0)
                {
                    list[i].CopyFeature = 0;
                    error++;
                }
                else
                {
                    for (int j = 0; j < result.Count; j++)
                    {

                        string[] split = result[j].Split('\\');
                        if (File.Exists(catRemove + "\\" + split[split.Length - 1]))
                            continue;
                        File.Copy(result[j], catRemove + "\\" + split[split.Length - 1]);
                        list[i].CopyFeature = 1;
                        CurrentPosition++;
                    }
                }
            }
            DBActions.Update<FindAndCopy>(list);
            if (error > 0)
            {
                CreateLogFileCopy(list, catRemove);
            }
            string message = "Do you want open log file?";
            if (MessageBox.Show(message, "Info", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start(catRemove + "\\LogCopy.txt");
            }
        }

        private void CreateLogFileCopy(List<ITable> list, string catRemove)
        {
            using (StreamWriter sw = new StreamWriter(catRemove + "\\LogCopy.txt", true, Encoding.Default))
            {
                sw.WriteLine(new string('-', 5) + DateTime.Now.ToString() + new string('-', 5));
                sw.WriteLine("ИН, для которых фотографии найдены не были:");
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].CopyFeature == 0)
                    {
                        sw.WriteLine("     " + ((FindAndCopy)list[i]).IN);
                    }
                }
                sw.WriteLine(new string('=', 29));
            }
        }

        private bool ErrorСhecking(string catFind, string catRemove)
        {
            bool Error = false;
            if (catFind == "")
            {
                MessageBox.Show("Введите каталог для поиска.");
                Error = true;
            }
            if (catRemove == "")
            {
                MessageBox.Show($"Введите каталог для {DopLblName}.");
                Error = true;
            }
            if (!Directory.Exists(catFind))
            {
                MessageBox.Show("Каталог для поиска не найден");
                Error = true;
            }
            if (!Directory.Exists(catRemove))
            {
                MessageBox.Show($"Каталог для {DopLblName} не найден");
                Error = true;
            }
            return Error;
        }
        #endregion

        #region Ctor
        public MainVM()
        {
            dialogService = new DefaultDialogService();
            _execBtnName = "Переместить";
            _dopLblName = "перемещения";
            _currentMode = Mods.Move;
            _selectFolderToFind = "";
            _selectFolderToMoveCopy = "";
            _coutnIter = 1;
            _currPos = 0;
        }
        #endregion
    }
}

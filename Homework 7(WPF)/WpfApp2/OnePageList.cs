using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    /// <summary>
    /// класс описывает одну строку планировщика
    /// </summary>
    class OnePageList : INotifyPropertyChanged
    {
        #region конструктор
        public OnePageList(DateTime CreationDate, bool IsDone, string Todo, DateTime Deadline, string Description)
        {
            this.CreationDate = CreationDate;
            this.IsDone = IsDone;
            this.Todo = Todo;
            this.Deadline = Deadline;
            this.Description = Description;
        }
        #endregion

        #region поля
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; } = DateTime.Now;

        private bool _isDone;
        private string _text;
        private string _description;
        #endregion

        #region свойства
        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                if (_isDone == value) return;

                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        public string Todo
        {
            get { return _text; }
            set
            {
                if (_text == value) return;

                _text = value;
                OnPropertyChanged("Todo");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value) return;

                _description = value;
            }
        }
        #endregion

        //событие
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

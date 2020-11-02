using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class OnePageList
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime Deadline { get; set; } = DateTime.Now;

        private bool _isDone;
        private string _text;
        private string _description;

        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                if (_isDone == value) return;

                _isDone = value;
            }
        }

        public string Todo
        {
            get { return _text; }
            set
            {
                if (_text == value) return;

                _text = value;
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
    }
}

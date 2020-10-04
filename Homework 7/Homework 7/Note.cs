using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_7
{
    struct Note
    {

        #region конструкторы
        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="title">короткое название</param>
        /// <param name="fullDescription">полное описание</param>
        /// <param name="comment">комментарий</param>
        /// <param name="TimeCreateNote">время создания заметки</param>
        /// <param name="DateTimeEvent">время события</param>
        public Note(int noteNumber, string fullDescription, string comment, DateTime TimeCreateNote, DateTime DateTimeEvent)
        {
            this.noteNumber = noteNumber;
            this.fullDescription = fullDescription;
            this.comment = comment;
            this.TimeCreateNote = TimeCreateNote;
            this.DateTimeEvent = DateTimeEvent;
        }
        #endregion

        #region методы
        public string Print()
        {
            return $"{this.noteNumber,15} {this.fullDescription,15} {this.comment,15} {this.TimeCreateNote} {this.DateTimeEvent}";
        }
        
        public string[] arrNote()
        {
            string[] arrNote = {Convert.ToString(this.noteNumber), this.fullDescription, this.comment, Convert.ToString(this.TimeCreateNote), Convert.ToString(this.DateTimeEvent)};
            return arrNote;
        }
        #endregion

        #region Поля
        /// <summary>
        /// Поле заголовка события
        /// </summary>
        private int noteNumber;

        /// <summary>
        /// Поле полного описания
        /// </summary>
        private string fullDescription;

        /// <summary>
        /// Поле комментарий
        /// </summary>
        private string comment;

        /// <summary>
        /// Поле дата создания записки
        /// </summary>
        private DateTime TimeCreateNote;

        /// <summary>
        /// Поле дата события
        /// </summary>
        private DateTime DateTimeEvent;
        #endregion
    }
}

using Common.Command.NotifyPropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Students : NotifyPropertyChanged
    {
        #region ------------------------- Fields, Constants, Delegates, Events --------------------------------------------
        /// <summary> Firstname of the students</summary>
        private string firstname;
        /// <summary> Lastname of the students</summary>
        private string lastname;
        #endregion

        #region ------------------------- Constructors, Destructors, Dispose, Clone ---------------------------------------
        /// <summary>
        /// Initiaalizes a new instance of the <see cref="Students"/> class.
        /// </summary>
        /// <param name="firstname">Firstnaame of the student.</param>
        /// <param name="lastname">Lastnme of the studdent.</param>
        public Students(string firstname, string lastname)
        {
            // set vaalues
            this.Firstname = firstname;
            this.Lastname = lastname;
        }
        #endregion

        #region ------------------------- Properties, Indexers ------------------------------------------------------------
        /// <summary> Gets or sets the firstname of the students. </summary>
        public string Firstname
        {
            get
            {
                return this.firstname;
            }

            set
            {
                if(this.firstname != value)
                {
                    this.firstname = value;
                    this.OnPropertyChanged(nameof(Firstname));
                    this.OnPropertyChanged(nameof(Fullname));
                    this.StudentDataChanged = true;
                }
            }
        }

        /// <summary> Gets or sets the lastname of the students. </summary>
        public string Lastname
        {
            get
            {
                return this.lastname;
            }

            set
            {
                if (this.lastname != value)
                {
                    this.lastname = value;
                    this.OnPropertyChanged(nameof(Lastname));
                    this.OnPropertyChanged(nameof(Fullname));
                    this.StudentDataChanged = true;
                }
            }
        }
        /// <summary> Gets the fullnamae of the student. </summary>
        public string Fullname
        {
            get
            {
                return this.firstname + " " + this.lastname;
            }
        }

        public bool StudentDataChanged { get; private set; }

        public void StudentDataSaved()
        {
            this.StudentDataChanged = false;
        }

        public override string ToString()
        {
            return Fullname;
        }
        #endregion
    }
}

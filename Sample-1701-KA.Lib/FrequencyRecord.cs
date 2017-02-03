using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_1701_KA
{
    public class FrequncyRecord : INotifyPropertyChanged
    {
        private string _word;
        private int _count;
        public FrequncyRecord()
            : this(null, 0)
        {
        }
        public FrequncyRecord(string word, int cnt)
        {
            Word = word;
            Count = cnt;
        }
        public virtual string Word
        {
            get { return _word ?? String.Empty; }
            protected set
            {
                if (Word != value)
                {
                    _word = value;
                    RaisePropertyChanged(nameof(Word));
                }
            }
        }
        public virtual int Count
        {
            get { return _count < 0 ? 0 : _count; }
            protected set
            {
                if (Count != value)
                {
                    _count = value < 0 ? 0 : value;
                    RaisePropertyChanged(nameof(Count));
                }
            }
        }

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion

    }

}

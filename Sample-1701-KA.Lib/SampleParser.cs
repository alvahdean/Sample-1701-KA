using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sample_1701_KA
{
    public class SampleParser : INotifyPropertyChanged
    {
        #region Static fields
        private static Regex _wsRemover = new Regex(@"\s\s+", RegexOptions.Compiled);
        private static Regex _punctRemover = new Regex(@"\p{P}+", RegexOptions.Compiled);
        private static object _lockObj=new object();
        #endregion
        #region Private fields
        private string _normal;
        private string _inputRaw;
        private string _lastError;
        private List<string> _words;
        private ObservableCollection<FrequncyRecord> _wordCounts;
        #endregion

        #region Class init
        public SampleParser()
        {
        }
        #endregion

        #region Public properties
        #region User read/write properties
        public virtual string Input
        {
            get { return _inputRaw; }
            set
            {
                if (Input != value)
                {
                    lock (_lockObj)
                    {
                        _inputRaw = value;
                        RaisePropertyChanged(nameof(Input));
                        Update(Input);
                    }
                }
            }
        }
        #endregion

        #region Calculated properties
        public virtual int Count
        {
            get { return Words.Count(); }
        }
        public virtual int UniqueCount
        {
            get { return UniqueWords.Count(); }
        }
        public virtual IEnumerable<string> UniqueWords
        {
            get { return Words.Distinct(); }
        }
        public virtual IOrderedEnumerable<string> WordsAlpha
        {
            get { return UniqueWords.OrderBy(t => t); }
        }
        #endregion

        #region Internal written properties
        public virtual ObservableCollection<FrequncyRecord> WordFrequency
        {
            get { return _wordCounts ?? (_wordCounts = new ObservableCollection<FrequncyRecord>()); }
            protected set
            {
                if (WordFrequency != value)
                {
                    WordFrequency.Clear();
                    if (value != null)
                        _wordCounts = new ObservableCollection<FrequncyRecord>(value);
                    RaisePropertyChanged(nameof(WordFrequency));
                }
            }
        }
        public virtual string Normalized
        {
            get { return _normal ?? String.Empty; }
            protected set
            {
                if (Normalized != value)
                {
                    _normal = value;
                    RaisePropertyChanged(nameof(Normalized));
                }
            }
        }
        public virtual List<string> Words
        {
            get { return _words ?? (_words = new List<string>()); }
            protected set
            {
                if (Words != value)
                {
                    _words.Clear();
                    _words.AddRange(value);
                    RaisePropertyChanged(nameof(Words));
                    RaisePropertyChanged(nameof(UniqueWords));
                    RaisePropertyChanged(nameof(WordsAlpha));
                    RaisePropertyChanged(nameof(Count));
                    RaisePropertyChanged(nameof(UniqueCount));
                }
            }
        }
        public virtual string LastError
        {
            get { return _lastError ?? (_lastError = String.Empty); }
            protected set
            {
                if (LastError != value)
                {
                    _lastError = value?.Trim() ?? String.Empty;
                    RaisePropertyChanged(nameof(LastError));
                }
            }
        }
        #endregion
        #endregion

        #region Private methods
        #endregion

        #region Protected methods
        protected virtual void ClearResults()
        {
            LastError = string.Empty;
            Normalized = null;
            Words.Clear();
            WordFrequency.Clear();
        }
        protected virtual bool Update(string raw)
        {
            try
            {
                ClearResults();
                Normalized = Normalize(raw);
                Words = GetAllWords(raw).ToList();
                WordFrequency = new ObservableCollection<FrequncyRecord>(GetWordFrequency(raw));
            }
            catch(Exception e)
            {
                LastError = $"EXCEPTION: {e.Message}";
            }
            return LastError==String.Empty;
        }
        protected virtual string Normalize(string raw)
        {
            string result = (raw ?? String.Empty).Trim().ToLower();
            result = _punctRemover.Replace(result, "");
            result = _wsRemover.Replace(result, " ");
            return result;
        }


        protected virtual string[] GetAllWords(string input)
        {
            return Normalize(input).Split(' ');
        }
        protected virtual IEnumerable<string> GetUniqueWords(string input)
        {
            return GetAllWords(input).Distinct();
        }
        protected virtual IEnumerable<FrequncyRecord> GetWordFrequency(string input)
        {
            List<FrequncyRecord> result = new List<FrequncyRecord>();
            string[] allWords = GetAllWords(input);
            string[] unqWords = GetUniqueWords(input).ToArray();
            foreach (string w in unqWords)
            {
                FrequncyRecord rec=new FrequncyRecord(w,allWords.Count(t => t == w));
                result.Add(rec);
            }
            return result;
        }
        #endregion

        #region Public methods

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        #endregion


    }
}

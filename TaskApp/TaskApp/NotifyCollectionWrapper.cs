using System;
using System.Collections;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace TaskApp
{
    public class NotifyCollectionWrapper
    {
        #region Constructor

        public NotifyCollectionWrapper(object source, Action<IList, int> add = null, Action<IList, int> remove = null,
                                       Action reset = null, Action finished = null, Action begin = null)
        {
            if (source is INotifyCollectionChanged)
            {
                var collection = (INotifyCollectionChanged)source;
                collection.CollectionChanged -= Collection_CollectionChanged;
                collection.CollectionChanged += Collection_CollectionChanged;

                Add = add;
                Remove = remove;
                Reset = reset;
                Finished = finished;
            }

            if (begin != null)
            {
                begin.Invoke();
            }

            if (reset != null)
            {
                reset.Invoke();
            }

            if (finished != null)
            {
                finished.Invoke();
            }
        }

        #endregion

        #region Properties

        public Action<IList, int> Add { get; }

        public Action Begin { get; }
        public Action Finished { get; }
        public Action<IList, int> Remove { get; }
        public Action Reset { get; }

        #endregion

        #region Methods

        private void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Begin != null)
            {
                Begin.Invoke();
            }

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (Add != null)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Add.Invoke(e.NewItems, e.NewStartingIndex);
                        });
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (Remove != null)
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Remove.Invoke(e.OldItems, e.OldStartingIndex);
                        });
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    if (Reset != null)
                    {
                        Reset.Invoke();
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
            }

            if (Finished != null)
            {
                Finished.Invoke();
            }
        }

        #endregion
    }
}

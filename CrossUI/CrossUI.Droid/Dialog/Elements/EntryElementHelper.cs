#region Copyright

// <copyright file="EntryElementHelper.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
//  
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using Android.Text;
using Android.Widget;

namespace CrossUI.Droid.Dialog.Elements
{
    public class EntryElementHelper : Java.Lang.Object, ITextWatcher
    {
        public static EntryElementHelper EnsureTagged(EditText editText)
        {
            var tag = (EntryElementHelper) editText.Tag;
            if (tag == null)
            {
                tag = new EntryElementHelper(editText);
                editText.Tag = tag;
            }
            return tag;
        }

        private EntryElementHelper(EditText entry)
        {
            entry.AddTextChangedListener(this);
            entry.EditorAction += EntryOnEditorAction;
        }

        public const int TagId = 24061972;

        public interface IEntryElementOwner
        {
            void OnTextChanged(string newText);
            void OnEditorAction(TextView.EditorActionEventArgs e);
        }

        public IEntryElementOwner Owner { get; set; }

        private void EntryOnEditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            if (Owner != null)
                Owner.OnEditorAction(e);
        }

        #region TextWatcher Android

        public void OnTextChanged(Java.Lang.ICharSequence s, int start, int before, int count)
        {
            if (Owner != null)
                Owner.OnTextChanged(s.ToString());
        }

        public void AfterTextChanged(IEditable s)
        {
            // nothing needed
        }

        public void BeforeTextChanged(Java.Lang.ICharSequence s, int start, int count, int after)
        {
            // nothing needed
        }

        #endregion
    }
}
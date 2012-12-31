﻿#region Copyright

// <copyright file="HtmlElement.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
//  
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using Android.Content;
using Android.Net;
using Android.Views;

namespace CrossUI.Droid.Dialog.Elements
{
#warning Not touched this class... need more explanation...

    public class HtmlElement : StringElement
    {
        // public string Value;

        public HtmlElement(string caption, string url)
            : base(caption, url, "dialog_labelfieldright")
        {
            Url = Uri.Parse(url);
        }

        public HtmlElement(string caption, Uri uri)
            : base(caption, uri.ToString(), "dialog_labelfieldright")
        {
            Url = uri;
        }

        public Uri Url { get; set; }

        private void OpenUrl(Context context)
        {
            var intent = new Intent(context, typeof (HtmlActivity));
            intent.PutExtra("URL", Url.ToString());
            intent.PutExtra("Title", Caption);
            intent.AddFlags(ActivityFlags.NewTask);
            context.StartActivity(intent);
        }

        protected override View GetViewImpl(Context context, View convertView, ViewGroup parent)
        {
            var view = base.GetViewImpl(context, convertView, parent);
            Click = (o, e) => OpenUrl(context);
            return view;
        }
    }
}
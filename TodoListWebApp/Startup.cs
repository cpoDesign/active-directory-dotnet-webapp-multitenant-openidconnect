﻿/************************************************************************************************
The MIT License (MIT)

Copyright (c) 2015 Microsoft Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
***********************************************************************************************/


using System;
using System.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TodoListWebApp.Startup))]

namespace TodoListWebApp
{
    public partial class Startup
    {
        public static string ClientId = ConfigurationManager.AppSettings["ida:ClientId"];
        public static string AppKey = ConfigurationManager.AppSettings["ida:ClientSecret"];
        public static string GraphResourceId = ConfigurationManager.AppSettings["ida:GraphAPIEndpoint"];
        public static string RedirectUri = ConfigurationManager.AppSettings["ida:RedirectUri"];

        public static string AadInstance = EnsureTrailingSlash(ConfigurationManager.AppSettings["ida:AADInstance"]);

        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }

        private static string EnsureTrailingSlash(string value)
        {
            if (value == null)
                value = string.Empty;

            if (!value.EndsWith("/", StringComparison.Ordinal))
                return value + "/";

            return value;
        }
    }
}
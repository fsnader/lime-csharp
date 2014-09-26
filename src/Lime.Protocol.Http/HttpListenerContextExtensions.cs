﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lime.Protocol.Http
{
    public static class HttpListenerContextExtensions
    {
        /// <summary>
        /// Extracts an variable value
        /// from the header or the query string.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="headerKey"></param>
        /// <param name="queryStringKey"></param>
        /// <returns></returns>
        public static string GetValue(this HttpListenerRequest request, string headerKey, string queryStringKey)
        {
            return request.Headers.Get(headerKey) ?? request.QueryString.Get(queryStringKey);
        }

        /// <summary>
        /// Gets the root path from a HTTP Listener request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetRootPath(this Uri uri)
        {
            var segments = uri.Segments;

            if (segments.Length > 1)
            {
                return uri.Segments[1].TrimEnd('/').ToLowerInvariant();
            }
            else
            {
                return "/";
            }            
        }
    }
}
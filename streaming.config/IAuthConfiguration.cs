using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace streaming.Config
{
    public interface IAuthConfiguration
    {
        /// <summary>
        /// Secret key for generating tokens.
        /// </summary>
        string TokenKey { get; }
        string Issuer { get; }
        string Audience { get; }
        /// <summary>
        /// How long token is valid, in minutes.
        /// </summary>
        int TokenValidInMinutes { get; }
    }
}
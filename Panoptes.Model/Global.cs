﻿using System;
using System.Diagnostics;

namespace Panoptes.Model
{
    public static class Global
    {
        public const string AppName = "Panoptes";

        public static string MachineName => Environment.MachineName;

        public static string OSVersion => Environment.OSVersion.VersionString;

        private static string _appVersion;
        public static string AppVersion
        {
            get
            {
                if (string.IsNullOrEmpty(_appVersion))
                {
                    _appVersion = GetVersion();
                }
                return _appVersion;
            }
        }

        private static string GetVersion()
        {
            try
            {
                // https://docs.microsoft.com/en-us/dotnet/core/deploying/single-file
                var fvi = FileVersionInfo.GetVersionInfo(Environment.ProcessPath);
#pragma warning disable CS8603 // Possible null reference return.
                if (fvi != null)
                {
                    if (fvi.FileVersion == fvi.ProductVersion)
                    {
                        return fvi.FileVersion;
                    }
                    else
                    {
                        return $"{fvi.FileVersion} ({fvi.ProductVersion})";
                    }
                }
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (System.Exception e)
            {
                return $"ERROR in version: {e.Message}";
            }
        }
    }
}

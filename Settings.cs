﻿using CommandLine;
using CommandLine.Text;
using System.Configuration;

namespace CouchDBAssembler
{
    sealed class Settings : ApplicationSettingsBase
    {
        static Settings defaultInstance = ApplicationSettingsBase.Synchronized(new Settings()) as Settings;

        public static Settings Default
        {
            get { return defaultInstance; }
        }

        [ValueOption(0)]
        [UserScopedSetting]
        [DefaultSettingValue(".")]
        public string SourceDir
        {
            get { return (string)this["SourceDir"]; }
            set { this["SourceDir"] = value; }
        }

        [ValueOption(1)]
        [UserScopedSetting]
        [DefaultSettingValue("")]
        [SpecialSetting(SpecialSetting.WebServiceUrl)]
        public string DatabaseUrl
        {
            get { return (string)this["DatabaseUrl"]; }
            set { this["DatabaseUrl"] = value; }
        }

        [Option('u', "username", HelpText = "Database username.")]
        [UserScopedSetting]
        [DefaultSettingValue("")]
        public string Username
        {
            get { return (string)this["Username"]; }
            set { this["Username"] = value; }
        }

        [Option('p', "password", HelpText = "Database password.")]
        [UserScopedSetting]
        [DefaultSettingValue("")]
        public string Password
        {
            get { return (string)this["Password"]; }
            set { this["Password"] = value; }
        }

        [HelpOption('h', "help")]
        public string GetUsage()
        {
            var help = new HelpText { AdditionalNewLineAfterOption = true, AddDashesToOption = true };
            help.AddPreOptionsLine("Usage: CouchDBAssembler [source-dir] [database-url]");
            help.AddPreOptionsLine("");
            help.AddPreOptionsLine("  [source-dir]      The directory from which to assemble design documents.");
            help.AddPreOptionsLine("");
            help.AddPreOptionsLine("  [database-url]    The url of the CouchDB database to update.");
            help.AddOptions(this);
            return help;
        }
    }
}
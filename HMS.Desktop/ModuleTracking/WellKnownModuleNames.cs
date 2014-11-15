// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace ModuleTracking
{
    /// <summary>
    /// A set of well-known module names for communication with IModuleTracker.
    /// </summary>
    public static class WellKnownModuleNames
    {
        /// <summary>
        /// The name of helpDeskModule.
        /// </summary>
        public const string HelpdeskModule="HelpdeskModule";
        public const string PatientInfoModule = "PatientInfoModule";
        public static List<string> HelpdeskModuleList = new List<string>();
        public static List<string> PatientInfoModuleList = new List<string>();

        public static void Load()
        {
            HelpdeskModuleList.Add("HelpdeskModule");
            HelpdeskModuleList.Add("PatientInfoModule");

            PatientInfoModuleList.Add("PatientInfoModule");

        }
    }
}
﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using CommandLine;
using Microsoft.Azure.Pipelines.CoveragePublisher.Model;

namespace Microsoft.Azure.Pipelines.CoveragePublisher
{
    internal class ArgumentsProcessor
    {
        public class Options : PublisherConfiguration
        {
            [Value(0, Required = true, HelpText = "Set of coverage files to be published.")]
            override public IEnumerable<string> CoverageFiles { get; set; }

            [Option("reportDirectory", Default = "", HelpText = "Path to report directory.")]
            override public string ReportDirectory { get; set; }

            [Option("sourceDirectory", Default = "", HelpText = "List of source directories separated by ';'.")]
            override public string SourceDirectories { get; set; }
        }


        public PublisherConfiguration ProcessCommandLineArgs(string[] args)
        {
            PublisherConfiguration cliArgs = null;

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opts => {
                    cliArgs = opts;
                });

            return cliArgs;
        }
    }
}
﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Management.Automation;

using Microsoft.Azure.Commands.Tags.Model;

using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch.Applications
{
    [Cmdlet(VerbsCommon.Add, Constants.AzureRmBatchApplicationPackage), OutputType(typeof(PSApplicationPackage))]
    public class UploadBatchApplicationCommand : BatchCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ApplicationId { get; set; }

        [Parameter(Position = 4, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ApplicationVersion { get; set; }

        [Parameter(Position = 5, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        public override void ExecuteCmdlet()
        {
            PSApplicationPackage response = BatchClient.UploadApplicationPackage(ResourceGroupName, AccountName, ApplicationId, ApplicationVersion, FilePath);
            WriteObject(response);
        }
    }
}

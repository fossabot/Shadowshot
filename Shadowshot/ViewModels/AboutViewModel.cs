// Copyright 2017-2018 Kagami Studio
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Reactive;
using System.Reflection;
using ReactiveUI;
using Shadowshot.Properties;

namespace Shadowshot.ViewModels
{
    internal class AboutViewModel : ReactiveObject
    {
        internal AboutViewModel()
        {
            var assembly = Assembly.GetEntryAssembly();
            var name = assembly.GetName();
            Version = string.Format(Strings.VersionFormat, name.Version.ToString(3));

            OkCommand = ReactiveCommand.Create(() => RequestClose?.Invoke());
        }

        public string Version { get; }

        public ReactiveCommand<Unit, Unit> OkCommand { get; }

        internal event Action RequestClose;
    }
}

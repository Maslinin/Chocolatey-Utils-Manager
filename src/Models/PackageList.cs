﻿using System.Collections.Generic;

namespace ChocolateyUtilsManager.Models
{
    internal sealed class PackageList
    {
        public string Category { get; set; }
        public IEnumerable<PackageInfo> Packages { get; set; }

        public override string ToString() => this.Category;
    }
}
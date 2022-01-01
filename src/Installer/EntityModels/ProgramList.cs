using System.Collections.Generic;

namespace CUM.Installer.EntityModels
{
    sealed class ProgramList
    {
        public string Category { get; set; }
        public List<ProgramInfo> Programs { get; set; } = new List<ProgramInfo>();

        public ProgramList(string Category, List<ProgramInfo> Programs)
        {
            this.Category = Category;
            this.Programs = new List<ProgramInfo>();
            this.Programs.AddRange(Programs);
        }
    }
}